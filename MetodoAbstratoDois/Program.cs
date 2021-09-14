using System;
using System.Globalization;
using System.Collections.Generic;
using MetodoAbstratoDois.Entities;
namespace MetodoAbstratoDois
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Taxpayer> taxpayers = new List<Taxpayer>();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char ic = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ic == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxpayers.Add(new Individual(name, anualIncome, healthExpenditures));
                } 
                else if(ic == 'c')
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    taxpayers.Add(new Company(name, anualIncome, numberOfEmployees));
                } else
                {
                    Console.WriteLine("Sorry, Individual or Company informed are wrong. Please just tap 'i' for individual or 'c' for company.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            foreach(Taxpayer t in taxpayers)
            {
                Console.WriteLine(t.Name + ": $ " + t.TaxesPaid().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
