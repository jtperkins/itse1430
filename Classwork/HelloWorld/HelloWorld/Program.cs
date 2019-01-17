/*
 * Multi line comment
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    // Single line comment
    class Program
    {
        static void Main( string[] args )
        {
            string name;

            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();

            Console.Write("Hello ");
            Console.WriteLine(name);
        }
    }
}
