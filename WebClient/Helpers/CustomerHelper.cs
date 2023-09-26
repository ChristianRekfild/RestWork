﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace WebClient.Helpers
{
    public static class CustomerHelper
    {
        public static Customer CreateRandCustomerWithoutCreating()
        {
            Random rand = new Random();

            int randomId = rand.Next(1, int.MaxValue);
            var customer = new Customer()
            {
                Id = randomId,
                Firstname = GetNewCustomerFirstName(),
                Lastname = GetNewCustomerLastName()
            };

            return customer;
        }

        private static string GetNewCustomerFirstName()
        {
            List<string> Names = new List<string>()
            {
                "Август","Августин","Авраам","Аврора","Агата","Агафон","Агнесса","Агния",

                "Ада","Аделаида","Аделина","Адонис","Акайо","Акулина","Алан","Алевтина","Александр","Александра","Алексей","Алена","Алина","Алиса","Алла","Алсу","Альберт","Альбина","Альфия",
                "Альфред","Амалия","Амелия",
                "Анастасий","Анастасия","Анатолий","Ангелина","Андрей","Анжела","Анжелика","Анисий","Анна","Антон","Антонина","Анфиса",
                "Аполлинарий","Аполлон","Ариадна","Арина","Аристарх","Аркадий","Арсен","Арсений","Артем","Артемий","Артур","Архип","Ася",
                "Беатрис", "Белла", "Бенедикт", "Берта", "Богдан", "Божена", "Болеслав", "Борис", "Борислав", "Бронислав", "Бронислава", "Булат",
                "Вадим", "Валентин", "Валентина", "Валерий", "Валерия", "Ванда", "Варвара", "Василий", "Василиса", "Венера", "Вениамин", "Вера", "Вероника", "Викентий", "Виктор", "Виктория", "Вилен", "Виолетта", "Виссарион", "Вита", "Виталий", "Влад", "Владимир", "Владислав", "Владислава", "Владлен", "Вольдемар", "Всеволод", "Вячеслав",
                "Габриэлла", "Гавриил", "Галина", "Гарри", "Гелла", "Геннадий", "Генриетта", "Георгий", "Герман", "Гертруда", "Глафира", "Глеб", "Глория", "Гордей", "Грейс", "Грета", "Григорий", "Гульмира",
                "Давид", "Дана", "Даниил", "Даниэла", "Дарина", "Дарья", "Даяна", "Демьян", "Денис", "Джеймс", "Джек", "Джессика", "Джозеф", "Диана", "Дина", "Динара", "Дмитрий", "Добрыня", "Доминика", "Дора",
                "Ева", "Евгений", "Евгения", "Евдоким", "Евдокия", "Егор", "Екатерина", "Елена", "Елизавета", "Елисей", "Есения", "Ефим", "Ефрем", "Ефросинья",
                "Захар", "Зинаида", "Зиновий", "Злата", "Зорий", "Зоряна", "Зоя",
                "Иван", "Иветта", "Игнатий", "Игорь", "Изабелла", "Изольда", "Илга", "Илларион", "Илона", "Илья", "Инга", "Инесса", "Инна", "Иннокентий", "Иосиф", "Ираида", "Ираклий", "Ирина", "Итан", "Ия",
                "Магдалина", "Майя", "Макар", "Максим", "Марат", "Маргарита", "Марианна", "Марина", "Мария", "Марк", "Марта", "Мартин", "Марфа", "Матвей", "Мелания", "Мелисса", "Милана", "Милена", "Мирон", "Мирослава", "Мирра", "Митрофан", "Михаил", "Мия", "Модест", "Моисей", "Мухаммед",
                "Лада", "Лариса", "Лев", "Леон", "Леонид", "Леонтий", "Леся", "Лидия", "Лика", "Лилиана", "Лилия", "Лина", "Лолита", "Луиза", "Лукьян", "Любовь", "Людмила",
                "Надежда", "Назар", "Наоми", "Наталия", "Наталья", "Наум", "Нелли", "Ника", "Никанор", "Никита", "Никифор", "Николай", "Николь", "Никон", "Нина", "Нинель", "Нонна", "Нора",
                "Оксана", "Олег", "Олеся", "Оливер", "Оливия", "Ольга", "Оскар",
                "Рада", "Радмила", "Раиса", "Райан", "Раймонд", "Раяна", "Регина", "Ренат", "Рената", "Рику", "Римма", "Ринат", "Рита", "Роберт", "Родион", "Роза", "Роксана", "Роман", "Россияна", "Ростислав", "Руслан", "Рустам", "Рэн",
                "Ульяна", "Урсула",
                "Фаддей", "Фаина", "Федор", "Федот", "Феликс", "Филат", "Филимон", "Филипп", "Фома", "Фрида",
                "Шарлотта", "Шейла", "Шелли",
                "Эдгар", "Эдита", "Эдуард", "Элеонора", "Элина", "Элла", "Эльвира", "Эльдар", "Эльза", "Эмили", "Эмилия", "Эмма", "Эрик", "Эрика",
                "Юи", "Юлиан", "Юлиана", "Юлий", "Юлия", "Юма", "Юна", "Юрий",
                "Яков", "Ямато", "Ян", "Яна", "Янина", "Ярослав"
            };

            Random r = new Random();
            int nameIndex = r.Next(0, Names.Count - 1);

            return Names[nameIndex];
        }

        private static string GetNewCustomerLastName()
        {
            List<string> LastNames = new List<string>()
            {
            "Смирнов",
            "Иванов",
            "Кузнецов",
            "Соколов",
            "Попов",
            "Лебедев",
            "Козлов",
            "Новиков",
            "Морозов",
            "Петров",
            "Волков",
            "Соловьёв",
            "Васильев",
            "Зайцев",
            "Павлов",
            "Семёнов",
            "Голубев",
            "Виноградов",
            "Богданов",
            "Воробьёв",
            "Фёдоров",
            "Михайлов",
            "Беляев",
            "Тарасов",
            "Белов",
            "Комаров",
            "Орлов",
            "Киселёв",
            "Макаров",
            "Андреев",
            "Ковалёв",
            "Ильин",
            "Гусев",
            "Титов",
            "Кузьмин",
            "Кудрявцев",
            "Баранов",
            "Куликов",
            "Алексеев",
            "Степанов",
            "Яковлев",
            "Сорокин",
            "Сергеев",
            "Романов",
            "Захаров",
            "Борисов",
            "Королёв",
            "Герасимов",
            "Пономарёв",
            "Григорьев",
            "Лазарев",
            "Медведев",
            "Ершов",
            "Никитин",
            "Соболев",
            "Рябов",
            "Поляков",
            "Цветков",
            "Данилов",
            "Жуков",
            "Фролов",
            "Журавлёв",
            "Николаев",
            "Крылов",
            "Максимов",
            "Сидоров",
            "Осипов",
            "Белоусов",
            "Федотов",
            "Дорофеев",
            "Егоров",
            "Матвеев",
            "Бобров",
            "Дмитриев",
            "Калинин",
            "Анисимов",
            "Петухов",
            "Антонов",
            "Тимофеев",
            "Никифоров",
            "Веселов",
            "Филиппов",
            "Марков",
            "Большаков",
            "Суханов",
            "Миронов",
            "Ширяев",
            "Александров",
            "Коновалов",
            "Шестаков",
            "Казаков",
            "Ефимов",
            "Денисов",
            "Громов",
            "Фомин",
            "Давыдов",
            "Мельников",
            "Щербаков",
            "Блинов",
            "Колесников",
            "Карпов",
            "Афанасьев",
            "Власов",
            "Маслов",
            "Исаков",
            "Тихонов",
            "Аксёнов",
            "Гаврилов",
            "Родионов",
            "Котов",
            "Горбунов",
            "Кудряшов",
            "Быков",
            "Зуев",
            "Третьяков",
            "Савельев",
            "Панов",
            "Рыбаков",
            "Суворов",
            "Абрамов",
            "Воронов",
            "Мухин",
            "Архипов",
            "Трофимов",
            "Мартынов",
            "Емельянов",
            "Горшков",
            "Чернов",
            "Овчинников",
            "Селезнёв",
            "Панфилов",
            "Копылов",
            "Михеев",
            "Галкин",
            "Назаров",
            "Лобанов",
            "Лукин",
            "Беляков",
            "Потапов",
            "Некрасов",
            "Хохлов",
            "Жданов",
            "Наумов",
            "Шилов",
            "Воронцов",
            "Ермаков",
            "Дроздов",
            "Игнатьев",
            "Савин",
            "Логинов",
            "Сафонов",
            "Капустин",
            "Кириллов",
            "Моисеев",
            "Елисеев",
            "Кошелев",
            "Костин",
            "Горбачёв",
            "Орехов",
            "Ефремов",
            "Исаев",
            "Евдокимов",
            "Калашников",
            "Кабанов",
            "Носков",
            "Юдин",
            "Кулагин",
            "Лапин",
            "Прохоров",
            "Нестеров",
            "Харитонов",
            "Агафонов",
            "Муравьёв",
            "Ларионов",
            "Федосеев",
            "Зимин",
            "Пахомов",
            "Шубин",
            "Игнатов",
            "Филатов",
            "Крюков",
            "Рогов",
            "Кулаков",
            "Терентьев",
            "Молчанов",
            "Владимиров",
            "Артемьев",
            "Гурьев",
            "Зиновьев",
            "Гришин",
            "Кононов",
            "Дементьев",
            "Ситников",
            "Симонов",
            "Мишин",
            "Фадеев",
            "Комиссаров",
            "Мамонтов",
            "Носов",
            "Гуляев",
            "Шаров",
            "Устинов",
            "Вишняков",
            "Евсеев",
            "Лаврентьев",
            "Брагин",
            "Константинов",
            "Корнилов",
            "Авдеев",
            "Зыков",
            "Бирюков",
            "Шарапов",
            "Никонов",
            "Щукин",
            "Дьячков",
            "Одинцов",
            "Сазонов",
            "Якушев",
            "Красильников",
            "Гордеев",
            "Самойлов",
            "Князев",
            "Беспалов",
            "Уваров",
            "Шашков",
            "Бобылёв",
            "Доронин",
            "Белозёров",
            "Рожков",
            "Самсонов",
            "Мясников",
            "Лихачёв",
            "Буров",
            "Сысоев",
            "Фомичёв",
            "Русаков",
            "Стрелков",
            "Гущин",
            "Тетерин",
            "Колобов",
            "Субботин",
            "Фокин",
            "Блохин",
            "Селиверстов",
            "Пестов",
            "Кондратьев",
            "Силин",
            "Меркушев",
            "Лыткин",
            "Туров"
            };

            Random r = new Random();
            int nameIndex = r.Next(0, LastNames.Count - 1);

            return LastNames[nameIndex];
        }
    }
}
