using System.ComponentModel;

namespace TextEditor
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbProduct = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbCopyright
            // 
            this.lbCopyright.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.Location = new System.Drawing.Point(12, 80);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(275, 132);
            this.lbCopyright.TabIndex = 0;
            this.lbCopyright.Click += new System.EventHandler(this.lbCopyright_Click);
            // 
            // lbProduct
            // 
            this.lbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProduct.Location = new System.Drawing.Point(12, 9);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(275, 30);
            this.lbProduct.TabIndex = 1;
            this.lbProduct.Text = "Text Editor";
            this.lbProduct.Click += new System.EventHandler(this.lbProduct_Click);
            // 
            // lbVersion
            // 
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.Location = new System.Drawing.Point(12, 39);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(275, 30);
            this.lbVersion.TabIndex = 2;
            this.lbVersion.Text = "Version 1.0.0";
            this.lbVersion.Click += new System.EventHandler(this.lbVersion_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(299, 221);
            this.ControlBox = false;
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lbProduct);
            this.Controls.Add(this.lbCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Click += new System.EventHandler(this.About_Click);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbProduct;
        private System.Windows.Forms.Label lbVersion;
        

        #endregion
    }
}