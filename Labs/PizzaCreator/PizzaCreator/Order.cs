using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreator
{
    class Order
    {
        public string size;
        public ArrayList meats;
        public ArrayList vegetables;
        public string sauce;
        public string cheese;
        public string delivery;
        private bool hasOrdered;

        public Order()
        {
            hasOrdered = false;
        }

        public Order(string size, ArrayList meats, ArrayList vegetables, string sauce, string cheese, string delivery)
        {
            this.size = size;
            this.meats = meats;
            this.vegetables = vegetables;
            this.sauce = sauce;
            this.cheese = cheese;
            this.delivery = delivery;
            hasOrdered = true;
        }

        public static void NewOrder(Order order)
        {
            if (!order.madeOrder())
            {
                Console.Clear();
                GetOrder(order);
                Console.Clear();
            } else
            {
                string choice;
                Console.WriteLine("");
                Console.WriteLine("An order is already created, would you like to start over? (Y/N) ");
                switch (choice = Console.ReadLine().ToLower())
                {
                    case "y":
                        order.hasOrdered = false;
                        NewOrder(order);
                        break;
                    case "n":
                        Console.Clear();
                        Menu.DisplayMenu(order);
                        break;
                }
            }
        }

        public static void ModifyOrder(Order order)
        {
            if (!order.madeOrder())
            {
                Console.WriteLine("No order to modify.");
                Console.ReadLine();
                Console.Clear();
                Menu.DisplayMenu(order);
            }
            else
            {
                Console.Clear();
                order.displayOrder();
                Console.WriteLine("");
                Console.WriteLine("Are you sure you want to modify your order? (Y/N)");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        Console.Clear();
                        GetOrder(order);
                        break;
                    case "n":
                        Console.Clear();
                        Menu.DisplayMenu(order);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.ReadLine();
                        Console.Clear();
                        ModifyOrder(order);
                        break;
                }
                Console.Clear();
                Menu.DisplayMenu(order);
            }
        }

        public static void DisplayOrder(Order order)
        {
            if (!order.madeOrder())
            {
                Console.WriteLine("No order to display.");
                Console.ReadLine();
                Console.Clear();

                Menu.DisplayMenu(order);
            }
            else
            {
                order.displayOrder();
            }
        }

        public static void GetOrder(Order order)
        {
            ArrayList meats = new ArrayList();
            ArrayList vegetables = new ArrayList();

            order = new Order(Menu.getSize(), Menu.getMeats(meats), Menu.getVegetables(vegetables), Menu.getSauce(), Menu.getCheese(), Menu.getDelivery());

            order.displayOrder();

            Console.WriteLine("");
            Console.WriteLine("Does your order look right? (Y/N) ");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    Console.Clear();
                    //quit = true;
                    Menu.DisplayMenu(order);
                    break;
                case "n":
                    Console.Clear();
                    GetOrder(order);
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    break;
            }
        }

        public double sizePrice(string size)
        {
            switch (size.ToLower())
            {
                case "small": return 5;
                case "medium": return 6.25;
                case "large": return 8.75;
                default: return 5;
            }
        }

        public double meatPrice(ArrayList meats)
        {
            return meats.Count * 0.75;
        }

        public double vegPrice(ArrayList vegs)
        {
            return vegs.Count * 0.50;
        }

        public double saucePrice(string sauce)
        {
            switch (sauce.ToLower())
            {
                case "traditional": return 0;
                case "garlic": return 1;
                case "oregano": return 1;
                default: return 0;
            }
        }

        public double deliveryPrice(string delivery)
        {
            switch (delivery.ToLower())
            {
                case "take out": return 0;
                case "delivery": return 2.50;
                default: return 0;
            }
        }

        public double totalPrice()
        {
            double price = 0;
            price += sizePrice(this.size);
            price += meatPrice(this.meats);
            price += vegPrice(this.vegetables);
            price += saucePrice(this.sauce);
            price += deliveryPrice(this.delivery);
            return price;
        }

        public void displayOrder()
        {
            Console.WriteLine("{0} pizza\t\t{1:C}", size, sizePrice(size));
            if (delivery.ToLower().CompareTo("take out") == 0)
            {
                Console.WriteLine(delivery);
            }
            else
            {
                Console.WriteLine("{0}\t\t{1:C}", delivery, deliveryPrice(delivery));
            }
            Console.WriteLine("Meats");
            foreach (string meat in meats)
            {
                if (meat.ToLower().CompareTo("pepperoni") == 0)
                    Console.WriteLine("\t{0}\t{1:C}", meat, .75);
                else
                    Console.WriteLine("\t{0}\t\t{1:C}", meat, .75);
                
            }
            Console.WriteLine("Vegetables");
            foreach (string veg in vegetables)
            {
                if (veg.ToLower().CompareTo("mushrooms") == 0 || veg.ToLower().CompareTo("black olives") == 0)
                    Console.WriteLine("\t{0}\t{1:C}", veg, .50);
                else
                    Console.WriteLine("\t{0}\t\t{1:C}", veg, .50);
            }
            Console.WriteLine("Sauce");
            if (sauce.ToLower() == "traditional")
            {
                Console.WriteLine("\t" + sauce);
            }
            else
            {
                Console.WriteLine("\t{0}\t\t{1:C}", sauce, saucePrice(sauce));
            }
            for (int i = 0; i < 30; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            Console.WriteLine("Total\t\t\t{0:C}", totalPrice());
        }

        public bool madeOrder()
        {
            return hasOrdered;
        }
    }

    
}
