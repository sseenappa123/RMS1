using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS.Service
{
    /// <summary>
    /// Assists in creating node elements and linked array in all necessary directions.
    /// </summary>
    internal class NodeService
    {
        public Node CreateNode(int rowBound, int colBound, int[][] searchGrid, int row, int column, int adjacentNumber)
        {
            Node n = new Node(GetRightArray(colBound, searchGrid, row, column, adjacentNumber), GetDownArray(rowBound, searchGrid, row, column, adjacentNumber), GetLefDiagnolArray(rowBound, searchGrid, row, column, adjacentNumber), GetRightDiagnolArray(rowBound, searchGrid, row, column, adjacentNumber), row, column);

            return n;
        }

        private int[] GetDownArray(int rowBound, int[][] searchGrid, int row, int column, int adjacentNumber)
        {
            var arrInts = new int[adjacentNumber];

            for (int i = 0; i < arrInts.Length; i++)
            {
                if (rowBound > row + i && searchGrid[row + i].GetLength(0) > column)
                    arrInts[i] = searchGrid[row + i][column];
                else
                { return null; }
            }

            return arrInts;
        }

        internal static List<int[]> Add(int[] array, List<int[]> nodeCombination)
        {
            if (array == null || nodeCombination == null)
                return nodeCombination;

            // Not sure it needs to be unique.
            Array.Sort(array);

            if (!nodeCombination.Exists(a => a.SequenceEqual(array)))
                nodeCombination.Add(array);

            return nodeCombination;
        }

        private int[] GetRightArray(int colBound, int[][] searchGrid, int row, int column, int adjacentNumber)
        {
            var arrInts = new int[adjacentNumber];

            for (int i = 0; i < arrInts.Length; i++)
            {
                if (colBound > column + i)
                    arrInts[i] = searchGrid[row][column + i];
                else
                { return null; }
            }

            return arrInts;
        }

        private int[] GetLefDiagnolArray(int rowBound, int[][] searchGrid, int row, int column, int adjacentNumber)
        {
            var arrInts = new int[adjacentNumber];

            for (int i = 0; i < arrInts.Length; i++)
            {
                if (rowBound > row + i && searchGrid[row + i].GetLength(0) > column - i && column - i >= 0)
                    arrInts[i] = searchGrid[row + i][column - i];
                else
                { return null; }
            }

            return arrInts;
        }

        private int[] GetRightDiagnolArray(int rowBound, int[][] searchGrid, int row, int column, int adjacentNumber)
        {
            var arrInts = new int[adjacentNumber];

            for (int i = 0; i < arrInts.Length; i++)
            {
                if (rowBound > row + i && searchGrid[row + i].GetLength(0) > column + i)
                    arrInts[i] = searchGrid[row + i][column + i];
                else
                { return null; }
            }

            return arrInts;
        }

        internal Node FindGreatestProductBetween(Node nodeA, Node nodeB)
        {
            if (nodeA == null && nodeB == null)
                return null;
            if (nodeA == null)
                return nodeB;

            return nodeB == null ? nodeA : nodeA.Compare(nodeB);
        }
    }
}