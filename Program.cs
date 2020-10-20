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
                    {  0,  1,  2, 3  },
                    {  4,  5,  6, 7  },
                    {  8,  9, 10, 11 },
                    { 12, 13, 14, 15 }
                };
            Block plainText = new Block(plain);

            int[,] cipher =
                {
                    { 15, 13, 13, 6 },
                    { 15, 11,  9, 8 },
                    {  4,  5, 15, 8 },
                    {  1,  4,  5, 6 }
                };
            Block cipherText = new Block(cipher);

            int[,] k =
                {
                    {  0,  1,  2, 3  },
                    {  4,  5,  6, 7  },
                    {  8,  9, 10, 11 },
                    { 12, 13, 14, 15 }
                };
            Block key = new Block(k);
            
            // Construct a LED object and execute Inc/Dec Method : 
            LED led = new LED();

            // Encryption & Decryption Methods :
            // led.encryption(plainText, key);
            // led.decryption(cipherText , key);

            // Construct an IMFA object and execute the analysis : 
            IMFA analysis = new IMFA();

            // Fault Injecting :
            Block[,] data = IMFA.createCorrectAndFaultyData(plainText , key);

            // Impossible Meet-In-The-Middle Fault Analysis on LED Lightweight Cipher :
            analysis.execute(data);

            // Calculate None-Zero Nibbles in MixColumnSerial level (Round r - 2) :
            // IMFA.showTable(IMFA.noneZeroNibblesTable());

        }
    }
}
