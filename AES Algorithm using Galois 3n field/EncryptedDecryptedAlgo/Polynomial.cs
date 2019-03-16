using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptedDecryptedAlgo
{
    class Polynomial1
    {

        public int[] coef;
        public int degree;
        public Polynomial1()
        {

        }

        public Polynomial1(int coefficient, int degree)
        {
            coef = new int[degree + 1];
            coef[degree] = coefficient;
            this.degree = dgree();
        }

        public int dgree()
        {
            int d = 0;
            for (int i = 0; i < coef.Length; i++)
            {
                if (coef[i] != 0)
                {
                    d = i;
                }
            }
            return d;
        }

        public Polynomial1 plus(Polynomial1 b)
        {
            Polynomial1 a = this;
            Polynomial1 c = new Polynomial1(0, Math.Max(a.degree, b.degree));
            for (int i = 0; i <= a.degree; i++)
            {
                c.coef[i] += a.coef[i];
            }
            for (int i = 0; i < b.degree; i++)
            {
                c.coef[i] += b.coef[i];
            }
            c.degree = c.dgree();
            return c;
        }
    }
}
