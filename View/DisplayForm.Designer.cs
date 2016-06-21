using System;
using System.Windows.Forms;

namespace Space_Game.View
{
    partial class DisplayForm
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
            this.SuspendLayout();
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 703);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.Load += new EventHandler(this.DisplayForm_Load);
            this.Paint += new PaintEventHandler(this.DisplayForm_Paint);
            this.KeyDown += new KeyEventHandler(this.DisplayForm_KeyDown);
            this.Resize += new EventHandler(this.DisplayForm_Resize);
            this.MouseWheel += new MouseEventHandler(DisplayForm_MouseWheel);
            this.ResumeLayout(false);

        }

        #endregion
    }
}