namespace WindowsFormsApp1
{
    partial class Form1
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
            this.toggleButton1 = new RKCustomControls.ToggleButton();
            this.toggleButton2 = new RKCustomControls.ToggleButton();
            this.toggleButton3 = new RKCustomControls.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton3)).BeginInit();
            this.SuspendLayout();
            // 
            // toggleButton1
            // 
            this.toggleButton1.DisableBackColor = System.Drawing.Color.DarkGray;
            this.toggleButton1.DisableToggleColor = System.Drawing.Color.LightGray;
            this.toggleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleButton1.Location = new System.Drawing.Point(268, 120);
            this.toggleButton1.MaximumSize = new System.Drawing.Size(1000, 22);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(142, 22);
            this.toggleButton1.TabIndex = 0;
            this.toggleButton1.UseVisualStyleBackColor = true;
            // 
            // toggleButton2
            // 
            this.toggleButton2.AutoSize = true;
            this.toggleButton2.DisableBackColor = System.Drawing.Color.DarkGray;
            this.toggleButton2.DisableToggleColor = System.Drawing.Color.LightGray;
            this.toggleButton2.Location = new System.Drawing.Point(12, 12);
            this.toggleButton2.MaximumSize = new System.Drawing.Size(1000, 22);
            this.toggleButton2.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton2.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton2.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleButton2.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton2.Size = new System.Drawing.Size(45, 22);
            this.toggleButton2.TabIndex = 1;
            this.toggleButton2.CheckedChanged += new System.EventHandler(this.toggleButton2_CheckedChanged);
            // 
            // toggleButton3
            // 
            this.toggleButton3.Checked = true;
            this.toggleButton3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleButton3.DisableBackColor = System.Drawing.Color.DarkGray;
            this.toggleButton3.DisableToggleColor = System.Drawing.Color.LightGray;
            this.toggleButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleButton3.Location = new System.Drawing.Point(268, 148);
            this.toggleButton3.MaximumSize = new System.Drawing.Size(1000, 22);
            this.toggleButton3.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton3.Name = "toggleButton3";
            this.toggleButton3.OffBackColor = System.Drawing.Color.IndianRed;
            this.toggleButton3.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton3.OnBackColor = System.Drawing.Color.Orange;
            this.toggleButton3.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton3.Size = new System.Drawing.Size(142, 22);
            this.toggleButton3.TabIndex = 2;
            this.toggleButton3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toggleButton3);
            this.Controls.Add(this.toggleButton2);
            this.Controls.Add(this.toggleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private RKCustomControls.ToggleButton toggleButton1;
        private RKCustomControls.ToggleButton toggleButton2;
        private RKCustomControls.ToggleButton toggleButton3;
    }
}

