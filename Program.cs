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
            // Changing The Console's Attributes :
            // Console.Title = "LED Block Cipher";
            // Console.BackgroundColor = ConsoleColor.White;
            // Console.ForegroundColor = ConsoleColor.DarkBlue;
            // Console.Clear();
            ///////////////////////////////////////////////////

            // Convert Key And PlainText To Program's Format : 
            int[,] plain = 
                { 
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                    { 12, 13, 14, 15 }
                };
            Block plainText = new Block(plain);
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {

            //        plainText.block[i, j] = new Number(plain[i, j]);
            //    }
            //}
            //
            int[,] k =
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                    { 12, 13, 14, 15 }
                };
            Block key = new Block(k);
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {

            //        key.block[i, j] = new Number(k[i, j]);
            //    }
            //}

            LED led = new LED();
            led.encryption(plainText, key);

            // Console.ReadLine();
        }
    }
}
