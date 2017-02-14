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

        public FichaDeEmpresa(int baseDeDatos)
        {
            InitializeComponent();
            m = new Model();
            db = baseDeDatos;
            m.seleccionarBaseDeDatos(db);
            calendar1.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar1.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar2.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar2.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar3.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar3.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar4.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar4.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar5.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar5.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar6.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar6.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar7.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar7.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar8.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar8.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar9.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar9.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar10.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar10.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar11.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar11.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
            calendar12.agregar += new Calendar.NET.Calendar.ag(agregar_feriado);
            calendar12.borrar += new Calendar.NET.Calendar.bo(borrar_feriado);
        }

        private void FichaDeEmpresa_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 1; i++)
                comboBox3.Items.Add(i);
            comboBox3.Text = DateTime.Now.Year.ToString();
            calendar1.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 1, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar1, 1);
            calendar2.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 2, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar2, 2);
            calendar3.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 3, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar3, 3);
            calendar4.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 4, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar4, 4);
            calendar5.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 5, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar5, 5);
            calendar6.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 6, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar6, 6);
            calendar7.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 7, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar7, 7);
            calendar8.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 8, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar8, 8);
            calendar9.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 9, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar9, 9);
            calendar10.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 10, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar10, 10);
            calendar11.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 11, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar11, 11);
            calendar12.CalendarDate = new DateTime(int.Parse(comboBox3.Text), 12, 1, 0, 0, 0);
            agregarNoLaborablesDelMes(calendar12, 12);

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void afectarDia(DateTime d,string dias, DayOfWeek dof,Calendar.NET.Calendar c)
        {
            if (comboBox4.Text.Equals(dias))
            {
                if (d.DayOfWeek == dof)
                {
                    var ce = new Calendar.NET.HolidayEvent();
                    ce.IgnoreTimeComponent = true;
                    ce.EventText = "No laborable";
                    ce.Date = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                    ce.RecurringFrequency = Calendar.NET.RecurringFrequencies.None;
                    ce.EventFont = new Font("Verdana", 8, FontStyle.Regular);
                    ce.Enabled = true;
                    ce.ReadOnlyEvent = false;
                    //ce.EventColor=
                    c.AddEvent(ce);
                    m.agregar_feriado(d, "No laborable");
                }
            }
        }

        private void quitarDia(DateTime d, string dias, DayOfWeek dof, Calendar.NET.Calendar c)
        {
            if (comboBox4.Text.Equals(dias))
            {
                if (d.DayOfWeek == dof)
                {
                    c.RemoveEvent(d);
                    m.borrar_feriado(d);
                }
            }
        }

        private void agregarTodosDelMes(Calendar.NET.Calendar c, int mes)
        {
            DateTime d;
            for (int i = 1; i < 32; i++)
            {
                try
                {
                    d = new DateTime(int.Parse(comboBox3.Text), mes, i);

                    afectarDia(d, "Lunes", DayOfWeek.Monday, c);
                    afectarDia(d, "Martes", DayOfWeek.Tuesday, c);
                    afectarDia(d, "Miercoles", DayOfWeek.Wednesday, c);
                    afectarDia(d, "Jueves", DayOfWeek.Thursday, c);
                    afectarDia(d, "Viernes", DayOfWeek.Friday, c);
                    afectarDia(d, "Sabados", DayOfWeek.Saturday, c);
                    afectarDia(d, "Domingos", DayOfWeek.Sunday, c);
                }
                catch (Exception ex) { }
            }
        }

        private void agregarNoLaborablesDelMes(Calendar.NET.Calendar c, int mes)
        {
            DateTime d;
            for (int i = 1; i < 32; i++)
            {
                try
                {
                    d = new DateTime(int.Parse(comboBox3.Text), mes, i);

                    if (m.existe_feriado(d))
                    {
                        m.agregar_feriado(d, "No laborable");
                        var ce = new Calendar.NET.HolidayEvent();
                        ce.IgnoreTimeComponent = true;
                        ce.EventText = "No laborable";
                        ce.Date = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                        ce.RecurringFrequency = Calendar.NET.RecurringFrequencies.None;
                        ce.EventFont = new Font("Verdana", 8, FontStyle.Regular);
                        ce.Enabled = true;
                        ce.ReadOnlyEvent = false;
                        //ce.EventColor=
                        c.AddEvent(ce);
                    }
                    
                }
                catch (Exception ex) { }
            }
        }

        private void quitarTodosDelMes(Calendar.NET.Calendar c, int mes)
        {
            DateTime d;
            for (int i = 1; i < 32; i++)
            {
                try
                {
                    d = new DateTime(int.Parse(comboBox3.Text), mes, i);

                    quitarDia(d, "Lunes", DayOfWeek.Monday, c);
                    quitarDia(d, "Martes", DayOfWeek.Tuesday, c);
                    quitarDia(d, "Miercoles", DayOfWeek.Wednesday, c);
                    quitarDia(d, "Jueves", DayOfWeek.Thursday, c);
                    quitarDia(d, "Viernes", DayOfWeek.Friday, c);
                    quitarDia(d, "Sabados", DayOfWeek.Saturday, c);
                    quitarDia(d, "Domingos", DayOfWeek.Sunday, c);
                }
                catch (Exception ex) { }
            }
        }

        private void noLaborable_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            comboBox4.Visible = true;
            
            calendar1.setLaborable(!(noLaborable.Checked));
            calendar2.setLaborable(!(noLaborable.Checked));
            calendar3.setLaborable(!(noLaborable.Checked));
            calendar4.setLaborable(!(noLaborable.Checked));
            calendar5.setLaborable(!(noLaborable.Checked));
            calendar6.setLaborable(!(noLaborable.Checked));
            calendar7.setLaborable(!(noLaborable.Checked));
            calendar8.setLaborable(!(noLaborable.Checked));
            calendar9.setLaborable(!(noLaborable.Checked));
            calendar10.setLaborable(!(noLaborable.Checked));
            calendar11.setLaborable(!(noLaborable.Checked));
            calendar12.setLaborable(!(noLaborable.Checked));

            if (comboBox4.Text.Length > 0)
            {
                agregarTodosDelMes(calendar1, 1);
                agregarTodosDelMes(calendar2, 2);
                agregarTodosDelMes(calendar3, 3);
                agregarTodosDelMes(calendar4, 4);
                agregarTodosDelMes(calendar5, 5);
                agregarTodosDelMes(calendar6, 6);
                agregarTodosDelMes(calendar7, 7);
                agregarTodosDelMes(calendar8, 8);
                agregarTodosDelMes(calendar9, 9);
                agregarTodosDelMes(calendar10, 10);
                agregarTodosDelMes(calendar11, 11);
                agregarTodosDelMes(calendar12, 12);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Length > 0)
            {
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
        }

        private void Laborable_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            comboBox4.Visible = true;
            calendar1.setLaborable(!(noLaborable.Checked));
            calendar2.setLaborable(!(noLaborable.Checked));
            calendar3.setLaborable(!(noLaborable.Checked));
            calendar4.setLaborable(!(noLaborable.Checked));
            calendar5.setLaborable(!(noLaborable.Checked));
            calendar6.setLaborable(!(noLaborable.Checked));
            calendar7.setLaborable(!(noLaborable.Checked));
            calendar8.setLaborable(!(noLaborable.Checked));
            calendar9.setLaborable(!(noLaborable.Checked));
            calendar10.setLaborable(!(noLaborable.Checked));
            calendar11.setLaborable(!(noLaborable.Checked));
            calendar12.setLaborable(!(noLaborable.Checked));

            if (comboBox4.Text.Length > 0)
            {
                quitarTodosDelMes(calendar1, 1);
                quitarTodosDelMes(calendar2, 2);
                quitarTodosDelMes(calendar3, 3);
                quitarTodosDelMes(calendar4, 4);
                quitarTodosDelMes(calendar5, 5);
                quitarTodosDelMes(calendar6, 6);
                quitarTodosDelMes(calendar7, 7);
                quitarTodosDelMes(calendar8, 8);
                quitarTodosDelMes(calendar9, 9);
                quitarTodosDelMes(calendar10, 10);
                quitarTodosDelMes(calendar11, 11);
                quitarTodosDelMes(calendar12, 12);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Laborable.Checked)
            {
                quitarTodosDelMes(calendar1, 1);
                quitarTodosDelMes(calendar2, 2);
                quitarTodosDelMes(calendar3, 3);
                quitarTodosDelMes(calendar4, 4);
                quitarTodosDelMes(calendar5, 5);
                quitarTodosDelMes(calendar6, 6);
                quitarTodosDelMes(calendar7, 7);
                quitarTodosDelMes(calendar8, 8);
                quitarTodosDelMes(calendar9, 9);
                quitarTodosDelMes(calendar10, 10);
                quitarTodosDelMes(calendar11, 11);
                quitarTodosDelMes(calendar12, 12);
            }
            if (noLaborable.Checked)
            {
                agregarTodosDelMes(calendar1, 1);
                agregarTodosDelMes(calendar2, 2);
                agregarTodosDelMes(calendar3, 3);
                agregarTodosDelMes(calendar4, 4);
                agregarTodosDelMes(calendar5, 5);
                agregarTodosDelMes(calendar6, 6);
                agregarTodosDelMes(calendar7, 7);
                agregarTodosDelMes(calendar8, 8);
                agregarTodosDelMes(calendar9, 9);
                agregarTodosDelMes(calendar10, 10);
                agregarTodosDelMes(calendar11, 11);
                agregarTodosDelMes(calendar12, 12);
            }
        }

        private void agregar_feriado(DateTime d)
        {
            m.agregar_feriado(d, "No laborable");
        }
        private void borrar_feriado(DateTime d)
        {
            m.borrar_feriado(d);
        }
    }
}
