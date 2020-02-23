using RomanNumbersTDD.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RomanNumbersTDD.UnitTest
{
    public class RomanNumbersTests
    {
        private readonly RomanNumbers romanNumbers;

        public RomanNumbersTests()
        {
            romanNumbers = new RomanNumbers();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Convert_WhenNumberIsInNullOrEmptyOrWhiteSpace_ThrowsException(string number)
        {
            Assert.Throws<ArgumentException>(() => romanNumbers.Convert(number));
        }

        [Fact]
        public void Convert_WhenNumberIsInvalid_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => romanNumbers.Convert("MYVI"));
        }

        [Fact]
        public void Convert_WhenNumbersIsDescendingOrder_ReturnsCorrectValue()
        {
            Assert.True(romanNumbers.Convert("MMVI") == 2006);
        }

        [Fact]
        public void Convert_WhenNumbersIsDifferentOrder_ReturnsCorrectValue()
        {
            Assert.True(romanNumbers.Convert("MCMXLIV") == 1944);
        }

        [Fact]
        public void Convert_WhenNumbersIsAscendingOrder_ReturnsCorrectValue()
        {
            Assert.True(romanNumbers.Convert("IVXL") == 44);
        }
    }
}
