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
    public partial class TiposNomina : Form
    {
        Model m;
        int db;
        bool nomina_agregado = false;
        public TiposNomina(int baseDeDatos)
        {
            InitializeComponent();
            m = new Model();
            db = baseDeDatos;
            m.seleccionarBaseDeDatos(db);
        }

        private void TiposNomina_Load(object sender, EventArgs e)
        {
            m.llenarGridTiposNomina(ref dataGridView1);
            imgEspere1.Left = 0;
            imgEspere1.Top = 0;
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;

            dataGridView1.Columns[0].Width = (this.Width / 2) - 40;
            dataGridView1.Columns[1].Width = (this.Width / 2) - 40;
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            nomina_agregado = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            imgEspere1.Visible = true;
            if (nomina_agregado)
            {
                int i = dataGridView1.Rows.Count;
                m.guardarTiposNomina(dataGridView1.Rows[i - 2].Cells[1].Value.ToString());
            }
            else
            {
                m.cambiarTiposNomina(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dataGridView1.CurrentRow.Cells[1].Value.ToString());
            }
            m.llenarGridTiposNomina(ref dataGridView1);
            imgEspere1.Visible = false;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            imgEspere1.Visible = true;
            m.borrarTiposNomina(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            imgEspere1.Visible = false;
        }

        private void TiposNomina_Resize(object sender, EventArgs e)
        {
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;

            try
            {
                dataGridView1.Columns[0].Width = (this.Width / 2) - 40;
                dataGridView1.Columns[1].Width = (this.Width / 2) - 40;
            }
            catch (Exception ex) { }
        }
    }
}
