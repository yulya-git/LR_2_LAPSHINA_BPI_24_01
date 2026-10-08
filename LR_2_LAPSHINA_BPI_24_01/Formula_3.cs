using System;
using LR_2_LAPSHINA_BPI_24_01.Properties;


namespace LR_2_LAPSHINA_BPI_24_01
{
    public class Formula_3: Formula
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public Formula_3() : base(Resources.FormulaImage3) { }

        public override double Calculate()
        {
            return C * A * A + D * B * B;
        }
    }
}
