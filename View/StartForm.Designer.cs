namespace Space_Game.View
{
    partial class StartForm
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
            this.btn_SolarSystem = new System.Windows.Forms.Button();
            this.btn_JustCarrier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_SolarSystem
            // 
            this.btn_SolarSystem.Location = new System.Drawing.Point(92, 38);
            this.btn_SolarSystem.Name = "btn_SolarSystem";
            this.btn_SolarSystem.Size = new System.Drawing.Size(369, 88);
            this.btn_SolarSystem.TabIndex = 0;
            this.btn_SolarSystem.Text = "Solar System";
            this.btn_SolarSystem.UseVisualStyleBackColor = true;
            this.btn_SolarSystem.Click += new System.EventHandler(this.btn_SolarSytem_Click);
            // 
            // btn_JustCarrier
            // 
            this.btn_JustCarrier.Location = new System.Drawing.Point(92, 132);
            this.btn_JustCarrier.Name = "btn_JustCarrier";
            this.btn_JustCarrier.Size = new System.Drawing.Size(369, 88);
            this.btn_JustCarrier.TabIndex = 1;
            this.btn_JustCarrier.Text = "Just the Carrier";
            this.btn_JustCarrier.UseVisualStyleBackColor = true;
            this.btn_JustCarrier.Click += new System.EventHandler(this.btn_JustCarrier_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 472);
            this.Controls.Add(this.btn_JustCarrier);
            this.Controls.Add(this.btn_SolarSystem);
            this.Name = "StartForm";
            this.Text = "Start";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_SolarSystem;
        private System.Windows.Forms.Button btn_JustCarrier;
    }
}