using System;
using System.Drawing;
using System.Linq;


namespace SortVisualizer
{
    class SortEngineHeap : ISortEngine
    {
        private int[] _theArray;
        private Graphics _g;
        private int _MaxVal;
        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black);
        public SortEngineHeap(int[] theArray, Graphics g, int MaxVal)
        {
            _theArray = theArray;
            _g = g;
            _MaxVal = MaxVal;
        }

        public void NextStep()
        {
            Sort(_theArray);
            foreach (int i in _theArray)
            {
                Console.WriteLine(i + " ");
            }
        }
        public void Sort(int[] array)
        {
            int xLength = array.Length;
            for (int i = xLength / 2 - 1; i >= 0; i--)
            {
                Heap(array, xLength, i);
            }
            for (int i = xLength - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                _g.FillRectangle(BlackBrush, 0, 0, 1, _MaxVal);
                _g.FillRectangle(BlackBrush, i, 0, 1, _MaxVal);

                _g.FillRectangle(WhiteBrush, 0, _MaxVal - array[0], 1, _MaxVal);
                _g.FillRectangle(WhiteBrush, i, _MaxVal - array[i], 1, _MaxVal);
                Heap(array, i, 0);
            }

        }


        public void Heap(int[] array, int length, int i)
        {
            int largest = i;
            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left < length && array[left] > array[largest])
            {
                largest = left;
            }
            if (right < length && array[right] > array[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                int temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

                _g.FillRectangle(BlackBrush, largest, 0, 1, _MaxVal);
                _g.FillRectangle(BlackBrush, i, 0, 1, _MaxVal);

                _g.FillRectangle(WhiteBrush, largest, _MaxVal - array[largest], 1, _MaxVal);
                _g.FillRectangle(WhiteBrush, i, _MaxVal - array[i], 1, _MaxVal);

                Heap(array, length, largest);
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
