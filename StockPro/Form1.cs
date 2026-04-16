using Microsoft.Data.SqlClient;
using StockPro.Data; // Esto permite usar tu clase Conexion

namespace StockPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // 1. Instanciar la conexión
            Conexion db = new Conexion();

            try
            {
                db.Abrir();

                // 2. Consulta SQL para validar usuario
                string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @user AND Clave = @pass";
                SqlCommand cmd = new SqlCommand(query, db.cn);

                // 3. Pasar los datos de los TextBoxes a la consulta
                cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Bienvenido al sistema StockPro!", "Éxito");

                    this.Hide(); // Oculta el Login
                    MenuPrincipal menu = new MenuPrincipal(); // Crea el menú
                    menu.Show(); // Lo muestra
                }
            }       
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.Cerrar();
            }
        }
    }
}