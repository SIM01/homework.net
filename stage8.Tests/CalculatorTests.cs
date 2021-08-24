using System;
using Xunit;

namespace stage8.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Addition_2_Plus_5_Eq_7()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Addition(2, 5);

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void GSubtract_5_Min_2_Eq_3()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Subtract(5, 2);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Multiply_5_To_2_Eq_10()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Multiply(5, 2);

            //Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Divide_6_To_2_Eq_3()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Divide(6, 2);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void DivideByZero()
        {
            //Arrange
            var calculator = new Calculator();

            Assert.Throws<DivideByZeroException>(() =>
            {
                //Act
                var result = calculator.Divide(1.0, 0.0);
                //Assert
                Assert.IsType<double>(result);
            });
        }
    }
}