using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortVisualizer
{
    public partial class Form1 : Form
    {
        int[] theArray;
        Graphics g;
        BackgroundWorker bgw = null;
        public Form1()
        {
            InitializeComponent();
            PopulateDropdown();
        }

        private void PopulateDropdown()
        {
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortEngine).IsAssignableFrom(x)&& !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();
            ClassList.Sort();
            foreach(string entry in ClassList)
            {
                comboBox1.Items.Add(entry);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;
            theArray = new int[NumEntries];
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, NumEntries, MaxVal);
            Random rand = new Random();
            for(int i=0; i <NumEntries; i++)
            {
                theArray[i] = rand.Next(0, MaxVal);
            }
            for(int i=0;i<NumEntries; i++)
            {
                g.FillRectangle(new SolidBrush(Color.White), i, MaxVal-theArray[i], 1, MaxVal);
            }


        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.RunWorkerAsync(argument: comboBox1.SelectedItem);
        }



        #region BackGroundStuff

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            string SortEngineName = (string)e.Argument;
            Type type = Type.GetType("SortVisualizer." + SortEngineName);
            var ctors = type.GetConstructors();
            //try
            //{
                ISortEngine se = (ISortEngine)ctors[0].Invoke(new object[] { theArray, g, panel1.Height });
            while (!se.IsSorted()) { 
                    se.NextStep();
            }
            //} catch (Exception ex)
            //{

            //}

        }

        #endregion
    }
}
