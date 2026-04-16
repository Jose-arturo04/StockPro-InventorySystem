using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using StockPro.Data;

namespace StockPro
{
    public partial class GestionProductos : Form
    {
        public GestionProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        // --- STK-7: MÉTODO PARA CARGAR DATOS EN LA TABLA ---
        private void CargarProductos()
        {
            Conexion db = new Conexion();
            try
            {
                db.Abrir();
                // Filtramos por Activo = 1 para el borrado lógico
                string query = "SELECT Id, Nombre, Categoria, Precio, StockActual FROM Productos WHERE Activo = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, db.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProductos.DataSource = dt;
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error");
            }
            finally
            {
                db.Cerrar();
            }
        }

        // --- STK-5: GUARDAR PRODUCTO ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.", "Aviso");
                return;
            }

            Conexion db = new Conexion();
            try
            {
                db.Abrir();
                string query = "INSERT INTO Productos (Nombre, Categoria, Precio, StockActual, Activo) " +
                               "VALUES (@nom, @cat, @pre, @stock, 1)";

                SqlCommand cmd = new SqlCommand(query, db.cn);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@pre", Convert.ToDecimal(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Producto registrado con éxito!", "StockPro");

                txtNombre.Clear();
                txtCategoria.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error");
            }
            finally
            {
                db.Cerrar();
            }
        }

        // --- STK-9: ELIMINAR PRODUCTO (NOMBRE CORREGIDO PARA EL DISEÑADOR) ---
        // Le agregamos el _1 para que Visual Studio deje de tirar error en el Designer.cs
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                object cellValue = dgvProductos.CurrentRow.Cells["Id"].Value;
                int id = Convert.ToInt32(cellValue);
                string nombre = dgvProductos.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "Producto";

                DialogResult res = MessageBox.Show($"¿Seguro que quieres eliminar {nombre}?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    Conexion db = new Conexion();
                    try
                    {
                        db.Abrir();
                        string query = "UPDATE Productos SET Activo = 0 WHERE Id = @id";
                        SqlCommand cmd = new SqlCommand(query, db.cn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Producto eliminado correctamente.", "StockPro");
                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error");
                    }
                    finally
                    {
                        db.Cerrar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila completa haciendo clic en el extremo izquierdo de la tabla.", "Selección Requerida");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Método vacío para evitar errores del diseñador
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no sea el encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                // Pasamos los datos de la fila seleccionada a los TextBoxes
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                txtCategoria.Text = fila.Cells["Categoria"].Value?.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value?.ToString();
                txtStock.Text = fila.Cells["StockActual"].Value?.ToString();

                // El ID lo guardamos en una variable para saber qué actualizar después
                // Tip: Puedes guardarlo en el .Tag del botón Actualizar o en una variable global
                btnActualizar.Tag = fila.Cells["Id"].Value;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (btnActualizar.Tag == null)
            {
                MessageBox.Show("Por favor, selecciona primero un producto de la tabla.");
                return;
            }

            Conexion db = new Conexion();
            try
            {
                db.Abrir();
                string query = "UPDATE Productos SET Nombre=@nom, Categoria=@cat, Precio=@pre, StockActual=@stock " +
                               "WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, db.cn);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@pre", Convert.ToDecimal(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text));
                cmd.Parameters.AddWithValue("@id", btnActualizar.Tag); // El ID que guardamos antes

                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Producto actualizado correctamente!", "StockPro");

                // Limpiar y refrescar
                txtNombre.Clear(); txtCategoria.Clear(); txtPrecio.Clear(); txtStock.Clear();
                btnActualizar.Tag = null; // Limpiamos el ID seleccionado
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
            finally
            {
                db.Cerrar();
            }
        }
    }
}