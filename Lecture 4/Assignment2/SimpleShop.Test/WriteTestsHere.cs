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
            Keyword keyNumberOne = new Keyword("TestKeyword", KeywordTypes.String);
            Keyword keyNumberTwo = new Keyword("3", KeywordTypes.Int);
            Keyword keyNumberThree = new Keyword("2,11", KeywordTypes.Decimal);
            Keyword[] testKeywordArray = { keyNumberOne, keyNumberTwo, keyNumberThree };

            KeywordPair firstPair = new KeywordPair(keyNumberOne, "Bilal"); // emek burda
            KeywordPair secondPair = new KeywordPair(keyNumberTwo, "Goekshen");
            KeywordPair threePair = new KeywordPair(keyNumberThree, "Koray");
            KeywordPair[] a = { firstPair, secondPair, threePair };

            ShopParser testParser = new ShopParser();
            testParser.SetKeywords(testKeywordArray);
            var B = ShopParser.ExtractFromTAG(testParser, "Bilal");
            Console.WriteLine(B[0]);

            Console.WriteLine("--");

            //Assert.That(ShopParser.ExtractFromTAG(testParser, "Bilal"),Is)
            Assert.Pass();
        }
        
        /// <summary>
        /// Check if the parser works correctly. This time you should check if repetition invalidates the findings.
        /// A A B B C C
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_InvalidatedFindingsWithRepeatedEntry_False(){
            Assert.Fail();
        }
        
        /// <summary>
        /// Check if the parser works correctly. This time with circular keywords.
        /// A B C A
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_InvalidatedFindingsCircular_False(){
            Assert.Fail();
        }
        
        /// <summary>
        /// See Tagfile (SampleOrder.tag) for more information. Are the correct number of keywords recognized ? 
        /// Rating 1
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_KeywordsSetTagString_CorrectNumberOfEntries(){
            Assert.Fail();
        }
        
        /// <summary>
        /// Again consult the Tagfile for more information. The parsing should follow the order of the keywords you provided.
        /// Make sure to make it adaptable to different configurations.
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_KeywordsSetTagString_ListOfProvidedTagsInOrder(){
            Assert.Fail();
        }

        /// <summary>
        /// Test if the VAT is calculated correctly for the Customer.CalculatePrice
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Customer")]
        public void Invoice_CalculateNormalCustomer_AddValueAddedTax(){
            Assert.Fail();
        }
        
        /// <summary>
        /// Test if the function CreateCustomer returns a customer
        /// Rating 0
        /// </summary>
        [Test]
        [Category("Customer")]
        public void Invoice_CreateCustomer_ReturnsCustomer(){
            Assert.Fail();
        }
        
        /// <summary>
        /// Test if the InvoicePosition.Price calculates correctly:
        /// Provided Orders, NetPrice is set.
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Invoice")]
        public void Invoice_OrdersAndNetPriceValid_CalculateCorrectPrice(){
            Assert.Fail();
        }
    }
}