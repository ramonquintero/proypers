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
    public partial class Estados : Form
    {
        Model m;
        int db;
        bool estado_agregado;
        int paisseleccionado = -1;
        public Estados(int baseDeDatos)
        {
            InitializeComponent();
            m = new Model();
            db = baseDeDatos;
            m.seleccionarBaseDeDatos(db);
            estado_agregado = false;
        }

        private void Estados_Load(object sender, EventArgs e)
        {
            //m.llenarGridEstado(ref dataGridView1,paisseleccionado);
            m.llenarComboPais(ref comboBox1);
            imgEspere1.Left = 0;
            imgEspere1.Top = 0;
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;

            /*dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 100;
            dataGridView1.Columns[0].Width = (this.Width / 2) - 20;
            dataGridView1.Columns[1].Width = (this.Width / 2) - 20;
            /*dataGridView1.Columns[2].Width = (this.Width / 6) - 20;
            dataGridView1.Columns[3].Width = (this.Width / 3) - 20;*/
        }

        private void Estados_Resize(object sender, EventArgs e)
        {
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;
            try
            {
                dataGridView1.Width = this.Width - 20;
                dataGridView1.Height = this.Height - 100;
                dataGridView1.Columns[0].Width = (this.Width / 3) - 20;
                dataGridView1.Columns[1].Width = (this.Width / 3) - 20;
                /*dataGridView1.Columns[2].Width = (this.Width / 6) - 20;
                dataGridView1.Columns[3].Width = (this.Width / 3) - 20;*/
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            estado_agregado = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            imgEspere1.Visible = true;
            try
            {

                if ((estado_agregado))
                {
                    int i = dataGridView1.Rows.Count;
                    m.guardarEstado(paisseleccionado, dataGridView1.Rows[i - 2].Cells[1].Value.ToString());
                }
                else
                {
                    m.cambiarEstado(paisseleccionado, int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                }
                dataGridView1.Rows.Clear();
                m.llenarGridEstado(ref dataGridView1, paisseleccionado);
            }
            catch (Exception ex) { }
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 100;
            dataGridView1.Columns[0].Width = (this.Width / 3) - 20;
            dataGridView1.Columns[1].Width = (this.Width / 3) - 20;
            /*dataGridView1.Columns[2].Width = (this.Width / 6) - 20;
            dataGridView1.Columns[3].Width = (this.Width / 3) - 20;*/
            imgEspere1.Visible = false;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            imgEspere1.Visible = true;
            m.borrarEstado(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            imgEspere1.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                imgEspere1.Visible = true;
                paisseleccionado = ((ComboboxItem)comboBox1.SelectedItem).GetValue();
                //dataGridView1.Rows.Clear();
                m.llenarGridEstado(ref dataGridView1, paisseleccionado);
                dataGridView1.Width = this.Width - 20;
                dataGridView1.Height = this.Height - 100;
                dataGridView1.Columns[0].Width = (this.Width / 3) - 20;
                dataGridView1.Columns[1].Width = (this.Width / 3) - 20;
                imgEspere1.Visible = false;
            }
            catch (Exception ex) { }
        }
    }
}
