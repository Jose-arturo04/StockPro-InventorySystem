namespace StockPro
{
    partial class AlertasStock
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
            dgvAlertas = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAlertas).BeginInit();
            SuspendLayout();
            // 
            // dgvAlertas
            // 
            dgvAlertas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlertas.Location = new Point(12, 189);
            dgvAlertas.Name = "dgvAlertas";
            dgvAlertas.RowHeadersWidth = 51;
            dgvAlertas.Size = new Size(776, 249);
            dgvAlertas.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(203, 48);
            label1.Name = "label1";
            label1.Size = new Size(394, 35);
            label1.TabIndex = 1;
            label1.Text = "PRODUCTOS CON STOCK CRÍTICO";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvAlertas);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvAlertas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAlertas;
        private Label label1;
    }
}