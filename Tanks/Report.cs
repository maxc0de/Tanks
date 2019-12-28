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
        public Report()
        {
            InitializeComponent();
            this.Location = new Point(730, 100);            
        }

        public void UpdateGrid(List<GameObject> objects)
        {
            dataGridViewEx1.DataSource = objects;
            dataGridViewEx1.Refresh();
        }

        private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
