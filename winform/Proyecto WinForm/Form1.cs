using Proyecto_WinForm.database;

namespace Proyecto_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = new GestorBaseDatos();
            var usuarios = db.Usuarios
                .OrderBy(b=>b.Id)
                .ToList();

            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource= usuarios;
        }
    }
}
