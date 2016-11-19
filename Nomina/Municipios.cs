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
    public partial class Municipios : Form
    {
        Model m;
        int db;
        bool municipio_agregado;
        int paisseleccionado = -1;
        int estadoseleccionado = -1;
        public Municipios(int baseDeDatos)
        {
            InitializeComponent();
            m = new Model();
            db = baseDeDatos;
            m.seleccionarBaseDeDatos(db);
            municipio_agregado = false;
        }

        private void Municipios_Load(object sender, EventArgs e)
        {
            m.llenarComboPais(ref comboBox1);
            imgEspere1.Left = 0;
            imgEspere1.Top = 0;
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 100;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgEspere1.Visible = true;
            paisseleccionado = ((ComboboxItem)comboBox1.SelectedItem).GetValue();
            m.llenarComboEstado(paisseleccionado, ref comboBox2);
            imgEspere1.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgEspere1.Visible = true;

            estadoseleccionado = ((ComboboxItem)comboBox2.SelectedItem).GetValue();
            m.llenarGridMunicipio(ref dataGridView1,estadoseleccionado);
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 100;
            dataGridView1.Columns[0].Width = (this.Width / 3) - 20;
            dataGridView1.Columns[1].Width = (this.Width / 3) - 20;

            imgEspere1.Visible = false;
        }

        private void Municipios_Resize(object sender, EventArgs e)
        {
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;
            try
            {
                dataGridView1.Width = this.Width - 20;
                dataGridView1.Height = this.Height - 100;
                dataGridView1.Columns[0].Width = (this.Width / 3) - 20;
                dataGridView1.Columns[1].Width = (this.Width / 3) - 20;
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            municipio_agregado = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            imgEspere1.Visible = true;
            try
            {

                if ((municipio_agregado))
                {
                    int i = dataGridView1.Rows.Count;
                    m.guardarMunicipio(estadoseleccionado, dataGridView1.Rows[i - 2].Cells[1].Value.ToString());
                }
                else
                {
                    m.cambiarMunicipio(estadoseleccionado, int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                }
                dataGridView1.Rows.Clear();
                m.llenarGridMunicipio(ref dataGridView1, estadoseleccionado);
            }
            catch (Exception ex) { }
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 100;
            dataGridView1.Columns[0].Width = (this.Width / 3) - 20;
            dataGridView1.Columns[1].Width = (this.Width / 3) - 20;
            imgEspere1.Visible = false;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            imgEspere1.Visible = true;
            m.borrarMunicipio(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            imgEspere1.Visible = false;
        }
    }
}
