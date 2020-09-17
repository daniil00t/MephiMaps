using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcc
{
    //Constructions
    class Person{
        public string name;         // имя
        public int age = 18;        // возраст

        public Person() { name = "Неизвестно"; age = 18; }      // 1 конструктор
        public Person(string n) { name = n; age = 18; }         // 2 конструктор
        public Person(string name, int age){
            this.name = name;
            this.age = age;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }
    }
    class Calc{
        private double a, b;
        private string op;

        public Calc(double a, double b, string op)
        {
            this.a = a;
            this.b = b;
            this.op = op;
        }
        public double calc(double a, double b, string op)
        {
            if (op == "+")
            {
                return a + b;
            }
            else if(op == "-")
            {
                return a - b;
            }
            else if(op == "*")
            {
                return a * b;
            }
            else
            {
                return a / b;
            }
        }
        public void getResult()
        {
            Console.WriteLine($"{this.a} {this.op} {this.b} = {this.calc(this.a, this.b, this.op)}");
        }

    }
    struct User
    {
        public string name;
        public int age;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }

    
}
