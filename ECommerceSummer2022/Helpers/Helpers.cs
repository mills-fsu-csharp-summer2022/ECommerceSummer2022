using Library.eCommerce.Models;

namespace ECommerceSummer2022.Helpers
{
    internal class Helpers
    {
        internal static void ListItems(IEnumerable<object> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        internal static InventoryItem FillInventoryItem(InventoryItem? invItem)
        {
            Console.WriteLine("What is the name of the product?");
            var name = Console.ReadLine();

            Console.WriteLine("What is the description of the product?");
            var desc = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("What is the price of the product?");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    if (invItem == null)
                    {
                        return new InventoryItem
                        {
                            Name = name ?? string.Empty
                            ,
                            Description = desc ?? string.Empty
                            ,
                            Price = price
                        };
                    }

                    invItem.Name = name ?? string.Empty;
                    invItem.Description = desc ?? string.Empty;
                    invItem.Price = price;
                    return invItem;
                }
            }
        }
    }
}
