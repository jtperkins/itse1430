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
        
        //private double small = 5;
        //private double medium = 6.25;
        //private double large = 8.75;
       

        //private double traditional = 0;
        //private double garlic = 1;
        //private double oregano = 1;
        //private double regular = 0;
        //private double extra = 1.25;
        //private double takeOut = 0;


        public Order()
        {

        }

        public Order(string size, ArrayList meats, ArrayList vegetables, string sauce, string cheese, string delivery)
        {
            this.size = size;
            this.meats = meats;
            this.vegetables = vegetables;
            this.sauce = sauce;
            this.cheese = cheese;
            this.delivery = delivery;
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
            price += sizePrice(size);
            price += meatPrice(meats);
            price += vegPrice(vegetables);
            price += saucePrice(sauce);
            price += deliveryPrice(delivery);
            return price;
        }

        public void displayOrder()
        {
            //TODO: Format pricing on displayOrder()
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
    }

    
}
