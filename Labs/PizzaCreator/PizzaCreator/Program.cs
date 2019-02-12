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
            Menu.DisplayMenu(order);
        }
    }
}
