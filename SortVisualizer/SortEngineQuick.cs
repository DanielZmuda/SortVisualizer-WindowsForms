using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer 
{
    class SortEngineQuick : ISortEngine
    {
        private int[] _theArray;
        private Graphics _g;
        private int _MaxVal;
        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black);
   

        public SortEngineQuick(int[] theArray, Graphics g, int MaxVal)
        {
            _theArray = theArray;
            _g = g;
            _MaxVal = MaxVal;
    
        }
        public void NextStep()
        {
            Sort(_theArray, 0, _theArray.Length-1);
            Console.WriteLine("Sorted Array: ");
            for (int i=0; i<_theArray.Length; i++)
            {
                Console.WriteLine(_theArray[i] + " ");
            }
        }
        public void Sort(int[] array, int left, int right)
        {

            var i = left;
            var j = right;
            var pivot = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    // swap
                    var tmp = array[i];
                    array[i] = array[j];  // ++ and -- inside array braces for shorter code
                    array[j] = tmp;

                    _g.FillRectangle(BlackBrush, i, 0, 1, _MaxVal);
                    _g.FillRectangle(BlackBrush, j, 0, 1, _MaxVal);

                    _g.FillRectangle(WhiteBrush, i, _MaxVal - array[i], 1, _MaxVal);
                    _g.FillRectangle(WhiteBrush, j, _MaxVal - array[j], 1, _MaxVal);
                    i++;
                    j--;
                  
                }
            }
            if (left < j) Sort(array, left, j);
            if (i < right) Sort(array, i, right);


            //if (left < right)
            //{
            //    int pivot = Partition(array, left, right);

            //    if (pivot > 1)
            //    {
            //        Sort(array, left, pivot - 1);
            //    }
            //    if (pivot + 1 < right)
            //    {
            //        Sort(array, pivot + 1, right);
            //    }
            //}
        }


        public int Partition(int[] _Array, int left, int right)
        {
            int pivot = _Array[left];
            while (true)
            {
                while (_Array[left] < pivot)
                {
                    left++;

                }
                while (_Array[right] > pivot)
                {
                    right--;

                }

                if (left <= right)
                {
                    if (_Array[left] == _Array[right]) return right;
                    int temp = _Array[left];
                    _Array[left] = _Array[right];
                    _Array[right] = temp;

                    _g.FillRectangle(BlackBrush, left, 0, 1, _MaxVal);
                    _g.FillRectangle(BlackBrush, right, 0, 1, _MaxVal);

                    _g.FillRectangle(WhiteBrush, left, _MaxVal - _Array[left], 1, _MaxVal);
                    _g.FillRectangle(WhiteBrush, right, _MaxVal - _Array[right], 1, _MaxVal);

                }
                else
                {
                    return right;
                }

            }
        }
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

