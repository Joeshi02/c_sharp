using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void cargoUsuarios()
        {
            List<Usuario> usuarios = UsuarioBussiness.ListarUsuario() ;
            dgvUsuario.AutoGenerateColumns = true;
            dgvUsuario.DataSource= usuarios;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargoUsuarios();
        }
    }
}
