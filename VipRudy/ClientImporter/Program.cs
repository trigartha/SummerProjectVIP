using System;

namespace ClientImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FileReader.AddClients();
            FileReader.AddCars();
            Console.ReadKey();
        }
    }
}
