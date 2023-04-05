using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_5_6
{
    class Program
    {
        static (string Name, string Surname, int Age, string[] Pet, string[] Color) EnterUser()
        {
            (string Name, string Surname, int Age, string[] Pet, string[] Color) User = ("", "", 0, null, null);            

            Console.WriteLine("Введите имя");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            User.Surname = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();

            } while (CheckNum(age, out intage));
            User.Age = intage;                    
            
            string statepet;
            do
            {
                Console.WriteLine("Есть питомец? Ответьте Да или Нет");
                statepet = Console.ReadLine();
            } while (CheckAnswer(statepet));

            if (statepet.ToLower() == "да")
            {
                string quantpet; // количество
                int intquantpet;
                do
                {
                    Console.WriteLine("Сколько у вас питомцев? Ввод произвести цифрами");
                    quantpet = Console.ReadLine();
                } while (CheckNum(quantpet, out intquantpet));
                User.Pet = CreateArrayPets(intquantpet);
            }

            string statecolor;
            do
            {
                Console.WriteLine("У Вас есть любимые цвета? Ответьте Да или Нет");
                statecolor = Console.ReadLine();
            } while (CheckAnswer(statecolor));

            if (statecolor.ToLower() == "да")
            {
                string quantcolor; // количество
                int intquantcolor;
                do
                {
                    Console.WriteLine("Сколько у вас любимых цветов? Ввод произвести цифрами");
                    quantcolor = Console.ReadLine();
                } while (CheckNum(quantcolor, out intquantcolor));
                User.Color = CreateArrayColor(intquantcolor);
            }

            return User;
        }
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            corrnumber = 0;
            return true;
        }
        static bool CheckAnswer(string state)
        {
            if (state.ToLower() == "да" || state.ToLower() == "нет")
            {
                return false;
            }                    
            return true;            
        }
        static string[] CreateArrayPets(int num)
        {
            var result = new string[num];
            Console.WriteLine("Перечислите питомцев по кличке");
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Console.ReadLine();
            }
            return result;
        }
        static string[] CreateArrayColor(int num)
        {
            var result = new string[num];
            Console.WriteLine("Перчислите любимые цвета");
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Console.ReadLine();
            }
            return result;
        }
        static void Print((string Name, string Surname, int Age, string[] Pet, string[] Color) User)
        {
            Console.WriteLine("Имя пользователя: " + User.Name);
            Console.WriteLine("Фамилия пользователя: " + User.Surname);
            Console.WriteLine("Возраст пользователя: " + User.Age);
            Console.WriteLine("Клички питомцев пользователя:");
            foreach (var item in User.Pet)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nЛюбимые цвета пользователя:");
            foreach (var item in User.Color)
            {
                Console.Write(item + " ");
            }
        }         
        static void Main(string[] args)
        {
            var call = EnterUser();
            Print(call);
            Console.ReadKey();
        }
    }
}
