using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonProject.Business
{
    public static class DataGridViewExtension
    {
        public static void FitContent(this DataGridView s)
        {
            try
            {
                for (int i = 1; i <= s.Columns.Count - 1; i++)
                {
                    int colw = s.Columns[i].Width;
                    s.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    s.Columns[i].Width = colw;
                }
                s.Columns[s.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                s.Columns[0].Frozen = true;
                s.Columns[1].Frozen = true;
                s.Columns[2].Frozen = true;
            }
            catch (Exception )
            {

            }
           
        }
    }
}
