using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                Console.WriteLine("###################################################");
                Console.WriteLine("###                                             ###");
                Console.WriteLine("###               REFLECTION IN C#              ###");
                Console.WriteLine("###                                             ###");
                Console.WriteLine("###################################################");
                Console.WriteLine("Developed by: Kevoy Walters, University of Technology");
                Console.WriteLine();
                Console.WriteLine("< Reflection provides objects (of type Type) that describe assemblies, modules and types.");
                Console.WriteLine("You can use reflection to dynamically create an instance of a type, bind the type to an existing object");
                Console.WriteLine(", or get the type from an existing object and invoke its methods or access its fields and properties.");
                Console.WriteLine("If you are using attributes in your code, reflection enables you to access them. >");
                Console.WriteLine();
                Console.WriteLine("Please enter type Name <System.String>");
                String name = Console.ReadLine();
                try
                {
                    Type type = Type.GetType(name);
                    //Console.WriteLine(type.Name);

                    PropertyInfo[] properties = type.GetProperties();
                    Console.WriteLine();
                    Console.WriteLine("###################################");
                    Console.WriteLine("     PROPERTIES OF {0}         ", name.ToUpper());
                    Console.WriteLine("###################################");
                    foreach (PropertyInfo prop in properties)
                    {
                        Console.WriteLine("\t" + prop.Name + "\t\t");
                    }
                    Console.WriteLine("###################################");

                    MethodInfo[] methods = type.GetMethods();
                    Console.WriteLine();
                    Console.WriteLine("###################################");
                    Console.WriteLine("     METHODS OF {0}         ", name.ToUpper());
                    Console.WriteLine("###################################");
                    foreach (MethodInfo meth in methods)
                    {
                        Console.WriteLine("\t" + meth.Name + "\t\t");
                    }
                    Console.WriteLine("###################################");

                    ConstructorInfo[] constructors = type.GetConstructors();
                    Console.WriteLine();
                    Console.WriteLine("###################################");
                    Console.WriteLine("     CONSTRUCTORS OF {0}         ", name.ToUpper());
                    Console.WriteLine("###################################");
                    foreach (ConstructorInfo con in constructors)
                    {
                        Console.WriteLine("\t" + con.ToString() + "\t\t");
                    }
                    Console.WriteLine("###################################");
                    continueProgram = false;
                    if(continueProgram == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Thanks for using this program to demonstrate reflection in C#".ToUpper());
                    }
                }
                catch (Exception e)
                {
                    String filePath = @"C:\SampleFiles\ExceptionLog.txt";
                    StreamWriter sw = new StreamWriter(filePath, true);
                    sw.WriteLine(e.Message + "\n" + e.StackTrace);
                    sw.Close();
                    Console.WriteLine("Cannot retrieve Type name...Is Not valid");
                    Console.WriteLine("Tyr again? (y/n)");
                    String loop = Console.ReadLine();
                    if (loop == "y")
                    {
                        continueProgram = true;
                        Console.Clear();
                    }
                    else if (loop == "n")
                    {
                        continueProgram = false;
                    }
                }
            }
        }
    }
}
