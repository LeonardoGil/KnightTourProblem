using KnightTourProblemApplication;
using KnightTourProblemApplication.DTOs;

namespace KnightTourProblemForms
{
    public partial class Main : Form
    {
        private Table Table { get; set; }

        private Panel[,] Cells { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void BuildTable(int n)
        {
            var width = panelTable.Width / n;
            var height = panelTable.Height / n;

            var primary = Color.Black;
            var secundary = Color.White;

            Cells = new Panel[n, n];

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    var location = new Point(x * width, y * height);

                    var panel = new Panel()
                    {
                        BackColor = x % 2 == (y % 2 == 1 ? 1 : 0) ? primary : secundary,
                        Width = width,
                        Height = height,
                        Location = location
                    };

                    panelTable.Controls.Add(panel);
                    Cells[x, y] = panel;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var n = (int)numericUpDownLenght.Value;

            if (n % 2 == 1)
            {
                MessageBox.Show("Tamanho precisa ser PAR!");
                return;
            }

            buttonStart.Enabled = false;

            Table = new Table(n);
            Table.SetCell += table_SetCell;
            Table.ClearCell += table_ClearCell;

            BuildTable(n);

            backgroundWorker.RunWorkerAsync();
        }

        private void table_SetCell(object sender, EventArgs e)
        {
            if (sender is CellDTO dto)
            {
                var cell = Cells[dto.X, dto.Y];

                var label = new Label
                {
                    Text = dto.Turn.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = cell.BackColor == Color.Black ? Color.White : Color.Black    
                };

                Invoke(() => { cell.Controls.Add(label); });
            }
        }

        private void table_ClearCell(object sender, EventArgs e)
        {
            if (sender is CellDTO dto)
            {
                Invoke(() => { Cells[dto.X, dto.Y].Controls.Clear(); });
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Table.Start();
        }
    }
}
