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
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // toggleButton1
            // 
            this.toggleButton1.AutoSize = true;
            this.toggleButton1.Checked = true;
            this.toggleButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleButton1.DisableBackColor = System.Drawing.Color.DarkGray;
            this.toggleButton1.DisableToggleColor = System.Drawing.Color.LightGray;
            this.toggleButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toggleButton1.Location = new System.Drawing.Point(59, 52);
            this.toggleButton1.MaximumSize = new System.Drawing.Size(1000, 22);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(45, 22);
            this.toggleButton1.TabIndex = 0;
            this.toggleButton1.TestRefresha = false;
            this.toggleButton1.UseVisualStyleBackColor = true;
            this.toggleButton1.CheckedChanged += new System.EventHandler(this.toggleButton1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toggleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private RKCustomControls.ToggleButton toggleButton1;
    }
}

