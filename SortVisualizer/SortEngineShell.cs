using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class SortEngineShell : ISortEngine
    {
        private int[] _theArray;
        private Graphics _g;
        private int _MaxVal;
        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black);
        public SortEngineShell(int[] theArray, Graphics g, int MaxVal)
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
            int h = 100;
            int j, temp;

            while (true)
            {
                for (int i = 0; i < xLength; i++)
                {
                    j = i;
                    temp = array[i];
                    while ((j >= h) && (array[j - h] > temp))
                    {
                        array[j] = array[j - h];
                        _g.FillRectangle(BlackBrush, j - h, 0, 1, _MaxVal);
                        _g.FillRectangle(BlackBrush, j, 0, 1, _MaxVal);

                        _g.FillRectangle(WhiteBrush, j, _MaxVal - array[j], 1, _MaxVal);
                        _g.FillRectangle(WhiteBrush, j - h, _MaxVal - array[j - h], 1, _MaxVal);
                        j = j - h;
                   
                    }
                    array[j] = temp;
                    _g.FillRectangle(BlackBrush, j, 0, 1, _MaxVal);
                    _g.FillRectangle(WhiteBrush, j, _MaxVal - array[j], 1, _MaxVal);
                }
                if (h / 2 != 0)
                {
                    h = h / 2;
                }
                else if (h == 1)
                {
                    h = 0;
                }
                else if (h == 0)
                {
                    break;
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
