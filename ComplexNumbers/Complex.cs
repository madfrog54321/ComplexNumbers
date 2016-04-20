using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Complex
    {
        private double _real;
        public double Real
        {
            get { return _real; }
            set { _real = value; }
        }

        private i _imaginary;
        public i Imaginary
        {
            get { return _imaginary; }
            set { _imaginary = value; }
        }

        public Complex(double real, i imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }

        public override int GetHashCode()
        {
            return (_real + _imaginary.Scalar).GetHashCode();
        }

        public static Complex operator +(double c1, Complex c2)
        {
            return new Complex(c1 + c2.Real, c2.Imaginary);
        }

        public static Complex operator +(Complex c1, double c2)
        {
            return c2 + c1;
        }

        public static Complex operator -(double c1, Complex c2)
        {
            return new Complex(c1 - c2.Real, c2.Imaginary);
        }

        public static Complex operator -(Complex c1, double c2)
        {
            return c2 - c1;
        }

        public static Complex operator +(i c1, Complex c2)
        {
            return new Complex(c2.Real, c2.Imaginary + c1);
        }

        public static Complex operator +(Complex c1, i c2)
        {
            return c2 + c1;
        }

        public static Complex operator -(i c1, Complex c2)
        {
            return new Complex(c2.Real, c2.Imaginary - c1);
        }

        public static Complex operator -(Complex c1, i c2)
        {
            return c2 - c1;
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Real * c2.Real - c1.Imaginary.Scalar * c2.Imaginary.Scalar, (i)(c1.Real * c2.Imaginary.Scalar + c1.Imaginary.Scalar * c2.Real));
        }

        public static Complex operator *(double c1, Complex c2)
        {
            return new Complex(c2.Real * c1, c2.Imaginary * c1);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return (c1.Real * c2.Real + c1.Imaginary.Scalar * c2.Imaginary.Scalar + c1.Imaginary.Scalar * (i)c2.Real - c2.Imaginary.Scalar * (i)c1.Real)/(c2.Real * c2.Real + c2.Imaginary.Scalar * c2.Imaginary.Scalar);
        }

        public static Complex operator /(double c1, Complex c2)
        {
            return new Complex(c1 / c2.Real, c1 / c2.Imaginary);
        }

        public static Complex operator /(Complex c1, double c2)
        {
            return new Complex(c1.Real / c2, c1.Imaginary / c2);
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Complex)) return false;
            Complex newObj = obj as Complex;
            return newObj.Real == Real && newObj.Imaginary == Imaginary;
        }

        public override string ToString()
        {
            return _real.ToString() + (_imaginary.Scalar >= 0 ? "+" : "") + _imaginary.ToString();
        }
    }

    class i
    {
        private double _scalar;
        public double Scalar
        {
            get { return _scalar; }
            set { _scalar = value; }
        }

        public i(double scalar)
        {
            _scalar = scalar;
        }

        public static explicit operator i(double x)
        {
            return new i(x);
        }

        public static Complex operator +(double c1, i c2)
        {
            return new Complex(c1, c2);
        }

        public static Complex operator +(i c1, double c2)
        {
            return c2 + c1;
        }

        public static Complex operator -(double c1, i c2)
        {
            return new Complex(c1, -c2);
        }

        public static Complex operator -(i c1, double c2)
        {
            return c2 - c1;
        }

        public static i operator -(i c1)
        {
            return new i(c1.Scalar * -1);
        }

        public static double operator *(i c1, i c2)
        {
            return c1.Scalar * c2.Scalar;
        }

        public static i operator *(double c1, i c2)
        {
            return new i(c1 * c2.Scalar);
        }

        public static i operator *(i c1, double c2)
        {
            return c2 * c1;
        }

        public static i operator /(i c1, double c2)
        {
            return new i(c1.Scalar / c2);
        }

        public static i operator /(double c1, i c2)
        {
            return new i(c1/ c2.Scalar);
        }

        public static i operator +(i c1, i c2)
        {
            return new i(c1.Scalar + c2.Scalar);
        }

        public static i operator -(i c1, i c2)
        {
            return new i(c1.Scalar - c2.Scalar);
        }

        public override int GetHashCode()
        {
            return _scalar.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return _scalar.Equals(obj);
        }

        public override string ToString()
        {
            return _scalar.ToString() + "i";
        }
    }
}
