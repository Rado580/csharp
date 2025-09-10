
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*bool isChild = true;
            Console.WriteLine(isChild);
            
            int myAge = 15;
            Console.WriteLine(myAge);

            float pi = 3.14f;
            Console.WriteLine(pi);

            string name = "Rado";
            Console.WriteLine(name);

            char gender = 'M';
            Console.WriteLine(gender);*/

            int a = 10;
            int b = 20 + 30 * 20 + 30 * 20 + 30;

            int sum = a + b;
            //Scitavanie cisla A a B
            //Console.WriteLine(sum);
            Console.WriteLine(a + b);
            //Console.WriteLine(10 + 5);

            //Odcitavanie cisla A a B
            Console.WriteLine(a - b);

            //Nasobe cisla A a B
            Console.WriteLine(a * b);

            //Delenie cisla A a B
            Console.WriteLine(a / b);

            Console.WriteLine("Volam sa Rado");





            int birthday = 8;
            int birthMonth = 3;
            int birthYear = 2010;

            //Scitanie datumu narodenia mesiaca a roku do premennej birthSum
            int birthSum = birthday + birthMonth * birthYear;
            //Vypisanie na konzolu birthSum (cez Console.Writeline)
            Console.WriteLine(birthSum);
            //Nasledne vynasobte birtSu * 10 a vypiste nasobok
            Console.WriteLine(birthSum * 10);


            //Scitanie datum narodenia a mesiac a ay potom prenasobte rokom
            Console.WriteLine((birthday + birthMonth) * birthYear);

            Console.WriteLine(5/3);

            //Vytvorte si premennu s vasim meno a scitajte ju s rokom narodenia
            string name = "Rado";
            Console.WriteLine(name+birthYear);

            //Vypiste meno a sucet dna a mesiaca narodenia
            Console.WriteLine(name + birthday + birthMonth);


            bool result = 6 > 3;
            Console.WriteLine(result);

            string igor = "Igor";
            string Michal = "Igor";
            Console.WriteLine(igor == Michal);
        }
    }
}