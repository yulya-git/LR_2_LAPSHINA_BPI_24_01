using System;
using LR_2_LAPSHINA_BPI_24_01.Properties;


namespace LR_2_LAPSHINA_BPI_24_01
{
    public class Formula_1: Formula
    {
        public double A { get; set; }
        public double F { get; set; }
        
        public Formula_1(): base(Resources.FormulaImage1) { }

        public override double Calculate()
        {
            return Math.Sin(F * A);
        }
    }
}
