using System;

namespace Ex13._6
{
    
    class Program
    {
        public static (string, string, int, bool, string[], string[]) GetUserData()
        {
            //Метод для получения массива кличек питомцев
            static string[] GetPetsNames(int amt)
            {
                string[] pets = new string[amt];

                for (int i = 0; i < amt; i++)
                {
                    pets[i] = GetCorrectString($"Enter pet №{i + 1} name");
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
            var numPets = GetCorrectNum("Enter the number of pets: ", 1);
            
            


            return userData;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
