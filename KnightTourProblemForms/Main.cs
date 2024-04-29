using KnightTourProblemApplication;
using KnightTourProblemApplication.DTOs;

namespace KnightTourProblemForms
{
    public partial class Main : Form
    {
        private Point Point;

        private Table Table { get; set; }

        private Panel[,] Cells { get; set; }

        private Panel LastCell { get; set; }

        private int Attempts { get; set; }

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
            Attempts++;

            Thread.Sleep(100);

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

                Invoke(() =>
                {
                    AddKigntPicture(cell);
                    cell.Controls.Add(label);
                    labelAttempts.Text = $"Tentativas: {Attempts}";
                });
            }
        }

        private void table_ClearCell(object sender, EventArgs e)
        {
            Thread.Sleep(50);

            if (sender is CellDTO dto)
            {
                Invoke(() => { Cells[dto.X, dto.Y].Controls.Clear(); });
            }
        }

        private void AddKigntPicture(Panel panel)
        {
            if (LastCell is not null)
            {
                var picControl = LastCell.Controls.OfType<Control>().FirstOrDefault(x => x is PictureBox);

                if (picControl is not null)
                    LastCell.Controls.Remove(picControl);
            }
            LastCell = panel;

            var picture = new PictureBox()
            {
                Image = Properties.Resources.Knight,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            panel.Controls.Add(picture);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Table.Start();
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            Point = e.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - Point.X;
                Top += e.Y - Point.Y;
            }
        }
    }
}
