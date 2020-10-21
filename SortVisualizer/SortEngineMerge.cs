using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class SortEngineMerge : ISortEngine
    {
        private int[] _theArray;
        private Graphics _g;
        private int _MaxVal;
        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black);
        public SortEngineMerge(int[] theArray, Graphics g, int MaxVal)
        {
            _theArray = theArray;
            _g = g;
            _MaxVal = MaxVal;
        }



        public void NextStep()
        {
            MergeSort(_theArray, 0 , _theArray.Length - 1);
            Console.WriteLine("Sorted Array: ");
            for (int i = 0; i < _theArray.Count(); i++)
            {
                Console.WriteLine(_theArray[i] + " ");
            }
        }
        private void Merge(int[] input, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }
        private void MergeSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }

        //_g.FillRectangle(BlackBrush, j, 0, 1, _MaxVal);
        //                _g.FillRectangle(BlackBrush, i, 0, 1, _MaxVal);

        //                _g.FillRectangle(WhiteBrush, j, _MaxVal - array[j], 1, _MaxVal);
        //                _g.FillRectangle(WhiteBrush, i, _MaxVal - array[i], 1, _MaxVal);



        public bool IsSorted()
        {
            for (int i = 0; i < _theArray.Count() - 1; i++)
            {
                if (_theArray[i] > _theArray[i + 1]) return false;
            }
            return true;
        }
    }
}
