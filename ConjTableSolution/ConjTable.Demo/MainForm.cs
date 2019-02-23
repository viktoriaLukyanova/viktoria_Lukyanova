using System;
using System.Windows.Forms;

namespace ConjTable.Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int[,] _matrix = new int[,]
            {
                {0, 1, 1, 1, 1},
                {1, 0, 1, 1, 1},
                {1, 1, 0, 1, 1},
                {1, 1, 1, 0, 1},
                {1, 1, 1, 0, 1},
            };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            conjTable1.Build(_matrix);
            conjPanel1.Build(_matrix);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix);
        }

        private void conjTable1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix);
        }
    }
}
