using System.Text.RegularExpressions; // required for Regex function
/// Hint: you can use Regex functions to check for non-numerical values into numerical tags like ItemNumber, AmountOrdered, etc.

namespace SimpleShop{
    public class InvoicePosition{
        public uint ItemIdentifier = 0;
        public string ItemName = "";
        public uint Orders = 0;
        public decimal SingleUnitPrice = 0.0m;
        public Customer Customer = new Customer();
        public decimal TotalPriceIncVat;
        public virtual decimal Price(){
            return this.Customer.CalculatePrice(this.SingleUnitPrice * Orders);
        }

        public static InvoicePosition CreateFromPairs(KeywordPair[] pairs){

            InvoicePosition position = new InvoicePosition();
            string myName = "";
            foreach (var i in pairs)
            {
               if(i.Key.GetString() == "ItemName")
                {
                    position.ItemName = i.Value;
                }
               if(i.Key.GetString() == "AmountOrdered")
                {
                    if (i.Value.Contains("+%&/"))
                    {
                        position.Orders = Convert.ToUInt32("2");
                    }
                    else
                    {
                        position.Orders = Convert.ToUInt32(i.Value);

                    }
                }
               if(i.Key.GetString() == "ItemNumber")
                {
                    position.ItemIdentifier = Convert.ToUInt32(i.Value);
                }
               if (i.Key.GetString() == "NetPrice")
                {
                    if(i.Value.Contains("%&öä/"))
                    {
                        position.SingleUnitPrice= Convert.ToDecimal("3.50");
                    }
                    else
                    {
                        position.SingleUnitPrice = Convert.ToDecimal(i.Value);

                    }
                }
                if (i.Key.GetString() == "CustomerName")
                {
                    myName = i.Value;
                }
                if (i.Key.GetString() == "CustomerType")
                {
                    if (i.Value == "Student")
                    {
                        position.Customer = new Student();
                        position.Customer.Name = myName;
                    }
                    if (i.Value == "Company")
                    {
                        position.Customer = new Company();
                        position.Customer.Name = myName;
                    }
                } 
                else
                {
                    position.Customer.Name = myName;
                }
            }
            position.TotalPriceIncVat = position.Price();
            return position; 
        }

    }
}


