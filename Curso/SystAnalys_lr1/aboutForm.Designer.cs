﻿namespace SystAnalys_lr1
{
    partial class aboutForm
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
            this.txtt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtt
            // 
            this.txtt.Location = new System.Drawing.Point(12, 21);
            this.txtt.Name = "txtt";
            this.txtt.Size = new System.Drawing.Size(577, 182);
            this.txtt.TabIndex = 0;
            this.txtt.Text = "";
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 235);
            this.Controls.Add(this.txtt);
            this.Name = "aboutForm";
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.aboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtt;
    }
}