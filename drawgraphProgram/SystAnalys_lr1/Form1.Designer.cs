namespace SystAnalys_lr1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAdj = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tableEnter = new System.Windows.Forms.DataGridView();
            this.hult = new System.Windows.Forms.ToolTip(this.components);
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // about
            // 
            this.about.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(94, 20);
            this.about.Text = "О программе";
            this.about.ToolTipText = "Справка это святое";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // buttonAdj
            // 
            this.buttonAdj.Location = new System.Drawing.Point(619, 372);
            this.buttonAdj.Name = "buttonAdj";
            this.buttonAdj.Size = new System.Drawing.Size(170, 37);
            this.buttonAdj.TabIndex = 7;
            this.buttonAdj.Text = "Создать матрицу смежности";
            this.hult.SetToolTip(this.buttonAdj, "Нажми меня и я создам матрицу смежности");
            this.buttonAdj.UseVisualStyleBackColor = true;
            this.buttonAdj.Click += new System.EventHandler(this.buttonAdj_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(845, 379);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Сохранить граф";
            this.hult.SetToolTip(this.saveButton, "Хочешь сохранить граф, тогда тебе сюда. Жми смелей не жалей");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tableEnter
            // 
            this.tableEnter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEnter.Location = new System.Drawing.Point(619, 43);
            this.tableEnter.Name = "tableEnter";
            this.tableEnter.Size = new System.Drawing.Size(338, 323);
            this.tableEnter.TabIndex = 14;
            this.hult.SetToolTip(this.tableEnter, "Привет, тут ты увидешь матрицу смежности)))0)))");
            // 
            // hult
            // 
            this.hult.AutomaticDelay = 5000;
            this.hult.AutoPopDelay = 50000;
            this.hult.InitialDelay = 50000;
            this.hult.ReshowDelay = 10000;
            this.hult.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // selectButton
            // 
            this.selectButton.Image = global::SystAnalys_lr1.Properties.Resources.cursor;
            this.selectButton.Location = new System.Drawing.Point(12, 12);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(45, 45);
            this.selectButton.TabIndex = 9;
            this.hult.SetToolTip(this.selectButton, "Я даже не знаю зачем я тебе нужна");
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Image = global::SystAnalys_lr1.Properties.Resources.deleteAll;
            this.deleteALLButton.Location = new System.Drawing.Point(13, 217);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(45, 45);
            this.deleteALLButton.TabIndex = 5;
            this.hult.SetToolTip(this.deleteALLButton, "Я удаляю все\r\n");
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::SystAnalys_lr1.Properties.Resources.delete;
            this.deleteButton.Location = new System.Drawing.Point(13, 166);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(45, 45);
            this.deleteButton.TabIndex = 3;
            this.hult.SetToolTip(this.deleteButton, "Я удалю только что-то одно");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Image = global::SystAnalys_lr1.Properties.Resources.no_translate_detected_318_605902;
            this.drawEdgeButton.Location = new System.Drawing.Point(12, 115);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(45, 45);
            this.drawEdgeButton.TabIndex = 2;
            this.hult.SetToolTip(this.drawEdgeButton, "Рисую дугу");
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Image = global::SystAnalys_lr1.Properties.Resources.vertex;
            this.drawVertexButton.Location = new System.Drawing.Point(13, 64);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(45, 45);
            this.drawVertexButton.TabIndex = 1;
            this.hult.SetToolTip(this.drawVertexButton, "Рисую вершины быстро и точно");
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Location = new System.Drawing.Point(70, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(510, 412);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 526);
            this.Controls.Add(this.tableEnter);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.buttonAdj);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Цепь Маркова";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button buttonAdj;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView tableEnter;
        private System.Windows.Forms.ToolTip hult;
    }
}

