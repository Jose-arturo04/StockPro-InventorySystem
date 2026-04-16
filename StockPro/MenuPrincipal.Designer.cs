namespace StockPro
{
    partial class MenuPrincipal
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
            label1 = new Label();
            btnProductos = new Button();
            btnMovimientos = new Button();
            btnAlertas = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(235, 9);
            label1.Name = "label1";
            label1.Size = new Size(319, 35);
            label1.TabIndex = 0;
            label1.Text = "Panel de Control - StockPro";
            // 
            // btnProductos
            // 
            btnProductos.Location = new Point(251, 133);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(266, 29);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "Gestión de Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnMovimientos
            // 
            btnMovimientos.Location = new Point(251, 180);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.Size = new Size(266, 29);
            btnMovimientos.TabIndex = 2;
            btnMovimientos.Text = "Entradas y salidas";
            btnMovimientos.UseVisualStyleBackColor = true;
            btnMovimientos.Click += btnMovimientos_Click;
            // 
            // btnAlertas
            // 
            btnAlertas.Location = new Point(251, 225);
            btnAlertas.Name = "btnAlertas";
            btnAlertas.Size = new Size(266, 29);
            btnAlertas.TabIndex = 3;
            btnAlertas.Text = "Alertas de Stock";
            btnAlertas.UseVisualStyleBackColor = true;
            btnAlertas.Click += btnAlertas_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(251, 271);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(266, 29);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnAlertas);
            Controls.Add(btnMovimientos);
            Controls.Add(btnProductos);
            Controls.Add(label1);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnProductos; // CORREGIDO: Antes decía btnInventario
        private Button btnMovimientos;
        private Button btnAlertas;
        private Button btnSalir;
    }
}