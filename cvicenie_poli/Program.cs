using System;

namespace cvicenie_poli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int[] numbers = new int[7];

            numbers[0] = 10;
            numbers[1] = 15;
            numbers[2] = 35;
            numbers[3] = 48;
            numbers[4] = 2;
            numbers[5] = 1;
            numbers[6] = 19;

            /*
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
            */

            /* int sum = 0;
             foreach (var number in numbers) 
             {
                 sum += number;
             }
             Console.WriteLine(sum); */


            int[] numbers = new int[5];
            Console.WriteLine("Kolko cisiel chete zadat?:");
            int howmutch = int.Parse(Console.ReadLine()); //nacitaj pocet cisel od pouzivatela

            int[] ints = new int[howmutch];
            int[] number = ints;


            for (int i = 0; i < howmutch; i++)  // cyklus 5 krát
            {
                Console.Write("hodnota ");
                numbers[i] = int.Parse(Console.ReadLine());  // načítaj číslo a ulož do poľa
            }

            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
                sum += numbers[i];
            }
            Console.WriteLine(sum);


            

            


        }
    }
}
