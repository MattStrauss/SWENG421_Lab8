using Lab8.Devices;
using Lab8.People;
using System;
namespace Lab8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your TV budget: ");
            int budget = Convert.ToInt32(Console.ReadLine());

            Retailer Boobaon = new Retailer();
            try
            {
                TV tv = Boobaon.ReplenishTV(budget);
                if (tv != null)
                {
                    tv.GetInfo();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
