namespace Cvicenie_GameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = LootGenerator.GetRandomLoot();/*
            Item currentBest = items[0];
            foreach (var item in items)
            {
                if (item.Price > currentBest.Price)
                {
                    currentBest = item;
                }
            }
            Console.WriteLine(currentBest);*/

            //najlacnejsi item
            Item worst = items.MinBy(item => item.Price);
            Console.WriteLine(worst);

            //najdrahsi item
            Item bestItem = items.MaxBy(item => item.Price);
            Console.WriteLine(bestItem);

            List<Item> orderByPrice = items.OrderBy(vec => vec.Price).ToList();
            Console.WriteLine(orderByPrice[0]);

            List<Item> orderByPriceNajdrahsi = items.OrderByDescending(vec => vec.Price).ToList();
            Console.WriteLine("Toto je najdrahsia vec: " + orderByPriceNajdrahsi[0]);

            List<Item> itemUnder1000 = items.Where(vec => vec.Price <= 1000).ToList();
            Console.WriteLine("Pocet itemov pod 1000: " + itemUnder1000.Count);
            
            List<Item> item500to1000 = items.Where(item => item.Price <= 1000 && item.Price >= 500).ToList();
            Console.WriteLine("Pocet itemov pod 1000 nad 500: " + item500to1000.Count);

        }
    }
}
