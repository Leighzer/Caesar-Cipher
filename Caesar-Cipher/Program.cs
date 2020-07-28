using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace Caesar_Cipher
{
    public class Program
    { 
        public static void Main(string[] argsArray)
        {
            List<string> args = new List<string>(argsArray);

            if (args.Count < 2)
            {
                Console.WriteLine("Not enough arguments supplied.");
                return;
            }

            string filePath = args[0];

            int origShift;
            if (!int.TryParse(args[1], out origShift))
            {
                Console.WriteLine($"Argument {args[1]} is not a valid shift value.");
            }
            int shift = origShift % (byte.MaxValue + 1);
            if(shift == 0)
            {
                Console.WriteLine($"{origShift} is an ineffictive shift value. The file is unchanged.");
                return;
            }

            bool fileExists = File.Exists(filePath);
            if (fileExists)
            {
                try
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    for(int i = 0; i < fileBytes.Length; i++)
                    {
                        fileBytes[i] = (byte) (fileBytes[i] + shift);
                    }
                    File.WriteAllBytes(filePath, fileBytes);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Caesar cipher 'encryption' failed.");
                    Console.WriteLine(e.StackTrace);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            Console.WriteLine("'Encryption' complete.");
        }
    }
}