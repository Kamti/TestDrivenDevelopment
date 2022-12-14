using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopment1.Test
{
    internal class StringCalculatorTests
    {
        [Test]
        public void AddEmptyString()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add(string.Empty),Is.EqualTo(0));
        }

        [Test]
        public void AddTwoNumbers()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add("1,2"), Is.EqualTo(3));
        }

        [Test]
        public void AddThreeNumbers()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add("1,2,4"), Is.EqualTo(7));
        }

        [Test]
        public void AddMoreLines()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add("1,2,4\n3"), Is.EqualTo(10));
        }

        [Test]
        public void SumWithDifferentDelimiter()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add("//;\n1;2"), Is.EqualTo(3));
        }

        [Test]
        public void SumNegatives()
        {
            var calc = new StringCalculator();

            Assert.That(() => calc.Add("//;\n-1;2\n-3"), Throws.TypeOf<Exception>()
             .With
             .Message
             .EqualTo("negatives not allowed -1,-3"));
        }

        [Test]
        public void IgnoreNumbersGreaterThan()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add("//;\n1001;2"), Is.EqualTo(2));
        }

        [Test]
        public void DelimiterContainsMoreChars()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add("//[***]\n1***2***3"), Is.EqualTo(6));
        }

        [Test]
        public void MoreDelimiters()
        {
            var calc = new StringCalculator();

            Assert.That(calc.Add("//[***][%]\n1***2***3"), Is.EqualTo(6));
        }
    }
}
