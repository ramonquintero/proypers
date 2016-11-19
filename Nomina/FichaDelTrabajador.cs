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
            m.llenarComboPais(ref comboBoxPais);
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
            m.lista_de_trabajadores(ref dataGridView2);
            FichaDelTrabajador_Resize( sender, e);
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
                if (comboBoxPais.SelectedItem != null)
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
                    }
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
                m.lista_de_trabajadores(ref dataGridView2);
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

        private void comboBoxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMunicipio.Items.Clear();
            comboBoxEstado.Text = "";
            comboBoxMunicipio.Text = "";
            m.llenarComboEstado(((ComboboxItem)comboBoxPais.Items[comboBoxPais.SelectedIndex]).GetValue(), ref comboBoxEstado);
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMunicipio.Text = "";
            m.llenarComboMunicipio(((ComboboxItem)comboBoxEstado.Items[comboBoxEstado.SelectedIndex]).GetValue(), ref comboBoxMunicipio);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void FichaDelTrabajador_Resize(object sender, EventArgs e)
        {
            int ratacrecimientox = 0;
            int ratacrecimientoy = 0;
            ratacrecimientox = ((this.Width - 730) / 20) < 0 ? 0 : ((this.Width - 730) / 20);
            button2.Left = this.Width - 112 - ratacrecimientox;
            button3.Left = this.Width - 112 - ratacrecimientox;
            button4.Left = this.Width - 112 - ratacrecimientox;
            button5.Left = this.Width - 112 - ratacrecimientox;
            Font f = new Font(button2.Font.Name,8.25f + ratacrecimientox/6);
            Font f2 = new Font(button2.Font.Name, 12f + ratacrecimientox / 6);
            button2.Font = f;
            button3.Font = f;
            button4.Font = f;
            button5.Font = f;

            button2.Width = 76 + (int)Math.Round(ratacrecimientox * 1.7);
            button3.Width = 76 + (int)Math.Round(ratacrecimientox * 1.7);
            button4.Width = 76 + (int)Math.Round(ratacrecimientox * 1.7);
            button5.Width = 76 + (int)Math.Round(ratacrecimientox * 1.7);

            ratacrecimientoy = Convert.ToInt32((600-this.Height)/1.2);

            label7.Top = this.Height - 270 + ratacrecimientoy;
            label7.Font = f2;
            label7.Left = 242 + ratacrecimientox*10;
            label8.Top = this.Height - 246 + ratacrecimientoy;
            label8.Font = f;
            label9.Top = this.Height - 246 + ratacrecimientoy;
            label9.Font = f;
            comboBoxDepartamento.Top = this.Height - 246 + ratacrecimientoy;
            comboBoxDepartamento.Left = 112 + ratacrecimientox * 2;
            comboBoxDepartamento.Font = f;
            comboBoxCargo.Top = this.Height - 246 + ratacrecimientoy;
            comboBoxCargo.Left = this.Width - 400;
            comboBoxCargo.Font = f;
            label9.Left = comboBoxCargo.Left - 32 - ratacrecimientox*2;

            label10.Top = this.Height - 217 + ratacrecimientoy;
            label19.Top = this.Height - 217 + ratacrecimientoy;
            dateTimePicker2.Top = this.Height - 217 + ratacrecimientoy;
            dateTimePicker3.Top = this.Height - 217 + ratacrecimientoy;
            dateTimePicker3.Left = this.Width - 335 + ratacrecimientox;
            dateTimePicker3.Font = f;
            dateTimePicker3.Width = 84 + ratacrecimientox * 2;
            dateTimePicker2.Left = 112 + ratacrecimientox * 2;
            dateTimePicker2.Font = f;
            dateTimePicker2.Width = 92 + ratacrecimientox * 2;
            label19.Left = dateTimePicker3.Left - 83 - ratacrecimientox*3;
            label19.Font = f;
            label10.Font = f;

            label11.Font = f;
            comboBoxNomina.Font = f;
            comboBoxNomina.Left = 112 + ratacrecimientox * 2;
            comboBoxNomina.Width = 160 + ratacrecimientox * 2;

            label11.Top = this.Height - 191 + ratacrecimientoy;
            label12.Top = this.Height - 191 + ratacrecimientoy;
            comboBoxNomina.Top = this.Height - 191 + ratacrecimientoy;
            textBox3.Top = this.Height - 191 + ratacrecimientoy;
            button6.Top = this.Height - 191 + ratacrecimientoy;

            label20.Top = this.Height - 161 + ratacrecimientoy;
            label20.Font = f2;
            label20.Left = 231 + ratacrecimientox*10;
            dataGridView2.Top = this.Height - 138 + ratacrecimientoy;
            dataGridView2.Height = 98 - ratacrecimientoy;
            dataGridView2.Font = f;
            dataGridView2.Width = this.Width - 38;
            groupBox1.Height = 147 + (label7.Top - groupBox1.Top- 147);
            dataGridView1.Font = f;
            groupBox1.Width = this.Width - 268;
            groupBox1.Font = f;
            dataGridView1.Columns[0].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 3;

            try
            {
                dataGridView2.Columns[0].Width = 40;
                dataGridView2.Columns[1].Width = dataGridView2.Width / 4;
                dataGridView2.Columns[2].Width = dataGridView2.Width / 4;
                dataGridView2.Columns[3].Width = dataGridView2.Width / 4;
                dataGridView2.Columns[4].Width = dataGridView2.Width / 4;
            }
            catch (Exception ex) { }
            button6.Left = this.Width - 280 + ratacrecimientox * 2;
            button6.Font = f;
            button6.Width = 56 + ratacrecimientox*2;
            button6.Height = 19+ratacrecimientox/4 - ratacrecimientoy/20;
            textBox3.Left = this.Width - 355 + ratacrecimientox ;
            textBox3.Font = f;
            textBox3.Width = 76 + ratacrecimientox/3;
            label12.Left = this.Width - 435 + ratacrecimientox/20;
            label12.Font = f;

            textBox2.Width = 260 + ratacrecimientox;
            textBox2.Left = this.Width - 384 - ratacrecimientox*2 ;
            textBox2.Font = f;
            label3.Left = textBox2.Left - 59 - ratacrecimientox * 2;
            label3.Font = f;

            textBox1.Width = 218 + ratacrecimientox;
            textBox1.Left = 64 +ratacrecimientox;
            textBox1.Font = f;
            label2.Font = f;

            comboBoxEstadoCivil.Width = 92 + ratacrecimientox;
            comboBoxEstadoCivil.Left = this.Width - 218 - ratacrecimientox * 2;
            comboBoxEstadoCivil.Font = f;

            label6.Left = comboBoxEstadoCivil.Left - 61-ratacrecimientox*2;
            label6.Font = f;

            comboBoxSexo.Width = 92 + ratacrecimientox;
            comboBoxSexo.Left = this.Width - 370 - ratacrecimientox*8;
            comboBoxSexo.Font = f;

            label5.Left = comboBoxSexo.Left - 27 - ratacrecimientox ;
            label5.Font = f;

            textBox4.Left = label5.Left - 89 - ratacrecimientox*2;
            textBox4.Width = 90 + ratacrecimientox;
            textBox4.Font = f;

            label14.Left = textBox4.Left - 39 - ratacrecimientox * 2;
            label14.Font = f;

            label1.Font = f2;
            label1.Left = 242 + ratacrecimientox * 10;

            dateTimePicker1.Font = f;
            dateTimePicker1.Width = 87 + ratacrecimientox * 2;
            dateTimePicker1.Left = 117 + ratacrecimientox * 4;

            label4.Font = f;

            comboBoxEstadoTrabajador.Width = 140 + ratacrecimientox;
            comboBoxEstadoTrabajador.Left = this.Width - 264 - ratacrecimientox*2;
            comboBoxEstadoTrabajador.Font = f;

            label13.Left = comboBoxEstadoTrabajador.Left - 39 - ratacrecimientox;
            label13.Font = f;

            groupBox3.Font = f;
            groupBox3.Width = 176 + ratacrecimientox*4;
            groupBox3.Left = this.Width - 301 - ratacrecimientox*6;

            textBox6.Font = f;
            textBox6.Width = 76 + ratacrecimientox;
            textBox6.Left = 0;
            textBox7.Font = f;
            textBox7.Width = 76 + ratacrecimientox;
            textBox7.Left = 0;
            textBox8.Font = f;
            textBox8.Width = 76 + ratacrecimientox;
            textBox8.Left = groupBox3.Width - 100 - ratacrecimientox;
            textBox9.Font = f;
            textBox9.Width = 76 + ratacrecimientox;
            textBox9.Left = groupBox3.Width - 100 - ratacrecimientox;

            groupBox2.Font = f;
            groupBox2.Width = 407 + ratacrecimientox * 10;

            comboBoxEstado.Left = groupBox2.Width - 177 - ratacrecimientox;
            comboBoxEstado.Font = f;
            comboBoxEstado.Width = 128 + ratacrecimientox;

            textBox5.Left = groupBox2.Width - 177 - ratacrecimientox*6;
            textBox5.Font = f;
            textBox5.Width = 174 + ratacrecimientox*6;

            label16.Left = comboBoxEstado.Left - 40 - ratacrecimientox*2;
            label18.Left = textBox5.Left - 58 -ratacrecimientox ;

            comboBoxPais.Left = 57 + ratacrecimientox;
            comboBoxPais.Width = 119 + ratacrecimientox;

            comboBoxMunicipio.Left = 57 + ratacrecimientox;
            comboBoxMunicipio.Width = 119 + ratacrecimientox;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells["nombres"].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells["apellidos"].Value.ToString();
                try
                {
                    string[] telefonos = new string[4];
                    telefonos = dataGridView2.CurrentRow.Cells["telefonos"].Value.ToString().Split('-');
                    textBox6.Text = telefonos[0];
                    textBox7.Text = telefonos[1];
                    textBox8.Text = telefonos[2];
                    textBox9.Text = telefonos[3];
                }
                catch (Exception ex) { }
                dateTimePicker1.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells["FechaNacimiento"].Value.ToString());
                textBox4.Text = dataGridView2.CurrentRow.Cells["cedula"].Value.ToString();
                comboBoxSexo.Text = dataGridView2.CurrentRow.Cells["sexo"].Value.ToString();
                comboBoxEstadoCivil.Text = dataGridView2.CurrentRow.Cells["estadocivil"].Value.ToString();
                comboBoxPais.Text = dataGridView2.CurrentRow.Cells["pais"].Value.ToString();
                comboBoxEstado.Text = dataGridView2.CurrentRow.Cells["estado"].Value.ToString();
                comboBoxMunicipio.Text = dataGridView2.CurrentRow.Cells["municipio"].Value.ToString();
                textBox5.Text = dataGridView2.CurrentRow.Cells["direccion"].Value.ToString();
                comboBoxEstadoTrabajador.Text = dataGridView2.CurrentRow.Cells["estadotrabajador"].Value.ToString();
                comboBoxCargo.Text = dataGridView2.CurrentRow.Cells["cargo"].Value.ToString();
                comboBoxDepartamento.Text=dataGridView2.CurrentRow.Cells["departamento"].Value.ToString();
                dateTimePicker2.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells["FechaIngreso"].Value.ToString());
                dateTimePicker3.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells["FechaEgreso"].Value.ToString());
                comboBoxNomina.Text = dataGridView2.CurrentRow.Cells["nomina"].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells["salario"].Value.ToString();
                m.leerdependientes(int.Parse(dataGridView2.CurrentRow.Cells["id"].Value.ToString()), ref dataGridView1);
            }
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
