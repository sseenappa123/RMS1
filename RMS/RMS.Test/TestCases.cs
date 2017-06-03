using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RMS.Service;

namespace RMS.Test
{

    public class Test
    {
        private int[][] inputA;
        private int[][] inputB;
        private int[][] inputC;

        private int[][] simple3x3ArrayOfArray;
        private int[][] simple3x3ArrayOfArray1;
        private int[][] simple3x3ArrayWithUniqueNumber;
        private int[][] jagged;
        private int[][] searchGrid;
        [SetUp]
        public void SetupInput()
        {

            inputA = new[]
            {
                new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                , new[] {11, 12, 13, 14, 15, 16, 17, 18, 19, 20}
                , new[] {21, 22, 23, 24, 25, 26, 27, 28, 29, 30}
                , new[] {31, 32, 33, 34, 35, 36, 37, 38, 39, 40}
                , new[] {41, 42, 43, 44, 45, 46, 47, 48, 49, 50}
                //  , new[] {4,-33}
                //, new[] {41, 42, 43, 44, 45, 46, 47, 48, 49, 50 , 12 , 90 , 852 }
                , new[] {51, 52, 53, 54, 55, 56, 57, 58, 59, 60}
                , new[] {61, 62, 63, 64, 65, 66, 67, 68, 69, 70}
                , new[] {71, 72, 73, 74, 75, 76, 77, 78, 79, 80}
                , new[] {81, 82, 83, 84, 85, 86, 87, 88, 89, 90}
                , new[] {91, 92, 93, 94, 95, 96, 97, 98, 99, 100}

            };

            inputB = new int[100][];

            inputC = new[]
            {
                new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                , new[] {11, 12, 13, 14, 15, 16, 17, 18, 19, 20}
                , new[] {21, 22, 23, 24, 25, 26, 27, 28, 29, 30}
                , new[] {31, 32, 33, 34, 35, 36, 37, 38, 39, 40}
                //  , new[] {41, 42, 43, 44, 45, 46, 47, 48, 49, 50}
                , null
                //  , new[] {4,-33}
                //, new[] {41, 42, 43, 44, 45, 46, 47, 48, 49, 50 , 12 , 90 , 852 }
                , new[] {51, 52, 53, 54, 55, 56, 57, 58, 59, 60}
                , new[] {61, 62, 63, 64, 65, 66, 67, 68, 69, 70}
                , new[] {71, 72, 73, 74, 75, 76, 77, 78, 79, 80}
                , new[] {81, 82, 83, 84, 85, 86, 87, 88, 89, 90}
                , new[] {91, 92, 93, 94, 95, 96, 97, 98, 99, 100}

            };

            searchGrid = new[]
         {
                new[] {8, 2, 22, 97, 38, 15, 0, 40, 0, 75}
                , new[] {49, 49, 99, 40, 17, 81, 18, 57, 60, 87}
                , new[] {81, 49, 31, 73, 55, 79, 14, 29, 93, 71}
                , new[] {52, 70, 95, 23, 4, 60, 11, 42, 69, 24}
                , new[] {22, 31, 16, 71, 51, 67, 63, 89, 41, 92}
                , new[] {24, 47, 32, 60, 99, 3, 45, 2, 44, 75}
                , new[] {32, 98, 81, 28, 64, 23, 67, 10, 26, 38}
                , new[] {67, 26, 20, 68, 2, 62, 12, 20, 95, 63}
                , new[] {24, 55, 58, 5, 66, 73, 99, 26, 97, 17}
                , new[] {21, 36, 23, 9, 75, 0, 76, 44, 20, 45}
            };

            simple3x3ArrayOfArray = new[] {new[] {1, 2, 4}, new[] {1, 2, 4}, new[] {1, 2, 4}};
            simple3x3ArrayWithUniqueNumber = new[] { new[] { 1, 2, 3 }, new[] {4, 5, 6 }, new[] { 7, 8, 9 } };

            jagged = new[] {new[] {1, 2, 3}, new[] {4}, new[] {0, 8, 9}};

                   simple3x3ArrayOfArray1 = new[] { new[] { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue }, new[] { 1, 2, 4 }, new[] { 1, 2, 4 } };

        }

        [TestCase(3)]
        public void ArguementExceptionWhenInputsAreNull(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(null);
            Assert.Throws<ArgumentNullException>(() => productN.LargestProductOfNAdjacentIntegers(inputA, adjacentNumber));
        }

        [TestCase(3)]
        public void ArguementExceptionWhenMethodInputsAreNull(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.Throws<ArgumentNullException>(() => productN.LargestProductOfNAdjacentIntegers(null, adjacentNumber));
        }

        [TestCase(3)]
        public void EmptyArrayPassed(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.Throws<InvalidOperationException>(() => productN.LargestProductOfNAdjacentIntegers(inputB, adjacentNumber));

        }

        [TestCase(3)]
        public void InputArrayWithNull(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.Throws<InvalidOperationException>(() => productN.LargestProductOfNAdjacentIntegers(inputC, adjacentNumber));

        }



        [TestCase(-20)]
        public void NegativeAdjacentNumber(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.Throws<ArgumentOutOfRangeException>(() => productN.LargestProductOfNAdjacentIntegers(inputA, adjacentNumber));

        }


        [TestCase(0)]
        public void ZeroAdjacentNumber(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.Throws<ArgumentOutOfRangeException>(() => productN.LargestProductOfNAdjacentIntegers(inputA, adjacentNumber));

        }

        [TestCase(2)]
        public void TestProductFor3x3Array(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.AreEqual(16, productN.LargestProductOfNAdjacentIntegers(simple3x3ArrayOfArray, adjacentNumber));

            Assert.AreEqual(5, productN.NumberOfUniqueCombinationNAdjacent(simple3x3ArrayOfArray, adjacentNumber));
            Assert.AreEqual(40, productN.NumberOfCombinationNAdjacent(simple3x3ArrayOfArray, adjacentNumber));
        }


        [TestCase(3)]
        public void TestProductFor3x3ArrayWith3AdjacentNumber(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.AreEqual(64, productN.LargestProductOfNAdjacentIntegers(simple3x3ArrayOfArray, adjacentNumber));

            Assert.AreEqual(4, productN.NumberOfUniqueCombinationNAdjacent(simple3x3ArrayOfArray, adjacentNumber));
            Assert.AreEqual(24, productN.NumberOfCombinationNAdjacent(simple3x3ArrayOfArray, adjacentNumber));

        }
        [TestCase(12)]
        public void WhenTheAdjacentNumberIsGreaterThanArrayLength(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.AreEqual(0, productN.LargestProductOfNAdjacentIntegers(simple3x3ArrayOfArray, adjacentNumber));

            Assert.AreEqual(0, productN.NumberOfUniqueCombinationNAdjacent(simple3x3ArrayOfArray, adjacentNumber));
            Assert.AreEqual(0, productN.NumberOfCombinationNAdjacent(simple3x3ArrayOfArray, adjacentNumber));

        }


        [TestCase(3)]
        public void TestProductForsimple3x3ArrayWithUniqueNumber3AdjacentNumber(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.AreEqual(504, productN.LargestProductOfNAdjacentIntegers(simple3x3ArrayWithUniqueNumber, adjacentNumber));

            Assert.AreEqual(8, productN.NumberOfUniqueCombinationNAdjacent(simple3x3ArrayWithUniqueNumber, adjacentNumber));
            Assert.AreEqual(24, productN.NumberOfCombinationNAdjacent(simple3x3ArrayWithUniqueNumber, adjacentNumber));

        }

        [TestCase(3)]
        public void Jagged1(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.AreEqual(6, productN.LargestProductOfNAdjacentIntegers(jagged, adjacentNumber));

            Assert.AreEqual(3, productN.NumberOfUniqueCombinationNAdjacent(jagged, adjacentNumber));
            Assert.AreEqual(9, productN.NumberOfCombinationNAdjacent(jagged, adjacentNumber));

        }

        [TestCase(3)]
        public void TestBounds(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.AreEqual(4611686024869838847, productN.LargestProductOfNAdjacentIntegers(simple3x3ArrayOfArray1, adjacentNumber));
            Assert.AreEqual(7, productN.NumberOfUniqueCombinationNAdjacent(simple3x3ArrayOfArray1, adjacentNumber));
        }


        [TestCase(3)]
        public void TestExample(int adjacentNumber)
        {
            ProductNAdajacentIntegerService productN = new ProductNAdajacentIntegerService(new InputValidator());
            Assert.AreEqual(667755, productN.LargestProductOfNAdjacentIntegers(searchGrid, adjacentNumber));
            Assert.AreEqual(285, productN.NumberOfUniqueCombinationNAdjacent(searchGrid, adjacentNumber));
        }

    }
}
