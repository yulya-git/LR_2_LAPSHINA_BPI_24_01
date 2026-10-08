using System;
using LR_2_LAPSHINA_BPI_24_01.Properties;


namespace LR_2_LAPSHINA_BPI_24_01
{
    public class Formula_5 : Formula
    {
        public double X { get; set; }  
        public double Y { get; set; }   
        public double N { get; set; }      
        public double K { get; set; }      

        public Formula_5() : base(Resources.FormulaImage5) { }

        public override double Calculate()
        {
            double z = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                   
                    double numerator = Math.Abs(Math.Pow(X, i)) + Math.Cos(Y) * Math.Pow(Y, j);

                    z += numerator / (i * j);
                }
            }
            return z;
        }
    }
}
