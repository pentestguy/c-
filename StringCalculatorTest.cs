using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringKata
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private StringCalculator calculator = new StringCalculator();

        [TestCase]
        public void Add_EmptyString_ReturnsZero()
        {
            int result = calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestCase]
        public void Add_OneNumber_ReturnsNumber()
        {
            int result = calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestCase]
        public void Add_TwoNumbersDelimitedWithComma_ReturnsSum()
        {
            int result = calculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [TestCase]
        public void Add_MultipleNumbersDelimitedWithComma_ReturnsSum()
        {
            int result = calculator.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [TestCase]
        public void Add_TwoNumbersDelimitedWithNewLine_ReturnsSum()
        {
            int result = calculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }


        [TestCase]
        public void Add_TwoNumbersDelimitedWithCustomDelimiter_ReturnsSum()
        {
            string input = "//;\n1;2";
            int result = calculator.Add(input);

            Assert.AreEqual(3, result);
        }

        [TestCase]
        public void Add_ThreeNumbersDelimitedWithCustomDelimiter_ReturnsSum()
        {
            string input = "//|\n1|2|3";
            int result = calculator.Add(input);

            Assert.AreEqual(6, result);
        }

        [TestCase]
        public void Add_TwoSEPNumbersDelimitedWithCustomDelimiter_ReturnsSum()
        {
            string input = "//sep\n2sep3";
            int result = calculator.Add(input);

            Assert.AreEqual(5, result);
        }

        [TestCase]
        public void Add_ThreeNumbersDelimitedWithDelimiter_ReturnsSum()
        {
            try
            {
                string input = "//|\n1|2,3";
                int result = calculator.Add(input);
                Assert.Fail();
            }
            catch(ArgumentException e)
            {
                Assert.AreEqual("'|' expected but ',' found at position 3", e.Message);
            }
        }

        [TestCase]
        public void Add_NegativeNumber_ErrorMessageContainsNumber()
        {
            try
            {
                calculator.Add("-1,2");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Negatives not allowed: -1", e.Message);
            }
        }

        [TestCase]
        public void Add_MultipleNegativeNumbers_ErrorMessageContainsAllNegativeNumbers()
        {
            try
            {
                calculator.Add("2,-4,-5");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Negatives not allowed: -4 -5", e.Message);
            }
        }
    }
}
