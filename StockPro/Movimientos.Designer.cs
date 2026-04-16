namespace StockPro
{
    partial class Movimientos
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
            dgvProductos = new DataGridView();
            numCantidad = new NumericUpDown();
            btnEntrada = new Button();
            btnSalida = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 250);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(776, 188);
            dgvProductos.TabIndex = 0;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(326, 217);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(150, 27);
            numCantidad.TabIndex = 1;
            // 
            // btnEntrada
            // 
            btnEntrada.Location = new Point(12, 165);
            btnEntrada.Name = "btnEntrada";
            btnEntrada.Size = new Size(235, 29);
            btnEntrada.TabIndex = 2;
            btnEntrada.Text = "Registrar Entrada";
            btnEntrada.UseVisualStyleBackColor = true;
            btnEntrada.Click += btnEntrada_Click;
            // 
            // btnSalida
            // 
            btnSalida.Location = new Point(553, 165);
            btnSalida.Name = "btnSalida";
            btnSalida.Size = new Size(235, 29);
            btnSalida.TabIndex = 4;
            btnSalida.Text = "Registrar Salida";
            btnSalida.UseVisualStyleBackColor = true;
            btnSalida.Click += btnSalida_Click;
            // 
            // Movimientos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalida);
            Controls.Add(btnEntrada);
            Controls.Add(numCantidad);
            Controls.Add(dgvProductos);
            Name = "Movimientos";
            Text = "Movimientos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductos;
        private NumericUpDown numCantidad;
        private Button btnEntrada;
        private Button btnSalida;
    }
}