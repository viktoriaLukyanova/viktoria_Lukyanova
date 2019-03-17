namespace AssociationRule
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataTrans = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnGetAs = new System.Windows.Forms.Button();
            this.openExcel = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataTrans)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTrans
            // 
            this.dataTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTrans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Transact});
            this.dataTrans.Location = new System.Drawing.Point(12, 12);
            this.dataTrans.Name = "dataTrans";
            this.dataTrans.Size = new System.Drawing.Size(776, 286);
            this.dataTrans.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID_Поля";
            this.ID.Name = "ID";
            // 
            // Transact
            // 
            this.Transact.HeaderText = "Транзакции";
            this.Transact.Name = "Transact";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 304);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(212, 28);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загрузить файл с транзакциями";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(12, 338);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(212, 29);
            this.btnClean.TabIndex = 2;
            this.btnClean.Text = "Очистить таблицу транзакций";
            this.btnClean.UseVisualStyleBackColor = true;
            // 
            // btnGetAs
            // 
            this.btnGetAs.Location = new System.Drawing.Point(672, 311);
            this.btnGetAs.Name = "btnGetAs";
            this.btnGetAs.Size = new System.Drawing.Size(116, 56);
            this.btnGetAs.TabIndex = 3;
            this.btnGetAs.Text = "Получить правила";
            this.btnGetAs.UseVisualStyleBackColor = true;
            // 
            // openExcel
            // 
            this.openExcel.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetAs);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dataTrans);
            this.Name = "Form1";
            this.Text = "Ассоциативные правила";
            ((System.ComponentModel.ISupportInitialize)(this.dataTrans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transact;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnGetAs;
        private System.Windows.Forms.OpenFileDialog openExcel;
    }
}

