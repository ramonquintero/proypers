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
    public partial class FichaDeEmpresa : Form
    {
        Model m;
        int db;
        bool estado_agregado = false;
        public FichaDeEmpresa(int baseDeDatos)
        {
            InitializeComponent();
            m = new Model();
            db = baseDeDatos;
            m.seleccionarBaseDeDatos(db);
        }

        private void FichaDeEmpresa_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 1; i++)
                comboBox3.Items.Add(i);
            comboBox3.Text = DateTime.Now.Year.ToString();
            calendar1.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 1, 1, 0, 0, 0);
            calendar2.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 2, 1, 0, 0, 0);
            calendar3.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 3, 1, 0, 0, 0);
            calendar4.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 4, 1, 0, 0, 0);
            calendar5.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 5, 1, 0, 0, 0);
            calendar6.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 6, 1, 0, 0, 0);
            calendar7.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 7, 1, 0, 0, 0);
            calendar8.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 8, 1, 0, 0, 0);
            calendar9.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 9, 1, 0, 0, 0);
            calendar10.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 10, 1, 0, 0, 0);
            calendar11.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 11, 1, 0, 0, 0);
            calendar12.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 12, 1, 0, 0, 0);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void noLaborable_CheckedChanged(object sender, EventArgs e)
        {
            calendar1.setLaborable(!(noLaborable.Checked));
        }
    }
}
