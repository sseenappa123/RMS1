using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RMS.Service
{
    /// <summary>
    /// Service to calculate Product of N adjacent number. 
    /// </summary>
    public class ProductNAdajacentIntegerService
    {
        private readonly IInputValidation _validator;

        public ProductNAdajacentIntegerService(IInputValidation validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// Calculates the product of N adjacent number.
        /// </summary>
        /// <param name="searchGrid">Jagged or Array of Arrays.</param>
        /// <param name="adjacentIntegers">Number of Adjacent squares or number</param>
        /// <exception cref="ArgumentException"> Null or Empty Array </exception>
        /// <exception cref="ArgumentOutOfRangeException"> if adjacent integer is negative. </exception>
        /// <exception cref="ArgumentNullException"> Validator not supplied </exception>
        /// <exception cref="InvalidOperationException">If the array elements are not initialised.</exception>
        /// <returns>the product.</returns>
        public long LargestProductOfNAdjacentIntegers(int[][] searchGrid, int adjacentIntegers)
        {
            if (searchGrid == null)
                throw new ArgumentNullException(nameof(searchGrid));
            if (adjacentIntegers <= 0)
                throw new ArgumentOutOfRangeException(nameof(adjacentIntegers));
            if (_validator == null)
                throw new ArgumentNullException(nameof(_validator));

            Node curreNode = null;
            if (_validator.Validate(searchGrid, adjacentIntegers))
            {
                int xBound = searchGrid.GetLength(0);

                NodeService service = new NodeService();
                for (int row = 0; row < xBound; row++)
                {


                    int yBound = searchGrid[row].GetLength(0);
                    for (int column = 0; column < yBound; column++)
                    {
                        Node node = service.CreateNode(xBound, yBound, searchGrid, row, column, adjacentIntegers);
                        if (node != null)
                            curreNode = node.Compare(curreNode);
                    }
                }
            }
            else
            {
                // Operation cannot succeed or result sare invalid.
                throw new InvalidOperationException(_validator.ToString());
            }

            return curreNode?.GetMaxProduct() ?? 0;
        }
        /// <summary>
        /// Count all combination in any direction.
        /// </summary>
        /// <param name="searchGrid">Jagged or Array of Arrays.</param>
        /// <param name="adjacentIntegers">Number of Adjacent squares or number</param>
        /// <exception cref="ArgumentException"> Null or Empty Array </exception>
        /// <exception cref="ArgumentOutOfRangeException"> if adjacent integer is negative. </exception>
        /// <exception cref="ArgumentNullException"> Validator not supplied </exception>
        /// <exception cref="InvalidOperationException">If the array elements are not initialised.</exception>
        /// <returns>count.</returns>
        public int NumberOfCombinationNAdjacent(int[][] searchGrid, int adjacentIntegers)
        {
            if (searchGrid == null)
                throw new ArgumentNullException(nameof(searchGrid));
            if (adjacentIntegers <= 0)
                throw new ArgumentOutOfRangeException(nameof(adjacentIntegers));
            if (_validator == null)
                throw new ArgumentNullException(nameof(_validator));

            int totalCombination = 0;
            if (_validator.Validate(searchGrid, adjacentIntegers))
            {
                int xBound = searchGrid.GetLength(0);

                NodeService service = new NodeService();
                for (int row = 0; row < xBound; row++)
                {
                    int yBound = searchGrid[row].GetLength(0);
                    for (int column = 0; column < yBound; column++)
                    {
                        Node node = service.CreateNode(xBound, yBound, searchGrid, row, column, adjacentIntegers);
                        if (node != null)
                        {
                            totalCombination += node.TotalCombination();
                            
                        }
                    }
                }
            }
            else
            {
                // Operation cannot succeed or result sare invalid.
                throw new InvalidOperationException(_validator.ToString());
            }

            return totalCombination;
        }
        /// <summary>
        /// Count of unique combination in any direction.
        /// </summary>
        /// <param name="searchGrid">Jagged or Array of Arrays.</param>
        /// <param name="adjacentIntegers">Number of Adjacent squares or number</param>
        /// <exception cref="ArgumentException"> Null or Empty Array </exception>
        /// <exception cref="ArgumentOutOfRangeException"> if adjacent integer is negative. </exception>
        /// <exception cref="ArgumentNullException"> Validator not supplied </exception>
        /// <exception cref="InvalidOperationException">If the array elements are not initialised.</exception>
        /// <returns>count.</returns>
        public int NumberOfUniqueCombinationNAdjacent(int[][] searchGrid, int adjacentIntegers)
        {
            if (searchGrid == null)
                throw new ArgumentNullException(nameof(searchGrid));
            if (adjacentIntegers <= 0)
                throw new ArgumentOutOfRangeException(nameof(adjacentIntegers));
            if (_validator == null)
                throw new ArgumentNullException(nameof(_validator));

            var combination = new List<int[]>();
            if (_validator.Validate(searchGrid, adjacentIntegers))
            {
                int xBound = searchGrid.GetLength(0);

                NodeService service = new NodeService();
                for (int row = 0; row < xBound; row++)
                {
                    int yBound = searchGrid[row].GetLength(0);
                    for (int column = 0; column < yBound; column++)
                    {
                        Node node = service.CreateNode(xBound, yBound, searchGrid, row, column, adjacentIntegers);
                        if (node != null)
                        {
                            combination = NodeService.Add(node.Right, combination);
                            combination = NodeService.Add(node.Down, combination);
                            combination = NodeService.Add(node.LeftDiagnol, combination);
                            combination = NodeService.Add(node.RightDiagnol, combination);
                        }
                    }
                }
            }
            else
            {
                // Operation cannot succeed or result sare invalid.
                throw new InvalidOperationException(_validator.ToString());
            }

//#if DEBUG 
//            foreach (var c in combination)
//            {
//                for (int i = 0; i < c.Length; i++)
//                {
//                    Debug.Write(c[i] + ",");
//                }
//                Debug.WriteLine("");
//            }
//#endif
            return combination.Count;
        }
    }
}