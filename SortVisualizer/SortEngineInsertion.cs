using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
   
        class SortEngineInsertion : ISortEngine
        {
            private int[] _theArray;
            private Graphics _g;
            private int _MaxVal;
            Brush WhiteBrush = new SolidBrush(Color.White);
            Brush BlackBrush = new SolidBrush(Color.Black);


            public SortEngineInsertion(int[] theArray, Graphics g, int MaxVal)
            {
                _theArray = theArray;
                _g = g;
                _MaxVal = MaxVal;

            }
            public void NextStep()
            {
                Sort(_theArray);
                Console.WriteLine("Sorted Array: ");
                for (int i = 0; i < _theArray.Count(); i++)
                {
                    Console.WriteLine(_theArray[i] + " ");
                }
            }
            public void Sort(int[] array)
            {
                int xLength = array.Length;

                for (int i = 0; i < xLength - 1; i++)
                {
                    for (int j = i + 1; j > 0; j--)
                    {
                        if (array[j - 1] > array[j])
                        {
                            //int temp = x[j-1];
                            //x[j-1] = x[j];
                            //x[j] = temp;

                            array[j - 1] = array[j - 1] ^ array[j];
                            array[j] = array[j] ^ array[j - 1];
                            array[j - 1] = array[j - 1] ^ array[j];

                        _g.FillRectangle(BlackBrush, j, 0, 1, _MaxVal);
                        _g.FillRectangle(BlackBrush, i, 0, 1, _MaxVal);

                        _g.FillRectangle(WhiteBrush, j, _MaxVal - array[j], 1, _MaxVal);
                        _g.FillRectangle(WhiteBrush, i, _MaxVal - array[i], 1, _MaxVal);
                    }
                        else
                        {
                            continue;
                        }
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

    


