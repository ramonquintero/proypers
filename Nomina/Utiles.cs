using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    class Utiles
    {
        public void afectar_controles(Form f, bool borrar, bool inhabilitar)
        {
            foreach (Control c in f.Controls)
            {
                try
                {
                    if ((c is TextBox) || (c is ComboBox))
                        c.Text = "";
                    if (c is DateTimePicker)
                    {
                        ((DateTimePicker)c).Format = DateTimePickerFormat.Custom;
                        ((DateTimePicker)c).CustomFormat = "    ";
                    }
                    /*if (c is DataGridView)
                    {
                        ((DataGridView)c).DataBindings.Clear();
                    }*/
                    if (c is GroupBox)
                    {
                        afectar_controles(c, borrar, inhabilitar);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void afectar_controles(Control cl, bool borrar, bool inhabilitar)
        {
            foreach (Control c in cl.Controls)
            {
                try
                {
                    if ((c is TextBox) || (c is ComboBox))
                        c.Text = "";
                    if (c is DateTimePicker)
                    {
                        ((DateTimePicker)c).Format = DateTimePickerFormat.Custom;
                        ((DateTimePicker)c).CustomFormat = "    ";
                    }
                    /*if (c is DataGridView)
                    {
                        ((DataGridView)c).DataBindings.Clear();
                    }*/
                    if (c is GroupBox)
                    {
                        afectar_controles(c, borrar, inhabilitar);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        /*internal void afectar_controles(ref FichaDelTrabajador fichaDelTrabajador, bool p1, bool p2)
        {
            try
            {
                if ((c is TextBox) || (c is ComboBox))
                    c.Text = "";
                if (c is DateTimePicker)
                {
                    ((DateTimePicker)c).Format = DateTimePickerFormat.Custom;
                    ((DateTimePicker)c).CustomFormat = "    ";
                }
                /*if (c is DataGridView)
                {
                    ((DataGridView)c).DataBindings.Clear();
                }*/
           /*     if (c is GroupBox)
                {
                    afectar_controles(c, borrar, inhabilitar);
                }
            }
            catch (Exception ex)
            {
            }
        }*/
    }
}
