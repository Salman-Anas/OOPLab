using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cartItems = new List<int>();
            List<product> products = new List<product>();
            List<user> users = new List<user>();
            List<record> records = new List<record>();

            products.Add(new product("Book", 50));
            cartItems.Add(5);
            products.Add(new product("Drnk", 70));
            cartItems.Add(6);
            CheckRateList(products);
            Console.ReadKey();
            CheckBill(products, cartItems);
            Console.ReadKey();
            //BuyProducts(products, cartItems);
            //MainMenu(users);
            //customer();
        }
        static void MainMenu(List<user> users)
        {

            int croption = 0;
            string[] options = { "Sign-In", "sign-Up", "Exit" };
            ConsoleKeyInfo key;
            int defaultCursorPosition = 7;

            Console.Clear();
            PrintHeader();
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(0, defaultCursorPosition + i);
                if (i == croption)
                {
                    ColorWrite(options[i]);
                }
                else
                {
                    Console.WriteLine(options[i]);
                }
            }

            while (true)
            {
                do
                {
                    key = Console.ReadKey();

                } while (key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.Enter);



                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    defaultWrite(options[croption]);

                    croption -= 1;
                    if (croption < 0)
                    {
                        croption += 3;
                    }
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    ColorWrite(options[croption]);
                    continue;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    defaultWrite(options[croption]);
                    croption = (croption + 1) % 3;
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    ColorWrite(options[croption]);
                    continue;
                }

                if (croption == 0)
                {
                    SignIn(users);
                    Console.WriteLine("press any key to continue....");
                    Console.ReadKey();
                }
                else if (croption == 1)
                {
                    SignUp(users);
                    Console.WriteLine("press any key to continue....");
                    Console.ReadKey();
                }
                else if (croption == 2)
                {
                    break;
                }
            }


        }
        static void SignIn(List<user> users)
        {
            string userName, password;
            int crIndex;
            Console.Clear();
            PrintHeader();
            Console.Write("Enter your username: ");
            userName = Console.ReadLine();
            Console.Write("Enter your password: ");
            password = Console.ReadLine();
            if (DoesUserNameExists(userName, users))
            {
                crIndex = UserNameIndex(userName, users);
                if (users[crIndex].password == password)
                {
                    Console.WriteLine("signed in as " + userName);
                }
                else
                {
                    Console.WriteLine("invalid password.....");
                    Console.Write("Enter 1 to try again, any other key to go back: ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        SignIn(users);
                    }
                    else
                    {
                        MainMenu(users);
                    }
                }
            }
            else
            {
                Console.WriteLine("user does not exist....");
                Console.Write("Enter 1 to try again, any other key to go back: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    SignIn(users);
                }
                else
                {
                    MainMenu(users);
                }
            }
        }
        static void SignUp(List<user> users)
        {
            string userName;
            string password;
            string role;
            Console.Clear();
            PrintHeader();
            Console.WriteLine("Enter userName: ");
            userName = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password = Console.ReadLine();

            Console.WriteLine("Enter your role(c for customer m for manager): ");
            role = Console.ReadLine();
            if (role == "m" || role == "u")
            {
                if (!DoesUserNameExists(userName, users))
                {
                    user s = new user(userName, password, role);
                    users.Add(s);
                    Console.WriteLine(userName + " addded");
                }
                else
                {
                    Console.WriteLine(userName + " already exists....");
                    Console.Write("Enter 1 to try again, any other key to go back: ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        SignUp(users);
                    }
                    else
                    {
                        MainMenu(users);
                    }
                }


            }
            else
            {
                Console.WriteLine("invalid role ");
                Console.Write("Enter 1 to try again, any other key to go back: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    SignUp(users);
                }
                else
                {
                    MainMenu(users);
                }
            }

        }
        static bool DoesUserNameExists(string userName, List<user> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].userName == userName)
                    return true;
            }
            return false;
        }

        static int UserNameIndex(string userName, List<user> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].userName == userName)
                {
                    return i;
                }
            }
            return -1;
        }

        static void customer()
        {
            int croption = 0;
            string[] options = { "Check rate list", "Buy Products", "Check Bill", "Pay bill", "exit" };
            ConsoleKeyInfo key;
            int defaultCursorPosition = 14;

            Console.Clear();
            PrintHeader();
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(0, defaultCursorPosition + i);
                if (i == croption)
                {
                    ColorWrite(options[i]);
                }
                else
                {
                    Console.WriteLine(options[i]);
                }
            }

            while (true)
            {
                do
                {
                    key = Console.ReadKey();

                } while (key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.Enter);



                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    defaultWrite(options[croption]);

                    croption -= 1;
                    if (croption < 0)
                    {
                        croption += 5;
                    }
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    ColorWrite(options[croption]);
                    continue;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    defaultWrite(options[croption]);
                    croption = (croption + 1) % 5;
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    ColorWrite(options[croption]);
                    continue;
                }

            }
        }

        static void CheckRateList(List<product> products)
        {
            Console.WriteLine("\t" + "Product".PadRight(20) + "price".PadRight(10));
            foreach (product product in products)
            {
                Console.WriteLine("\t" + product.productName.PadRight(20) + product.price.ToString().PadRight(10));
            }
        }

        static void BuyProducts(List<product> products, List<int> cartItems)
        {
            List<string> cloneProducts = new List<string>();

            for (int i = 0; i < products.Count; i++)
            {
                cloneProducts.Add(products[i].productName);
            }
            cloneProducts.Add("Done");
            int totalItems = cloneProducts.Count;

            int croption = 0;
            ConsoleKeyInfo key;
            int defaultCursorPosition = 7;

            Console.Clear();
            PrintHeader();
            for (int i = 0; i < cloneProducts.Count; i++)
            {
                Console.SetCursorPosition(0, defaultCursorPosition + i);
                if (i == croption)
                {
                    ColorWrite(cloneProducts[i]);
                }
                else
                {
                    Console.WriteLine(cloneProducts[i]);
                }
            }

            while (true)
            {
                Console.SetCursorPosition(0, defaultCursorPosition + cloneProducts.Count);
                Console.Write("                                ");
                do
                {
                    key = Console.ReadKey();

                } while (key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.Enter);



                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    defaultWrite(cloneProducts[croption]);

                    croption -= 1;
                    if (croption < 0)
                    {
                        croption += totalItems;
                    }
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    ColorWrite(cloneProducts[croption]);
                    continue;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    defaultWrite(cloneProducts[croption]);
                    croption = (croption + 1) % totalItems;
                    Console.SetCursorPosition(0, croption + defaultCursorPosition);
                    ColorWrite(cloneProducts[croption]);
                    continue;
                }
                if (croption == totalItems - 1)
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, defaultCursorPosition + cloneProducts.Count);
                    Console.Write("Enter Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    cartItems[croption] = quantity;
                }
            }
        }

        static void CheckBill(List<product> products, List<int> cartItems)
        {
            Console.WriteLine("\t" + "Product".PadRight(20) + "price".PadRight(10) + "Quantity".PadRight(10) + "Total".PadRight(10));
            for (int i = 0; i < products.Count; i++)
            {
                if (cartItems[i] != 0)
                {
                    Console.WriteLine("\t" + products[i].productName.PadRight(20) + products[i].price.ToString().PadRight(10)
                                       + cartItems[i].ToString().PadRight(10) + (products[i].price * cartItems[i]).ToString().PadRight(10));
                }
            }
        }

        static void payBill(List<product> products, List<int> cartItems,List<record> records)
        {
            int bill = 0;
            for (int i = 0; i < products.Count; i++)
            {
                bill += products[i].price * cartItems[i];
            }
            Console.WriteLine("Enter any key to pay bill");
            saveRecord(cartItems, products, records);
        }

        static void saveRecord(List<int> cartItems, List<product> products, List<record> records)
        {
            int recordIndex;
            for(int i = 0; i < cartItems.Count; i++)
            {
                if(cartItems[i] != 0)
                {
                    recordIndex = SearchRecord(products[i].productName, records);
                    records[recordIndex].totalQuantity += cartItems[i];

                }
            }
        }
        static int SearchRecord(string productName,List<record> records)
        {
            for(int i = 0; i < records.Count; i++)
            {
                if(productName == records[i].productName)
                {
                    return i;
                }
            }
            return -1;
        }
        static void ColorWrite(string text)
        {
            ConsoleColor colour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ForegroundColor = colour;
        }
        static void defaultWrite(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }
        static void PrintHeader()
        {
            Console.WriteLine(@"
            ____   ____ ____  ___ ____ _________ ___ ______ ______________        __ ______  ___  ____  ____
            || \\ ||   ||  \\// \\|| \\| || |||\\//||||   ||\ ||| || |// \\||    (( \| || | // \\ || \\||   
            ||  ))||== || _//||=||||_//  ||  || \/ ||||== ||\\||  ||  ||=||||     \\   ||  ((   ))||_//||== 
            ||__//||___||    || |||| \\  ||  ||    ||||___|| \||  ||  || ||||__| \_))  ||   \\_// || \\||___
                                                                                                                          
        ");
        }

    }
}