namespace ConjTable.Demo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.conjTable1 = new System.Windows.Forms.AdjTable();
            this.conjPanel1 = new System.Windows.Forms.AdjPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conjTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.conjTable1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.conjPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(760, 440);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 3;
            // 
            // conjTable1
            // 
            this.conjTable1.AllowUserToAddRows = false;
            this.conjTable1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conjTable1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.conjTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conjTable1.ColumnHeadersVisible = false;
            this.conjTable1.Dock = System.Windows.Forms.DockStyle.Top;
            this.conjTable1.Location = new System.Drawing.Point(0, 0);
            this.conjTable1.Name = "conjTable1";
            this.conjTable1.RowHeadersVisible = false;
            this.conjTable1.Size = new System.Drawing.Size(252, 176);
            this.conjTable1.TabIndex = 1;
            this.conjTable1.VirtualMode = true;
            this.conjTable1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conjTable1_CellValueChanged);
            // 
            // conjPanel1
            // 
            this.conjPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conjPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conjPanel1.Location = new System.Drawing.Point(0, 0);
            this.conjPanel1.Name = "conjPanel1";
            this.conjPanel1.Size = new System.Drawing.Size(504, 440);
            this.conjPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 440);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.conjTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.AdjPanel conjPanel1;
        private System.Windows.Forms.AdjTable conjTable1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

