namespace BurgeriVisual
{
    partial class adminForm
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
            this.components = new System.ComponentModel.Container();
            this.visualizeAllOrders = new System.Windows.Forms.DataGridView();
            this.updatebtn = new System.Windows.Forms.Button();
            this.openCloseShop = new System.Windows.Forms.Button();
            this.refreshOrders = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.visualizeAllOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // visualizeAllOrders
            // 
            this.visualizeAllOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visualizeAllOrders.Location = new System.Drawing.Point(12, 12);
            this.visualizeAllOrders.Name = "visualizeAllOrders";
            this.visualizeAllOrders.Size = new System.Drawing.Size(1106, 402);
            this.visualizeAllOrders.TabIndex = 0;
            this.visualizeAllOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.visualizeAllOrders_CellContentClick);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(653, 421);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(75, 23);
            this.updatebtn.TabIndex = 1;
            this.updatebtn.Text = "update";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // openCloseShop
            // 
            this.openCloseShop.Location = new System.Drawing.Point(52, 421);
            this.openCloseShop.Name = "openCloseShop";
            this.openCloseShop.Size = new System.Drawing.Size(75, 23);
            this.openCloseShop.TabIndex = 2;
            this.openCloseShop.UseVisualStyleBackColor = true;
            this.openCloseShop.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshOrders
            // 
            this.refreshOrders.Enabled = true;
            this.refreshOrders.Interval = 5000;
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 450);
            this.Controls.Add(this.openCloseShop);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.visualizeAllOrders);
            this.Name = "adminForm";
            this.Text = "adminForm";
            this.Load += new System.EventHandler(this.adminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizeAllOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView visualizeAllOrders;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button openCloseShop;
        private System.Windows.Forms.Timer refreshOrders;
    }
}