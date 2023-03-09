using System;
using System.Reflection;

namespace MenuPlanner
{
    class Program
    {

        static bool TryParseInt(string input, out int result)
        {
            result = 0;
            int index = 0;
            while (index < input.Length)
            {
                char c = input[index];
                if (c < '0' || c > '9')
                {
                    return false;
                }
                result = result * 10 + (c - '0');
                index++;
            }
            return true;
        }
        static void Main(string[] args)
        {
           
            string[] cuisineStyles = {"Італійська", "Французька" };
            string[][] menuItems = new string[][] {
            new string[] { "Солянка" ,  "Каша", "Kруасан" },
            new string[] {"Харчо",  "Мівіна", "Хліб"}
            };
            string[] seasons = { "Весна", "Літо" };
            string[][] seasonalItems = new string[][] {
            new string[] {"Суп", "курка", "тірамісу" },
            new string[] {"Борщ", "риба", "торт" }
            };

            string[] weekDays = { "Перші страви", "Другі страви", "Десерт"};

            int cuisineIndex = 0;
            int seasonIndex = 0;

            string[] veganMenu = { "Салат зі свіжих овочів", "Вегетаріанська піца", "Каша з кокосовим молоком"};

            bool validInput = false;
           
            Console.Write("Ви веган? (Так - 1/Ні - 2): ");
            string veganAnswer = Console.ReadLine();

            if (veganAnswer == "1")
            {
                Console.WriteLine("Меню для веганів:");
                for (int i = 0; i < veganMenu.Length; i++)
                {
                    Console.WriteLine(veganMenu[i]);
                }
            }
            else if (veganAnswer == "2")
            { 

                while (!validInput)
                {
                    Console.WriteLine("стиль кухні:");
                    for (int i = 0; i < cuisineStyles.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {cuisineStyles[i]}");
                    }
                    Console.Write("\nОберіть стиль кухні номер: ");
                    string cuisineInput = Console.ReadLine();

                    if (TryParseInt(cuisineInput, out cuisineIndex) && cuisineIndex >= 1 && cuisineIndex <= cuisineStyles.Length)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Неправильне значення '{cuisineInput}'. Введіть число від 1 до {cuisineStyles.Length}.");
                    }
                }

                validInput = false;

                while (!validInput)
                {
                    Console.WriteLine("\nВиберіть сезон:");
                    for (int i = 0; i < seasons.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {seasons[i]}");
                    }
                    Console.Write("\nОберіть сезон номер: ");
                    string seasonInput = Console.ReadLine();

                    if (TryParseInt(seasonInput, out seasonIndex) && seasonIndex >= 1 && seasonIndex <= seasons.Length)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Неправильне значення '{seasonInput}'. Введіть число від 1 до {seasons.Length}.");
                    }
                }

                Console.WriteLine($"\nСписок страв за стилем '{cuisineStyles[cuisineIndex - 1]}' та сезоном '{seasons[seasonIndex - 1]}'");



                for (int i = 0; (i < seasonalItems[seasonIndex - 1].Length && i < menuItems[cuisineIndex - 1].Length); i++)
                {
                    Console.WriteLine($"{weekDays[i]}:");
                    Console.WriteLine(seasonalItems[seasonIndex - 1][i]);
                    Console.WriteLine(menuItems[cuisineIndex - 1][i]);

                }
            }
            else
            {
                Console.WriteLine("Невірно введені дані.");

            }


            string[] drinks = { "Алкогольні", "Безалкогольні" };
            string[][] drinkItems = new string[][] {
    new string[] {"Вино", "Вермут", "Граппа"},
    new string[] {"Лимонад", "Сік", "Чай"}
};

            int drinkIndex = 0;
            validInput = false;

            while (!validInput)
            {
                Console.WriteLine("\nВиберіть напій:");
                for (int i = 0; i < drinks.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {drinks[i]}");
                }
                Console.Write("\nОберіть напій номер: ");
                string drinkInput = Console.ReadLine();

                if (TryParseInt(drinkInput, out drinkIndex) && drinkIndex >= 1 && drinkIndex <= drinks.Length)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine($"Неправильне значення '{drinkInput}'. Введіть число від 1 до {drinks.Length}.");
                }
            }


            switch (drinkIndex)
            {
                case 1:
                    for (int i = 0; i < drinkItems[0].Length; i++)
                    {
                        Console.WriteLine(drinkItems[0][i]);
                    }
                    break;
                case 2:
                    for (int i = 0; i < drinkItems[1].Length; i++)
                    {
                        Console.WriteLine(drinkItems[1][i]);
                    }
                    break;
            }


            Console.ReadLine();
        }

    }

}


