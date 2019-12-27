using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Report : Form
    {
        DataGridViewEx viewEx;
        public Report()
        {
            InitializeComponent();

            this.Location = new Point(730, 100);
            viewEx = new DataGridViewEx();
            viewEx.Dock = DockStyle.Fill;
            viewEx.VirtualMode = true;

            this.Controls.Add(viewEx);
            
        }

        public void UpdateGrid(List<Tank> objects)
        {
            viewEx.DataSource = objects;
        }
    }

    public class DataGridViewEx : DataGridView
    {
        protected override bool DoubleBuffered { get => true; }
    }
}
