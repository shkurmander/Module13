using System;

namespace Ex13._6
{
    
    class Program
    {
        /// <summary>
        /// Метод заполняющий и возвращающий данные о пользователе
        /// </summary>
        /// <returns> объект кортежа userData </returns>
        public static (string name, string lastName, int age, bool havePet, string[] pets, string[] favColors) GetUserData()
        //если типизировать метод кортежем,надо делать заглушку на массив pets[](которую обрабатывать при печати)
        //иначе ошибка на возврат переменной которой не присвоено значение

        {

            //Метод для получения массива любимых цветов пользователя
            //amt - количество цветов
            static string[] GetFavColors(int amt)
            {
                string[] favColors = new string[amt];

                for (int i = 0; i < amt; i++)
                {
                    favColors[i] = GetCorrectString($"Enter your {i + 1} favorite color: ");
                }

                return favColors;

            }
            //Метод для получения массива кличек питомцев
            //amt - количество питомцев
            static string[] GetPetsNames(int amt)
            {
                string[] pets = new string[amt];

                for (int i = 0; i < amt; i++)
                {
                    pets[i] = GetCorrectString($"Enter pet №{i + 1} name: ");
                }

                return pets;

            }

            // Метод для получения корректного числа
            // text = текст для пользователя, с приглашением ввода
            // reference - минимально допустимое значение
            static int GetCorrectNum(string text, int reference)
            {
                int num = 0;
                bool correct = false;
                while (!correct)
                {

                    Console.Write(text);

                    correct = Int32.TryParse(Console.ReadLine(),out num);

                    if (!correct || num < reference)
                    {
                        correct = false;
                        Console.WriteLine($"Value not correct - expected number >= {reference}, try again");
                    }
                   
                }
                return num;
            }

            // Метод для получения не пустой строки
            // text = текст для пользователя, с приглашением ввода

            static string GetCorrectString(string text) 
            {
                var str = "";
                bool correct = false;
                while (!correct)
                {
                    
                    Console.Write(text);

                    str = Console.ReadLine();

                    if (str.Length > 0)
                    {
                        correct = true;
                    }
                    else
                    {
                        Console.WriteLine("Value can't be empty");
                    }
                }
                return str;
            }

            //кортеж данных о пользователе
            (string name, string lastName, int age, bool havePet, string[] pets, string[] favColors) userData;

                        

            userData.name = GetCorrectString("Enter your name: ");
            userData.lastName = GetCorrectString("Enter your last name: ");
            userData.age = GetCorrectNum("Enter your age: ", 3);

            //проверка на наличие питомца
            bool correct = false;
            userData.havePet = false;
            while (!correct)
            {

                Console.WriteLine("Do you have a pet?");
                Console.Write("Type \"y\" or \"n\": ");
                var str = Console.ReadLine();

                switch (str)
                { 
                    case "y" :
                        correct = true;
                        userData.havePet = true;
                        break;
                    case "n":
                        correct = true;
                        userData.havePet = false;
                        break;

                    default:
                        
                        Console.WriteLine("Incorrect value - type \"y\" or \"n\"!!!");
                        break;
                }                 
            }
            if (userData.havePet)
            {
                var numPets = GetCorrectNum("Enter the number of pets: ", 1);
                userData.pets = GetPetsNames(numPets);
            }
            else
            {
                userData.pets = null;
            }
           
            var numColors = GetCorrectNum("Enter the number of your favorite colors: ", 1);
            userData.favColors = GetFavColors(numColors);
            

            return userData;
                       
        }
        /// <summary>
        /// Метод печатающий данные о пользователе
        /// </summary>
        /// <param name="userData"> Кортеж с данными о пользователе</param>
        static void PrintUserData((string name, string lastName, int age, bool havePet, string[] pets, string[] favColors) userData)
        {
            Console.Clear();

            Console.WriteLine("User info:");

            Console.WriteLine($"Name: {userData.name}\nLast Name: {userData.lastName}\nAge:{userData.age}");
            Console.WriteLine("Pets list:");
            try
            {
                foreach (var item in userData.pets)
                {
                    Console.WriteLine($"\t{item}");
                }
            }
            catch 
            {
                Console.WriteLine("User have no pets - empty pets array!");
            }            

            Console.WriteLine("Favorite colors:");
            foreach (var item in userData.favColors)
            {
                Console.WriteLine($"\t{item}");
            }
        }

        static void Main(string[] args)
        {
            var user1 = GetUserData();
            PrintUserData(user1);

            Console.ReadKey();
        }
    }
}
