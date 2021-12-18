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
            this.visualizeAllOrders = new System.Windows.Forms.DataGridView();
            this.orderDone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.visualizeAllOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // visualizeAllOrders
            // 
            this.visualizeAllOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visualizeAllOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderDone});
            this.visualizeAllOrders.Location = new System.Drawing.Point(12, 12);
            this.visualizeAllOrders.Name = "visualizeAllOrders";
            this.visualizeAllOrders.Size = new System.Drawing.Size(776, 426);
            this.visualizeAllOrders.TabIndex = 0;
            // 
            // orderDone
            // 
            this.orderDone.HeaderText = "Order status";
            this.orderDone.Name = "orderDone";
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.visualizeAllOrders);
            this.Name = "adminForm";
            this.Text = "adminForm";
            this.Load += new System.EventHandler(this.adminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizeAllOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView visualizeAllOrders;
        private System.Windows.Forms.DataGridViewCheckBoxColumn orderDone;
    }
}