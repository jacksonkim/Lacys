using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LacysMobile.Data;
using LacysMobile.Models;

namespace LacysMobile.CreateDb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Database...");

            DataContext context = new DataContext();
            try
            {
                context.Database.Initialize(true);

                Console.WriteLine("Done...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Done...");
                Console.ReadLine();
            }
        }
    }
}
