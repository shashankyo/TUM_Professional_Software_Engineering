using System;
using System.IO;

namespace SimpleShop
{
    public static class SimpleShop
    {
        public static string[] ReadFileLineByLine(string path){
            var reader = new System.IO.StreamReader(path); // similar to Console.ReadLine but it reads input from files instead of Console
            var line_counter = 0;
            var needed_space = 0;
            // determine number of lines to create the correct size of array
            for (var line = ""; line != null; line = reader.ReadLine(), ++line_counter){
                if (line.Length > 0 && line[0] != '#'){
                    ++needed_space;
                }
            }

            // Set Position to beginning of file
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.DiscardBufferedData();
            
            // Read actual data
            var lines = new string[needed_space];
            
            for (var tag_lines = 0; line_counter > 1; --line_counter){
                var tmp = reader.ReadLine();
                if (tmp[0] == '#'){continue;}
                lines[tag_lines++] = tmp;
            }
            return lines;
        }

        static void PrintWelcome(){
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("#########################################\n" +
                          "#\t\t\t\t\t#\n" +
                          "#\tWelcome to the SimpleShop\t#\n" +
                          "#\t\t\t\t\t#\n#" +
                          "########################################\n\n");
            Console.ForegroundColor = tmp;
        }

        static void PrintInvoice(InvoicePosition ivp){
            Console.WriteLine(String.Join(", ",new string[]{
                ivp.Customer.Name, ivp.ItemName,ivp.Orders.ToString(), ivp.Price().ToString("0.##")
            }));
        }

        public static int Main(string[] args){
            // check if path to input file is provided
            if (args.Length != 1){
                Console.WriteLine("That is not how you use this shop!");
                return 1;
            }
            // check if input file exists at given path and whether it contains order data or not
            if (!File.Exists(args[0])){
                ReadFileLineByLine(args[0]);
                Console.WriteLine("Orders not found!");
                return 1;
            }
            
            PrintWelcome();
            var orders = ReadFileLineByLine(args[0]);
            Console.WriteLine("Invoices:");
            //Console.WriteLine(orders[1]);


            //#############################################################################
            //# Code to modify starts here:
            //# (1) Setup the ShopParser
            //# (2) Parse the "orders"
            //# (3) Create Invoices from "orders" (which should be in TAG format)
            //# (4) Output the sum for each customer, you must use the "PrintInvoice" function
            //#############################################################################

            Keyword keyNumberOne = new Keyword("ItemNumber", KeywordTypes.String);
            Keyword keyNumberTwo = new Keyword("ItemName", KeywordTypes.String);
            Keyword keyNumberThree = new Keyword("CustomerName", KeywordTypes.String);
            Keyword keyNumberFour = new Keyword("AmountOrdered", KeywordTypes.String);
            Keyword keyNumberFive = new Keyword("NetPrice", KeywordTypes.String);
            Keyword keyNumberSix = new Keyword("CustomerType", KeywordTypes.String);
            Keyword[] shopKeywordArray = { keyNumberOne, keyNumberTwo, keyNumberThree, keyNumberFour, keyNumberFive, keyNumberSix };

            ShopParser shopParser = new ShopParser();
            shopParser.SetKeywords(shopKeywordArray);
            foreach (var order in orders)
            {
                var parsedOrders = ShopParser.ExtractFromTAG(shopParser, order);
                InvoicePosition orderInvoice = InvoicePosition.CreateFromPairs(parsedOrders);
                PrintInvoice(orderInvoice);
            }
            //foreach (var i in parsedOrders)
            //{
            //    Console.WriteLine(i.Key.GetString());
            //    Console.WriteLine(i.Value);
            //}



            return 0;
        }
    }
}
