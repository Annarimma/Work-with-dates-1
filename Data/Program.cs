using System;

namespace Data
{
    class Program
    {

        // ввод с клавиатуры Read;
        static Date Read(Date UIntData)
        {

            Console.WriteLine("Введите год: ");
            uint year = Convert.ToUInt32(Console.ReadLine());
            while (year > 3000)
            {
                Console.WriteLine("Глобальные планы! Но давайте посчитаем их до 3000 года.");
                year = Convert.ToUInt32(Console.ReadLine());
            }


            Console.WriteLine("Введите месяц: ");
            uint month = Convert.ToUInt32(Console.ReadLine());
            while (month > 13)
            {
                Console.WriteLine("Давайте попробуем заново. Введите месяц.");
                month = Convert.ToUInt32(Console.ReadLine());
            }


            Console.WriteLine("Введите день: ");
            uint day = Convert.ToUInt32(Console.ReadLine());

            while (day > 32)
            {
                Console.WriteLine("Давайте попробуем заново. Введите день.");
                day = Convert.ToUInt32(Console.ReadLine());
            }

            while (day>=29 & !Year366(year))
            {
                Console.WriteLine("Февраль в указанном году имеет 28 дней. Введите день заново.");
                day = Convert.ToUInt32(Console.ReadLine());
            }

            UIntData.ymd.year = year;
            UIntData.ymd.month = month;
            UIntData.ymd.day = day;

            return UIntData;

        }

        //вывод на эран Display;
        static void Display(Date UIntData)
        {
            Console.WriteLine("Ваша введенная дата: " + toString(UIntData));
        }

        //определение високосности года
        //год является високосным в двух случаях: либо он кратен 4, но при этом не кратен 100, либо кратен 400.
        static bool Year366(uint year)                                   
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        //вычисление количества дней между датами
        static void DaysBtwDatas(Date UIntData)
        {
            Display(UIntData);

            DateTime d1 = new DateTime(Convert.ToInt32(UIntData.ymd.year), Convert.ToInt32(UIntData.ymd.month), Convert.ToInt32(UIntData.ymd.day));
            Console.WriteLine("Введите вторую дату для вычисления интервала: ");
            uint year=1, month=1, day=1;
            Date SecondData = new Date();
            SecondData.Init(year,month, day);
            SecondData = Read(SecondData);

            Display(SecondData);

            DateTime d2 = new DateTime(Convert.ToInt32(SecondData.ymd.year), Convert.ToInt32(SecondData.ymd.month), Convert.ToInt32(SecondData.ymd.day));
            TimeSpan interval = d2 - d1;
            Console.WriteLine("Выявленная разность дней: " + interval);
            Console.WriteLine("{0} - {1} = {2}", d2, d1, interval.ToString());
        }


        //вычисление даты через заданное количество дней
        static void DateAfterDays(Date UIntData)
        {
            DateTime date1 = new DateTime(Convert.ToInt32(UIntData.ymd.year), Convert.ToInt32(UIntData.ymd.month), Convert.ToInt32(UIntData.ymd.day));
            Console.WriteLine("Введите количество дней, которое надо добавить к первой введенной дате.");
            double value = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine( date1.AddDays(value));
        }


        //сравнение дат(равно, до, после)
        static void Comparison()
        {
            Console.WriteLine("Введите первую дату для сравнения.");

            Console.WriteLine("Введите год:");
            int year1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите месяц:");
            int month1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите день:");
            int day1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введенная дата: " + year1 + "." + month1 + "." + day1);


            Console.WriteLine("Введите вторую дату для сравнения.");

            Console.WriteLine("Введите год:");
            int year2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите месяц:");
            int month2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите день:");
            int day2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введенная дата: " + year2 + "." + month2 + "." + day2);

            int date1 = day1 + month1*100 + year1*1000;
            int date2 = day2 + month2*100 + year2*1000;

            if (date1==date2)
            {
                Console.WriteLine("Даты " + year1 + "." + month1 + "." + day1 + "и" + year2 + "." + month2 + "." + day2 + " равны.");
            } else if (date1>date2)
            {
                Console.WriteLine("Первая дата позже.");
            } else
            {
                Console.WriteLine("Вторая дата позже.");
            }
        }

        //присвоение и получение отдельных частей(год, месяц, день)
        static void Retrieve(Date UIntData)
        {
            Console.WriteLine("Вы вводили год: " + UIntData.ymd.year);
            Console.WriteLine("Вы вводили месяц: " + UIntData.ymd.month);
            Console.WriteLine("Вы вводили день: " + UIntData.ymd.day);
        }

        //вычитание заданного количества дней из даты
        static void SubtractionDays(Date UIntData)
        {
            DateTime date1 = new DateTime(Convert.ToInt32(UIntData.ymd.year), Convert.ToInt32(UIntData.ymd.month), Convert.ToInt32(UIntData.ymd.day));
            Console.WriteLine("Введите количество дней, которое надо вычесть из первой введенной даты.");
            double value = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(date1.AddDays(-value));
        }

        static string toString(Date UIntData)
        {
            return UIntData.ymd.year.ToString() + "." + UIntData.ymd.month.ToString() + "." + UIntData.ymd.day.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Уважаемый пользователь! Введите по очереди год, месяц и день ЦИФРАМИ.");
            Date UIntData = new Date();
            UIntData=Read(UIntData);
            if (Year366(UIntData.ymd.year))
            {
                Console.WriteLine("Год високосный.");
            }
            else
            {
                Console.WriteLine("Год невисокосный.");
            }
            DaysBtwDatas(UIntData);
            DateAfterDays(UIntData);
            DateAfterDays(UIntData);
            Comparison();
            SubtractionDays(UIntData);

            Console.WriteLine("На этом все. Нажмите любую клавишу для выхода из программы.");
            Console.ReadLine();


        }

    }
}