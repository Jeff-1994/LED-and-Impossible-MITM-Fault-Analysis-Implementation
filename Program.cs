using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Block_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Convert Key And PlainText To Program's Format : 
            int[,] plain = 
                { 
                    { 0,  1,  2,  3  },
                    { 4,  5,  6,  7  },
                    { 8,  9,  10, 11 },
                    { 12, 13, 14, 15 }
                };
            Block plainText = new Block(plain);

            int[,] k =
                {
                    { 0,  1,  2,  3  },
                    { 4,  5,  6,  7  },
                    { 8,  9,  10, 11 },
                    { 12, 13, 14, 15 }
                };
            Block key = new Block(k);
            
            // Construct a LED object and execute Inc/Dec Method : 
            LED led = new LED();
            led.encryption(plainText, key);

            // Construct an IMFA object and execute the analysis : 
            // IMFA analysis = new IMFA();
            // analysis.execute();
        }
    }
}
