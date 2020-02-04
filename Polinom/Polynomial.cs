using System;
using System.Text;

namespace Polynom
{
    public class Polynomial
    {
        private decimal[] _monomials;
        public int Degree { get; private set; }
        public int Length { get; private set; }

        public Polynomial(decimal[] monomials)
        {
            _monomials = monomials;
            Degree = monomials.Length - 1;
        }

        public decimal GetMonCoefByIndex(int index)
        {
            if (index >= _monomials.Length)
            {
                throw new ArgumentOutOfRangeException("Индекс не может быть больше степени полинома");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Индекс не может быть отрицательным числом");
            }
            return _monomials[index];
        }

        public Polynomial Add(Polynomial pol)
        {
            int addCount = (Degree > pol.Degree) ? Degree  + 1 : pol.Degree + 1;

            decimal[] coefs = new decimal[addCount];

            for (int i = 0; i <= addCount; i++)
            {
                if (_monomials.Length > i)
                {
                    coefs[i] += this.GetMonCoefByIndex(i);
                }
                if (pol.Degree + 1 > i)
                {
                    coefs[i] += pol.GetMonCoefByIndex(i);
                }
            }

            return new Polynomial(coefs);
        }

        public Polynomial Mult(Polynomial pol)
        {
            int multCount = (Degree > pol.Degree) ? Degree : pol.Degree;

            decimal[] coefs = new decimal[multCount + 1];

            for (int i = 0; i <= multCount; i++)
            {
                coefs[i] = 1;
                if (_monomials.Length > i)
                {
                    coefs[i] *= this.GetMonCoefByIndex(i);
                }
                if (pol.Degree + 1 > i)
                {
                    coefs[i] *= pol.GetMonCoefByIndex(i);
                }
            }

            return new Polynomial(coefs);
        }

        public Polynomial Sub(Polynomial pol)
        {
            int subCount = (Degree > pol.Degree) ? Degree + 1 : pol.Degree + 1;

            decimal[] coefs = new decimal[subCount];

            for (int i = 0; i <= subCount; i++)
            {
                if (_monomials.Length > i)
                {
                    coefs[i] += this.GetMonCoefByIndex(i);
                }
                if (pol.Degree + 1 > i)
                {
                    coefs[i] += pol.GetMonCoefByIndex(i);
                }
            }

            return new Polynomial(coefs);
        }

        public Polynomial Div(Polynomial pol)
        {
            int divCount = (Degree > pol.Degree) ? Degree : pol.Degree;

            decimal[] coefs = new decimal[divCount + 1];
            Array.Copy(_monomials, coefs, _monomials.Length);

            for (int i = 0; i <= divCount; i++)
            {
                if (pol.GetMonCoefByIndex(i) == 0)
                {
                    throw new DivideByZeroException("Многочлен содержит члены равные нулю");
                }
                coefs[i] /= pol.GetMonCoefByIndex(i);
            }

            return new Polynomial(coefs);
        }

        public override bool Equals(object obj)
        {
            Polynomial item = obj as Polynomial;

            if (item == null || item.Degree != this.Degree)
            {
                return false;
            }

            for (int i = 0; i < _monomials.Length; i++)
            {
                if (this.Degree != item.Degree)
                {
                    return false;
                }
            }

            return true;
        }

        public static Polynomial operator+(Polynomial firstPol, Polynomial secondPol)
        {
            return firstPol.Add(secondPol);
        }

        public static Polynomial operator -(Polynomial firstPol, Polynomial secondPol)
        {
            return firstPol.Sub(secondPol);
        }
        public static Polynomial operator *(Polynomial firstPol, Polynomial secondPol)
        {
            return firstPol.Mult(secondPol);
        }
        public static Polynomial operator /(Polynomial firstPol, Polynomial secondPol)
        {
            return firstPol.Div(secondPol);
        }

        public decimal[] getPolynomAsArr()
        {
            return _monomials;
        }

        public decimal getValueOfPol(decimal x)
        {
            decimal result = 0;
            int exp = 0;
            foreach (decimal mon in _monomials)
            {
                    result += mon * (decimal)Math.Pow((double)x, exp++);
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int pow = 0;

            foreach (decimal mon in _monomials)
            {
                sb.Append($"{mon}*x^{pow++} + ");
            }
            sb.Length = sb.Length - 2;

            return sb.ToString();
        }
    }
}
