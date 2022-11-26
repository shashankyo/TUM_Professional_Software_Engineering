using System.Text.RegularExpressions; // required for Regex function
/// Hint: you can use Regex functions to check for non-numerical values into numerical tags like ItemNumber, AmountOrdered, etc.

namespace SimpleShop{
    public class InvoicePosition{
        public uint ItemIdentifier = 0;
        public string ItemName = "";
        public uint Orders = 0;
        public decimal SingleUnitPrice = 0.0m;
        public Customer Customer;

        public virtual decimal Price(){
            return this.Customer.CalculatePrice(this.SingleUnitPrice * Orders);
        }

        public static InvoicePosition CreateFromPairs(KeywordPair[] pairs){

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
                    sortedArray[3] = i;
                }
               if(i.Key.GetString() == "ItemNumber")
                {
                    sortedArray[0] = i;
                }
               if (i.Key.GetString() == "NetPrice")
                {
                    sortedArray[4] = i;
                }
            }
            position.ItemIdentifier = Convert.ToUInt32(sortedArray[0].Value);
            position.ItemName = sortedArray[1].Value;
            position.Customer = new Customer();
            position.Orders = Convert.ToUInt32(sortedArray[3].Value);
            position.SingleUnitPrice = Convert.ToDecimal(sortedArray[4].Value);
            return position; 
        }

    }
}


