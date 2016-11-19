using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Sexo : Form
    {
        Model m;
        int db;
        bool sexo_agregado = false;
        public Sexo(int baseDeDatos)
        {
            InitializeComponent();
            m = new Model();
            db=baseDeDatos;
            m.seleccionarBaseDeDatos(db);
        }

        private void Sexo_Load(object sender, EventArgs e)
        {
            m.llenarGridSexo(ref dataGridView1);
            imgEspere1.Left = 0;
            imgEspere1.Top = 0;
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;

            dataGridView1.Columns[0].Width = (this.Width / 2) - 40;
            dataGridView1.Columns[1].Width = (this.Width / 2) - 40;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            sexo_agregado = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            imgEspere1.Visible = true;
            if (sexo_agregado)
            {
                int i = dataGridView1.Rows.Count;
                m.guardarSexo(dataGridView1.Rows[i - 2].Cells[1].Value.ToString());
            }
            else
            {
                m.cambiarSexo(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dataGridView1.CurrentRow.Cells[1].Value.ToString());
            }
            m.llenarGridSexo(ref dataGridView1);
            imgEspere1.Visible = false;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            imgEspere1.Visible = true;
            m.borrarSexo(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            imgEspere1.Visible = false;
        }

        private void Sexo_Resize(object sender, EventArgs e)
        {
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;

            dataGridView1.Columns[0].Width = (this.Width / 2) - 40;
            dataGridView1.Columns[1].Width = (this.Width / 2) - 40;
        }
    }
}
