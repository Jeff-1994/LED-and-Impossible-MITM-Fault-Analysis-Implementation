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

         public void execute(Block[,] data)
        {
            int faultsNumber = 50;
            Column[] firstColumn0 = null;
            Column[] secondColumn0 = null;
            Column[] firstColumn1 = null;
            Column[] secondColumn1 = null;
            Column[] firstColumn2 = null;
            Column[] secondColumn2 = null;
            Column[] firstColumn3 = null;
            Column[] secondColumn3 = null;
            Block resultKey;
            
            Block[] deltas = calculateDeltaValues();
            for (int num = 0; num < faultsNumber; num++)
            {
                Block correct = data[num , 0];
                Block faulty = data[num , 1];
                Block yp = ISR(IMC(correct));
                Block yhp = ISR(IMC(faulty));

                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        for (int m = 0; m < 16; m++)
                        {
                            for (int n = 0; n < 16; n++)
                            {
                                Column C = new Column(i , j , m , n);
                                Block G = new Block(C , C , C , C);
                                //Block.showBlock(G);
                                Block kBr = ISR(IMC(G));
                                //Block.showBlock(kBr);
                                Block phi = ISC(ISR(IMC(AC(ISC(yp | kBr),31))))
                                          | ISC(ISR(IMC(AC(ISC(yhp | kBr),31))));
                                Column bC0 = new Column(phi.block[0,0].Num , phi.block[1,1].Num , phi.block[2,2].Num , phi.block[3,3].Num);
                                Column bC1 = new Column(phi.block[0,1].Num , phi.block[1,2].Num , phi.block[2,3].Num , phi.block[3,0].Num);
                                Column bC2 = new Column(phi.block[0,2].Num , phi.block[1,3].Num , phi.block[2,0].Num , phi.block[3,1].Num);
                                Column bC3 = new Column(phi.block[0,3].Num , phi.block[1,0].Num , phi.block[2,1].Num , phi.block[3,2].Num);
                                
                                // For Column #0 :
                                for (int d = 0; d < deltas.Length; d++)
                                {
                                    Column dC0 = new Column(deltas[d].block[0,0].Num , deltas[d].block[1,1].Num , deltas[d].block[2,2].Num , deltas[d].block[3,3].Num);
                                    if (bC0 == dC0)
                                    {
                                        secondColumn0 = addToArray(secondColumn0 , C);
                                    }
                                }

                                // For Column #1 :
                                for (int d = 0; d < deltas.Length; d++)
                                {
                                    Column dC1 = new Column(deltas[d].block[0,1].Num , deltas[d].block[1,2].Num , deltas[d].block[2,3].Num , deltas[d].block[3,0].Num);
                                    if (bC1 == dC1)
                                    {
                                        secondColumn1 = addToArray(secondColumn1 , C);
                                    }
                                }

                                // For Column #2 :
                                for (int d = 0; d < deltas.Length; d++)
                                {
                                    Column dC2 = new Column(deltas[d].block[0,2].Num , deltas[d].block[1,3].Num , deltas[d].block[2,0].Num , deltas[d].block[3,1].Num);
                                    if (bC2 == dC2)
                                    {
                                        secondColumn2 = addToArray(secondColumn2 , C);
                                    }
                                }

                                // For Column #3 :
                                for (int d = 0; d < deltas.Length; d++)
                                {
                                    Column dC3 = new Column(deltas[d].block[0,3].Num , deltas[d].block[1,0].Num , deltas[d].block[2,1].Num , deltas[d].block[3,2].Num);
                                    if (bC3 == dC3)
                                    {
                                        secondColumn3 = addToArray(secondColumn3 , C);
                                    }
                                }
                            }
                        }
                    }
                }
                Column c0 , c1 , c2 , c3;
                //Console.WriteLine("Number of Fault : " + num);
                firstColumn0 = intersection(firstColumn0 , secondColumn0);
                firstColumn1 = intersection(firstColumn1 , secondColumn1);
                firstColumn2 = intersection(firstColumn2 , secondColumn2);
                firstColumn3 = intersection(firstColumn3 , secondColumn3);
                if ((firstColumn0.Length == 1) && (firstColumn1.Length == 1) && (firstColumn2.Length == 1) && (firstColumn3.Length == 1))
                {
                    c0 = firstColumn0[0];
                    c1 = firstColumn1[0];
                    c2 = firstColumn2[0];
                    c3 = firstColumn3[0];

                    resultKey = new Block(c0 , c1 , c2 , c3);
                    Block.showBlock(resultKey);

                    break;
                }
            }
        }
        
        public static Block[,] createCorrectAndFaultyData(Block plainText , Block key)
        {
            Block [,]result = new Block[50,2];

            LED LBC = new LED();

            for (int i = 0; i < 50; i++)
            {
                result[i,0] = LBC.encryptionWithoutPrint(plainText , key , false);
                result[i,1] = LBC.encryptionWithoutPrint(plainText , key , true);
            }

            return result;
        } 

        public static Column[] addToArray(Column[] array , Column col)
        {
            if(array == null)
            {
                Column[] res = new Column[1];
                res[0] = col;
                return res;
            }
            int newLength = array.Length + 1;
            Column[] result = new Column[newLength];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }
            result[newLength - 1] = col;
            return result;
        }

        public static Column[] intersection(Column[] cols1 , Column[] cols2)
        {
            if(cols1 == null)
            {
                return cols2;
            }

            Column[] tempArr = new Column[cols1.Length];

            int k = 0;
            for (int i = 0; i < cols1.Length; i++)
            {
                for (int j = 0; j < cols2.Length; j++)
                {
                    if(cols1[i] == cols2[j])
                    {
                        tempArr[k] = cols1[i];
                        k++;
                    }
                }
            }

            if(k == 0)
            {
                return null;
            }
            
            Column[] result = new Column[k];

            for (int i = 0; i < k; i++)
            {
                result[i] = tempArr[i];
            }

            return result;
        }

        public static Block[] calculateDeltaValues()
        {
            int length = (int) Math.Pow(15 , 4);
            Block[] outputs = new Block[length];

            int k = 0;
            for (int i = 1; i < 16; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    for (int m = 1; m < 16; m++)
                    {
                        for (int n = 1; n < 16; n++)
                        {
                            Column c = new Column(i , j , m ,n);
                            Block tempBlock = new Block(c , c , c , c);
                            outputs[k] = MC(tempBlock);
                            k++;
                        }
                    }
                }
            }
            return outputs;
        }

        public static int[,] noneZeroNibblesTable()
        {
            int[,] result = new int[5 , 5];

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int m = 0; m < 16; m++)
                    {
                        for (int n = 0; n < 16; n++)
                        {
                            Column tempCol = new Column(i , j , m , n);
                            Column mltBlock =  MDS * tempCol;

                            int inputNoneZeros = 4 - calculateNoneZeroNibbles(tempCol);
                            int outputNoneZeros = 4 - calculateNoneZeroNibbles(mltBlock);

                            for (int k = 0; k < 5; k++)
                            {
                                for (int l = 0; l < 5; l++)
                                {
                                    if((k == inputNoneZeros) && (l == outputNoneZeros))
                                    {
                                        result[k , l]++;
                                    }   
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static void showTable(int[ , ] table)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("\t" + table[i , j]);
                }
                Console.Write("\n");
            }
        }

        public static int calculateNoneZeroNibbles(Column col)
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                if(col.column[i , 0].Num == 0)
                {
                    counter++;
                }
            }            
            return counter;
        }

        public static Block AC(Block plain_text, int round_number)
        {
            return LED.addConstant(plain_text , round_number , false);
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
            return LED.addConstant(plain_text , round_number , false);
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