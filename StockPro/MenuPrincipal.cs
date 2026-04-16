using System;
using System.Windows.Forms;

namespace StockPro
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        // --- STK-5: ABRIR GESTIÓN DE PRODUCTOS ---
        private void btnProductos_Click(object sender, EventArgs e)
        {
            GestionProductos ventana = new GestionProductos();
            ventana.ShowDialog();
        }

        // --- STK-10/11: ABRIR ENTRADAS Y SALIDAS ---
        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            Movimientos ventana = new Movimientos();
            ventana.ShowDialog();
        }

        // --- STK-12: ABRIR ALERTAS DE STOCK (REPORTE CRÍTICO) ---
        private void btnAlertas_Click(object sender, EventArgs e)
        {
            // Asegúrate de haber creado el Formulario "AlertasStock"
            AlertasStock ventana = new AlertasStock();
            ventana.ShowDialog();
        }

        // --- STK-13: CERRAR SESIÓN (LOGOUT) ---
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea cerrar la sesión actual?",
                "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                this.Hide();
                Form1 login = new Form1();
                login.Show();
            }
        }

        // --- MÉTODOS DE SOPORTE (Mantener para evitar errores del Designer) ---
        private void label1_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}