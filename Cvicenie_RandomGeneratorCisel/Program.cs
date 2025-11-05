namespace Cvicenie_RandomGeneratorCisel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int ct = 0;
            for (int i = 0; i < 100000; i++)
            {
                bool result = Prob(r);
                if (result == true);
                {
                    ct++;
                }
            }
            Console.WriteLine("True bolo: " +ct+ "x");
        }

        public static bool Prob(Random r )
        {
            
            int nahodneCislo = r.Next(0, 101);
            if (nahodneCislo >= 73) 
            {
                return true;
            }
            return false;
        }
    }
}