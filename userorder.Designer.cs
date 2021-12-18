namespace BurgeriVisual
{
    partial class userorder
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ordernewBurgerMenu = new System.Windows.Forms.DataGridView();
            this.orderbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordernewBurgerMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 196);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // ordernewBurgerMenu
            // 
            this.ordernewBurgerMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordernewBurgerMenu.Location = new System.Drawing.Point(12, 12);
            this.ordernewBurgerMenu.Name = "ordernewBurgerMenu";
            this.ordernewBurgerMenu.Size = new System.Drawing.Size(480, 178);
            this.ordernewBurgerMenu.TabIndex = 1;
            // 
            // orderbtn
            // 
            this.orderbtn.Location = new System.Drawing.Point(138, 193);
            this.orderbtn.Name = "orderbtn";
            this.orderbtn.Size = new System.Drawing.Size(75, 23);
            this.orderbtn.TabIndex = 2;
            this.orderbtn.Text = "order";
            this.orderbtn.UseVisualStyleBackColor = true;
            this.orderbtn.Click += new System.EventHandler(this.orderbtn_Click);
            // 
            // userorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.orderbtn);
            this.Controls.Add(this.ordernewBurgerMenu);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "userorder";
            this.Text = "userorder";
            this.Load += new System.EventHandler(this.userorder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordernewBurgerMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView ordernewBurgerMenu;
        private System.Windows.Forms.Button orderbtn;
    }
}