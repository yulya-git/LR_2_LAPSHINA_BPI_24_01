using System;
using LR_2_LAPSHINA_BPI_24_01.Properties;


namespace LR_2_LAPSHINA_BPI_24_01
{
    public class Formula_4 : Formula
    {
        public double A { get; set; }
        public double D { get; set; }
        public double C { get; set; }

        public Formula_4() : base(Resources.FormulaImage4)
        { }

        public override double Calculate()
        {
            double res = 0;
            for (int i = 0; i <= (int)D; i++)
                res += System.Math.Pow(C + A, i);
            return res;
        }
    }
}
