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
            this.ordernewBurgerMenu = new System.Windows.Forms.DataGridView();
            this.orderbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comemntary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ordernewBurgerMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ordernewBurgerMenu
            // 
            this.ordernewBurgerMenu.AllowUserToAddRows = false;
            this.ordernewBurgerMenu.AllowUserToDeleteRows = false;
            this.ordernewBurgerMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordernewBurgerMenu.Location = new System.Drawing.Point(12, 12);
            this.ordernewBurgerMenu.Name = "ordernewBurgerMenu";
            this.ordernewBurgerMenu.ReadOnly = true;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Quantity,
            this.Comemntary,
            this.del_Address});
            this.dataGridView1.Location = new System.Drawing.Point(12, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "quantity";
            this.Quantity.MaxInputLength = 2;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 50;
            // 
            // Comemntary
            // 
            this.Comemntary.HeaderText = "Comemntary";
            this.Comemntary.Name = "Comemntary";
            // 
            // del_Address
            // 
            this.del_Address.HeaderText = "Delivery Addresss";
            this.del_Address.Name = "del_Address";
            // 
            // userorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.orderbtn);
            this.Controls.Add(this.ordernewBurgerMenu);
            this.Name = "userorder";
            this.Text = "userorder";
            this.Load += new System.EventHandler(this.userorder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordernewBurgerMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ordernewBurgerMenu;
        private System.Windows.Forms.Button orderbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comemntary;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_Address;
    }
}