using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Form1 : Form
    {
        int baseDeDatos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar_menu("");//idioma por defecto: español venezuela
            baseDeDatos = 0;
            
        }
        private void cargar_menu(String idioma)
        {
            ToolStripMenuItem[] mnuOpcion;
            ToolStripMenuItem mnuSubOpcion;
            mnuOpcion = new ToolStripMenuItem[100];
            int i = 0;
            menuStrip1.Items.Clear();
            
            ResXResourceReader rsxr = new ResXResourceReader(".\\RecursosLocalizables\\StringResources"+idioma+".resx");
            foreach (DictionaryEntry d in rsxr)
            {
                i = int.Parse(d.Key.ToString().Substring(4, 1));
                if (d.Key.ToString().Contains("main"))
                {
                    mnuOpcion[i] = new ToolStripMenuItem(d.Value.ToString());
                    mnuOpcion[i].Tag = d.Key.ToString();
                    menuStrip1.Items.Add(mnuOpcion[i]);
                }
                if (d.Key.ToString().Contains("sub_"))
                {
                    mnuSubOpcion = new ToolStripMenuItem(d.Value.ToString());
                    mnuSubOpcion.Tag = d.Key.ToString();
                    mnuSubOpcion.Click += menuStrip1_Click;
                    mnuOpcion[i].DropDownItems.Add(mnuSubOpcion);
                }
                if (d.Key.ToString().Contains("titu1"))
                {
                    this.Text = d.Value.ToString();
                }
            }
            rsxr.Close();
        }
        private void menuStrip1_Click(object sender, EventArgs e)
        {
            String eleccion = sender.ToString();
            //MenuStrip menu = sender as MenuStrip;
            if (eleccion.Equals("&Ficha del trabajador"))
            {
                FichaDelTrabajador form = new FichaDelTrabajador(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("F&icha de Empresa"))
            {
                FichaDeEmpresa form = new FichaDeEmpresa(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Periodo"))
            {
                Periodo form = new Periodo();
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Asistencias"))
            {
                Asistencias form = new Asistencias();
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Sexo"))
            {
                Sexo form = new Sexo(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Estado Civil"))
            {
                EstadoCivil form = new EstadoCivil(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Parentesco"))
            {
                Parentesco form = new Parentesco(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Cargo"))
            {
                Cargo form = new Cargo(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Departamento"))
            {
                Departamento form = new Departamento(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Tipos de nomina"))
            {
                TiposNomina form = new TiposNomina(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("Estad&o del trabajador"))
            {
                EstadoTrabajador form = new EstadoTrabajador(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("P&aises"))
            {
                Paises form = new Paises(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("Estados/Depa&rtamentos/Provincias"))
            {
                Estados form = new Estados(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("&Municipios"))
            {
                Municipios form = new Municipios(baseDeDatos);
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("C&oncepto"))
            {
                Concepto form = new Concepto();
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("Concepto por &trabajador"))
            {
                ConceptoAsociado form = new ConceptoAsociado();
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("Co&ncepto por periodo"))
            {
                ConceptoAsociado form = new ConceptoAsociado();
                form.MdiParent = this;
                form.Show();
            }
            if (eleccion.Equals("Concepto por t&ipo de nomina"))
            {
                ConceptoAsociado form = new ConceptoAsociado();
                form.MdiParent = this;
                form.Show();
            }
        }
    }
}
