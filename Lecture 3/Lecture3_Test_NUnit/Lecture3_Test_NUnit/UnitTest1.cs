using NUnit;

namespace ProSE_Lecture3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Test1()
        {
         Assert.Pass();
        }
        [Test]
        public void Vector2d_Norm_3_4_is_5()
        {
            // 2d Vector with 3,4 is 5?
            Vector2D firstvector = new Vector2D(3, 4);


            Assert.That(firstvector.GetNorm(), Is.EqualTo(5));
        }
    }
}