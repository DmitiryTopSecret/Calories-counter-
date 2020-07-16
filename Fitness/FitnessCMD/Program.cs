using FitnessBL.Controller;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Greetings! This is an application for counting callories, called FITNESS");
            
            Console.WriteLine("Enter a User Name: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {

                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine(); 
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Weight");
                var height = ParseDouble("Height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you wan't to do?");
            Console.WriteLine("E - Enter your eating");
            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight); 

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }


            Console.ReadLine();

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Enter name of product: ");
            var food = Console.ReadLine();

            var callories = ParseDouble("callories");
            var prot = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydrates");

            var weight = ParseDouble("weight of portion");
            var product = new Food(food, callories, prot, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Enter your date of birth(dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid {name} format");
                }
            }
        }
    }
}
