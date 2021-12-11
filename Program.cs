using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace РГР
{
    class Equation2
    {
        private double[] coefs = new double[6];


        public Equation2(double a, double b, double c, double d, double e, double f)
        {
            coefs[0] = a;
            coefs[1] = b;
            coefs[2] = c;
            coefs[3] = d;
            coefs[4] = e;
            coefs[5] = f;
        }

        public Equation2()
        {
            for (int i = 0; i < 6; i++)
            { coefs[i] = Console.Read(); }
        }

        public void Rot(double angle)
        {
            coefs[0] = coefs[0] * Math.Cos(angle) * Math.Cos(angle) - coefs[1] * Math.Cos(angle) * Math.Sin(angle) + coefs[2] * Math.Sin(angle) * Math.Sin(angle);
            coefs[1] = 2 * coefs[0] * Math.Sin(angle) * Math.Cos(angle) + coefs[1] * Math.Cos(angle) * Math.Cos(angle) - coefs[1] * Math.Sin(angle) * Math.Sin(angle) - 2 * coefs[2] * Math.Sin(angle) * Math.Cos(angle);
            coefs[2] = coefs[0] * Math.Sin(angle) * Math.Sin(angle) + coefs[1] * Math.Cos(angle) * Math.Sin(angle) + coefs[2] * Math.Cos(angle) * Math.Cos(angle);
            coefs[3] = coefs[3] * Math.Cos(angle) - coefs[4] * Math.Sin(angle);
            coefs[4] = coefs[3] * Math.Sin(angle) + coefs[4] * Math.Cos(angle);
        }

        public void RotB()
        {
            if (coefs[1] != 0)
            {
                double angle;
                if (coefs[0] == coefs[2])
                { angle = Math.PI / 4; }
                else
                { angle = Math.Atan(coefs[1] / (coefs[0] - coefs[2])) / 2; }

                this.Rot(angle);
                coefs[1] = 0;
            }
        }

        public void Trans()
        {
            if (coefs[0] != 0)
            {
                coefs[3] = 0;
                coefs[5] = coefs[5] - coefs[3] * coefs[3] / coefs[0] / 4;
            }
            if (coefs[2] != 0)
            {
                coefs[4] = 0;
                coefs[5] = coefs[5] - coefs[4] * coefs[4] / coefs[2] / 4;
            }
        }
        
        public void ToCanon()
        {
            RotB();
            Trans();

            coefs[0] /= -coefs[5];
            coefs[2] /= -coefs[5];
            coefs[5] /= -coefs[5];

            if(Math.Abs(coefs[0]) > Math.Abs(coefs[2]))
            {
                Rot(Math.PI / 2);
                coefs[1] = 0;
            }

            if (coefs[0] < 0)
            {
                coefs[0] = -coefs[0];
                coefs[2] = -coefs[2];
                coefs[5] = -coefs[5];
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
