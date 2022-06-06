using Library.eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSummer2022.Helpers
{
    internal class EmployeeMenuHelper
    {
        public void DoWork()
        {
            var inventoryService = InventoryService.Current;
            var userAction = GetEmployeeAction();
            while (userAction != UserAction.Quit)
            {
                switch (userAction)
                {
                    case UserAction.Create_Inventory:
                        inventoryService.AddOrUpdate(Helpers.FillInventoryItem(null));
                        break;
                    case UserAction.Update_Inventory:
                        var itemToUpdate = inventoryService
                            .Inventory
                            .FirstOrDefault(i => i.Id == SelectInventoryItem("update"));
                        if (itemToUpdate != null)
                        {
                            inventoryService.AddOrUpdate(Helpers.FillInventoryItem(itemToUpdate));
                        }
                        break;
                    case UserAction.Delete_Inventory:
                        var indexToDelete = SelectInventoryItem("delete");
                        inventoryService.Delete(indexToDelete);
                        break;
                    case UserAction.Read_Inventory:
                        Helpers.ListItems(inventoryService.Inventory);
                        break;
                    case UserAction.Search_Inventory:
                        Console.WriteLine("Please enter your search query:");
                        Helpers.ListItems(inventoryService.GetFilteredList(Console.ReadLine() ?? string.Empty));
                        break;
                    case UserAction.Save_Inventory:
                        inventoryService.Save();
                        break;
                    case UserAction.Load_Inventory:
                        inventoryService.Load();
                        break;
                }
                userAction = GetEmployeeAction();
            }
        }

        private UserAction GetEmployeeAction()
        {
            while (true)
            {
                Console.WriteLine("\nSelect from the following options:");
                Console.WriteLine("1. Add product to inventory");
                Console.WriteLine("2. List products in inventory");
                Console.WriteLine("3. Search product in inventory");
                Console.WriteLine("4. Update product in inventory");
                Console.WriteLine("5. Delete product from inventory");
                Console.WriteLine("6. Save inventory");
                Console.WriteLine("7. Load inventory");
                Console.WriteLine("8. Quit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return UserAction.Create_Inventory;
                        case 2:
                            return UserAction.Read_Inventory;
                        case 3:
                            return UserAction.Search_Inventory;
                        case 4:
                            return UserAction.Update_Inventory;
                        case 5:
                            return UserAction.Delete_Inventory;
                        case 6:
                            return UserAction.Save_Inventory;
                        case 7:
                            return UserAction.Load_Inventory;
                        case 8:
                            return UserAction.Quit;
                    }
                }
                Console.WriteLine();
            }
        }

        private int SelectInventoryItem(string action)
        {
            Helpers.ListItems(InventoryService.Current.Inventory);
            while (true)
            {
                Console.WriteLine($"Which inventory item would you like to {action}?");
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    return id;
                }
            }

        }
    }
}
