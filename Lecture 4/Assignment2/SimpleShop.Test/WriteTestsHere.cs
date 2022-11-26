using NUnit.Framework;
using SimpleShop;
using System.Security.Cryptography;
// Remember [UnitOfWork_StateUnderTest_ExpectedBehaviour]

namespace SimpleShop.Test
{
    public class Tests
    {
        /* test b was here*/
        [SetUp]
        public void Setup(){
        }
        
        /// <summary>
        /// Check if the Keyword opening is modified with added <Keyword> 
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Keyword")]
        public void Parsing_KeywordStartTag_AddedBraces(){

            Keyword newkeyword = new Keyword("TestKeyword");
            Assert.That(newkeyword.GetStart(),Is.EqualTo("<TestKeyword>"));
        }
        
        /// <summary>
        /// Check if the Keyword closing is modified with added </Keyword>
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Keyword")]
        public void Parsing_KeywordEndTag_AddedSlashAndBraces(){

            Keyword newkeyword = new Keyword("TestKeyword");
            Assert.That(newkeyword.GetEnd(), Is.EqualTo("</TestKeyword>"));
        }
        
        /// <summary>
        /// Set the Keywords an check if they are valid.
        /// Rating 1
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_SetKeywords_OrderOfKeywordsIsCorrect(){

            Keyword[] testKeywordArray = new Keyword[2];
            Keyword newkeyword = new Keyword("TestKeyword");
            Keyword newkeyword2 = new Keyword("KorayKeyword");

            testKeywordArray[0] = newkeyword;
            testKeywordArray[1] = newkeyword2;

            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);
            Assert.That(testParser.GetKeywords, Is.EqualTo(testKeywordArray));
        }
        
        /// <summary>
        /// Set the Keyword types and check if they are valid.
        /// Rating 1
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void ShopParser_SetKeyword_Typ()
        {
            Keyword[] testKeywordArray = new Keyword[3];
            Keyword newKeyword = new Keyword("TestKeyword", KeywordTypes.String);
            Keyword newKeyword2 = new Keyword("3", KeywordTypes.Int);
            Keyword newKeyword3 = new Keyword("2,11", KeywordTypes.Decimal);

            testKeywordArray[0] = newKeyword;
            testKeywordArray[1] = newKeyword2;
            testKeywordArray[2] = newKeyword3;
            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);
            var a = testParser.GetKeywords(); // to do. naming will be corrected
            
            Assert.That(a[0].WhichType(),Is.EqualTo(KeywordTypes.String));
            Assert.That(a[1].WhichType(), Is.EqualTo(KeywordTypes.Int));
            Assert.That(a[2].WhichType(), Is.EqualTo(KeywordTypes.Decimal));

        }
        
        
        /// <summary>
        /// Check if the parser works correctly. Make examples and see if you can find problems with the code.
        /// Literals represent KeywordPairs with different Keywords
        /// A B C D
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_ValidFindings_True(){
            Keyword keyNumberOne = new Keyword("ItemNumber", KeywordTypes.String);
            Keyword keyNumberTwo = new Keyword("ItemName", KeywordTypes.String);
            Keyword keyNumberThree = new Keyword("CustomerName", KeywordTypes.String);
            Keyword keyNumberFour = new Keyword("AmountOrdered", KeywordTypes.String);
            Keyword keyNumberFive = new Keyword("NetPrice", KeywordTypes.String);
            Keyword[] testKeywordArray = { keyNumberOne, keyNumberTwo, keyNumberThree, keyNumberFour, keyNumberFive};

            KeywordPair firstPair = new KeywordPair(keyNumberOne, "1");
            KeywordPair secondPair = new KeywordPair(keyNumberTwo, "Burger");
            KeywordPair threePair = new KeywordPair(keyNumberThree, "James T. Kirk");
            KeywordPair fourPair = new KeywordPair(keyNumberFour, "2");
            KeywordPair fivePair = new KeywordPair(keyNumberFive, "8.00");
            KeywordPair[] sampleKeywordPairArray = { firstPair, secondPair, threePair, fourPair, fivePair};

            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);

            var mysample = SimpleShop.ReadFileLineByLine("D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 4\\Assignment2\\SimpleShop.Test\\SampleOrder.tag");

            var myFindings = ShopParser.ExtractFromTAG(testParser, mysample.First());
            //Console.WriteLine(myFindings[1].Value);
            //Console.WriteLine(myFindings[3].Key.GetString());
            //Console.WriteLine(sampleKeywordPairArray[3].Key.GetString());
            //ShopParser.ValidateFindings(myFindings);
            //Test tam olmadi!
            //Assert.That(myFindings, Is.EqualTo(sampleKeywordPairArray));
            Assert.That(ShopParser.ValidateFindings(myFindings), Is.EqualTo(true));
            myFindings[0];
            //Assert.That(ShopParser.ValidateFindings(sampleKeywordPairArray),Is.EqualTo(true));

            //
            //
            // ***** PROBLEM IN CODE *****
            //
            // 
            // 
            //
            //

        }

        /// <summary>
        /// Check if the parser works correctly. This time you should check if repetition invalidates the findings.
        /// A A B B C C
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_InvalidatedFindingsWithRepeatedEntry_False(){
            Keyword keyNumberOne = new Keyword("ItemNumber", KeywordTypes.String);
            Keyword keyNumberTwo = new Keyword("ItemName", KeywordTypes.String);
            Keyword keyNumberThree = new Keyword("CustomerName", KeywordTypes.String);
            Keyword keyNumberFour = new Keyword("AmountOrdered", KeywordTypes.String);
            Keyword keyNumberFive = new Keyword("NetPrice", KeywordTypes.String);
            Keyword[] testKeywordArray = { keyNumberOne, keyNumberTwo, keyNumberThree, keyNumberFour, keyNumberFive };

            KeywordPair firstPair = new KeywordPair(keyNumberOne, "4");
            KeywordPair secondPair = new KeywordPair(keyNumberTwo, "Coke");
            KeywordPair threePair = new KeywordPair(keyNumberThree, "James T. Kirk");
            KeywordPair fourPair = new KeywordPair(keyNumberFour, "1");
            KeywordPair fivePair = new KeywordPair(keyNumberFive, "2.50");
            KeywordPair[] sampleKeywordPairArray = { firstPair, secondPair, threePair, fourPair, fivePair };

            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);

            var mysample = SimpleShop.ReadFileLineByLine("D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 4\\Assignment2\\SimpleShop.Test\\SampleOrder.tag");

            var myFindings = ShopParser.ExtractFromTAG(testParser, mysample[1]);
            Console.WriteLine(mysample[1]);
            Console.WriteLine(myFindings[1].Value);
            Console.WriteLine("----");

            //Assert.That(myFindings, Is.EqualTo(sampleKeywordPairArray));
            Assert.That(ShopParser.ValidateFindings(myFindings), Is.EqualTo(false));
        }
        
        /// <summary>
        /// Check if the parser works correctly. This time with circular keywords.
        /// A B C A
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_InvalidatedFindingsCircular_False(){
            Keyword keyNumberOne = new Keyword("ItemNumber", KeywordTypes.String);
            Keyword keyNumberTwo = new Keyword("ItemName", KeywordTypes.String);
            Keyword keyNumberThree = new Keyword("CustomerName", KeywordTypes.String);
            Keyword keyNumberFour = new Keyword("AmountOrdered", KeywordTypes.String);
            Keyword keyNumberFive = new Keyword("NetPrice", KeywordTypes.String);
            Keyword[] testKeywordArray = { keyNumberOne, keyNumberTwo, keyNumberThree, keyNumberFour, keyNumberFive };

            KeywordPair firstPair = new KeywordPair(keyNumberOne, "2");
            KeywordPair secondPair = new KeywordPair(keyNumberTwo, "IceCream");
            KeywordPair threePair = new KeywordPair(keyNumberThree, "S'chn T'gai Spock");
            KeywordPair fourPair = new KeywordPair(keyNumberFour, "7");
            KeywordPair fivePair = new KeywordPair(keyNumberFive, "4.50");
            KeywordPair[] sampleKeywordPairArray = { firstPair, secondPair, threePair, fourPair, fivePair };

            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);


            Console.WriteLine("--");
            var mysample = SimpleShop.ReadFileLineByLine("D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 4\\Assignment2\\SimpleShop.Test\\SampleOrder.tag");

            Console.WriteLine("----");
            var myFindings = ShopParser.ExtractFromTAG(testParser, mysample[2]);
            Console.WriteLine(mysample[2]);
            Console.WriteLine(myFindings[0].Value);
            Console.WriteLine("----");

            //Assert.That(myFindings, Is.EqualTo(sampleKeywordPairArray));
            Assert.That(ShopParser.ValidateFindings(myFindings), Is.EqualTo(false)); 
        }
        
        /// <summary>
        /// See Tagfile (SampleOrder.tag) for more information. Are the correct number of keywords recognized ? 
        /// Rating 1
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_KeywordsSetTagString_CorrectNumberOfEntries(){
            Keyword keyNumberOne = new Keyword("ItemNumber", KeywordTypes.String);
            Keyword keyNumberTwo = new Keyword("ItemName", KeywordTypes.String);
            Keyword keyNumberThree = new Keyword("CustomerName", KeywordTypes.String);
            Keyword keyNumberFour = new Keyword("AmountOrdered", KeywordTypes.String);
            Keyword keyNumberFive = new Keyword("NetPrice", KeywordTypes.String);
            Keyword[] testKeywordArray = { keyNumberOne, keyNumberTwo, keyNumberThree, keyNumberFour, keyNumberFive };

            KeywordPair firstPair = new KeywordPair(keyNumberOne, "1");
            KeywordPair secondPair = new KeywordPair(keyNumberTwo, "Burger");
            KeywordPair threePair = new KeywordPair(keyNumberThree, "James T. Kirk");
            KeywordPair fourPair = new KeywordPair(keyNumberFour, "2");
            KeywordPair fivePair = new KeywordPair(keyNumberFive, "8.00");
            KeywordPair[] sampleKeywordPairArray = { firstPair, secondPair, threePair, fourPair, fivePair };

            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);

            Console.WriteLine("--");
            var mysample = SimpleShop.ReadFileLineByLine("D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 4\\Assignment2\\SimpleShop.Test\\SampleOrder.tag");

            Console.WriteLine("----");
            var myFindings = ShopParser.ExtractFromTAG(testParser, mysample.First());
            Console.WriteLine(myFindings[1].Value);
            Console.WriteLine("----");
            Console.WriteLine(myFindings[3].Key.GetString());
            Console.WriteLine(sampleKeywordPairArray[3].Key.GetString());
            Console.WriteLine("----");

            //Test tam olmadi!
            //Assert.That(myFindings, Is.EqualTo(sampleKeywordPairArray));
            Assert.That(myFindings.Length, Is.EqualTo(sampleKeywordPairArray.Length));
        }
        
        /// <summary>
        /// Again consult the Tagfile for more information. The parsing should follow the order of the keywords you provided.
        /// Make sure to make it adaptable to different configurations.
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_KeywordsSetTagString_ListOfProvidedTagsInOrder(){
            Keyword keyNumberOne = new Keyword("ItemNumber", KeywordTypes.String);
            Keyword keyNumberTwo = new Keyword("ItemName", KeywordTypes.String);
            Keyword keyNumberThree = new Keyword("CustomerName", KeywordTypes.String);
            Keyword keyNumberFour = new Keyword("AmountOrdered", KeywordTypes.String);
            Keyword keyNumberFive = new Keyword("NetPrice", KeywordTypes.String);
            Keyword[] testKeywordArray = { keyNumberOne, keyNumberTwo, keyNumberThree, keyNumberFour, keyNumberFive };

            KeywordPair firstPair = new KeywordPair(keyNumberOne, "1");
            KeywordPair secondPair = new KeywordPair(keyNumberTwo, "Burger");
            KeywordPair threePair = new KeywordPair(keyNumberThree, "James T. Kirk");
            KeywordPair fourPair = new KeywordPair(keyNumberFour, "2");
            KeywordPair fivePair = new KeywordPair(keyNumberFive, "8.00");
            KeywordPair[] sampleKeywordPairArray = { firstPair, secondPair, threePair, fourPair, fivePair };

            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);

            Console.WriteLine("--");
            var mysample = SimpleShop.ReadFileLineByLine("D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 4\\Assignment2\\SimpleShop.Test\\SampleOrder.tag");

            Console.WriteLine("----");
            var myFindings = ShopParser.ExtractFromTAG(testParser, mysample.First());
            Console.WriteLine(myFindings[5].Value);
            Console.WriteLine("----");
            Console.WriteLine(myFindings[3].Key.GetString());
            Console.WriteLine(sampleKeywordPairArray[3].Key.GetString());
            Console.WriteLine("----");

            //Test tam olmadi!
            //Assert.That(myFindings, Is.EqualTo(sampleKeywordPairArray));
            Assert.That(myFindings, Is.EqualTo(sampleKeywordPairArray));
        }

        /// <summary>
        /// Test if the VAT is calculated correctly for the Customer.CalculatePrice
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Customer")]
        public void Invoice_CalculateNormalCustomer_AddValueAddedTax(){

            Customer bilalCustomer = new Customer();
            bilalCustomer.CalculatePrice(100);
            Assert.That(bilalCustomer.CalculatePrice(100), Is.EqualTo(119));
        }
        
        /// <summary>
        /// Test if the function CreateCustomer returns a customer
        /// Rating 0
        /// </summary>
        [Test]
        [Category("Customer")]
        public void Invoice_CreateCustomer_ReturnsCustomer(){
            var testCustomer = Customer.CreateCustomer("bilal", "normal");
            Customer controlCustomer = new Customer();
            controlCustomer.GetType();
            Assert.That(testCustomer.GetType(), Is.EqualTo(controlCustomer.GetType()));
        }
        
        /// <summary>
        /// Test if the InvoicePosition.Price calculates correctly:
        /// Provided Orders, NetPrice is set.
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Invoice")]
        public void Invoice_OrdersAndNetPriceValid_CalculateCorrectPrice(){
            Customer bilalCustomer = new Customer();
            bilalCustomer.CalculatePrice(100);

            InvoicePosition testInvoicePosition = 
            testInvoicePosition.Price();
            Assert.Fail();
        }
    }
}