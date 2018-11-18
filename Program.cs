using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Calculating_GC_Content_And_Reverse_Complement
{
    class Program
    {
        static void Main(string[] args)
        {
            string dna = "";
            string input = "";
            string pattern = "^[CGATN]+$"; // Regex pattern used to exclude characters which are not bases of DNA code or the unknown base read "N"
            bool correctInput = false;
            Console.WriteLine("*****************************************************************************************************************");
            Console.WriteLine("This simple program calculates the GC content of the DNA sequence, and creates a reverse complement DNA sequence.");
            Console.WriteLine("*****************************************************************************************************************");
            Console.WriteLine("");

            /*User input of the DNA sequence and testing if input characters are DNA bases*/
            do
            {

                Console.WriteLine("Please input the DNA sequence: ");
                input = Console.ReadLine();
                dna = input.ToUpper();


                Match match = Regex.Match(dna, pattern);
                if (match.Success)
                { correctInput = true; }
                else {
                    Console.WriteLine("\nYour sequence has invalid characters. The only characters allowed in DNA sequence are A, T, C, G and N (N stands for unknown DNA base readout).");
                    correctInput = false; }


            } while (correctInput == false);
            Console.WriteLine("\nYour DNA sequence is: ");
            Console.WriteLine(dna);
            Console.WriteLine("");

            /*Counting GC content from the inputed DNA sequence*/
            int C_count = dna.Count(c => c == 'C');
            int G_count = dna.Count(g => g == 'G');
            int length = dna.Length;
            double GC_count = ((double)C_count + (double)G_count) / (double)length * 100;
            Console.WriteLine("The GC content of the sequence is: " + GC_count.ToString("N2") + "%.");
            Console.WriteLine("");

            /*Complement DNA*/
            string tempDNA = dna.Replace('A', 'X').Replace('C', 'Y');
            string tempDNA1 = tempDNA.Replace('T', 'A').Replace('G', 'C');
            string complementDNA = tempDNA1.Replace('X', 'T').Replace('Y', 'G');

            /*Reverse Complement DNA*/
            string reverseComplement = new string(complementDNA.Reverse().ToArray());
            Console.WriteLine("The reverse complement of the sequence is: ");
            Console.WriteLine(reverseComplement);
            Console.ReadKey();

        }
    }
}
