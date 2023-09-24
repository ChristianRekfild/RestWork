using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebClient.Helpers;

namespace WebClient
{
    static class Program
    {
        static HttpClient client = new HttpClient();


        static Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите режим работы.");
                Console.WriteLine("\t1 - получение Customer с сервера по id");
                Console.WriteLine("\t2 - добавление нового Customer с случайными параметрами. (Мне повезёт!)");

                try
                {
                    int a = int.Parse(Console.ReadLine());
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine("Введите id для получения Cutomer с сервера");
                            int id = int.Parse(Console.ReadLine());
                            CustomerCreateRequest cust = GetCustomerById(id);
                            Console.WriteLine($"Firstname = {cust.Firstname}, Lastname = {cust.Lastname}");
                            break;
                        case 2:
                            CustomerCreateRequest customer = RandomCustomer();
                            Console.WriteLine($"Firstname = {customer.Firstname}, Lastname = {customer.Lastname}");
                            break;

                    }
                } catch (Exception e)
                {
                    Console.WriteLine("Товаришь! Нам тут говорят вы что-то нехорошее и  неправильное с программой творите!");
                    Console.WriteLine($"Вот текст жалобы на вас: {e.ToString()}");
                }
                

            }
        }

        private static CustomerCreateRequest RandomCustomer()
        {
            Customer newCstomer = CustomerHelper.CreateRandCustomerWithoutCreating();

            HttpResponseMessage response = client.PostAsJsonAsync(
                "http://localhost:5000/customers/", newCstomer).Result;

            // Получили id последнего клиента, которого мы создали
            var cont = response.Content.ReadAsStringAsync().Result;

            var CustomerCreateRequest = GetCustomerById(int.Parse(cont));

            return CustomerCreateRequest;
        }

        private static CustomerCreateRequest GetCustomerById(int id)
        {
            HttpResponseMessage response = client.GetAsync(
                $"http://localhost:5000/customers/{id}").Result;

            Customer customer = response.Content.ReadFromJsonAsync<Customer>().Result;

            return new CustomerCreateRequest
            {
                Firstname = customer.Firstname,
                Lastname = customer.Lastname
            };
        }
    }
}