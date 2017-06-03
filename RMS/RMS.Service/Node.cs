using System;
using System.Linq;

namespace RMS.Service
{
    public class Node
    {
        public int[] Down { get; }
        public int[] LeftDiagnol { get; }
        public int[] Right { get; }
        public int[] RightDiagnol { get; }

        private long? _computedMaxProduct;
        public Direction? Direction;

        public Node(int[] v1, int[] v2, int[] v3, int[] v4, int row, int col)
        {
            Row = row;
            Col = col;
            Right = v1;
            Down = v2;
            LeftDiagnol = v3;
            RightDiagnol = v4;

            GetMaxProduct();
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public long RightProduct => GetProduct(Right);
        public long DownProduct => GetProduct(Down);
        public long LeftDiagnolProduct => GetProduct(LeftDiagnol);
        public long RightDiagnolProduct => GetProduct(RightDiagnol);

        public int TotalCombination()
        {
            return (Right?.Length).GetValueOrDefault(0)
                   + (Down?.Length).GetValueOrDefault(0)
                   + (LeftDiagnol?.Length).GetValueOrDefault(0)
                   + (RightDiagnol?.Length).GetValueOrDefault(0);
        }

        public Node Compare(Node nodeB)
        {
            return GetMaxProduct() >= (nodeB?.GetMaxProduct() ?? 0) ? this : nodeB;
        }
        /// <summary>
        /// Calculates the product of two notes.
        /// </summary>
        /// <returns></returns>
        public long GetMaxProduct()
        {
            if (!_computedMaxProduct.HasValue)
            {
                long[] largest = {RightProduct, DownProduct, LeftDiagnolProduct, RightDiagnolProduct};
                _computedMaxProduct = largest.Max();
                int index = largest.ToList().IndexOf(_computedMaxProduct.Value);
                if (Enum.IsDefined(typeof(Direction), index)) { Direction = (Direction) index; }
            }
            return _computedMaxProduct.GetValueOrDefault(0);
        }

        private long GetProduct(int[] right)
        {
            if (right == null)
                return 0;

            long product = 1;
            foreach (int t in right)
            {
                product *= t;
            }
            return product;
        }
    }
}