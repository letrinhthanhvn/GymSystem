namespace GymSystem
{
    partial class fThongKeNguoiTapGoiTap
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNguoiTap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 58);
            this.label1.TabIndex = 3;
            this.label1.Text = "THỐNG KÊ SỐ LƯỢNG NGƯỜI TẬP THEO CÁC GÓI TẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaGT,
            this.SoNguoiTap});
            this.dataGridView1.Location = new System.Drawing.Point(12, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(470, 179);
            this.dataGridView1.TabIndex = 4;
            // 
            // MaGT
            // 
            this.MaGT.DataPropertyName = "MaGT";
            this.MaGT.HeaderText = "Mã gói tập";
            this.MaGT.Name = "MaGT";
            this.MaGT.ReadOnly = true;
            this.MaGT.Width = 225;
            // 
            // SoNguoiTap
            // 
            this.SoNguoiTap.DataPropertyName = "SoNguoiTap";
            this.SoNguoiTap.HeaderText = "Số lượng người tập";
            this.SoNguoiTap.Name = "SoNguoiTap";
            this.SoNguoiTap.ReadOnly = true;
            this.SoNguoiTap.Width = 200;
            // 
            // fThongKeNguoiTapGoiTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 272);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "fThongKeNguoiTapGoiTap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ SỐ LƯỢNG NGƯỜI TẬP THEO CÁC GÓI TẬP";
            this.Load += new System.EventHandler(this.fThongKeNguoiTapGoiTap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNguoiTap;
    }
}