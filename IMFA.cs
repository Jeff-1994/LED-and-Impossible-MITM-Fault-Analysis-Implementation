using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Block_Cipher
{
    class IMFA
    {

        
        static int[,] mdsMatrix =
                {
                    { 4, 1, 2, 2 },
                    { 8, 6, 5, 6 },
                    { 11, 14, 10, 9 },
                    { 2, 2, 15, 11 }
                };
        static Block MDS = new Block(mdsMatrix);

        static int[,] imdsMatrix =
                {
                    { 12, 12, 13, 4 },
                    { 3, 8, 4, 5 },
                    { 7, 6, 2, 14 },
                    { 13, 9, 9, 13 }
                };
        static Block IMDS = new Block(imdsMatrix);

        static int[] SBox =  { 12, 5, 6, 11, 9, 0, 10, 13, 3, 14, 15, 8, 4, 7, 1, 2 };
        static int[] iSBox = { 5, 14, 15, 8, 12, 1, 2, 13, 11, 4, 6, 3, 0, 7, 9, 10 };

        static bool leftShift = false;
        static bool inverseLeftShift = true;

        public IMFA()
        {

        }

        public void execute()
        {

        }

        public void _mitmAnalysis()
        {
            Block tempBlock = new Block();
            int[,] _k =
                {
                    { 0 , 1 , 2 , 3 },
                    { 4 , 5 , 6 , 7 },
                    { 8 , 9 , 10 , 11 },
                    { 12 , 13 , 14 , 15}
                };
            Block k = new Block(_k);
            int[,] _c =
                {
                    { 15 , 13 , 13 , 6 },
                    { 15 , 11 , 9 , 8 },
                    { 4 , 5 , 15 , 8 },
                    { 1 , 4 , 5 , 6 }
                };
            Block c = new Block(_c);

            int[,] _ch =
                {
                    { 8 , 9 , 14 , 10 },
                    { 12 , 12 , 2 , 15 },
                    { 5 , 8 , 8 , 12 },
                    { 11 , 4 , 10 , 0 }
                };
            Block ch = new Block(_ch);

            int[,] _t =
                {
                    { 7,10,6,7 },
                    { 9,12,0,5 },
                    { 13,13,5,12 },
                    { 13,4,5,3 }
                };
            Block t = new Block(_t);
            int[,] _th =
                {
                    { 1,3,0,0 },
                    { 13,14,0,14 },
                    { 0,4,13,11 },
                    { 9,1,6,12 }
                };
            Block th = new Block(_th);

            Block betaR = LED.shiftRows(LED.mixColumnSerial(c , IMDS), true);
            Block betaHR = LED.shiftRows(LED.mixColumnSerial(ch, IMDS), true);
            //Block.showBlock(betaR | betaHR);

            //Block deltaR_2 = subCells(shiftRows(mixColumnSerial(addConstant(subCells(betaR, iSBox), 31), IMDS), true) , iSBox);
            //Block deltaHR_2 = subCells(shiftRows(mixColumnSerial(addConstant(subCells(betaHR, iSBox), 31), IMDS), true), iSBox);

            Block betaR_1 = LED.subCells(betaR, iSBox);
            Block betaHR_1 = LED.subCells(betaHR, iSBox);
            Block.showBlock(betaR_1 | betaHR_1);
            //Block.showBlock(deltaR_2 | deltaHR_2);

            //Number[,] deltaR_2 = 4;

            //for (int i = 0; i < 16; i++)
            //{
            //    Block yp = shiftRows(mixColumnSerial(y, IMDS), true);
            //    Block yhp = shiftRows(mixColumnSerial(yh, IMDS), true);


            //    int[,] k = { { i, 0, 0, 0 } , { 0, 0, 0, 0 } , { 0, 0, 0, 0 } , { 0, 0, 0, 0 } };
            //    Block kp = new Block(k);
            //    Block res = yp | kp;

            //    Block leftOprand = subCells(shiftRows(mixColumnSerial(addConstant(subCells(res , iSBox) , 31) , IMDS) , true) , iSBox);
            //    res = yhp | kp;
            //    Block rightOprand = subCells(shiftRows(mixColumnSerial(addConstant(subCells(res , iSBox) , 31), IMDS), true), iSBox);
            //    res = leftOprand | rightOprand;
            //    //if(res.block[0,0].Num == deltaR_2)
            //    //{
            //    //    Console.WriteLine("i : " + i);
            //    //}
            //    Block.showBlock(res);
            //    Console.WriteLine("\n");
            //}
        }

         public void mitmAnalysis()
        {
            Block tempBlock = new Block();
            int[,] _k =
                {
                    { 0 , 1 , 2 , 3 },
                    { 4 , 5 , 6 , 7 },
                    { 8 , 9 , 10 , 11 },
                    { 12 , 13 , 14 , 15}
                };
            Block k = new Block(_k);
            int[,] _c =
                {
                    { 15 , 13 , 13 , 6 },
                    { 15 , 11 , 9 , 8 },
                    { 4 , 5 , 15 , 8 },
                    { 1 , 4 , 5 , 6 }
                };
            Block c = new Block(_c);

            int[,] _ch =
                {
                    { 8 , 9 , 14 , 10 },
                    { 12 , 12 , 2 , 15 },
                    { 5 , 8 , 8 , 12 },
                    { 11 , 4 , 10 , 0 }
                };
            Block ch = new Block(_ch);

            

            Block betaR = ISR(IMC(c));
            Block betaHR = ISR(IMC(ch));
            Block.showBlock(betaR | betaHR);

            int[,] _delta =
                {
                    { 4 , 5 , 4 , 7 },
                    { 2 , 14 , 12 , 8 },
                    { 6 , 1 , 14 , 10 },
                    { 9 , 14 , 5 , 8 }
                };
            Block delta = new Block(_delta);
            Column deltaC0 = Block.insertBlockInColumn(delta, 0);
            Column deltaC1 = Block.insertBlockInColumn(delta, 1);
            Column deltaC2 = Block.insertBlockInColumn(delta, 2);
            Column deltaC3 = Block.insertBlockInColumn(delta, 3);


            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    for (int m = 0; m < 15; m++)
                    {
                        for (int n = 0; n < 15; n++)
                        {
                            Column keyC0 = new Column(i, j, m, n);
                            Column keyC1 = new Column(i, j, m, n);
                            Column keyC2 = new Column(i, j, m, n);
                            Column keyC3 = new Column(i, j, m, n);
                            Block K = new Block(keyC0 , keyC1 , keyC2 , keyC3);


                        }
                    }
                }
            }


        }


        
        public static Block AC(Block plain_text, int round_number)
        {
            return LED.addConstant(plain_text , round_number);
        }

        public static Block SC(Block plain_text)
        {
            return LED.subCells(plain_text, SBox);
        }

        public static Block SR(Block plain_text)
        {
            return LED.shiftRows(plain_text , leftShift);
        }

        public static Block MC(Block plain_text)
        {
            return LED.mixColumnSerial(plain_text, MDS);
        }


        public static Block IAC(Block plain_text, int round_number)
        {
            return LED.addConstant(plain_text , round_number);
        }

        public static Block ISC(Block plain_text)
        {
            return LED.subCells(plain_text, iSBox);
        }

        public static Block ISR(Block plain_text)
        {
            return LED.shiftRows(plain_text , inverseLeftShift);
        }

        public static Block IMC(Block plain_text)
        {
            return LED.mixColumnSerial(plain_text, IMDS);
        }
    }
}