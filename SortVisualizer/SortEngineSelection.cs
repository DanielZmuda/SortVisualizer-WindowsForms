using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class SortEngineSelection : ISortEngine
    {
        private int[] _theArray;
        private Graphics _g;
        private int _MaxVal;
        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black);
        public SortEngineSelection(int[] theArray, Graphics g, int MaxVal)
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
            int store, temp;

            Console.WriteLine("Initial Array: ");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                store = i;
                for (int y = 1 + i; y < array.Length; y++)
                {
                    if (array[y] < array[store])
                    {
                        store = y;
                    }
                }
                temp = array[store];
                array[store] = array[i];
                array[i] = temp;

                _g.FillRectangle(BlackBrush, store, 0, 1, _MaxVal);
                _g.FillRectangle(BlackBrush, i, 0, 1, _MaxVal);

                _g.FillRectangle(WhiteBrush, store, _MaxVal - array[store], 1, _MaxVal);
                _g.FillRectangle(WhiteBrush, i, _MaxVal - array[i], 1, _MaxVal);
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
