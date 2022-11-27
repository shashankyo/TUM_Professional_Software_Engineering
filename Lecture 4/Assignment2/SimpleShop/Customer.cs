namespace SimpleShop{

    public class Customer
    {
        public const decimal ValueAddedTax = 0.19m;
        public string Name = "";
        public string CustomerType = "";
        public virtual decimal CalculatePrice(decimal basePrice)
        {
            return (1 + ValueAddedTax) * basePrice;
        }
      
        public static Customer CreateCustomer(string name, string customerType = "")
        {
            if (customerType == "Company")
            {
                Company company = new Company();
                company.Name = name;
                return company;
            }
            if (customerType == "Student")
            {
                Student student = new Student();
                student.Name = name;
                return student;
            }
            else
            {
                Customer customer = new Customer();
                customer.Name = name;
                return customer;
            }

        }
    }
    public class Company : Customer
    {
        public override decimal CalculatePrice(decimal basePrice)
        {
            return  basePrice;
        }
    }
    public class Student : Customer
    {
        public override decimal CalculatePrice(decimal basePrice)
        {

            decimal discount = 0.8m;
            return (1 + ValueAddedTax) * (Decimal.Multiply(basePrice, discount));
        }
    }
}