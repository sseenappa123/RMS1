using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using RMS.Service;

namespace RMS
{
    /*
        Inputs      => X into Y grid of  numbers
                        Assumption 
                            1 > X and Y are positive numbers ( empty array can be passed, Array to Adjacent square)
                            2 > Numbers in grid are valid integer, can be negative.
                    =>  Z adjacent numbers
                    =>  Directions ( not supplied per trans) , but are up, down left , right and diagnol. ( traversing should be 4 ) 

        Problem    => N number of different combinations , Find N. ( assumption : Set {1 ,2 , 3 } , {2 ,3,1} means N =1)
                   => Greates product ( f(a,b,c..Z)) any direction), output in long {Int.Maxvalue ^ Z}
                   => Solve bound
        Constraing  => Performance as they will use large grid, overflow ( array bounds traversing, product result) method signature as prescribed.
                        Clean and readable, testable.
     */

    internal class Program
    {
   

        private static void Main(string[] args)
        {
            try
            {

                //int adjacentInteger = 10;

                // // Jagged Array instead of Matrix or two dimensional Array as the sample method signature provided takes a input of Array of Array.
                //var searchGrid = new[]
                // {
                //         new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                //     , new[] {11, 12, 13, 14, 15, 16, 17, 18, 19, 20}
                //     , new[] {21, 22, 23, 24, 25, 26, 27, 28, 29, 30}
                //     , new[] {31, 32, 33, 34, 35, 36, 37, 38, 39, 40}
                //     , new[] {41, 42, 43, 44, 45, 46, 47, 48, 49, 50}
                //   //  , new[] {4,-33}
                //     //, new[] {41, 42, 43, 44, 45, 46, 47, 48, 49, 50 , 12 , 90 , 852 }
                //     , new[] {51, 52, 53, 54, 55, 56, 57, 58, 59, 60}
                //     , new[] {61, 62, 63, 64, 65, 66, 67, 68, 69, 70}
                //     , new[] {71, 72, 73, 74, 75, 76, 77, 78, 79, 80}
                //     , new[] {81, 82, 83, 84, 85, 86, 87, 88, 89, 90}
                //     , new[] {91, 92, 93, 94, 95, 96, 97, 98, 99, 100}

                // };
                int row = 0;
                int adjacentInteger = 0;

                Console.WriteLine("Enter number of rows in the grid");
                string d = Console.ReadLine();

                if (!int.TryParse(d, out row) || row <= 0)
                {
                    Console.WriteLine("should be positive number , HIT A KEY TO EXTI");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Enter number of adjacent number");
                d = Console.ReadLine();
                if (!int.TryParse(d, out adjacentInteger) || adjacentInteger <= 0)
                {
                    Console.WriteLine("should be positive number , HIT A KEY TO EXTI");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Full Path to file (.txt) which containes rows of space delimited number please");

                d = Console.ReadLine();
                if (!File.Exists(d))
                {
                    Console.WriteLine("file does not exit, HIT A KEY TO EXTI");
                    Console.ReadKey();
                    return;
                }

                var searchGrid = new int[row][];
                using (StreamReader reader = new StreamReader(d))
                {
                    int i = 0;
                    do
                    {

                        string[] temp = reader.ReadLine()?.TrimEnd().Split(' ');
                        if (temp != null)
                            searchGrid[i++] = Array.ConvertAll(temp, int.Parse);
                    }
                    while (!reader.EndOfStream);

                }





                ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
                Console.WriteLine(
                    $"The Greatest prodcut of {adjacentInteger} adjacent is {productN.LargestProductOfNAdjacentIntegers(searchGrid, adjacentInteger)}.");
                Console.WriteLine(
                    $"Total Non Unique combination  for  {adjacentInteger} adjacent number is {productN.NumberOfCombinationNAdjacent(searchGrid, adjacentInteger)}.");
                Console.WriteLine(
                    $"Total Unique (different) combination {adjacentInteger} adjacent number is {productN.NumberOfUniqueCombinationNAdjacent(searchGrid, adjacentInteger)}.");

                Console.ReadKey();
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
