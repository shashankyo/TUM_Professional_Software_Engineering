using System.Text.RegularExpressions; // required for Regex function
/// Hint: you can use Regex functions to check for non-numerical values into numerical tags like ItemNumber, AmountOrdered, etc.

namespace SimpleShop{
    public class InvoicePosition{
        public uint ItemIdentifier = 0;
        public string ItemName = "";
        public uint Orders = 0;
        public decimal SingleUnitPrice = 0.0m;
        public Customer Customer;
        public decimal TotalPriceIncVat;
        public virtual decimal Price(){
            return this.Customer.CalculatePrice(this.SingleUnitPrice * Orders);
        }

        public static InvoicePosition CreateFromPairs(KeywordPair[] pairs){

            //Regex regex = new Regex(@"^\d$");
            InvoicePosition position = new InvoicePosition();
            KeywordPair[] sortedArray = new KeywordPair[pairs.Length];
            foreach (var i in pairs)
            {
               if(i.Key.GetString() == "ItemName")
                {
                    sortedArray[1] = i;
                }
               if(i.Key.GetString() == "AmountOrdered")
                {
                    //if(regex.IsMatch(i.Value) == false)
                    //{
                    //    sortedArray[3] = new KeywordPair(new Keyword("AmountOrdered"),"2");
                    //}
                    //else
                    //{
                    //    sortedArray[3] = i;
                    //}
                    sortedArray[3] = i;
                }
               if(i.Key.GetString() == "ItemNumber")
                {
                    sortedArray[0] = i;
                }
               if (i.Key.GetString() == "NetPrice")
                {
                    //if (regex.IsMatch(i.Value) == false)
                    //{
                    //    Console.WriteLine("yeni regex hikayesi");
                    //    sortedArray[4] = new KeywordPair(new Keyword("NetPrice"), "3.50");
                    //}
                    //else
                    //{
                    //    sortedArray[4] = i;
                    //}
                    sortedArray[4] = i;
                }
                if (i.Key.GetString() == "CustomerName")
                {
                    sortedArray[2] = i;
                    position.Customer = new Customer();
                    position.Customer.Name = i.Value;
                }
                if (i.Key.GetString() == "CustomerType")
                {
                    if (i.Value == "Student")
                    {
                        position.Customer = new Student();
                    }
                    if (i.Value == "Company")
                    {
                        position.Customer = new Company();
                    }
                }
            }
            position.ItemIdentifier = Convert.ToUInt32(sortedArray[0].Value);
            position.ItemName = sortedArray[1].Value;
            position.Orders = Convert.ToUInt32(sortedArray[3].Value);
            position.SingleUnitPrice = Convert.ToDecimal(sortedArray[4].Value);
            //if (position.Customer == null)
            //{
            //    position.Customer = new Customer();
            //    position.Customer.Name = sortedArray[2].Value;
            //}
            position.Customer = new Customer();
            position.Customer.Name = sortedArray[2].Value;
            position.TotalPriceIncVat = position.Price();
 
            
            return position; 
        }

    }
}


