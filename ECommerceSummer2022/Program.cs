using Library.eCommerce.Models;
using Library.eCommerce.Services;
using ECommerceSummer2022.Helpers;

namespace ECommerceSummer2022
{
    public partial class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the widget store!");
            var inventoryService = InventoryService.Current;
            switch(GetUserTypeChoice())
            {
                
                case UserType.Employee:
                    new EmployeeMenuHelper().DoWork();
                    break;
                case UserType.Customer:
                    GetCustomerAction();
                    break;
            }
        }


        private static UserType GetUserTypeChoice()
        {
            while(true)
            {
                Console.WriteLine("Are you a store employee or a customer?");
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Customer");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return UserType.Employee;
                        case 2:
                            return UserType.Customer;

                    }
                }
                Console.WriteLine();
            }
        }
    
        public static UserAction GetCustomerAction()
        {
            while (true)
            {
                Console.WriteLine("\nSelect from the following options:");
                Console.WriteLine("1. Add product to cart");
                Console.WriteLine("2. List products in cart");
                Console.WriteLine("3. Search product in cart");
                Console.WriteLine("4. Update product in cart");
                Console.WriteLine("5. Delete product from cart");
                Console.WriteLine("6. Save cart");
                Console.WriteLine("7. Load cart");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return UserAction.Create_Cart;
                        case 2:
                            return UserAction.Read_Cart;
                        case 3:
                            return UserAction.Search_Cart;
                        case 4:
                            return UserAction.Update_Cart;
                        case 5:
                            return UserAction.Delete_Cart;
                        case 6:
                            return UserAction.Save_Cart;
                        case 7:
                            return UserAction.Load_Cart;
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public enum UserType
    {
        Employee, Customer
    }

    public enum UserAction
    {
        Create_Inventory
        , Read_Inventory
        , Update_Inventory
        , Delete_Inventory
        , Search_Inventory
        , Save_Inventory
        , Load_Inventory
        , Create_Cart
        , Update_Cart
        , Read_Cart
        , Delete_Cart
        , Search_Cart
        , Save_Cart
        , Load_Cart
        , Quit
    }
}