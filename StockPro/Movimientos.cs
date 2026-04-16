using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using StockPro.Data;

namespace StockPro
{
    public partial class Movimientos : Form
    {
        public Movimientos()
        {
            InitializeComponent();
            CargarProductos();
        }

        // --- STK-7/12: CARGAR TABLA CON ALERTAS VISUALES ---
        private void CargarProductos()
        {
            Conexion db = new Conexion();
            try
            {
                db.Abrir();
                string query = "SELECT Id, Nombre, StockActual FROM Productos WHERE Activo = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, db.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProductos.DataSource = dt;
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Aplicar colores de alerta
                PintarAlertas();
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar: " + ex.Message); }
            finally { db.Cerrar(); }
        }

        private void PintarAlertas()
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                // Seguridad: Saltamos la fila vacía del final (la que tiene el *)
                if (row.IsNewRow) continue;

                if (row.Cells["StockActual"].Value != null && row.Cells["StockActual"].Value != DBNull.Value)
                {
                    int stock = Convert.ToInt32(row.Cells["StockActual"].Value);

                    if (stock <= 5)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        // --- STK-10/11: PROCESAR ENTRADAS Y SALIDAS ---
        private void ProcesarMovimiento(string signo)
        {
            if (dgvProductos.CurrentRow == null || dgvProductos.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Por favor, selecciona un producto válido de la tabla.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);
                int cantidad = (int)numCantidad.Value;

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0.");
                    return;
                }

                Conexion db = new Conexion();
                db.Abrir();

                string query = $"UPDATE Productos SET StockActual = StockActual {signo} @cant WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, db.cn);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@id", id);

                int resultado = cmd.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show($"¡Movimiento exitoso! El inventario ha sido actualizado.");
                    numCantidad.Value = 0;
                    CargarProductos(); // Refresca visualmente la tabla
                }

                db.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error técnico: " + ex.Message);
            }
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            ProcesarMovimiento("+");
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null || dgvProductos.CurrentRow.IsNewRow) return;

            // Validación de seguridad para no quedar en negativo
            int stockActual = Convert.ToInt32(dgvProductos.CurrentRow.Cells["StockActual"].Value);
            if (numCantidad.Value > stockActual)
            {
                MessageBox.Show("Error: No puedes retirar más unidades de las que existen en stock.");
                return;
            }

            ProcesarMovimiento("-");
        }
    }
}