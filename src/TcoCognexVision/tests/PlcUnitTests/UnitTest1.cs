using NUnit.Framework;
using NUnit.Framework.Constraints;
using TcoCognexVisionTests;
using Tc.Prober.Runners;

namespace TcoCognexVisionUnitTests
{
    public class fbUnitTestExampleTests
    {
        SampleComponentTests sut;

        [OneTimeSetUp]
        public void Setup()
        {
            Entry.TcoCognexVisionTests.Connector.BuildAndStart().ReadWriteCycleDelay = 100;
            sut = Entry.TcoCognexVisionTests.MAIN._sampleComponentTests;
        }

        [Test]
        [TestCase(10, 42)]
        [TestCase(50, 42)]
        public void AddTwoNumbersTest(short number1, short number2)
        {
            //-- Arrange
            var expected = number1 + number2;

            //-- Act
            var actual = sut.Run(p => sut.AddTwoNumbersTest(number1, number2), 1);


            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        [Timeout(1000)]
        public void WaitForModuloTest(short modulo)
        {            
            //-- Act            
            sut.Run(a => sut.WaitForModuloTest(modulo));            
        }
    }
}
