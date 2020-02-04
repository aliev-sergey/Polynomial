using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynom;

namespace UnitTestPolynom
{
    [TestClass]
    public class PolynomUnitTest
    {
        public const string CoefByIndexOverThenOrder = "Индекс не может быть больше степени полинома";
        public const string CoefByIndexNegativeNum = "Индекс не может быть отрицательным числом";
        public const string DivByZeroExceptionStr = "Многочлен содержит члены равные нулю";
        public decimal[] TestPolArr1 = new decimal[] { 12, -11, 52, 67, 24.2M };
        public decimal[] TestPolArr2 = new decimal[] { 2, 68, 2.1M, -2, 14, 28 };

        [TestMethod]
        public void GetMonCoefByIndex_IndexMoreThenOrder_ThrowIndexOutOfRangeException()
        {
            Polynomial polynom = new Polynomial(TestPolArr1);

            try
            {
                decimal monCoef1 = polynom.GetMonCoefByIndex(TestPolArr1.Length);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, PolynomUnitTest.CoefByIndexOverThenOrder);
                return;
            }

            Assert.Fail("Ожидаемое исключение не было обработано.");
        }

        [TestMethod]
        public void GetMonCoefByIndex_NegativeIndex_ThrowIndexOutOfRangeException()
        {
            Polynomial polynom = new Polynomial(TestPolArr1);

            try
            {
                decimal monCoef1 = polynom.GetMonCoefByIndex(-1);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, PolynomUnitTest.CoefByIndexNegativeNum);
                return;
            }

            Assert.Fail("Ожидаемое исключение не было обработано.");
        }

        [TestMethod]
        public void Add_AdditionTest_ReturnsSumOfPolynomials()
        {
            decimal[] expectedPolArray = new decimal[] { 14, 57, 54.1M, 65, 38.2M, 28 };
            Polynomial firstPolynom = new Polynomial(TestPolArr1);
            Polynomial secondPolynom = new Polynomial(TestPolArr2);
            Polynomial expectedPol = new Polynomial(expectedPolArray);
            Polynomial sumOfPols = firstPolynom + secondPolynom;

            Assert.AreEqual(expectedPol, sumOfPols, "Неправильное поведение метода Add()");
        }

        [TestMethod]
        public void Mult_MultTest_ReturnsMultOfPolynomials()
        {
            decimal[] expectedPolArray = new decimal[] { 24, -691, 109.2M, -134, 338.8M, 28 };
            Polynomial firstPolynom = new Polynomial(TestPolArr1);
            Polynomial secondPolynom = new Polynomial(TestPolArr2);
            Polynomial expectedPol = new Polynomial(expectedPolArray);
            Polynomial multOfPols = firstPolynom * secondPolynom;

            Assert.AreEqual(expectedPol, multOfPols, "Неправильное поведение метода Mult()");
        }

        [TestMethod]
        public void Sub_SubTest_ReturnsSubOfPolynomials()
        {
            decimal[] expectedPolArray = new decimal[] { 10, -79, 49.9M, 69, 10.2M, -28 };
            Polynomial firstPolynom = new Polynomial(TestPolArr1);
            Polynomial secondPolynom = new Polynomial(TestPolArr2);
            Polynomial expectedPol = new Polynomial(expectedPolArray);
            Polynomial subOfPols = firstPolynom - secondPolynom;

            Assert.AreEqual(expectedPol, subOfPols, "Неправильное поведение метода Sub()");
        }

        [TestMethod]
        public void Div_DivTest_ReturnsDivOfPolynomials()
        {
            decimal[] expectedPolArray = new decimal[] { 6, (decimal)(-11/68), (52/2.1M), (67/-2), (24.2M/14), 0/28 };
            Polynomial firstPolynom = new Polynomial(TestPolArr1);
            Polynomial secondPolynom = new Polynomial(TestPolArr2);
            Polynomial expectedPol = new Polynomial(expectedPolArray);
            Polynomial DivOfPols = firstPolynom / secondPolynom;

            Assert.AreEqual(expectedPol, DivOfPols, "Неправильное поведение метода Div()");
        }


        [TestMethod]
        public void Div_ZeroDiv_ThrowDivideByZeroException()
        {
            Polynomial firstPolynom = new Polynomial(TestPolArr1);
            Polynomial secondPolynom = new Polynomial(new decimal[] { 0, 0, 0, 0, 0 } );
            try
            {
                Polynomial result = firstPolynom / secondPolynom;
            }
            catch (System.DivideByZeroException e)
            {
                // Assert
                StringAssert.Contains(e.Message, PolynomUnitTest.DivByZeroExceptionStr);
                return;
            }

            Assert.Fail("Ожидаемое исключение не было обработано.");
        }

    }
}
