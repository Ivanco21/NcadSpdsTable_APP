namespace NcadSpdsTable_APP
{
    partial class GlobalFormApp
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
            this.btnMergeAllTable = new System.Windows.Forms.Button();
            this.btnMergeUserTableVertical = new System.Windows.Forms.Button();
            this.pnlMergeAllTable = new System.Windows.Forms.Panel();
            this.tbRowsInTitleTable = new System.Windows.Forms.TextBox();
            this.lbSizeUpTitleTable = new System.Windows.Forms.Label();
            this.btnMergeUserTableHorizontal = new System.Windows.Forms.Button();
            this.lblHorOrVert = new System.Windows.Forms.Label();
            this.pnlMergeAllTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMergeAllTable
            // 
            this.btnMergeAllTable.Location = new System.Drawing.Point(3, 3);
            this.btnMergeAllTable.Name = "btnMergeAllTable";
            this.btnMergeAllTable.Size = new System.Drawing.Size(81, 48);
            this.btnMergeAllTable.TabIndex = 0;
            this.btnMergeAllTable.Text = "Объединить все таблицы";
            this.btnMergeAllTable.UseVisualStyleBackColor = true;
            this.btnMergeAllTable.Click += new System.EventHandler(this.btnMergeAllTable_Click);
            // 
            // btnMergeUserTableVertical
            // 
            this.btnMergeUserTableVertical.Location = new System.Drawing.Point(6, 77);
            this.btnMergeUserTableVertical.Name = "btnMergeUserTableVertical";
            this.btnMergeUserTableVertical.Size = new System.Drawing.Size(102, 48);
            this.btnMergeUserTableVertical.TabIndex = 1;
            this.btnMergeUserTableVertical.Text = "Вертикально";
            this.btnMergeUserTableVertical.UseVisualStyleBackColor = true;
            this.btnMergeUserTableVertical.Click += new System.EventHandler(this.btnMergeUserTable_Click);
            // 
            // pnlMergeAllTable
            // 
            this.pnlMergeAllTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMergeAllTable.Controls.Add(this.lblHorOrVert);
            this.pnlMergeAllTable.Controls.Add(this.btnMergeUserTableHorizontal);
            this.pnlMergeAllTable.Controls.Add(this.btnMergeAllTable);
            this.pnlMergeAllTable.Controls.Add(this.tbRowsInTitleTable);
            this.pnlMergeAllTable.Controls.Add(this.btnMergeUserTableVertical);
            this.pnlMergeAllTable.Controls.Add(this.lbSizeUpTitleTable);
            this.pnlMergeAllTable.Location = new System.Drawing.Point(12, 12);
            this.pnlMergeAllTable.Name = "pnlMergeAllTable";
            this.pnlMergeAllTable.Size = new System.Drawing.Size(265, 130);
            this.pnlMergeAllTable.TabIndex = 2;
            // 
            // tbRowsInTitleTable
            // 
            this.tbRowsInTitleTable.Location = new System.Drawing.Point(143, 28);
            this.tbRowsInTitleTable.Name = "tbRowsInTitleTable";
            this.tbRowsInTitleTable.Size = new System.Drawing.Size(102, 20);
            this.tbRowsInTitleTable.TabIndex = 3;
            this.tbRowsInTitleTable.Text = "0";
            this.tbRowsInTitleTable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRowsInTitleTable_KeyPress);
            // 
            // lbSizeUpTitleTable
            // 
            this.lbSizeUpTitleTable.AutoSize = true;
            this.lbSizeUpTitleTable.Location = new System.Drawing.Point(128, 4);
            this.lbSizeUpTitleTable.Name = "lbSizeUpTitleTable";
            this.lbSizeUpTitleTable.Size = new System.Drawing.Size(127, 13);
            this.lbSizeUpTitleTable.TabIndex = 1;
            this.lbSizeUpTitleTable.Text = "Размер шапки таблицы";
            // 
            // btnMergeUserTableHorizontal
            // 
            this.btnMergeUserTableHorizontal.Location = new System.Drawing.Point(143, 77);
            this.btnMergeUserTableHorizontal.Name = "btnMergeUserTableHorizontal";
            this.btnMergeUserTableHorizontal.Size = new System.Drawing.Size(102, 48);
            this.btnMergeUserTableHorizontal.TabIndex = 4;
            this.btnMergeUserTableHorizontal.Text = "Горизонтально";
            this.btnMergeUserTableHorizontal.UseVisualStyleBackColor = true;
            this.btnMergeUserTableHorizontal.Click += new System.EventHandler(this.btnMergeUserTableHorizontal_Click);
            // 
            // lblHorOrVert
            // 
            this.lblHorOrVert.AutoSize = true;
            this.lblHorOrVert.Location = new System.Drawing.Point(3, 58);
            this.lblHorOrVert.Name = "lblHorOrVert";
            this.lblHorOrVert.Size = new System.Drawing.Size(179, 13);
            this.lblHorOrVert.TabIndex = 5;
            this.lblHorOrVert.Text = "Объединить выбранные таблицы:";
            // 
            // GlobalFormApp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(289, 152);
            this.Controls.Add(this.pnlMergeAllTable);
            this.MaximizeBox = false;
            this.Name = "GlobalFormApp";
            this.ShowIcon = false;
            this.Text = "SpdsTableApp by Ivanco v 0.1";
            this.pnlMergeAllTable.ResumeLayout(false);
            this.pnlMergeAllTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMergeAllTable;
        private System.Windows.Forms.Button btnMergeUserTableVertical;
        private System.Windows.Forms.Panel pnlMergeAllTable;
        private System.Windows.Forms.Label lbSizeUpTitleTable;
        private System.Windows.Forms.TextBox tbRowsInTitleTable;
        private System.Windows.Forms.Label lblHorOrVert;
        private System.Windows.Forms.Button btnMergeUserTableHorizontal;
    }
}

