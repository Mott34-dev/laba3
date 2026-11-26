
using System.Diagnostics;
namespace mott34
{
    class Program
    {


        static void Main()
        {
            bool i = true;





            while (i)
            {
                Console.WriteLine("МЕНЮ:");
                Console.WriteLine("1 - ОТГАДАЙ ОТВЕТ");
                Console.WriteLine("2 - ОБ АВТОРЕ");
                Console.WriteLine("3 - СОРТИРОВКА МАССИВА");
                Console.WriteLine("4 - ВЫХОД");
                Console.Write("выберете число:");
                string game = Console.ReadLine();
                switch (game)
                {
                    case "1":
                        game1();
                        break;
                    case "2":
                        game2();
                        break;
                    case "3":
                        game3();
                        break;
                    case "4":
                        i = !Exit();
                        break;
                    default:
                        Console.WriteLine("ошибка.такого пункта не было");
                        break;
                }

            }
        }
        static void game1()
        {

            double u = Numbers2("введите число a: ");
            double b = Numbers2("введите число b:");
            while (Math.Log(Math.Pow(b, 4)) < 0 || Math.Cos(u) == 0)
            {
                Console.WriteLine("ошибка!введите другие числа. ");
                u = Numbers2("введите число a: ");
                b = Numbers2("введите число b: ");

            }
            Console.WriteLine("пример: (cos(п)^7 + (ln(b^4))^0.5)/sin(п/2 + a)");
            double c = ab(u, b);
            game(c);
        }
        static void game2()
        {
            Console.WriteLine("Автор: Беспалов Матвей Николаевич");
            Console.WriteLine("ИВТ 6 группа ");
        }
        static void game3()
        {

            int n = Numbers("введите длину массива:");
            while (n <= 0)
            {
                Console.WriteLine("длина должа быть больше 0");
                n = Numbers("введите корректную длину:");

            }


            int[] num1 = zap(n);

            Console.WriteLine("ИСХОДНЫЙ МАССИВ");
            input(num1);

            int[] copy1 = clone(num1);
            int[] copy2 = clone(num1);


            double g = time(copy1, true);
            double g1 = time(copy2, false);

            Console.WriteLine("После пузырька:");
            input(copy1);
            Console.WriteLine("После Шелла:");
            input(copy2);
            Console.WriteLine($"Пузырёк: {g} ms");
            Console.WriteLine($"Шелл:    {g1} ms");
            if (g > g1)
            {
                Console.WriteLine("Shell быстрее");
            }
            else
            {
                Console.WriteLine("puzirec быстрее");
            }
        }

        static bool Exit()
        {
            while (true)
            {
                Console.WriteLine("вы точно хотите выйти ?(да/нет)");
                string otvet = Console.ReadLine()?.ToLower();
                if (otvet == "да")
                    return true;
                if (otvet == "нет")
                    return false;
                Console.WriteLine("ответьте да или нет");
            }
        }
        static public int Numbers(string input)
        {

            while (true)
            {
                Console.Write(input);
                string f = Console.ReadLine();
                if (int.TryParse(f, out int result))
                    return result;
                Console.WriteLine("надо число:");
            }

        }
        static void input(int[] j)
        {
            if (j.Length > 10)
            {
                Console.WriteLine("длина массива больше 10");
                return;
            }
            foreach (int x in j)
                Console.Write(x + "\t");
            Console.WriteLine();



        }
        static int[] puz(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1 - i; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            return arr;
        }

        static int[] shell(int[] arr)
        {
            for (int gap = arr.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    int temp = arr[i];
                    int j = i;
                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }
            }
            return arr;
        }



        static int[] clone(int[] arr)
        {
            return (int[])arr.Clone();
        }


        static int[] zap(int n)
        {
            int[] num1 = new int[n];
            Random random = new Random();
            for (int i = 0; i < num1.Length; i++)
                num1[i] = random.Next(-25, 26);
            return num1;
        }


        static double ab(double a, double b)
        {
            const double p = Math.PI;
            double cos = Math.Cos(p);
            double c = (Math.Pow(cos, 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4)))) / (Math.Pow(Math.Sin(p / 2 + a), 2));
            return Math.Round(c, 2);
        }

        static double Numbers2(string input)
        {

            while (true)
            {
                Console.Write(input);
                string f = Console.ReadLine();
                if (double.TryParse(f, out double result))
                    return result;
                Console.WriteLine("МЫ ЖЕ ПРОСИЛИ ЧИСЛО ...");
            }
        }

        static void game(double a1)
        {
            int a = 0;
            bool h = false;
            while (!h && a < 3)
            {
                double user = Numbers2("введите ваш ответ:");
                a++;
                if (user == a1)
                {
                    h = true;
                    Console.WriteLine("ПОБЕДА");
                }
                else
                {
                    Console.WriteLine("ОТВЕТ НЕВЕРНЫЙ...");
                    if (a < 3)
                        Console.WriteLine("осталось попыток:" + (3 - a));
                }

            }
            if (!h)
            {
                Console.WriteLine("ВЫ ПРОИГРАЛИ");
                Console.WriteLine("ПРАВИЛЬНЫЙ ОТВЕТ:" + a1);


            }

        }
        static double time(int[] arr, bool k)
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (k)
                puz(arr);
            else
                shell(arr);
            sw.Stop();

            double m = sw.Elapsed.TotalMilliseconds;
            return m;
        }


    }



}

