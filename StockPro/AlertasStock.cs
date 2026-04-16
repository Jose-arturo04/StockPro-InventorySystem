using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using StockPro.Data;

namespace StockPro
{
    public partial class AlertasStock : Form
    {
        public AlertasStock()
        {
            InitializeComponent();
            CargarReporteCritico();
        }

        private void CargarReporteCritico()
        {
            Conexion db = new Conexion();
            try
            {
                db.Abrir();
                // El Query clave: filtramos solo los que tienen 5 o menos
                string query = "SELECT Nombre, Categoria, StockActual FROM Productos WHERE StockActual <= 5 AND Activo = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, db.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAlertas.DataSource = dt;
                dgvAlertas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Pintamos todo de rojo suave porque aquí todo es una alerta
                dgvAlertas.DefaultCellStyle.BackColor = Color.LightCoral;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { db.Cerrar(); }
        }
    }
}