namespace BurgeriVisual
{
    partial class BurgerMenu_OrderBtn
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
            this.bigmenu = new System.Windows.Forms.DataGridView();
            this.orderbtn = new System.Windows.Forms.Button();
            this.menulbl = new System.Windows.Forms.Label();
            this.pastOrders = new System.Windows.Forms.DataGridView();
            this.pastordslbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bigmenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // bigmenu
            // 
            this.bigmenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bigmenu.Location = new System.Drawing.Point(3, 25);
            this.bigmenu.Name = "bigmenu";
            this.bigmenu.Size = new System.Drawing.Size(796, 167);
            this.bigmenu.TabIndex = 0;
            this.bigmenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bigmenu_CellClick);
            this.bigmenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BigMenu_CellContentClick);
            // 
            // orderbtn
            // 
            this.orderbtn.Location = new System.Drawing.Point(13, 425);
            this.orderbtn.Name = "orderbtn";
            this.orderbtn.Size = new System.Drawing.Size(75, 23);
            this.orderbtn.TabIndex = 1;
            this.orderbtn.Text = "Order burger";
            this.orderbtn.UseVisualStyleBackColor = true;
            // 
            // menulbl
            // 
            this.menulbl.AutoSize = true;
            this.menulbl.Location = new System.Drawing.Point(3, 6);
            this.menulbl.Name = "menulbl";
            this.menulbl.Size = new System.Drawing.Size(73, 13);
            this.menulbl.TabIndex = 2;
            this.menulbl.Text = "Current menu:";
            // 
            // pastOrders
            // 
            this.pastOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pastOrders.Location = new System.Drawing.Point(3, 252);
            this.pastOrders.Name = "pastOrders";
            this.pastOrders.Size = new System.Drawing.Size(796, 167);
            this.pastOrders.TabIndex = 3;
            // 
            // pastordslbl
            // 
            this.pastordslbl.AutoSize = true;
            this.pastordslbl.Location = new System.Drawing.Point(6, 233);
            this.pastordslbl.Name = "pastordslbl";
            this.pastordslbl.Size = new System.Drawing.Size(63, 13);
            this.pastordslbl.TabIndex = 4;
            this.pastordslbl.Text = "Past orders:";
            // 
            // BurgerMenu_OrderBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pastordslbl);
            this.Controls.Add(this.pastOrders);
            this.Controls.Add(this.menulbl);
            this.Controls.Add(this.orderbtn);
            this.Controls.Add(this.bigmenu);
            this.Name = "BurgerMenu_OrderBtn";
            this.Text = "BurgerMenu_OrderBtn";
            this.Load += new System.EventHandler(this.BurgerMenu_OrderBtn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bigmenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bigmenu;
        private System.Windows.Forms.Button orderbtn;
        private System.Windows.Forms.Label menulbl;
        private System.Windows.Forms.DataGridView pastOrders;
        private System.Windows.Forms.Label pastordslbl;
    }
}