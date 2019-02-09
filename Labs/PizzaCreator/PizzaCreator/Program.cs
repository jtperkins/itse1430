using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreator
{
    class Program
    {
        //static string choice = null;
        //static bool quit = false;
        public static Order order = new Order();
        ArrayList list = new ArrayList();
        static Menu menu = new Menu();

        static void Main(string[] args)
        {
            

            //while (!quit)
            //{
            //    menu.DisplayMenu();
            //}

            Menu.DisplayMenu(order);
            
        }

        //void DisplayMenu()
        //{
        //    string choice;
        //    if (order == null)
        //    {
        //        Console.WriteLine("\t\t\t\t      ----------------------------------");
        //        Console.WriteLine("\t\t\t\t\t**Current order total: {0:C}**", 0);
        //        Console.WriteLine("\t\t\t\t      ----------------------------------");
        //    } else
        //    {
        //        Console.WriteLine("\t\t\t\t      ----------------------------------");
        //        Console.WriteLine("\t\t\t\t\t**Current order total: {0:C}**", order.totalPrice());
        //        Console.WriteLine("\t\t\t\t      ----------------------------------");
        //    }

        //    Console.WriteLine("1. New Order");
        //    Console.WriteLine("2. Modify Order");
        //    Console.WriteLine("3. Display Order");
        //    Console.WriteLine("4. Quit");
        //    Console.WriteLine("Please enter your choice (1 - 4)");

        //    choice = Console.ReadLine();

        //    //ProcessChoice(choice);

        //}

        //static void NewOrder()
        //{
        //    if (order == null)
        //    {
        //        Console.Clear();
        //        GetOrder();
        //        Console.Clear();
        //    }
        //    else
        //    {
        //        string choice;
        //        Console.WriteLine("");
        //        Console.WriteLine("An order is already created, would you like to start over? (Y/N) ");
        //        switch (choice = Console.ReadLine().ToUpper())
        //        {
        //            case "Y": order = null;
        //                NewOrder();
        //                break;
        //            case "N": Console.Clear();
        //                DisplayMenu();
        //                break;
        //        }
        //    }
        //}

        //static void ModifyOrder()
        //{
        //    if (order == null)
        //    {
        //        Console.WriteLine("No order to modify.");
        //        Console.ReadLine();
        //        Console.Clear();
        //        DisplayMenu();
        //    }
        //    else
        //    {
        //        Console.Clear();
        //        order.displayOrder();
        //        Console.WriteLine("");
        //        Console.WriteLine("Are you sure you want to modify your order? (Y/N)");
        //        switch (Console.ReadLine().ToLower())
        //        {
        //            case "y": Console.Clear();
        //                GetOrder();
        //                break;
        //            case "n": Console.Clear();
        //                DisplayMenu();
        //                break;
        //            default: Console.WriteLine("Invalid input");
        //                Console.ReadLine();
        //                Console.Clear();
        //                //ModifyOrder();
        //                break;
        //        }
        //        Console.Clear();
        //        //order.displayOrder();
        //        //Console.ReadLine();
        //        //Console.Clear();
        //        DisplayMenu();
        //    }
        //}

        //static void DisplayOrder()
        //{
        //    if (order == null)
        //    {
        //        Console.WriteLine("No order to display.");
        //        Console.ReadLine();
        //        Console.Clear();
                
        //        DisplayMenu();
        //    }
        //    else
        //    {
        //        order.displayOrder();
        //    }  
        //}

        //public static void GetOrder()
        //{
        //    string size;
        //    ArrayList meats = new ArrayList();
        //    ArrayList vegetables = new ArrayList();
        //    string sauce;
        //    string cheese;
        //    string delivery;

        //    //size = getSize();
        //    //meats = getMeats(meats);
        //    //vegetables = getVegetables(vegetables);
        //    //sauce = getSauce();
        //    //cheese = getCheese();
        //    //delivery = getDelivery();

        //    //debugging purposes
        //    //foreach (var item in meats)
        //    //{
        //    //    Console.WriteLine(item);
        //    //}

        //    //foreach (var item in vegetables)
        //    //{
        //    //    Console.WriteLine(item);
        //    //}

        //    //order = new Order(size, meats, vegetables, sauce, cheese, delivery);

        //    order.displayOrder();

        //    Console.WriteLine("");
        //    Console.WriteLine("Does your order look right? (Y/N) ");
        //    switch (Console.ReadLine().ToLower())
        //    {
        //        case "y": Console.Clear();
        //            //quit = true;
        //            DisplayMenu();
        //            break;
        //        case "n":
        //            Console.Clear();
        //            GetOrder();
        //            break;
        //        default:
        //            Console.WriteLine("Invalid input, try again");
        //            break;
        //    }

        //    //return order;
        //}

        //static string getSize()
        //{
        //    string size = null;
        //    bool quit = false;

        //    while (!quit)
        //    {
        //        Console.WriteLine("Choose a size (one is required)");
        //        Console.WriteLine(" - Small ($5)");
        //        Console.WriteLine(" - Medium ($6.25)");
        //        Console.WriteLine(" - Large ($8.75)");
        //        size = Console.ReadLine();
        //        if (size.ToLower() == "small" || size.ToLower() == "medium" || size.ToLower() == "large")
        //            quit = true;
        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Invalid repsonse, try again: ");
        //            Console.WriteLine("");
        //            //getSize();
        //        }
                    
        //    }
        //    Console.Clear();
        //    return size;
        //}

        //static ArrayList getMeats(ArrayList list)
        //{
        //    string meats = null;
        //    bool quit = false;

            

        //    while (!quit)
        //    {
        //        Console.WriteLine("Meats (zero or more). Each option is $0.75 extra");
        //        Console.WriteLine("please choose one meat at a time (type none if none desired): ");
        //        Console.WriteLine(" - Bacon");
        //        Console.WriteLine(" - Ham");
        //        Console.WriteLine(" - Pepperoni");
        //        Console.WriteLine(" - Sausage");
        //        meats = Console.ReadLine();
        //        if (meats.ToLower() == "bacon" || meats.ToLower() == "pepperoni" || meats.ToLower() == "ham" || meats.ToLower() == "sausage" || meats.ToLower() == "none")
        //        {
        //            if (meats.ToLower() == "none")
        //            {
        //                return list;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Would you like to choose another? (Y/N) ");
        //                switch (Console.ReadLine().ToLower())
        //                {
        //                    case "y":
        //                        list.Add(meats);
        //                        Console.Clear();
        //                        //quit = true;
        //                        continue;

        //                    case "n":
        //                        list.Add(meats);
        //                        Console.Clear();
        //                        return list;
        //                    default:
        //                        Console.Clear();
        //                        Console.WriteLine("Invalid repsonse, try again: ");
        //                        Console.ReadLine();
        //                        Console.Clear();
        //                        break;
        //                }
        //            }
        //        }
                    
        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Invalid repsonse, try again: ");
        //            Console.ReadLine();
        //            continue;
        //        }

        //    }
        //    return list;
        //}

        //static ArrayList getVegetables(ArrayList list)
        //{
        //    string vegetables = null;
        //    bool quit = false;



        //    while (!quit)
        //    {
        //        Console.WriteLine("Vegetables (zero or more). Each option is $0.50 extra");
        //        Console.WriteLine("please choose one veggie at a time (type none if none desired): ");
        //        Console.WriteLine(" - Black olives");
        //        Console.WriteLine(" - Mushrooms");
        //        Console.WriteLine(" - Onions");
        //        Console.WriteLine(" - Peppers");
        //        vegetables = Console.ReadLine();
        //        if (vegetables.ToLower() == "black olives" || vegetables.ToLower() == "mushrooms" || vegetables.ToLower() == "onions" || vegetables.ToLower() == "peppers" || vegetables.ToLower() == "none")
        //        {
                    
        //            if (vegetables.ToLower().CompareTo("none") == 0)
        //            {
        //                return list;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Would you like to choose another? (Y/N) ");
        //                switch (Console.ReadLine().ToLower())
        //                {
        //                    case "y":
        //                        list.Add(vegetables);
        //                        Console.Clear();
        //                        continue;
        //                    case "n":
        //                        list.Add(vegetables);
        //                        Console.Clear();
        //                        return list;
        //                    default:
        //                        Console.Clear();
        //                        Console.WriteLine("Invalid repsonse, try again: ");
        //                        Console.ReadLine();
        //                        Console.Clear();
        //                        break;
        //                }
        //            }
        //        }

        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Invalid repsonse, try again: ");
        //            Console.ReadLine();
        //            continue;
        //        }

        //    }
        //    return list;
        //}

        //static string getSauce()
        //{
        //    string sauce = null;
        //    bool quit = false;

        //    while (!quit)
        //    {
        //        Console.WriteLine("Choose a sauce (one is required)");
        //        Console.WriteLine(" - Traditional ($0)");
        //        Console.WriteLine(" - Garlic ($1)");
        //        Console.WriteLine(" - Oregano ($1)");
        //        sauce = Console.ReadLine();
        //        if (sauce.ToLower() == "traditional" || sauce.ToLower() == "garlic" || sauce.ToLower() == "oregano")
        //            quit = true;
        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Invalid repsonse, try again: ");
        //            Console.ReadLine();
        //            continue;
        //        }

        //    }
        //    Console.Clear();
        //    return sauce;
        //}

        //static string getCheese()
        //{
        //    string cheese = null;
        //    bool quit = false;

        //    while (!quit)
        //    {
        //        Console.WriteLine("Cheese preferrence (one is required)");
        //        Console.WriteLine(" - Regular ($0)");
        //        Console.WriteLine(" - Extra ($1.25)");
        //        cheese = Console.ReadLine();
        //        if (cheese.ToLower() == "regular" || cheese.ToLower() == "extra")
        //            quit = true;
        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Invalid repsonse, try again: ");
        //            Console.ReadLine();
        //            continue;
        //        }

        //    }
        //    Console.Clear();
        //    return cheese;
        //}

        //static string getDelivery()
        //{
        //    string delivery = null;
        //    bool quit = false;

        //    while (!quit)
        //    {
        //        Console.WriteLine("Delivery preferrence (one is required)");
        //        Console.WriteLine(" - Take Out ($0)");
        //        Console.WriteLine(" - Delivery ($2.50)");
        //        delivery = Console.ReadLine();
        //        if (delivery.ToLower() == "take out" || delivery.ToLower() == "delivery")
        //            break;
        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Invalid repsonse, try again: ");
        //            Console.ReadLine();
        //            continue;
        //        }

        //    }
        //    Console.Clear();
        //    return delivery;
        //}

        //static void ProcessChoice(string choice)
        //{
        //    switch (choice)
        //    {
        //        case "1":
        //            NewOrder();
        //            break;
        //        case "2":
        //        Console.Clear();
        //        ModifyOrder();
        //            //Console.Clear();
        //            //if (order == null)
        //            //{
        //            //    Console.WriteLine("No order to modify");
        //            //}
        //            //else
        //            //{
        //            //    //order.displayOrder();
        //            //    ModifyOrder();
        //            //}
        //            //Console.ReadLine();
        //            //Console.Clear();
        //            break;
        //        //ModifyOrder();
        //        //break;
        //        case "3":
        //            Console.Clear();
        //            //quit = true;
        //            //if (order == null)
        //            //{
        //            //    Console.WriteLine("No order to display");
        //            //}
        //            //else
        //            //{
        //            //    order.displayOrder();
        //            //}
        //            DisplayOrder();
                    
        //            Console.ReadLine();
        //            Console.Clear();
        //            DisplayMenu();
        //            break;
        //        case "4":
        //            quit = true;
                    
        //            break;
        //        default:
        //            Console.Clear();
        //            Console.WriteLine("Invalid input, try again");
        //            Console.ReadLine();
        //            Console.Clear();
        //            break;
        //    }
        //}
    }
}
