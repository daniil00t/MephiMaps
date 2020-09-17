using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSpace
{
    class Account
    {
        public int Id { get; private set; }
        public Account(int _id)
        {
            Id = _id;
        }
    }

    /*
    1. public: публичный, общедоступный класс или член класса. Такой член класса доступен из любого места в коде, а также из других программ и сборок.
    2. private: закрытый класс или член класса. Представляет полную противоположность модификатору public. Такой закрытый класс или член класса доступен только из кода в том же классе или контексте.
    3. protected: такой член класса доступен из любого места в текущем классе или в производных классах. При этом производные классы могут располагаться в других сборках.
    4. internal: класс и члены класса с подобным модификатором доступны из любого места кода в той же сборке, однако он недоступен для других программ и сборок (как в случае с модификатором public).
    5. protected internal: совмещает функционал двух модификаторов. Классы и члены класса с таким модификатором доступны из текущей сборки и из производных классов.
    6. private protected: такой член класса доступен из любого места в текущем классе или в производных классах, которые определены в той же сборке.
     */
    public class State
    {
        // все равно, что private int defaultVar;
        int defaultVar;
        // поле доступно только из текущего класса
        private int privateVar;
        // доступно из текущего класса и производных классов, которые определены в этом же проекте
        protected private int protectedPrivateVar;
        // доступно из текущего класса и производных классов
        protected int protectedVar;
        // доступно в любом месте текущего проекта
        internal int internalVar;
        // доступно в любом месте текущего проекта и из классов-наследников в других проектах
        protected internal int protectedInternalVar;
        // доступно в любом месте программы, а также для других программ и сборок
        public int publicVar;

        // по умолчанию имеет модификатор private
        void defaultMethod() => Console.WriteLine($"defaultVar = {defaultVar}");

        // метод доступен только из текущего класса
        private void privateMethod() => Console.WriteLine($"privateVar = {privateVar}");

        // доступен из текущего класса и производных классов, которые определены в этом же проекте
        protected private void protectedPrivateMethod() => Console.WriteLine($"protectedPrivateVar = {protectedPrivateVar}");

        // доступен из текущего класса и производных классов
        protected void protectedMethod() => Console.WriteLine($"protectedVar = {protectedVar}");

        // доступен в любом месте текущего проекта
        internal void internalMethod() => Console.WriteLine($"internalVar = {internalVar}");

        // доступен в любом месте текущего проекта и из классов-наследников в других проектах
        protected internal void protectedInternalMethod() => Console.WriteLine($"protectedInternalVar = {protectedInternalVar}");

        // доступен в любом месте программы, а также для других программ и сборок
        public void publicMethod() => Console.WriteLine($"publicVar = {publicVar}");
    }


    // Еще есть так называемые свойства, обеспечивающие простой доступ к классу: get and set:
    class Person
    {
        private string name;

        public string Name
        {
            get {return name;}
            set{name = value;}
        }
    }

    //Автоматические свойства определения и выдачи значения:
    class Person_copy
    {
        private string name;
        private string job;

        public string Name
        {
            private get { return name; }
            set { name = value; }
        }
        // эквивалентно public string Name { get { return name; } }
        public string Job => job;
    }

    class OOP2
    {
        public static void Nope(string[] args)
        {
            Account account = new Account(4);

            //Если мы захотим получить значение name объекта person_c класса Person_copy, то скорее всего ничего не получится
            Person_copy person_c = new Person_copy();
            person_c.Name = "daniil";
            try
            {
                person_c.Job = "dev"; // ошибка! потому что job доступен только для чтения
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            

        }
    }
    
}

