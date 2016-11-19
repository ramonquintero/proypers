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
    public partial class FichaDelTrabajador : Form
    {
        Model m;
        int db;
        Utiles u;
        public FichaDelTrabajador(int baseDeDatos)
        {
            InitializeComponent();
            m = new Model();
            db = baseDeDatos;
            m.seleccionarBaseDeDatos(db);
            u = new Utiles();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FichaDelTrabajador_Load(object sender, EventArgs e)
        {
            m.llenarComboSexo(ref comboBoxSexo);
            m.llenarComboEstadoCivil(ref comboBoxEstadoCivil);
            m.llenarComboCargo(ref comboBoxCargo);
            m.llenarComboDepartamento(ref comboBoxDepartamento);
            m.llenarComboEstadoTrabajador(ref comboBoxEstadoTrabajador);
            m.llenarComboTiposNomina(ref comboBoxNomina);
            /*m.llenarComboPais(ref comboBoxPais);*/
            imgEspere1.Left = 0;
            imgEspere1.Top = 0;
            imgEspere1.Width = this.Width;
            imgEspere1.Height = this.Height;
            
            DataGridViewComboBoxColumn column =
                (DataGridViewComboBoxColumn)dataGridView1.Columns[2];
            m.llenarComboParentesco(ref column);
            
            dataGridView1.Columns[0].Width = dataGridView1.Width / 8;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 4;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 4;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 4;

            /*dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "    ";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "    ";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "    ";*/
            //m.lista_de_trabajadores(ref dataGridView2);
            //FichaDelTrabajador_Resize( sender, e);
        }

        private bool DatosObligatorios()
        {
            bool res = false;

            res = textBox1.Text.Length > 0 && textBox2.Text.Length > 0 &&
                  textBox4.Text.Length > 0 && textBox3.Text.Length > 0 &&
                  comboBoxCargo.Text.Length > 0 && comboBoxNomina.Text.Length > 0 &&
                  comboBoxDepartamento.Text.Length > 0;

            return res;
        }

        private void button3_Click(object sender, EventArgs e) //Guardar ficha
        {
            imgEspere1.Visible = true;
            if (DatosObligatorios())
            {
                Application.DoEvents();
                string telfs = "";
                if ((textBox6.Text.Length>0))
                        telfs=textBox6.Text;
                if ((textBox7.Text.Length>0))
                {
                    if (telfs.Length==0)
                        telfs=textBox7.Text;
                    else
                        telfs += "-"+textBox7.Text;
                }
                if ((textBox8.Text.Length>0))
                {
                    if (telfs.Length==0)
                        telfs=textBox8.Text;
                    else
                        telfs += "-"+textBox8.Text;
                }
                if ((textBox9.Text.Length>0))
                {
                    if (telfs.Length==0)
                        telfs=textBox9.Text;
                    else
                        telfs += "-"+textBox9.Text;
                }
                int sexo = 0;
                if (comboBoxSexo.SelectedItem != null)
                    sexo = ((ComboboxItem)comboBoxSexo.SelectedItem).GetValue();
                else
                    if (comboBoxSexo.Text.Length > 0)
                    {
                        string tempo = comboBoxSexo.Text;
                        m.guardarSexo(comboBoxSexo.Text);
                        m.llenarComboSexo(ref comboBoxSexo);
                        comboBoxSexo.Text = tempo;
                        sexo = ((ComboboxItem)comboBoxSexo.SelectedItem).GetValue();
                    }
                int edocivil = 0;
                if (comboBoxEstadoCivil.SelectedItem != null)
                    edocivil = ((ComboboxItem)comboBoxEstadoCivil.SelectedItem).GetValue();
                else
                    if (comboBoxEstadoCivil.Text.Length > 0)
                    {
                        string tempo = comboBoxEstadoCivil.Text;
                        m.guardarEstadoCivil(comboBoxEstadoCivil.Text);
                        m.llenarComboEstadoCivil(ref comboBoxEstadoCivil);
                        comboBoxEstadoCivil.Text = tempo;
                        edocivil = ((ComboboxItem)comboBoxEstadoCivil.SelectedItem).GetValue();
                    }
                int pais = 0;
                int estado = 0;
                int municipio = 0;
                string tempopais = "";
                string tempoestado = "";
                string tempomunicipio = "";
                /*if (comboBoxPais.SelectedItem != null)
                    pais = ((ComboboxItem)comboBoxPais.SelectedItem).GetValue();
                else
                    if (comboBoxPais.Text.Length > 0)
                    {
                        tempopais = comboBoxPais.Text;
                        if (comboBoxEstado.Text.Length > 0)
                        {
                            if (comboBoxEstado.SelectedItem != null)
                                estado = ((ComboboxItem)comboBoxEstado.SelectedItem).GetValue();
                            else
                                tempoestado = comboBoxEstado.Text;
                        }
                        if (comboBoxMunicipio.Text.Length > 0)
                        {
                            if (comboBoxMunicipio.SelectedItem != null)
                                municipio = ((ComboboxItem)comboBoxMunicipio.SelectedItem).GetValue();
                            else
                                tempomunicipio = comboBoxMunicipio.Text;
                        }
                        m.guardarPais(comboBoxPais.Text);
                        m.llenarComboPais(ref comboBoxPais);
                        comboBoxPais.Text = tempopais;
                        pais = ((ComboboxItem)comboBoxPais.SelectedItem).GetValue();
                    }
                if (comboBoxEstado.SelectedItem != null) 
                    estado = ((ComboboxItem)comboBoxEstado.SelectedItem).GetValue();
                else
                    if ((comboBoxEstado.Text.Length > 0) || (tempoestado.Length>0))
                    {
                        if (tempoestado.Length==0) tempoestado = comboBoxEstado.Text;
                        if (comboBoxMunicipio.Text.Length > 0) tempomunicipio = comboBoxMunicipio.Text;
                        m.guardarEstado(pais,tempoestado);
                        m.llenarComboEstado(pais,ref comboBoxEstado);
                        comboBoxEstado.Text = tempoestado;
                        estado = ((ComboboxItem)comboBoxEstado.SelectedItem).GetValue();
                    }
                if (comboBoxMunicipio.SelectedItem != null)
                    municipio = ((ComboboxItem)comboBoxMunicipio.SelectedItem).GetValue();
                else
                    if ((comboBoxMunicipio.Text.Length > 0) || (tempomunicipio.Length>0))
                    {
                        if (tempomunicipio.Length == 0) tempomunicipio = comboBoxMunicipio.Text;
                        m.guardarMunicipio(estado, tempomunicipio);
                        m.llenarComboMunicipio(estado, ref comboBoxMunicipio);
                        comboBoxMunicipio.Text = tempomunicipio;
                        municipio = ((ComboboxItem)comboBoxMunicipio.SelectedItem).GetValue();
                    }*/
                int estadotrabajador = 0;
                if (comboBoxEstadoTrabajador.SelectedItem != null)
                    estadotrabajador = ((ComboboxItem)comboBoxEstadoTrabajador.SelectedItem).GetValue();
                else
                    if (comboBoxEstadoTrabajador.Text.Length > 0)
                    {
                        string tempo = comboBoxEstadoTrabajador.Text;
                        m.guardarEstadoTrabajador(comboBoxEstadoTrabajador.Text);
                        m.llenarComboEstadoTrabajador(ref comboBoxEstadoTrabajador);
                        comboBoxEstadoTrabajador.Text = tempo;
                        estadotrabajador = ((ComboboxItem)comboBoxEstadoTrabajador.SelectedItem).GetValue();
                    }
                int departamento = 0;
                if (comboBoxDepartamento.SelectedItem !=null)
                    departamento = ((ComboboxItem)comboBoxDepartamento.SelectedItem).GetValue();
                else
                    if (comboBoxDepartamento.Text.Length > 0)
                    {
                        string tempo = comboBoxDepartamento.Text;
                        m.guardarDepartamento(comboBoxDepartamento.Text);
                        m.llenarComboDepartamento(ref comboBoxDepartamento);
                        comboBoxDepartamento.Text = tempo;
                        departamento = ((ComboboxItem)comboBoxDepartamento.SelectedItem).GetValue();
                    }
                int cargo = 0;
                if (comboBoxCargo.SelectedItem != null)
                    cargo = ((ComboboxItem)comboBoxCargo.SelectedItem).GetValue();
                else
                    if (comboBoxCargo.Text.Length > 0)
                    {
                        string tempo = comboBoxCargo.Text;
                        m.guardarCargo(comboBoxCargo.Text);
                        m.llenarComboCargo(ref comboBoxCargo);
                        comboBoxCargo.Text = tempo;
                        cargo = ((ComboboxItem)comboBoxCargo.SelectedItem).GetValue();
                    }
                int nomina = 0;
                if (comboBoxNomina.SelectedItem != null)
                    nomina = ((ComboboxItem)comboBoxNomina.SelectedItem).GetValue();
                else
                    if (comboBoxNomina.Text.Length > 0)
                    {
                        string tempo = comboBoxNomina.Text;
                        m.guardarTiposNomina(comboBoxNomina.Text);
                        m.llenarComboTiposNomina(ref comboBoxNomina);
                        comboBoxNomina.Text = tempo;
                        nomina = ((ComboboxItem)comboBoxNomina.SelectedItem).GetValue();
                    }
                DateTime fnac = DateTime.Now;
                if (dateTimePicker1.Value !=null)
                    fnac = dateTimePicker1.Value;
                DateTime fingreso = DateTime.Now;
                if (dateTimePicker2.Value != null)
                    fingreso = dateTimePicker2.Value;
                DateTime fegreso = DateTime.Now;
                if (dateTimePicker3.Value != null)
                    fegreso = dateTimePicker3.Value;
                m.guardarFichaTrabajador(textBox1.Text, textBox2.Text,
                    fnac.ToShortDateString(), textBox4.Text,
                    sexo, edocivil,telfs, pais,estado, municipio,
                    textBox5.Text, estadotrabajador,
                    departamento, cargo,
                    fingreso.ToShortDateString(), fegreso.ToShortDateString(),
                    nomina, textBox3.Text,dataGridView1);
                u.afectar_controles(this, true, false);
                dataGridView1.Rows.Clear();
                //m.lista_de_trabajadores(ref dataGridView2);
                button2.Enabled = button3.Enabled = true;
                /*button1.Text = "Nuevo";*/
            }
            else
            {
                MessageBox.Show("Faltan datos obligatorios (*)");
            }
            imgEspere1.Visible = false;
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {

            ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            /*DateTime fecha = new DateTime(dateTimePicker1.Value.Year,
                                          dateTimePicker1.Value.Month,
                                          dateTimePicker1.Value.Day);
            if (fecha.Equals(DateTime.Today))
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "    ";
            }*/
        }

        private void dateTimePicker2_Enter(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            /*DateTime fecha = new DateTime(dateTimePicker2.Value.Year,
                                          dateTimePicker2.Value.Month,
                                          dateTimePicker2.Value.Day);
            if (fecha.Equals(DateTime.Today))
            {
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "    ";
            }*/
        }

        private void dateTimePicker3_Enter(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
        }

        private void dateTimePicker3_Leave(object sender, EventArgs e)
        {
            /*DateTime fecha = new DateTime(dateTimePicker3.Value.Year,
                                          dateTimePicker3.Value.Month,
                                          dateTimePicker3.Value.Day);
            if (fecha.Equals(DateTime.Today))
            {
                dateTimePicker3.Format = DateTimePickerFormat.Custom;
                dateTimePicker3.CustomFormat = "    ";
            }*/
        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = " ";
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = " ";
            }
        }

        private void dateTimePicker3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                dateTimePicker3.Format = DateTimePickerFormat.Custom;
                dateTimePicker3.CustomFormat = " ";
            }
        }



        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }



        private void button2_Click(object sender, EventArgs e)
        {
            u.afectar_controles(this, true, false);
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id","Id");
            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("FechaNacimiento", "FechaNacimiento");
            dataGridView1.Columns.Add("Parentesco", "Parentesco");
            //dataGridView1.Rows.Add();
        }

        
    }
}
