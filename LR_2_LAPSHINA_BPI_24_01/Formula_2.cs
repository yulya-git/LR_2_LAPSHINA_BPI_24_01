using System;
using LR_2_LAPSHINA_BPI_24_01.Properties;


namespace LR_2_LAPSHINA_BPI_24_01
{
    public class Formula_2: Formula
    {
        public double A { get; set; }
        public double B { get; set; }
        public double F { get; set; }

        public Formula_2() : base(Resources.FormulaImage2) { }

        public override double Calculate()
        {
            return Math.Cos(F * A) + Math.Sin(F * B);
        }
    }
}
