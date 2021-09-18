using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int fm = 0;
            double sum = 0.0;
            for(fm = 1;fm <= 100; fm++)
            {
                if(fm % 2 == 0)
                {
                    sum -= 1.0 / fm;
                }
                else
                {
                    sum += 1.0 / fm;
                }
            }
            Console.WriteLine(sum);

        }
    }


}
