namespace BitMapConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            while (repeat)
            {
                Console.Write("Please Enter Bitmap value:");

                string hexString = Console.ReadLine()!.Replace(" ", "");

                string binaryString = HexadecimalToLong(hexString);

                //string binaryString = BinaryValue(num);

                Print(binaryString,1);

                if (binaryString[0] == '1')
                {
                    Console.WriteLine("There is exist second bitmap");

                    Console.Write("Please Enter Second Bitmap Value or exit(Y):");

                    string secondHexString = Console.ReadLine()!.Replace(" ", "");

                    if (secondHexString == "Y")
                    {
                        repeat = false;
                        break;
                    }

                    string binarySecondString = HexadecimalToLong(secondHexString);

                    //string binarySecondString = BinaryValue(num2);

                    Print(binarySecondString,65);

                    if (binarySecondString[0] == '1')
                    {
                        Console.WriteLine("There is exist third bitmap");

                        Console.Write("Please Enter Third Bitmap Value:");

                        string thirdHexString = Console.ReadLine()!.Replace(" ", "");

                        string binaryThirdString = HexadecimalToLong(secondHexString);

                        //string binaryThirdString = BinaryValue(num2);

                        Print(binaryThirdString,129);

                        Exit();
                    }
                    else
                        Console.WriteLine("----");

                }
                else
                {
                    Console.WriteLine("");
                }
            }

            //string BinaryValue(ulong num)
            //{
            //    try
            //    {
            //        return Convert.ToString((long)num, 2).PadLeft(64, '0');
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //     return String.Empty;
                
            //}


            string HexadecimalToLong(string num)
            {
                try
                {
                    string binaryString = String.Join(String.Empty,
                                                  num.Select(
                            c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                    ));

                    return binaryString;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }

                return String.Empty;
                      

            }

            void Print(string binaryString,int offset)
            {
                // İlk değere gerek yok

                for (int i = 1; i < binaryString.Length; i++)
                {
                    if (binaryString[i] == '1')
                    {
                        var dataElementKey = ISO8583DataElements.DataElements.FirstOrDefault(x => x.Key.Equals(i)).Value;
                        Console.WriteLine($"DE {i + offset}  {dataElementKey}");
                    }
                }
            }

            bool Exit()
            {
                Console.WriteLine("Do you want to enter another value? (Y/N): ");
                string response = Console.ReadLine()?.Trim().ToUpper();

                if (response != "Y")
                {
                    repeat = false;
                    return repeat;
                }

                return repeat;
            }

        }
    }
}


//// Hexadecimal number
//string hexNumber = "767F464128E2B608";
//// Convert hexadecimal to binary
//string binaryNumber = Convert.ToString(Convert.ToInt64(hexNumber, 16), 2);
//Console.WriteLine("Hexadecimal: " + hexNumber);
//Console.WriteLine("Binary: " + binaryNumber);

//Console.WriteLine();
