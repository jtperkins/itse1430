using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreator
{
    class Menu
    {
        
        public Menu()
        {
            
        }

        public static void DisplayMenu(Order order)
        {
            string choice;
            bool quit = false;
            
            while (!quit)
            {
                if (!order.MadeOrder())
                {
                    Console.WriteLine("\t\t\t\t      ----------------------------------");
                    Console.WriteLine("\t\t\t\t\t**Current order total: {0:C}**", 0);
                    Console.WriteLine("\t\t\t\t      ----------------------------------");
                } else
                {
                    Console.WriteLine("\t\t\t\t      ----------------------------------");
                    Console.WriteLine("\t\t\t\t\t**Current order total: {0:C}**", order.TotalPrice());
                    Console.WriteLine("\t\t\t\t      ----------------------------------");
                }

                Console.WriteLine("1. New Order");
                Console.WriteLine("2. Modify Order");
                Console.WriteLine("3. Display Order");
                Console.WriteLine("4. Quit");
                Console.WriteLine("Please enter your choice (1 - 4)");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Order.NewOrder(order);
                        break;
                    case "2":
                        Console.Clear();
                    
                        if (!order.MadeOrder())
                        {
                            Console.WriteLine("No order to modify");
                        }
                        else
                        {
                            Order.ModifyOrder(order);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        //quit = true;
                        if (!order.MadeOrder())
                        {
                            Console.WriteLine("No order to display");
                        }
                        else
                        {
                            order.DisplayOrder(order);
                        }
                        //DisplayOrder();

                        Console.ReadLine();
                        Console.Clear();
                        //DisplayMenu();
                        break;
                    case "4":
                        //quit = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input, try again");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public static string GetSize()
        {
            string size = null;
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Choose a size (one is required)");
                Console.WriteLine(" - Small ($5)");
                Console.WriteLine(" - Medium ($6.25)");
                Console.WriteLine(" - Large ($8.75)");
                size = Console.ReadLine();
                if (size.ToLower() == "small" || size.ToLower() == "medium" || size.ToLower() == "large")
                    quit = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid repsonse, try again: ");
                    Console.WriteLine("");
                    //getSize();
                }

            }
            Console.Clear();
            return size;
        }

        public static ArrayList GetMeats( ArrayList list )
        {
            string meats = null;
            bool quit = false;

            list = new ArrayList();

            while (!quit)
            {
                Console.WriteLine("Meats (zero or more). Each option is $0.75 extra");
                Console.WriteLine("please choose one meat at a time (type none if none desired): ");
                Console.WriteLine(" - Bacon");
                Console.WriteLine(" - Ham");
                Console.WriteLine(" - Pepperoni");
                Console.WriteLine(" - Sausage");
                meats = Console.ReadLine();
                if (meats.ToLower() == "bacon" || meats.ToLower() == "pepperoni" || meats.ToLower() == "ham" || meats.ToLower() == "sausage" || meats.ToLower() == "none")
                {
                    if (meats.ToLower() == "none")
                    {
                        Console.Clear();
                        return list;
                    } else
                    {
                        Console.WriteLine("Would you like to choose another? (Y/N) ");
                        switch (Console.ReadLine().ToLower())
                        {
                            case "y":
                                list.Add(meats);
                                Console.Clear();
                                //quit = true;
                                continue;

                            case "n":
                                list.Add(meats);
                                Console.Clear();
                                return list;
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid repsonse, try again: ");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                    }
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid repsonse, try again: ");
                    Console.ReadLine();
                    continue;
                }

            }
            return list;
        }

        public static ArrayList GetVegetables( ArrayList list )
        {
            string vegetables = null;
            bool quit = false;

            list = new ArrayList();

            while (!quit)
            {
                Console.WriteLine("Vegetables (zero or more). Each option is $0.50 extra");
                Console.WriteLine("please choose one veggie at a time (type none if none desired): ");
                Console.WriteLine(" - Black olives");
                Console.WriteLine(" - Mushrooms");
                Console.WriteLine(" - Onions");
                Console.WriteLine(" - Peppers");
                vegetables = Console.ReadLine();
                if (vegetables.ToLower() == "black olives" || vegetables.ToLower() == "mushrooms" || vegetables.ToLower() == "onions" || vegetables.ToLower() == "peppers" || vegetables.ToLower() == "none")
                {
                    if (vegetables.ToLower().CompareTo("none") == 0)
                    {
                        Console.Clear();
                        return list;
                    } else
                    {
                        Console.WriteLine("Would you like to choose another? (Y/N) ");
                        switch (Console.ReadLine().ToLower())
                        {
                            case "y":
                                list.Add(vegetables);
                                Console.Clear();
                                continue;
                            case "n":
                                list.Add(vegetables);
                                Console.Clear();
                                return list;
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid repsonse, try again: ");
                                Console.ReadLine();
                                Console.Clear();
                            break;
                        }
                    }
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid repsonse, try again: ");
                    Console.ReadLine();
                    continue;
                }
            }
            return list;
        }

        public static string GetSauce()
        {
            string sauce = null;
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Choose a sauce (one is required)");
                Console.WriteLine(" - Traditional ($0)");
                Console.WriteLine(" - Garlic ($1)");
                Console.WriteLine(" - Oregano ($1)");
                sauce = Console.ReadLine();
                if (sauce.ToLower() == "traditional" || sauce.ToLower() == "garlic" || sauce.ToLower() == "oregano")
                    quit = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid repsonse, try again: ");
                    Console.ReadLine();
                    continue;
                }

            }
            Console.Clear();
            return sauce;
        }

        public static string GetCheese()
        {
            string cheese = null;
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Cheese preferrence (one is required)");
                Console.WriteLine(" - Regular ($0)");
                Console.WriteLine(" - Extra ($1.25)");
                cheese = Console.ReadLine();
                if (cheese.ToLower() == "regular" || cheese.ToLower() == "extra")
                    quit = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid repsonse, try again: ");
                    Console.ReadLine();
                    continue;
                }
            }
            Console.Clear();
            return cheese;
        }

        public static string GetDelivery()
        {
            string delivery = null;
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Delivery preferrence (one is required)");
                Console.WriteLine(" - Take Out ($0)");
                Console.WriteLine(" - Delivery ($2.50)");
                delivery = Console.ReadLine();
                if (delivery.ToLower() == "take out" || delivery.ToLower() == "delivery")
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid repsonse, try again: ");
                    Console.ReadLine();
                    continue;
                }
            }
            Console.Clear();
            return delivery;
        }
    }


}
