using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace Cvicenie_Pravdepodobnost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Random rand = new Random();
            int value = rand.Next(0, 100);
            if (value < 80) 
            {
                Console.WriteLine("Vyhral ten s 80%");
            }else
            {
                Console.WriteLine("Vyhral ten s 20%");
            }
            */

            Student student1 = new Student("Michal", 5);
            Student student2 = new Student("Radovan", 15);
            Student student3 = new Student("Dano", 25);
            Student student4 = new Student("Hugo", 55);

            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(new Student("Michal", 1));

            List<Student> klobucik = new List<Student>();
            foreach (Student stud in students)
            {
                for (int i = 0; i < stud.TicketCount; i++)
                {
                    klobucik.Add(stud);
                }
            }
            Random random = new Random();
            int index = random.Next(klobucik.Count);
            Student vyherca = klobucik[index];
            Console.WriteLine(vyherca.Name + vyherca.TicketCount);

        }
    }
}

