using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calcc;

namespace HelloWorld
{
    class Program{
        static void Main(string[] args){

            string Name = Console.ReadLine();
            Console.Write($"Hello, {Name}");
            Console.Read();

            /*2*/
            string name;

            /*3*/
            Console.WriteLine(true);
            Console.WriteLine(false);
            Console.WriteLine(-11);
            Console.WriteLine(5);
            Console.WriteLine(505);
            Console.WriteLine(0b11);        // 3
            Console.WriteLine(0b1011);      // 11
            Console.WriteLine(0b100001);    // 33
            Console.WriteLine(0x0A);    // 10
            Console.WriteLine(0xFF);    // 255
            Console.WriteLine(0xA1);    // 161
            Console.WriteLine(3.2e3);   // по сути равно 3.2 * 10<sup>3</sup> = 3200
            Console.WriteLine(1.2E-1);  // равно 1.2 * 10<sup>-1</sup> = 0.12

            /*4Type of data*/
            bool alive = true; 
            byte bit1 = 1;
            sbyte bit2 = -101;
            short n1 = 1;
            ushort n2 = 1;
            int a1 = 10;
            uint a2 = 10;
            long a3 = -10;
            ulong a4 = 10;
            char a = 'A';
            string hello = "Hello";
            /*object: может хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе. Представлен системным типом System.Object, который является базовым для всех других типов и классов .NET.*/
            object a5 = 22;
            object b = 3.14;
            object c = "hello code";

            float a51 = 3.14F;
            decimal c2 = 1005.8M;

            /*Есть еще неявная форма обозначения переменных через var:*/
            var hello1 = "Hell to World";
            var c3 = 20;

            Console.WriteLine(c.GetType().ToString());
            Console.WriteLine(hello.GetType().ToString());

            /*5*/
            string name1 = "Tom";
            int age1 = 34;
            double height = 1.7;
            Console.WriteLine($"Имя: {name1}  Возраст: {age1}  Рост: {height}м");

            /*6, 7, 8 - арифметические действия, побитовае операции, присваивания - это уже точно в с++ есть*/

            /*9*/
            ushort a6 = 4;
            byte b6 = (byte)a6; /*вот так надо*/
            try{
                int a7 = 33;
                int b7 = 600;
                byte c7 = checked((byte)(a7 + b7));
                Console.WriteLine(c);
            }
            catch (OverflowException ex){
                Console.WriteLine(ex.Message);
            }
            /*10,11,12,13 - сравнения - есть в с++*/

            /*14 - массивы*/
            int[] nums = new int[4]; /*другое обозначение*/
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            /*а тут вот так можно, оказывается!*/
            foreach (int i in numbers){
                Console.WriteLine(i);
            }

            /*N-мерные массивы*/
            int[,] nums3 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
            public const int SIZE = 6;
            public float[,] matrix = new float[SIZE, SIZE]; // матрица связей
            public float[] a = new float[SIZE]; // посещенные вершины
            public float[] d = new float[SIZE]; // минимальное расстояние
            public float save;//временное хранение различных величин
            public int begin_index = 0;//задаем индекс начальной вершины, от которой будем искать путь
            public int min;
            public int minindex;
            /*массив массивов*/
            /*int[][] numbers = new int[3][];
            numbers[0] = new int[] { 1, 2 };
            numbers[1] = new int[] { 1, 2, 3 };
            numbers[2] = new int[] { 1, 2, 3, 4, 5 };
            foreach (int[] row in numbers)
            {
                foreach (int number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }*/

            // перебор с помощью цикла for
           /* for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]} \t");
                }
                Console.WriteLine();
            }*/


            /*16*/
            static void SayHello(){
                Console.WriteLine("Hello");
            }
            /*сокр версия*/
            static void _sayHello() => Console.WriteLine("Hello");
            static string GetHello() => "hello";

            /*18 можно как в питоне: дефолтные значения аргументов*/
            static int OptionalParam(int x, int y, int z = 5, int s = 4)
            {
                return x + y + z + s;
            }
            OptionalParam(y: 2, x: 3, s: 10);


            /*19 - ref - как global в питоне*/
            static void IncrementRef(ref int x)
            {
                x++;
                Console.WriteLine($"IncrementRef: {x}");
            }
            int a9 = 5;
            Console.WriteLine($"Начальное значение переменной a  = {a}");
            //Передача переменных по ссылке
            //После выполнения этого кода a = 6, так как мы передали саму переменную
            IncrementRef(ref a9);
            Console.WriteLine($"Переменная a после передачи ссылке равна = {a}");
            // out - ref Только без инициализации
            // in - out, только значение нельзя менять

            /*20*/
            static void Addition(params int[] integers)
            {
                int result = 0;
                for (int i = 0; i < integers.Length; i++)
                {
                    result += integers[i];
                }
                Console.WriteLine(result);
            }
            //params - ...params из питона

            /*...конец...*/
            var tuple = (count: 5, sum: 10);
            Console.WriteLine(tuple.count); // 5
            Console.WriteLine(tuple.sum); // 10

            var (name2, age2) = ("Tom", 23);
            (string, int, double) person = ("Tom", 25, 81.23);
            Console.WriteLine(name2);    // Tom
            Console.WriteLine(age2);     // 23
            Console.Read();

            static (int sum, int count) GetNamedValues(int[] numbers)
            {
                var result = (sum: 0, count: 0);
                for (int i = 0; i < numbers.Length; i++)
                {
                    result.sum += numbers[i];
                    result.count++;
                }
                return result;
            }
            var tuple1 = GetNamedValues(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Console.WriteLine(tuple.count);
            Console.WriteLine(tuple.sum);
            Console.Clear();










            //
            // ООП
            //
            double Num1, Num2;
            string op;
            Num1 = Convert.ToDouble(Console.ReadLine());
            Num2 = Convert.ToDouble(Console.ReadLine());
            op = Console.ReadLine();
            Calc calc = new Calc(Num1, Num2, op);
            calc.getResult();



            Console.ReadKey();
        }   


    }
}


/*
5
3(4)
4+
4
5-
5
 */