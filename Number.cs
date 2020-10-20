using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Block_Cipher
{
    class Number
    {

        int number;

        public Number()
        {
            this.number = 0;
        }

        public Number(int num)
        {
            this.number = num;
        }
        

        public static Number operator +(Number num1 , Number num2)
        {

            int[,] plusMatrix =
            {
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 } ,
                { 1, 0, 3, 2, 5, 4, 7, 6, 9, 8, 11, 10, 13, 12, 15, 14 } ,
                { 2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13 } ,
                { 3, 2, 1, 0, 7, 6, 5, 4, 11, 10, 9, 8, 15, 14, 13, 12 } ,
                { 4, 5, 6, 7, 0, 1, 2, 3, 12, 13, 14, 15, 8, 9, 10, 11 } ,
                { 5, 4, 7, 6, 1, 0, 3, 2, 13, 12, 15, 14, 9, 8, 11, 10 } ,
                { 6, 7, 4, 5, 2, 3, 0, 1, 14, 15, 12, 13, 10, 11, 8, 9 } ,
                { 7, 6, 5, 4, 3, 2, 1, 0, 15, 14, 13, 12, 11, 10, 9, 8 } ,
                { 8, 9, 10, 11, 12, 13, 14, 15 ,0, 1, 2, 3, 4, 5, 6, 7 } ,
                { 9, 8, 11, 10, 13, 12, 15, 14 ,1, 0, 3, 2, 5, 4, 7, 6 } ,
                { 10, 11, 8, 9, 14, 15 ,12, 13, 2, 3, 0, 1, 6, 7, 4, 5 } ,
                { 11, 10, 9, 8, 15, 14 ,13, 12, 3, 2, 1, 0, 7, 6, 5, 4 } ,
                { 12, 13, 14, 15 ,8, 9, 10, 11, 4, 5, 6, 7, 0, 1, 2, 3 } ,
                { 13, 12, 15, 14 ,9, 8, 11, 10, 5, 4, 7, 6, 1, 0, 3, 2 } ,
                { 14, 15 ,12, 13, 10, 11, 8, 9, 6, 7, 4, 5, 2, 3, 0, 1 } ,
                { 15, 14 ,13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
            };

            return new Number(plusMatrix[num1.number, num2.number]);
        }

        public static Number operator *(Number num1, Number num2)
        {

            int[,] prodMatrix =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 , 0 , 0 , 0 , 0 , 0 , 0 } ,
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 } ,
                { 0, 2, 4, 6, 8, 10, 12, 14, 3, 1, 7, 5, 11, 9, 15, 13 } ,
                { 0, 3, 6, 5, 12, 15, 10, 9, 11, 8, 13, 14, 7, 4, 1, 2 } ,
                { 0, 4, 8, 12, 3, 7, 11, 15, 6, 2, 14, 10, 5, 1, 13, 9 } ,
                { 0, 5, 10, 15, 7, 2, 13, 8, 14, 11, 4, 1, 9, 12, 3, 6 } ,
                { 0, 6, 12, 10, 11, 13, 7, 1, 5, 3, 9, 15, 14, 8, 2, 4 } ,
                { 0, 7, 14, 9, 15, 8, 1, 6, 13, 10, 3, 4, 2, 5, 12, 11 } ,
                { 0, 8, 3, 11, 6, 14, 5, 13 ,12, 4, 15, 7, 10, 2, 9, 1 } ,
                { 0, 9, 1, 8, 2, 11, 3, 10 ,4, 13, 5, 12, 6, 15, 7, 14 } ,
                { 0, 10, 7, 13, 14, 4 ,9, 3, 15, 5, 8, 2, 1, 11, 6, 12 } ,
                { 0, 11, 5, 14, 10, 1 ,15, 4, 7, 12, 2, 9, 13, 6, 8, 3 } ,
                { 0, 12, 11, 7 ,5, 9, 14, 2, 10, 6, 1, 13, 15, 3, 4, 8 } ,
                { 0, 13, 9, 4 ,1, 12, 8, 5, 2, 15, 11, 6, 3, 14, 10, 7 } ,
                { 0, 14 ,15, 1, 13, 3, 2, 12, 9, 7, 6, 8, 4, 10, 11, 5 } ,
                { 0, 15 ,13, 2, 9, 6, 4, 11, 1, 14, 12, 3, 8, 7, 5, 10 }
            };

            return new Number(prodMatrix[num1.number, num2.number]);
        }

        public int Num
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }
    }


    class Column
    {
        Number[,] col = new Number[4, 1];


        public Column()
        {
            for (int i = 0; i < 4; i++)
            {
                this.column[i, 0] = new Number(0);
            }
        }


        public Column(int c0 , int c1 , int c2 , int c3)
        {
            this.column[0, 0] = new Number(c0);
            this.column[1, 0] = new Number(c1);
            this.column[2, 0] = new Number(c2);
            this.column[3, 0] = new Number(c3);
        }


        public Column(int[] elements)
        {
            for (int i = 0; i < 4; i++)
            {
                this.column[i, 0] = new Number(elements[i]);
            }
        }

        public static void showColumn(Column col)
        {
            for (int i = 0; i < 4; i++)
            {
                String tempStr;
                    switch (col.column[i, 0].Num)
                    {
                        case 10:
                            tempStr = "A";
                            break;
                        case 11:
                            tempStr = "B";
                            break;
                        case 12:
                            tempStr = "C";
                            break;
                        case 13:
                            tempStr = "D";
                            break;
                        case 14:
                            tempStr = "E";
                            break;
                        case 15:
                            tempStr = "F";
                            break;
                        default:
                            tempStr = col.column[i, 0].Num.ToString();
                            break;
                    }
                Console.WriteLine(tempStr);
            }
        }

        public static Boolean operator ==(Column clm1, Column clm2)
        {
            if(clm1.col[0,0].Num == clm2.col[0,0].Num &&
               clm1.col[1,0].Num == clm2.col[1,0].Num &&
               clm1.col[2,0].Num == clm2.col[2,0].Num &&
               clm1.col[3,0].Num == clm2.col[3,0].Num)
               {
                   return true;
               }
            return false;
        }

        public static Boolean operator !=(Column clm1, Column clm2)
        {
            if(clm1.col[0,0].Num == clm2.col[0,0].Num &&
               clm1.col[1,0].Num == clm2.col[1,0].Num &&
               clm1.col[2,0].Num == clm2.col[2,0].Num &&
               clm1.col[3,0].Num == clm2.col[3,0].Num)
               {
                   return false;
               }
            return true;
        }

        internal Number[,] column
        {
            get
            {
                return col;
            }

            set
            {
                col = value;
            }
        }
    }

    class Block
    {
        Number[,] blck = new Number[4, 4];

        public Block()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.blck[i, j] = new Number(0);
                }
            }
        }

        public Block(Column c0 , Column c1 , Column c2 , Column c3)
        {

            for (int i = 0; i < 4; i++)
            {
                this.blck[i, 0] = new Number(c0.column[i, 0].Num);
                this.blck[i, 1] = new Number(c1.column[i, 0].Num);
                this.blck[i, 2] = new Number(c2.column[i, 0].Num);
                this.blck[i, 3] = new Number(c3.column[i, 0].Num);
            }
        }

        public Block(int[,] _blck)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.blck[i, j] = new Number(_blck[i, j]);
                }
            }
        }


        public Block(String[,] _blck)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch(_blck[i, j])
                    {
                        case "A":
                            blck[i, j].Num = 10;
                            break;
                        case "B":
                            blck[i, j].Num = 11;
                            break;
                        case "C":
                            blck[i, j].Num = 12;
                            break;
                        case "D":
                            blck[i, j].Num = 13;
                            break;
                        case "E":
                            blck[i, j].Num = 14;
                            break;
                        case "F":
                            blck[i, j].Num = 15;
                            break;
                        default:
                            int num = Convert.ToInt32(_blck[i, j]);
                            if (num >=0 && num <= 9)
                            {
                                blck[i, j].Num = num;
                            }
                            else
                            {
                                blck[i, j].Num = -1;
                            }
                            break;
                    }
                }
            }
        }


        public static Block operator +(Block blc1, Block blc2)
        {
            Block blc3 = new Block();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    blc3.block[i, j] = blc1.block[i, j] + blc2.block[i, j];
                }
            }
            return blc3;
        }


        public static Column operator *(Block blc, Column col)
        {
            int m = 4;
            int n = 4;
            int q = 1;
            //Number[,] blc3 = new Number[4, 1];
            Column res = new Column();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    Number result = new Number();
                    for (int k = 0; k < n; k++)
                    {
                        result = result + (blc.block[i, k] * col.column[k, j]); // Number multiple
                    }
                    res.column[i, j] = new Number(result.Num);
                }
            }

            return res;
        }


        public static Number[,] operator *(Block blc1, Number[,] blc2)
        {
            int m = 4;
            int n = 4;
            int q = 1;
            Number[,] blc3 = new Number[4, 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    Number result = new Number();
                    for (int k = 0; k < n; k++)
                    {
                        result = result + (blc1.block[i,k] * blc2[k,j]); // Number multiple
                    }
                    blc3[i,j]= new Number(result.Num);
                }
            }

            return blc3;
        }


        public static Block operator |(Block blc1, Block blc2)
        {
            Block blc3 = new Block();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    String biNum1 = getBinaryNibble(blc1.block[i, j].Num);
                    String biNum2 = getBinaryNibble(blc2.block[i, j].Num);
                    String biNum3 = xOr(biNum1, biNum2);
                    String result = getHexNibble(biNum3);
                    blc3.block[i, j].Num = Convert.ToInt32(result);
                }
            }

            return blc3;
        }


        public static String xOr(String BiNum1, String BiNum2)
        {
            if (BiNum1.Length > BiNum2.Length)
            {
                BiNum2 = addZero(BiNum2, BiNum1.Length - BiNum2.Length);
            }
            else
            {
                BiNum1 = addZero(BiNum1, BiNum2.Length - BiNum1.Length);
            }
            String result = "";
            for (int i = BiNum1.Length - 1; i >= 0; i--)
            {
                if (BiNum1[i] == BiNum2[i])
                {
                    result = "0" + result;
                }
                else
                {
                    result = "1" + result;
                }
            }

            return result;
        }

        public static String addZero(String BiNum, int quantity)
        {
            String result = "";
            for (int i = 0; i < quantity; i++)
            {
                result = "0" + result;
            }
            return result + BiNum;
        }

        public static String getBinaryNibble(int hex)
        {
            String result;
            switch (hex)
            {
                case 0:
                    result = "0000";
                    break;
                case 1:
                    result = "0001";
                    break;
                case 2:
                    result = "0010";
                    break;
                case 3:
                    result = "0011";
                    break;
                case 4:
                    result = "0100";
                    break;
                case 5:
                    result = "0101";
                    break;
                case 6:
                    result = "0110";
                    break;
                case 7:
                    result = "0111";
                    break;
                case 8:
                    result = "1000";
                    break;
                case 9:
                    result = "1001";
                    break;
                case 10:
                    result = "1010";
                    break;
                case 11:
                    result = "1011";
                    break;
                case 12:
                    result = "1100";
                    break;
                case 13:
                    result = "1101";
                    break;
                case 14:
                    result = "1110";
                    break;
                case 15:
                    result = "1111";
                    break;
                default:
                    result = "EROR";
                    break;
            }

            return result;
        }

        public static String getHexNibble(String bin)
        {
            String result;
            switch (bin)
            {
                case "0000":
                    result = "0";
                    break;
                case "0001":
                    result = "1";
                    break;
                case "0010":
                    result = "2";
                    break;
                case "0011":
                    result = "3";
                    break;
                case "0100":
                    result = "4";
                    break;
                case "0101":
                    result = "5";
                    break;
                case "0110":
                    result = "6";
                    break;
                case "0111":
                    result = "7";
                    break;
                case "1000":
                    result = "8";
                    break;
                case "1001":
                    result = "9";
                    break;
                case "1010":
                    result = "10";
                    break;
                case "1011":
                    result = "11";
                    break;
                case "1100":
                    result = "12";
                    break;
                case "1101":
                    result = "13";
                    break;
                case "1110":
                    result = "14";
                    break;
                case "1111":
                    result = "15";
                    break;
                default:
                    result = "-1";
                    break;
            }

            return result;
        }

        public static int getBinaryNibble(String hex)
        {
            int result;
            switch (hex)
            {
                case "A":
                    result = 10;
                    break;
                case "B":
                    result = 11;
                    break;
                case "C":
                    result = 12;
                    break;
                case "D":
                    result = 13;
                    break;
                case "E":
                    result = 14;
                    break;
                case "F":
                    result = 15;
                    break;
                default:
                    result = Convert.ToInt32(hex);
                    break;
            }

            return result;
        }


        public static void insertColumnInBlock(Block blc , Column clm , int ColumnNumber)
        {
            for (int i = 0; i < 4; i++)
            {
                blc.block[i, ColumnNumber].Num = clm.column[i , 0].Num;
            }
        }


        public static Column insertBlockInColumn(Block blc, int ColumnNumber)
        {
            Column result = new Column();

            for (int i = 0; i < 4; i++)
            {
                result.column[i, 0].Num = blc.block[i, ColumnNumber].Num;
            }

            return result;
        }


        internal Number[,] block
        {
            get
            {
                return this.blck;
            }

            set
            {
                this.blck = value;
            }
        }

        public static void showBlock(Block blc)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    String tempStr;
                    switch (blc.block[i, j].Num)
                    {
                        case 10:
                            tempStr = "A";
                            break;
                        case 11:
                            tempStr = "B";
                            break;
                        case 12:
                            tempStr = "C";
                            break;
                        case 13:
                            tempStr = "D";
                            break;
                        case 14:
                            tempStr = "E";
                            break;
                        case 15:
                            tempStr = "F";
                            break;
                        default:
                            tempStr = blc.block[i, j].Num.ToString();
                            break;
                    }
                    Console.Write("\t" + tempStr);
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }
    }

    class LED
    {

        Block plainText;
        Block cipherText;
        Block key;

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


        public LED()
        {
            this.plainText = null;
            this.key = null;
        }

        public Block encryption(Block plain_text, Block _key)
        {
            const int ALL_ROUNDS = 8;

            this.plainText = plain_text;
            this.key = _key;

            // Show Plain-Text Block :
            Console.WriteLine("\tPlain Text Block : ");
            Block.showBlock(plainText);
            /////////////////////////////////////////////////

            // Show Key Block :
            Console.WriteLine("\tKey Block : ");
            Block.showBlock(key);
            /////////////////////////////////////////////////

            Block cipher_text = blockCopy(plainText);

            // Pre_Whitening :
            cipher_text = addRoundKey(cipher_text, key);

            // Show AddRoundKey level - Round : 1
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\tAddRoundKey Level - Round : " + 1);
            Block.showBlock(cipher_text);
            /////////////////////////////////////////////////

            // 
            for (int round = 0; round < ALL_ROUNDS; round++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //Round Constant :
                    cipher_text = addConstant(cipher_text, (4 * round + j) , false);

                    // Show RoundConstant level - Round : i
                    Console.WriteLine("\n------------------------------------\n\tRoundConstant Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(cipher_text);
                    /////////////////////////////////////////////////

                    // Sub Cells :
                    cipher_text = subCells(cipher_text, SBox);

                    // Show SubCells level - Round : i
                    Console.WriteLine("\tSubCells Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(cipher_text);
                    /////////////////////////////////////////////////

                    // Shift Rows :
                    cipher_text = shiftRows(cipher_text , leftShift);

                    // Show ShiftRows level - Round : i
                    Console.WriteLine("\tShiftRows Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(cipher_text);
                    /////////////////////////////////////////////////

                    // Mix Column Serial :
                    cipher_text = mixColumnSerial(cipher_text , MDS);

                    // Show MixColumnSerial level - Round : i
                    Console.WriteLine("\tMixColumnSerial Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(cipher_text);
                    /////////////////////////////////////////////////
                }
                cipher_text = cipher_text | key;

                // Show AddRoundKey level - Round : i
                Console.WriteLine("------------------------------------");
                Console.WriteLine("\tAddRoundKey Level - Round : " + (round + 1));
                Block.showBlock(cipher_text);
                /////////////////////////////////////////////////
            }

            // Show Final CipherText :
            Console.WriteLine("\n------------------------------------\n------------------------------------");
            Console.WriteLine("\tFinal CipherText : ");
            Block.showBlock(cipher_text);
            /////////////////////////////////////////////////

            this.cipherText = cipher_text;
            return cipher_text;
        }

        public Block decryption(Block cipher_text, Block _key)
        {
            const int ALL_ROUNDS = 8;

            this.cipherText = cipher_text;
            this.key = _key;

            // Show Cipher-Text Block :
            Console.WriteLine("\tCipher Text Block : ");
            Block.showBlock(cipherText);
            /////////////////////////////////////////////////

            // Show Key Block :
            Console.WriteLine("\tKey Block : ");
            Block.showBlock(key);
            /////////////////////////////////////////////////

            Block plain_text = blockCopy(cipherText);

            // Pre_Whitening :
            plain_text = addRoundKey(plain_text, key);

            // Show AddRoundKey level - Round : 8
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\tInvAddRoundKey Level - Round : " + 8);
            Block.showBlock(plain_text);
            /////////////////////////////////////////////////                                    Updated 

            // 
            for (int round = ALL_ROUNDS - 1; round >= 0; round--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    
                    // Mix Column Serial :
                    plain_text = mixColumnSerial(plain_text , IMDS);

                    // Show MixColumnSerial level - Round : i
                    Console.WriteLine("\n------------------------------------\n\tInvMixColumnSerial Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(plain_text);
                    /////////////////////////////////////////////////

                    // Shift Rows :
                    plain_text = shiftRows(plain_text , inverseLeftShift);

                    // Show ShiftRows level - Round : i
                    Console.WriteLine("\tInvShiftRows Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(plain_text);
                    /////////////////////////////////////////////////

                    // Sub Cells :
                    plain_text = subCells(plain_text, iSBox);

                    // Show SubCells level - Round : i
                    Console.WriteLine("\tInvSubCells Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(plain_text);
                    /////////////////////////////////////////////////


                    //Round Constant :
                    plain_text = addConstant(plain_text, (4 * round + j) , false);    // Fault Injection belongs to Encryption method

                    // Show RoundConstant level - Round : i
                    Console.WriteLine("\tInvRoundConstant Level - Round : " + (4 * round + j + 1));
                    Block.showBlock(plain_text);
                    /////////////////////////////////////////////////
                }
                plain_text = plain_text | key;

                // Show AddRoundKey level - Round : i
                Console.WriteLine("------------------------------------");
                Console.WriteLine("\tInvAddRoundKey Level - Round : " + (round + 1));
                Block.showBlock(plain_text);
                /////////////////////////////////////////////////
            }

            // Show Final CipherText :
            Console.WriteLine("\n------------------------------------\n------------------------------------");
            Console.WriteLine("\tFinal PlainText : ");
            Block.showBlock(plain_text);
            /////////////////////////////////////////////////

            this.plainText = plain_text;
            return plain_text;
        }

        public Block encryptionWithoutPrint(Block plain_text, Block _key , Boolean faultInjection)
        {
            const int ALL_ROUNDS = 8;

            this.plainText = plain_text;
            this.key = _key;

            Block cipher_text = blockCopy(plainText);

            // Pre_Whitening :
            cipher_text = addRoundKey(cipher_text, key);

            // 
            for (int round = 0; round < ALL_ROUNDS; round++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //Round Constant :
                    cipher_text = addConstant(cipher_text, (4 * round + j) , faultInjection);
                    /////////////////////////////////////////////////

                    // Sub Cells :
                    cipher_text = subCells(cipher_text, SBox);
                    /////////////////////////////////////////////////

                    // Shift Rows :
                    cipher_text = shiftRows(cipher_text , leftShift);
                    /////////////////////////////////////////////////

                    // Mix Column Serial :
                    cipher_text = mixColumnSerial(cipher_text , MDS);
                    /////////////////////////////////////////////////
                }
                cipher_text = cipher_text | key;
                /////////////////////////////////////////////////
            }

            this.cipherText = cipher_text;
            return cipher_text;
        }

        public static Block addRoundKey(Block plain_text , Block _key)
        {
            return (plain_text | _key);
        }

        public static Block addConstant(Block plain_text , int round_number , Boolean faultInjection)
        {
            String[] constants = { "01" , "03" , "07" , "17" , "37" , "76" , "75" , "73" , "67" , "57" , "36" , "74" ,
                                   "71" , "63" , "47" , "16" , "35" , "72" , "65" , "53" , "26" , "54" , "30" , "60" ,
                                   "41" , "02" , "05" , "13" , "27" , "56" , "34" , "70" , "61" , "43" , "06" , "15" ,
                                   "33" , "66" , "55" , "32" , "64" , "51" , "22" , "44" , "10" , "21" , "42" , "04" };


            int x = Block.getBinaryNibble(constants[round_number][0].ToString());
            int y = Block.getBinaryNibble(constants[round_number][1].ToString());
            
            int[,] intArray = { { 0, x, 0, 0 }, { 1, y, 0, 0 }, { 2, x, 0, 0 }, { 3, y, 0, 0 } };
            Block RC = new Block(intArray);

            Block result = plain_text | RC;
            ////////////////////////////////////////////////////////////////////////////

            // Fault Injecting :

            if (faultInjection)
            {
                if (round_number == 27)
                {
                Random r = new Random();
                int faultyRow, faultyColumn, faultValue;
                while (true)                                                          // "if" |FaultValue - plain[i,j]| == 0 "then" try again
                {
                    faultyRow = r.Next(0, 3);                                         // First random rowNumber was : 0
                    faultyColumn = r.Next(0, 3);                                      // First random columnNumber was : 2
                    faultValue = r.Next(0, 15);                                       // First random rowNumber was : 7
                    if(faultValue != plain_text.block[faultyRow, faultyColumn].Num)
                    {
                        break;
                    }
                }
                result.block[faultyRow, faultyColumn].Num = faultValue;
                }
            }
            ////////////////////////////////////////////////////////////////////////////

            return result;
        }

        public static Block subCells(Block plain_text , int[] S_BOX)
        {
            

            Block tempBlock = new Block();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tempBlock.block[i, j] = new Number();
                    tempBlock.block[i, j].Num = S_BOX[plain_text.block[i, j].Num];
                }
            }


            return (tempBlock);//| plain_text);
        }

        public static Block shiftRows(Block plain_text , bool doInverseLeftShift)
        {
            Block tempBlock = new Block();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if(doInverseLeftShift == false)
                    {
                        plain_text = leftShiftRow(plain_text, i);
                    }
                    else
                    {
                        plain_text = rightShiftRow(plain_text, i);
                    }
                }
            }
            

            return plain_text;
        }

        public static Block mixColumnSerial(Block plain_text , Block MDS_MATRIX)
        {
            Block tempBlock = new Block();

            for (int i = 0; i < 4; i++)
            {
                //Number[,] tempColumn = matrixMultiple(plain_text , i , MDS_MATRIX);
                Column tempColumn = matrixMultiple(plain_text, i, MDS_MATRIX);
                for (int j = 0; j < 4; j++)
                {
                    //plain_text.block[j, i].Num = tempColumn[j , 0].Num;
                    Block.insertColumnInBlock(plain_text, tempColumn, i);
                }
            }
            

            return plain_text;
        }

        public static Column matrixMultiple(Block plain_text, int column, Block MDS_MATRIX)
        {
            Column resultColumn = new Column();
            Column tempColumn = new Column();




            for (int i = 0; i < 4; i++)
            {
                tempColumn.column[i, 0] = new Number(plain_text.block[i, column].Num);
            }

            resultColumn = MDS_MATRIX * tempColumn;

            return resultColumn;
        }


        public static Block leftShiftRow(Block blck , int row)
        {
            int tempNumber = blck.block[row, 0].Num;
            blck.block[row, 0].Num = blck.block[row, 1].Num;
            blck.block[row, 1].Num = blck.block[row, 2].Num;
            blck.block[row, 2].Num = blck.block[row, 3].Num;
            blck.block[row, 3].Num = tempNumber;
            return blck;
        }

        public static Block rightShiftRow(Block blck, int row)
        {
            int tempNumber = blck.block[row, 3].Num;
            blck.block[row, 3].Num = blck.block[row, 2].Num;
            blck.block[row, 2].Num = blck.block[row, 1].Num;
            blck.block[row, 1].Num = blck.block[row, 0].Num;
            blck.block[row, 0].Num = tempNumber;
            return blck;
        }

        public static Block blockCopy(Block block)
        {
            Block result = new Block();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.block[i, j].Num = block.block[i, j].Num;
                }
            }
            return result;
        }


        internal Block PlainText
        {
            get
            {
                return plainText;
            }

            set
            {
                plainText = value;
            }
        }

        internal Block CipherText
        {
            get
            {
                return cipherText;
            }

            set
            {
                cipherText = value;
            }
        }

        internal Block Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }
    }
}
