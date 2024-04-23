namespace KnightTourProblemForms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTable = new Panel();
            panelInfo = new Panel();
            labelAttempts = new Label();
            numericUpDownLenght = new NumericUpDown();
            buttonStart = new Button();
            labelLenght = new Label();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLenght).BeginInit();
            SuspendLayout();
            // 
            // panelTable
            // 
            panelTable.Dock = DockStyle.Left;
            panelTable.Location = new Point(0, 0);
            panelTable.Name = "panelTable";
            panelTable.Size = new Size(600, 600);
            panelTable.TabIndex = 0;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = SystemColors.ControlDark;
            panelInfo.Controls.Add(labelAttempts);
            panelInfo.Controls.Add(numericUpDownLenght);
            panelInfo.Controls.Add(buttonStart);
            panelInfo.Controls.Add(labelLenght);
            panelInfo.Dock = DockStyle.Right;
            panelInfo.Location = new Point(600, 0);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(200, 600);
            panelInfo.TabIndex = 1;
            panelInfo.MouseDown += Form_MouseDown;
            panelInfo.MouseMove += Form_MouseMove;
            // 
            // labelAttempts
            // 
            labelAttempts.AutoSize = true;
            labelAttempts.Location = new Point(15, 510);
            labelAttempts.Name = "labelAttempts";
            labelAttempts.Size = new Size(86, 19);
            labelAttempts.TabIndex = 3;
            labelAttempts.Text = "Tentativas: 0";
            // 
            // numericUpDownLenght
            // 
            numericUpDownLenght.Location = new Point(15, 31);
            numericUpDownLenght.Name = "numericUpDownLenght";
            numericUpDownLenght.Size = new Size(66, 25);
            numericUpDownLenght.TabIndex = 2;
            numericUpDownLenght.TextAlign = HorizontalAlignment.Right;
            numericUpDownLenght.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(15, 544);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(173, 44);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelLenght
            // 
            labelLenght.AutoSize = true;
            labelLenght.Location = new Point(15, 9);
            labelLenght.Name = "labelLenght";
            labelLenght.Size = new Size(66, 19);
            labelLenght.TabIndex = 0;
            labelLenght.Text = "Tamanho";
            // 
            // backgroundWorker
            // 
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 600);
            ControlBox = false;
            Controls.Add(panelInfo);
            Controls.Add(panelTable);
            Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLenght).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTable;
        private Panel panelInfo;
        private Label labelLenght;
        private Button buttonStart;
        private NumericUpDown numericUpDownLenght;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Label labelAttempts;
    }
}
