using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace PolyLib
{
    public class Polynomial
    {
        #region Fields

        /// <summary>
        /// Coefficients a_0,...,a_n of a polynomial p, such that
        /// p(x) = a_0 + a_1*x + a_2*x^2 + ... + a_n*x^n.
        /// </summary>
        public Complex[] Coefficients;
       
        #endregion

        #region constructors

        /// <summary>
        /// Inits zero polynomial p = 0.
        /// </summary>
        public Polynomial()
        {            
            Coefficients = new Complex[1];
            Coefficients[0] = Complex.Zero;
        }

        /// <summary>
        /// Inits polynomial from given complex coefficient array.
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(params Complex[] coeffs)
        {
            if (coeffs == null || coeffs.Length < 1)
            {                
                Coefficients = new Complex[1];
                Coefficients[0] = Complex.Zero;
            }
            else
            {                
                Coefficients = (Complex[])coeffs.Clone();
            }
        }

        /// <summary>
        /// Inits polynomial from given real coefficient array.
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null || coeffs.Length < 1)
            {
                Coefficients = new Complex[1];
                Coefficients[0] = Complex.Zero;
            }
            else
            {
                Coefficients = new Complex[coeffs.Length];
                for (int i = 0; i < coeffs.Length; i++)
                    Coefficients[i] = new Complex(coeffs[i]);
            }
        }

        /// <summary>
        /// Inits constant polynomial.
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(Complex c)
        {
            Coefficients = new Complex[1];

            if (c == null)
                Coefficients[0] = Complex.Zero;            
            else
                Coefficients[0] = c;            
        }

        /// <summary>
        /// Inits constant polynomial.
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(double c)
        {
            Coefficients = new Complex[1];

            Coefficients[0] = new Complex(c);
        }

        /// <summary>
        /// Inits polynomial from string like "2x^2 + 4x + (2+2i)"
        /// </summary>
        /// <param name="p"></param>
        public Polynomial(string p)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region dynamics

        /// <summary>
        /// Computes value of the differentiated polynomial at x.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Differentiate(Complex x)
        {
            Complex[] buf = new Complex[Degree];

            for (int i = 0; i < buf.Length; i++)
                buf[i] = (i + 1) * Coefficients[i + 1];

            return (new Polynomial(buf)).Evaluate(x);
        }

        /// <summary>
        /// Computes the definite integral within the borders a and b.
        /// </summary>
        /// <param name="a">Left integration border.</param>
        /// <param name="b">Right integration border.</param>
        /// <returns></returns>
        public Complex Integrate(Complex a, Complex b)
        {
            Complex[] buf = new Complex[Degree + 2];
            buf[0] = Complex.Zero; // this value can be arbitrary, in fact

            for (int i = 1; i < buf.Length; i++)
                buf[i] = Coefficients[i - 1] / i;

            Polynomial p = new Polynomial(buf);

            return (p.Evaluate(b) - p.Evaluate(a));
        }

        /// <summary>
        /// Degree of the polynomial.
        /// </summary>
        public int Degree
        {
            get
            {
                return Coefficients.Length - 1;
            }
        }

        /// <summary>
        /// Checks if given polynomial is zero.
        /// </summary>
        /// <returns></returns>
        public bool IsZero()
        {
            for (int i = 0; i < Coefficients.Length; i++)
                if (Coefficients[i] != 0) return false;

            return true;
        }

        /// <summary>
        /// Evaluates polynomial by using the horner scheme.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Evaluate(Complex x)
        {            
            Complex buf = Coefficients[Degree];

            for (int i = Degree - 1; i >= 0; i--)
            {
                buf = Coefficients[i] + x * buf;
            }

            return buf;
        }

        /// <summary>
        /// Normalizes the polynomial, e.i. divides each coefficient by the
        /// coefficient of a_n the greatest term if a_n != 1.
        /// </summary>
        public void Normalize()
        {
            this.Clean();

            if (Coefficients[Degree] != Complex.One)
                for (int k = 0; k <= Degree; k++)
                    Coefficients[k] /= Coefficients[Degree];
        }

        /// <summary>
        /// Removes unnecessary zero terms.
        /// </summary>
        public void Clean()
        {
            int i;

            for (i = Degree; i >= 0 && Coefficients[i] == 0; i--) ;

            Complex[] coeffs = new Complex[i + 1];

            for (int k = 0; k <= i; k++)
                coeffs[k] = Coefficients[k];

            Coefficients = (Complex[])coeffs.Clone();
        }

        /// <summary>
        /// Factorizes polynomial to its linear factors.
        /// </summary>
        /// <returns></returns>
        public FactorizedPolynomial Factorize()
        {
            // this is to be returned
            FactorizedPolynomial p = new FactorizedPolynomial();

            // cannot factorize polynomial of degree 0 or 1
            if (this.Degree <= 1)
            {                
                p.Factor = new Polynomial[] { this };
                p.Power = new int[] { 1 };

                return p;
            }

            Complex[] roots = Roots(this);

            //ArrayList rootlist = new ArrayList();
            //foreach (Complex z in roots) rootlist.Add(z);

            //roots = null; // don't need you anymore

            //rootlist.Sort();

            //// number of different roots
            //int num = 1; // ... at least one

            //// ...or more?
            //for (int i = 1; i < rootlist.Count; i++)
            //    if (rootlist[i] != rootlist[i - 1]) num++;

            Polynomial[] factor = new Polynomial[roots.Length];
            int[] power = new int[roots.Length];

            //factor[0] = new Polynomial( new Complex[]{ -(Complex)rootlist[0] * Coefficients[Degree],
            //    Coefficients[Degree] } );
            //power[0] = 1;

            //num = 1;
            //len = 0;
            //for (int i = 1; i < rootlist.Count; i++)
            //{
            //    len++;
            //    if (rootlist[i] != rootlist[i - 1])
            //    {
            //        factor[num] = new Polynomial(new Complex[] { -(Complex)rootlist[i], Complex.One });
            //        power[num] = len;
            //        num++;
            //        len = 0;
            //    }
            //}

            power[0] = 1;
            factor[0] = new Polynomial(new Complex[] { -Coefficients[Degree] * (Complex)roots[0], Coefficients[Degree] });

            for (int i = 1; i < roots.Length; i++)
            {
                power[i] = 1;
                factor[i] = new Polynomial(new Complex[] { -(Complex)roots[i], Complex.One });
            }

            p.Factor = factor;
            p.Power = power;

            return p;
        }

        /// <summary>
        /// Computes the roots of polynomial via Weierstrass iteration.
        /// </summary>        
        /// <returns></returns>
        public Complex[] Roots()
        {
            double tolerance = 1e-12;
            int max_iterations = 30;

            Polynomial q = Normalize(this);
            //Polynomial q = p;

            Complex[] z = new Complex[q.Degree]; // approx. for roots
            Complex[] w = new Complex[q.Degree]; // Weierstraﬂ corrections

            // init z
            for (int k = 0; k < q.Degree; k++)
                //z[k] = (new Complex(.4, .9)) ^ k;
                z[k] = Complex.Exp(2 * Math.PI * Complex.I * k / q.Degree);


            for (int iter = 0; iter < max_iterations
                && MaxValue(q, z) > tolerance; iter++)
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < q.Degree; k++)
                        w[k] = q.Evaluate(z[k]) / WeierNull(z, k);

                    for (int k = 0; k < q.Degree; k++)
                        z[k] -= w[k];
                }

            // clean...
            for (int k = 0; k < q.Degree; k++)
            {
                z[k].Re = Math.Round(z[k].Re, 12);
                z[k].Im = Math.Round(z[k].Im, 12);
            }

            return z;
        }

        /// <summary>
        /// Computes the roots of polynomial p via Weierstrass iteration.
        /// </summary>
        /// <param name="p">Polynomial to compute the roots of.</param>
        /// <param name="tolerance">Computation precision; e.g. 1e-12 denotes 12 exact digits.</param>
        /// <param name="max_iterations">Maximum number of iterations; this value is used to bound
        /// the computation effort if desired pecision is hard to achieve.</param>
        /// <returns></returns>
        public Complex[] Roots(double tolerance, int max_iterations)
        {
            Polynomial q = Normalize(this);

            Complex[] z = new Complex[q.Degree]; // approx. for roots
            Complex[] w = new Complex[q.Degree]; // Weierstraﬂ corrections

            // init z
            for (int k = 0; k < q.Degree; k++)
                //z[k] = (new Complex(.4, .9)) ^ k;
                z[k] = Complex.Exp(2 * Math.PI * Complex.I * k / q.Degree);


            for (int iter = 0; iter < max_iterations
                && MaxValue(q, z) > tolerance; iter++)
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < q.Degree; k++)
                        w[k] = q.Evaluate(z[k]) / WeierNull(z, k);

                    for (int k = 0; k < q.Degree; k++)
                        z[k] -= w[k];
                }

            // clean...
            for (int k = 0; k < q.Degree; k++)
            {
                z[k].Re = Math.Round(z[k].Re, 12);
                z[k].Im = Math.Round(z[k].Im, 12);
            }

            return z;
        }


        #endregion

        #region statics

        /// <summary>
        /// Expands factorized polynomial p_1(x)^(k_1)*...*p_r(x)^(k_r) to its normal form a_0 + a_1 x + ... + a_n x^n.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Polynomial Expand(FactorizedPolynomial p)
        {
            Polynomial q = new Polynomial(new Complex[] { Complex.One });

            for (int i = 0; i < p.Factor.Length; i++)
            {
                for (int j = 0; j < p.Power[i]; j++)
                    q *= p.Factor[i];

                q.Clean();
            }

            // clean...
            for (int k = 0; k <= q.Degree; k++)
            {
                q.Coefficients[k].Re = Math.Round(q.Coefficients[k].Re, 12);
                q.Coefficients[k].Im = Math.Round(q.Coefficients[k].Im, 12);
            }

            return q;
        }

        /// <summary>
        /// Evaluates factorized polynomial p at point x.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Complex Evaluate(FactorizedPolynomial p, Complex x)
        {
            Complex z = Complex.One;

            for (int i = 0; i < p.Factor.Length; i++)
            {
                z *= Complex.Pow(p.Factor[i].Evaluate(x), p.Power[i]);
            }

            return z;
        }

        /// <summary>
        /// Removes unncessary leading zeros.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Polynomial Clean(Polynomial p)
        {
            int i;

            for (i = p.Degree; i >= 0 && p.Coefficients[i] == 0; i--) ;

            Complex[] coeffs = new Complex[i + 1];

            for (int k = 0; k <= i; k++)
                coeffs[k] = p.Coefficients[k];

            return new Polynomial(coeffs);
        }
        
        /// <summary>
        /// Normalizes the polynomial, e.i. divides each coefficient by the
        /// coefficient of a_n the greatest term if a_n != 1.
        /// </summary>
        public static Polynomial Normalize(Polynomial p)
        {
            Polynomial q = Clean(p);

            if (q.Coefficients[q.Degree] != Complex.One)
                for (int k = 0; k <= q.Degree; k++)
                    q.Coefficients[k] /= q.Coefficients[q.Degree];

            return q;
        }

        /// <summary>
        /// Computes the roots of polynomial p via Weierstrass iteration.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Complex[] Roots(Polynomial p)
        {
            double tolerance = 1e-12;
            int max_iterations = 30;
            
            Polynomial q = Normalize(p);
            //Polynomial q = p;

            Complex[] z = new Complex[q.Degree]; // approx. for roots
            Complex[] w = new Complex[q.Degree]; // Weierstraﬂ corrections

            // init z
            for (int k = 0; k < q.Degree; k++)
                //z[k] = (new Complex(.4, .9)) ^ k;
                z[k] = Complex.Exp(2 * Math.PI * Complex.I * k / q.Degree);


            for (int iter = 0; iter < max_iterations
                && MaxValue(q, z) > tolerance; iter++)
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < q.Degree; k++)
                        w[k] = q.Evaluate(z[k]) / WeierNull(z, k);

                    for (int k = 0; k < q.Degree; k++)
                        z[k] -= w[k];
                }

            // clean...
            for (int k = 0; k < q.Degree; k++)
            {
                z[k].Re = Math.Round(z[k].Re, 12);
                z[k].Im = Math.Round(z[k].Im, 12);
            }

            return z;
        }

        /// <summary>
        /// Computes the roots of polynomial p via Weierstrass iteration.
        /// </summary>
        /// <param name="p">Polynomial to compute the roots of.</param>
        /// <param name="tolerance">Computation precision; e.g. 1e-12 denotes 12 exact digits.</param>
        /// <param name="max_iterations">Maximum number of iterations; this value is used to bound
        /// the computation effort if desired pecision is hard to achieve.</param>
        /// <returns></returns>
        public static Complex[] Roots(Polynomial p, double tolerance, int max_iterations)
        {            
            Polynomial q = Normalize(p);

            Complex[] z = new Complex[q.Degree]; // approx. for roots
            Complex[] w = new Complex[q.Degree]; // Weierstraﬂ corrections

            // init z
            for (int k = 0; k < q.Degree; k++)
                //z[k] = (new Complex(.4, .9)) ^ k;
                z[k] = Complex.Exp(2 * Math.PI * Complex.I * k / q.Degree);


            for (int iter = 0; iter < max_iterations
                && MaxValue(q, z) > tolerance; iter++)
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < q.Degree; k++)
                        w[k] = q.Evaluate(z[k]) / WeierNull(z, k);

                    for (int k = 0; k < q.Degree; k++)
                        z[k] -= w[k];
                }

            // clean...
            for (int k = 0; k < q.Degree; k++)
            {
                z[k].Re = Math.Round(z[k].Re, 12);
                z[k].Im = Math.Round(z[k].Im, 12);
            }

            return z;
        }


        /// <summary>
        /// Computes the greatest value |p(z_k)|.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double MaxValue(Polynomial p, Complex[] z)
        {
            double buf = 0;


            for (int i = 0; i < z.Length; i++)
            {
                if(Complex.Abs(p.Evaluate(z[i])) > buf)
                    buf = Complex.Abs(p.Evaluate(z[i]));
            }

            return buf;
        }

        /// <summary>
        /// For g(x) = (x-z_0)*...*(x-z_n), this method returns
        /// g'(z_k) = \prod_{j != k} (z_k - z_j).
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        private static Complex WeierNull(Complex[] z, int k)
        {
            if (k < 0 || k >= z.Length)
                throw new ArgumentOutOfRangeException();

           Complex buf = Complex.One;

           for (int j = 0; j < z.Length; j++)
                    if (j != k) buf *= (z[k] - z[j]);

            return buf;
        }

        /// <summary>
        /// Differentiates given polynomial p.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Polynomial Derivative(Polynomial p)
        {
            Complex[] buf = new Complex[p.Degree];

            for (int i = 0; i < buf.Length; i++)
                buf[i] = (i + 1) * p.Coefficients[i + 1];

            return new Polynomial(buf);
        }

        /// <summary>
        /// Integrates given polynomial p.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Polynomial Integral(Polynomial p)
        {
            Complex[] buf = new Complex[p.Degree + 2];
            buf[0] = Complex.Zero; // this value can be arbitrary, in fact

            for (int i = 1; i < buf.Length; i++)
                buf[i] = p.Coefficients[i - 1] / i;

            return new Polynomial(buf);
        }

        /// <summary>
        /// Computes the monomial x^degree.
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Polynomial Monomial(int degree)
        {
            if (degree == 0) return new Polynomial(1);

            Complex[] coeffs = new Complex[degree + 1];

            for (int i = 0; i < degree; i++)
                coeffs[i] = Complex.Zero;

            coeffs[degree] = Complex.One;

            return new Polynomial(coeffs);
        }

        public static Polynomial[] GetStandardBase(int dim)
        {
            if(dim < 1)
                throw new ArgumentException("Dimension expected to be greater than zero.");

            Polynomial[] buf = new Polynomial[dim];

            for (int i = 0; i < dim; i++)
                buf[i] = Monomial(i);

            return buf;
        }

        #endregion

        #region overrides & operators

        public static Polynomial operator +(Polynomial p, Polynomial q)
        {
            
            int degree = Math.Max(p.Degree, q.Degree);

            Complex[] coeffs = new Complex[degree + 1];

            for (int i = 0; i <= degree; i++)
            {
                if (i > p.Degree) coeffs[i] = q.Coefficients[i];
                else if (i > q.Degree) coeffs[i] = p.Coefficients[i];
                else coeffs[i] = p.Coefficients[i] + q.Coefficients[i];
            }

            return new Polynomial(coeffs);
        }

        public static Polynomial operator -(Polynomial p, Polynomial q)
        {
            return p + (-q);
        }

        public static Polynomial operator -(Polynomial p)
        {
            Complex[] coeffs = new Complex[p.Degree + 1];

            for (int i = 0; i < coeffs.Length; i++)
                coeffs[i] = -p.Coefficients[i];

            return new Polynomial(coeffs);
        }

        public static Polynomial operator *(Complex d, Polynomial p)
        {
            Complex[] coeffs = new Complex[p.Degree + 1];

            for (int i = 0; i < coeffs.Length; i++)
                coeffs[i] = d * p.Coefficients[i];            

            return new Polynomial(coeffs);
        }

        public static Polynomial operator *(Polynomial p, Complex d)
        {
            Complex[] coeffs = new Complex[p.Degree + 1];

            for (int i = 0; i < coeffs.Length; i++)
                coeffs[i] = d * p.Coefficients[i];
            
            return new Polynomial(coeffs);
        }

        public static Polynomial operator *(double d, Polynomial p)
        {
            Complex[] coeffs = new Complex[p.Degree + 1];

            for (int i = 0; i < coeffs.Length; i++)
                coeffs[i] = d * p.Coefficients[i];

            return new Polynomial(coeffs);
        }

        public static Polynomial operator *(Polynomial p, double d)
        {
            Complex[] coeffs = new Complex[p.Degree + 1];

            for (int i = 0; i < coeffs.Length; i++)
                coeffs[i] = d * p.Coefficients[i];

            return new Polynomial(coeffs);
        }

        public static Polynomial operator /(Polynomial p, Complex d)
        {
            Complex[] coeffs = new Complex[p.Degree + 1];

            for (int i = 0; i < coeffs.Length; i++)
                coeffs[i] = p.Coefficients[i] / d;

            return new Polynomial(coeffs);
        }

        public static Polynomial operator /(Polynomial p, double d)
        {
            Complex[] coeffs = new Complex[p.Degree + 1];

            for (int i = 0; i < coeffs.Length; i++)
                coeffs[i] = p.Coefficients[i] / d;

            return new Polynomial(coeffs);
        }

        public static Polynomial operator *(Polynomial p, Polynomial q)
        {
            int degree = p.Degree + q.Degree;

            Polynomial r = new Polynomial();

     
            for (int i = 0; i <= p.Degree; i++)
                for (int j = 0; j <= q.Degree; j++)                    
                        r += (p.Coefficients[i] * q.Coefficients[j]) * Monomial(i + j);

            return r;            
        }

        public static Polynomial operator ^(Polynomial p, uint k)
        {
            if (k == 0)
                return Monomial(0);
            else if (k == 1)
                return p;
            else
                return p * (p ^ (k - 1));
        }

        public override string ToString()
        {
            if (this.IsZero()) return "0";
            else
            {
                string s = "";                               

                for (int i = 0; i < Degree + 1; i++)
                {
                    if (Coefficients[i] != Complex.Zero)
                    {
                        if (Coefficients[i] == Complex.I)
                            s += "i";
                        else if (Coefficients[i] != Complex.One)
                        {
                            if (Coefficients[i].IsReal() && Coefficients[i].Re > 0)
                                s += Coefficients[i].ToString();
                            else
                                s += "(" + Coefficients[i].ToString() + ")";
                                
                        }
                        else if (/*Coefficients[i] == Complex.One && */i == 0)
                            s += 1;
                                                
                        if (i == 1)
                            s += "x";
                        else if (i > 1)
                            s += "x^" + i.ToString();                        
                    }

                    if (i < Degree && Coefficients[i + 1] != 0 && s.Length > 0)                    
                        s += " + ";                    
                }

                return s;
            }
        }

        public string ToString(string format)
        {
            if (this.IsZero()) return "0";
            else
            {
                string s = "";

                for (int i = 0; i < Degree + 1; i++)
                {
                    if (Coefficients[i] != Complex.Zero)
                    {
                        if (Coefficients[i] == Complex.I)
                            s += "i";
                        else if (Coefficients[i] != Complex.One)
                        {
                            if (Coefficients[i].IsReal() && Coefficients[i].Re > 0)
                                s += Coefficients[i].ToString(format);
                            else
                                s += "(" + Coefficients[i].ToString(format) + ")";

                        }
                        else if (/*Coefficients[i] == Complex.One && */i == 0)
                            s += 1;

                        if (i == 1)
                            s += "x";
                        else if (i > 1)
                            s += "x^" + i.ToString(format);
                    }

                    if (i < Degree && Coefficients[i + 1] != 0 && s.Length > 0)
                        s += " + ";
                }

                return s;
            }
        }

        public override bool Equals(object obj)
        {
            return (this.ToString() == ((Polynomial)obj).ToString());
        }

        #endregion

        #region structs

        /// <summary>
        /// Factorized polynomial p := set of polynomials p_1,...,p_k and their corresponding
        /// powers n_1,...,n_k, such that p = (p_1)^(n_1)*...*(p_k)^(n_k).
        /// </summary>
        public struct FactorizedPolynomial
        {
            /// <summary>
            /// Set of factors the polynomial  consists of.
            /// </summary>
            public Polynomial[] Factor;

            /// <summary>
            /// Set of powers, where Factor[i] is lifted
            /// to Power[i].
            /// </summary>
            public int[] Power;
        }

        #endregion
    }
}
