using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class SortEngineBubble : ISortEngine
    {
        private int[] _theArray;
        private Graphics _g;
        private int _MaxVal;
        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black);
        public SortEngineBubble(int[] theArray, Graphics g, int MaxVal)
        {
            _theArray = theArray;
            _g = g;
            _MaxVal = MaxVal;
        }
   

        
        public void NextStep()
        {
            for (int i = 0; i < _theArray.Count() - 1; i++)
            {
                if (_theArray[i] > _theArray[i + 1])
                {
                    Swap(i, i + 1);
                }
            }
            foreach(int i in _theArray)
            {
                Console.WriteLine(i + " ");
            }
        }
        private void Swap(int i, int v)
        {
            int temp = _theArray[i];
            _theArray[i] = _theArray[v];
            _theArray[v] = temp;

            _g.FillRectangle(BlackBrush, i, 0, 1, _MaxVal);
            _g.FillRectangle(BlackBrush, v, 0, 1, _MaxVal);

            _g.FillRectangle(WhiteBrush, i, _MaxVal-_theArray[i], 1, _MaxVal);
            _g.FillRectangle(WhiteBrush, v, _MaxVal - _theArray[v], 1, _MaxVal);
        }

        public bool IsSorted()
        {
            for (int i=0; i<_theArray.Count() - 1; i++)
            {
                if (_theArray[i] > _theArray[i + 1]) return false;
            }
            return true;
        }
    }
}
