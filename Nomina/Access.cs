using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    class Access : BaseDeDatos
    {
        public string stringdeconexion = "";

        public Access()
        {
            stringdeconexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Data\\Nomina.accdb";
            
        }
        public Access(string path)
        {
            stringdeconexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "\\Nomina.accdb";
        }

        public bool inicializarBaseDeDatos()
        {
            bool res = true;

            return res;
        }

        #region menu

        public void insert_menu(int id_menu, int id_perfil)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "insert into opciones-menu ";
            sql += " (descripcion,accion) values (";
            sql += id_perfil.ToString() + ", " + id_menu.ToString() + ")";

            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public string[][] obtener_menu(ref MenuStrip mnu)
        {
            string[][] res = new string[1][];

            return res;
        }
        private string[][] obtener_sub_menu(string menu)
        {
            string[][] res = new string[1][];

            return res;
        }

        #endregion menu

        #region sexo

        public void llenarGridSexo(ref DataGridView grid)
        {
            DataTable dt;
            
            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string    sql = "select id,descripcion from sexo ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboSexo(ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from sexo  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {
                
                control.Items.Add(new ComboboxItem((string)linea["descripcion"],(int)linea["id"]));
                Application.DoEvents();
            }
        }

        public bool existe_sexo(string sexo)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            int i = 0;

            string sql = "SELECT descripcion ";
            sql += "FROM sexo ";
            sql += "WHERE descripcion='"+sexo+"'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_sexo(string sexo)
        {
            if (!existe_sexo(sexo))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO sexo ";
                sql += " (descripcion) VALUES ('";
                sql += sexo + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        public void eliminar_sexo(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM sexo ";
            sql += " WHERE id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }
        public void actualizar_sexo(int idx,string sexo)
        {
            if (!existe_sexo(sexo))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE sexo SET descripcion='" + sexo + "'";
                sql += " WHERE id=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
#endregion sexo

        #region estadocivil

        public void llenarGridEstadoCivil(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select id,descripcion from EstadoCivil ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboEstadoCivil(ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from EstadoCivil  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));
                Application.DoEvents();
            }
        }

        public bool existe_EstadoCivil(string EstadoCivil)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            int i = 0;

            string sql = "SELECT descripcion ";
            sql += "FROM EstadoCivil ";
            sql += "WHERE descripcion='" + EstadoCivil + "'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_EstadoCivil(string EstadoCivil)
        {
            if (!existe_EstadoCivil(EstadoCivil))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO EstadoCivil ";
                sql += " (descripcion) VALUES ('";
                sql += EstadoCivil + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        public void eliminar_EstadoCivil(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM EstadoCivil ";
            sql += " WHERE id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }
        public void actualizar_EstadoCivil(int idx, string EstadoCivil)
        {
            if (!existe_EstadoCivil(EstadoCivil))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE EstadoCivil SET descripcion='" + EstadoCivil + "'";
                sql += " WHERE id=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        #endregion estadocivil

        #region pais

        public void llenarGridPais(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select IDpais,descripcion from Pais ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboPais(ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select IDpais,descripcion from Pais  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["IDpais"]));
                Application.DoEvents();
            }
        }

        public void llenarComboPais(ref DataGridViewComboBoxColumn control)
        {
            DataSet oDs;
            control.Items.Clear();
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select IDpais,descripcion from Pais ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {
                /*control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));*/
                control.Items.Add((string)linea["descripcion"]);
                Application.DoEvents();
            }
        }

        public bool existe_Pais(string Pais)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            string sql = "SELECT descripcion ";
            sql += "FROM Pais ";
            sql += "WHERE descripcion='" + Pais + "'";

            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_Pais(string Pais)
        {
            if (!existe_Pais(Pais))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO Pais ";
                sql += " (descripcion) VALUES ('";
                sql += Pais + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        public void eliminar_Pais(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM Pais ";
            sql += " WHERE IDpais=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }

        public void actualizar_Pais(int idx, string Pais)
        {
            if (!existe_Pais(Pais))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE Pais SET descripcion='" + Pais + "'";
                sql += " WHERE IDpais=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        #endregion pais

        #region estado

        public void llenarGridEstado(ref DataGridView grid, int paisseleccionado)
        {
            DataTable dt;
            
            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            //string sql = "select Pais.IDpais as idpais,Pais.Descripcion as descpais,Estado.IdEstado as idestado,Estado.descripcion as descestado from Pais,Estado ";
            string sql = "select Estado.IdEstado as idestado,Estado.descripcion as descestado from Pais,Estado ";
            sql += " WHERE Pais.IDpais = Estado.IDPais ";
            if (paisseleccionado != -1)
                sql += "AND Estado.IDPais=" + paisseleccionado.ToString();
            sql+= " order by Estado.Descripcion";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            con1.Close();
            /*DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn columnN = new DataGridViewTextBoxColumn();
            /*DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn();*/
            //DataGridViewTextBoxColumn columnN2 = new DataGridViewTextBoxColumn();
            /*grid.ColumnCount = 1;
            grid.Columns[0].Name = "IdPais";
            llenarComboPais(ref column);
            grid.Columns.Add(column);
            grid.Columns[1].Name = "Pais";*/
            /*grid.Columns.Add(columnN);
            grid.Columns[0].Name = "IdEstado";
            grid.Columns.Add(columnN2);
            grid.Columns[1].Name = "Estado";

            foreach (DataRow linea in dt.Rows)
            {
                /*DataGridViewRow fila = new DataGridViewRow();*/
              //  string[] fila = new string[4];
                /*fila[0] = ((int)linea["IdPais"]).ToString();
                fila[1] = (string)linea["descpais"];*/
                /*fila[0] = ((int)linea["IdEstado"]).ToString();
                fila[1] = (string)linea["descestado"];
                grid.Rows.Add(fila);
                Application.DoEvents();
            }*/
            

            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
            //grid.Columns[1].ReadOnly = true;
            //grid.Columns[2].ReadOnly = true;
        }

        public void llenarComboEstado(int pais,ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select Estado.IdEstado as idestado,Estado.descripcion as descestado from Pais,Estado where Pais.IDPais = Estado.IDPais and Estado.IDpais="+pais.ToString(), oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descestado"], (int)linea["IDestado"]));
                Application.DoEvents();
            }
        }

        public void llenarComboEstado(int pais, ref DataGridViewComboBoxColumn control)
        {
            DataSet oDs;
            control.Items.Clear();
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select Estado.IdEstado as idestado,Estado.descripcion as descestado from Pais,Estado where Pais.IDPais = Estado.IDPais and Estado.IDpais=" + pais.ToString(), oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {
                /*control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));*/
                control.Items.Add((string)linea["descestado"]);
                Application.DoEvents();
            }
        }

        public bool existe_Estado(int idpais,string Estado)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            string sql = "SELECT descripcion ";
            sql += "FROM Estado ";
            sql += "WHERE descripcion='" + Estado + "'";
            sql += " AND IDPais=" + idpais.ToString();

            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_Estado(int idpais,string Estado)
        {
            if (!existe_Estado(idpais,Estado))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO Estado ";
                sql += " (IDPais,descripcion) VALUES ("+idpais.ToString()+",'";
                sql += Estado + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        public void eliminar_Estado(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM Estado ";
            sql += " WHERE IDEstado=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }

        public void actualizar_Estado(int idpais, int idestado, string Estado)
        {
            if (!existe_Estado(idpais, Estado))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE Estado SET descripcion='" + Estado + "'";
                sql += " WHERE IDPais=" + idpais.ToString();
                sql += "AND IDEstado=" + idestado.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        #endregion estado

        #region municipio

        public void llenarGridMunicipio(ref DataGridView grid, int estado)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select Municipio.Id as idmunicipio,Municipio.descripcion as descmunicipio from Estado,Municipio ";
            sql += " WHERE Estado.IDEstado ="+estado.ToString()+" AND Estado.IDEstado = Municipio.IDEstado";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
            
        }

        public void llenarComboMunicipio(int estado, ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select Municipio.Id as idmunicipio,Municipio.descripcion as descmunicipio from Estado,Municipio where Estado.IDEstado = Municipio.IDEstado and Municipio.IDEstado=" + estado.ToString(), oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descmunicipio"], (int)linea["idmunicipio"]));
                Application.DoEvents();
            }
        }

        public void llenarComboMunicipio(int estado, ref DataGridViewComboBoxColumn control)
        {
            DataSet oDs;
            control.Items.Clear();
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select Municipio.Id as idmunicipio,Municipio.descripcion as descmunicipio from Estado,Municipio where Estado.IDEstado = Municipio.IDEstado and Municipio.IDEstado=" + estado.ToString(), oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {
                /*control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));*/
                control.Items.Add((string)linea["descmunicipio"]);
                Application.DoEvents();
            }
        }

        public bool existe_Municipio(int idestado, string Municipio)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            string sql = "SELECT descripcion ";
            sql += "FROM Municipio ";
            sql += "WHERE descripcion='" + Municipio + "'";
            sql += " AND IDEstado=" + idestado.ToString();

            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_Municipio(int idestado, string Municipio)
        {
            if (!existe_Municipio(idestado, Municipio))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO Municipio ";
                sql += " (IDEstado,descripcion) VALUES (" + idestado.ToString() + ",'";
                sql += Municipio + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        public void eliminar_Municipio(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM Municipio ";
            sql += " WHERE Id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }

        public void actualizar_Municipio(int idestado, int idmunicipio, string Municipio)
        {
            if (!existe_Municipio(idestado, Municipio))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE Municipio SET descripcion='" + Municipio + "'";
                sql += " WHERE IDEstado=" + idestado.ToString();
                sql += "AND Id=" + idmunicipio.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        #endregion municipio

        #region cargo

        public void llenarGridCargo(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select id,descripcion from Cargo ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboCargo(ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from Cargo  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));
                Application.DoEvents();
            }
        }

        public bool existe_Cargo(string Cargo)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            int i = 0;

            string sql = "SELECT descripcion ";
            sql += "FROM Cargo ";
            sql += "WHERE descripcion='" + Cargo + "'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_Cargo(string Cargo)
        {
            if (!existe_Cargo(Cargo))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO Cargo ";
                sql += " (descripcion) VALUES ('";
                sql += Cargo + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        public void eliminar_Cargo(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM Cargo ";
            sql += " WHERE id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }
        public void actualizar_Cargo(int idx, string Cargo)
        {
            if (!existe_Cargo(Cargo))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE Cargo SET descripcion='" + Cargo + "'";
                sql += " WHERE id=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        #endregion cargo

        #region departamento

        public void llenarGridDepartamento(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select id,descripcion from Departamento ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboDepartamento(ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from Departamento  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));
                Application.DoEvents();
            }
        }

        public bool existe_Departamento(string Departamento)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            int i = 0;

            string sql = "SELECT descripcion ";
            sql += "FROM Departamento ";
            sql += "WHERE descripcion='" + Departamento + "'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_Departamento(string Departamento)
        {
            if (!existe_Departamento(Departamento))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO Departamento ";
                sql += " (descripcion) VALUES ('";
                sql += Departamento + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        public void eliminar_Departamento(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM Departamento ";
            sql += " WHERE id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }

        public void actualizar_Departamento(int idx, string Departamento)
        {
            if (!existe_Departamento(Departamento))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE Departamento SET descripcion='" + Departamento + "'";
                sql += " WHERE id=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        #endregion departamento

        #region tiposnomina

        public void llenarGridTiposNomina(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select id,descripcion from Nomina ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboTiposNomina(ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from Nomina  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));
                Application.DoEvents();
            }
        }

        public bool existe_TiposNomina(string TiposNomina)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            int i = 0;

            string sql = "SELECT descripcion ";
            sql += "FROM Nomina ";
            sql += "WHERE descripcion='" + TiposNomina + "'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_TiposNomina(string TiposNomina)
        {
            if (!existe_TiposNomina(TiposNomina))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO Nomina ";
                sql += " (descripcion) VALUES ('";
                sql += TiposNomina + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        public void eliminar_TiposNomina(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM Nomina ";
            sql += " WHERE id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }

        public void actualizar_TiposNomina(int idx, string TiposNomina)
        {
            if (!existe_TiposNomina(TiposNomina))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE Nomina SET descripcion='" + TiposNomina + "'";
                sql += " WHERE id=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        #endregion tiposnomina

        #region estadotrabajador

        public void llenarGridEstadoTrabajador(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select id,descripcion from EstadoTrabajador ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboEstadoTrabajador(ref ComboBox control)
        {

            DataSet oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from EstadoTrabajador  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();

            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));
                Application.DoEvents();
            }
        }

        public bool existe_EstadoTrabajador(string EstadoTrabajador)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            int i = 0;

            string sql = "SELECT descripcion ";
            sql += "FROM EstadoTrabajador ";
            sql += "WHERE descripcion='" + EstadoTrabajador + "'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_EstadoTrabajador(string EstadoTrabajador)
        {
            if (!existe_EstadoTrabajador(EstadoTrabajador))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO EstadoTrabajador ";
                sql += " (descripcion) VALUES ('";
                sql += EstadoTrabajador + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        public void eliminar_EstadoTrabajador(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM EstadoTrabajador ";
            sql += " WHERE id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }

        public void actualizar_EstadoTrabajador(int idx, string EstadoTrabajador)
        {
            if (!existe_EstadoTrabajador(EstadoTrabajador))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE EstadoTrabajador SET descripcion='" + EstadoTrabajador + "'";
                sql += " WHERE id=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        #endregion estadotrabajador

        #region parentesco

        public void llenarGridParentesco(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "select id,descripcion from Parentesco ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void llenarComboParentesco(ref ComboBox control)
        {

            DataSet oDs;
            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from Parentesco  ", oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            
            
            foreach (DataRow linea in oDs.Tables[0].Rows)
            {

                control.Items.Add(new ComboboxItem((string)linea["descripcion"], (int)linea["id"]));
                Application.DoEvents();
            }
        }

        public void llenarComboParentesco(ref DataGridViewComboBoxColumn control)
        {
            DataTable oDs;

            control.Items.Clear();

            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            OleDbDataAdapter oCmd = new OleDbDataAdapter("select id,descripcion from Parentesco  ", oConn);
            oConn.Open();
            oDs = new DataTable();
            oCmd.Fill(oDs);
            oConn.Close();

            control.DataSource = oDs;
            control.ValueMember = "id";
            control.DisplayMember = "descripcion";
        }

        public bool existe_Parentesco(string Parentesco)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            int i = 0;

            string sql = "SELECT descripcion ";
            sql += "FROM Parentesco ";
            sql += "WHERE descripcion='" + Parentesco + "'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_Parentesco(string Parentesco)
        {
            if (!existe_Parentesco(Parentesco))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "INSERT INTO Parentesco ";
                sql += " (descripcion) VALUES ('";
                sql += Parentesco + "')";
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }

        public void eliminar_Parentesco(int idx)
        {
            OleDbConnection conn;
            conn = new OleDbConnection(stringdeconexion);
            conn.Open();
            String sql;

            sql = "DELETE FROM Parentesco ";
            sql += " WHERE id=";
            sql += idx.ToString();
            Application.DoEvents();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Application.DoEvents();
            }
            conn.Close();
        }

        public void actualizar_Parentesco(int idx, string Parentesco)
        {
            if (!existe_Parentesco(Parentesco))
            {
                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;

                sql = "UPDATE Parentesco SET descripcion='" + Parentesco + "'";
                sql += " WHERE id=" + idx.ToString();
                Application.DoEvents();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    Application.DoEvents();
                }
                conn.Close();
            }
        }
        #endregion parentesco

        #region fichadeltrabajador

        public void listadetrabajadores(ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "SELECT FichaTrabajador.id,FichaTrabajador.cedula,FichaTrabajador.nombres,FichaTrabajador.apellidos,FichaTrabajador.Telefonos, ";
            sql += "FichaTrabajador.FechaNacimiento,Sexo.descripcion as sexo,Municipio.Descripcion as municipio,Estado.Descripcion as estado, Pais.Descripcion as pais,";
            sql += "FichaTrabajador.Direccion,EstadoCivil.descripcion as estadocivil, Cargo.descripcion as cargo,Departamento.descripcion as departamento, FichaTrabajador.Salario, ";
            sql += "Nomina.descripcion as nomina, FichaTrabajador.FechaIngreso, EstadoTrabajador.Descripcion as estadotrabajador, FichaTrabajador.FechaEgreso ";
            sql += "FROM FichaTrabajador,Sexo,Municipio,Estado,Pais,EstadoCivil,Cargo,Departamento,Nomina,EstadoTrabajador WHERE ";
            sql += " FichaTrabajador.Sexo = Sexo.id AND ";
            sql += " FichaTrabajador.Municipio = Municipio.id AND ";
            sql += " FichaTrabajador.EdoProvincia = Estado.IDEstado AND ";
            sql += " FichaTrabajador.Pais = Pais.IDpais AND ";
            sql += " FichaTrabajador.EstadoCivil = EstadoCivil.id AND ";
            sql += " FichaTrabajador.Cargo = Cargo.id AND ";
            sql += " FichaTrabajador.Departamento = Departamento.id AND ";
            sql += " FichaTrabajador.Nomina = Nomina.id AND ";
            sql += " FichaTrabajador.Estado = EstadoTrabajador.id; ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;
        }

        public void leerdependientes(int idtrabajador, ref DataGridView grid)
        {
            DataTable dt;

            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection(stringdeconexion);

            dt = new DataTable();
            string sql = "SELECT Dependientes.id,Dependientes.NombreYApellido as Nombre, Dependientes.FechaNacimiento, Parentesco.Descripcion ";
            sql += "FROM Dependientes, Parentesco, [Trabajador-Dependientes] WHERE ";
            sql += " [Trabajador-Dependientes].idFichaTrabajador = "+idtrabajador.ToString()+" AND ";
            sql += " Dependientes.id = [Trabajador-Dependientes].idDependientes AND ";
            sql += " Parentesco.id = Dependientes.Parentesco; ";
            Application.DoEvents();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con1);
            Application.DoEvents();
            da.Fill(dt);
            grid.Columns.Clear();
            grid.DataSource = dt;
            grid.Columns[0].ReadOnly = true;

        }

        public bool existe_Ficha(string cedula)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);
            
            string sql = "SELECT sexo ";
            sql += "FROM FichaTrabajador ";
            sql += "WHERE cedula='" + cedula + "'";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_Ficha_del_trabajador(string nombre, string apellido, string fnac,
            string cedula, int sexo, int edocivil, string telefonos, int pais, int estado, int municipio,
            string direccion, int statustrabajador, int departamento, int cargo, string fingreso,
            string fegreso, int tiponomina, string salario, DataGridView dt)
        {
            if (!existe_Ficha(cedula))
            {
                OleDbConnection conn;
                DataSet oDs;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;
                int id = 0;


                sql = "INSERT INTO FichaTrabajador ";
                sql += " (Nombres,Apellidos,cedula,FechaNacimiento,";
                sql += "Telefonos,Sexo,Municipio,EdoProvincia,Pais,";
                sql += "Direccion,EstadoCivil,Cargo,Departamento,Salario,";
                sql += "Nomina, FechaIngreso,Estado,FechaEgreso) VALUES ('";
                sql += nombre + "','"+apellido+"','"+cedula+"','"+fnac+"'";
                sql += ",'" + telefonos + "'," + sexo.ToString();
                sql += "," + municipio.ToString() + "," + estado.ToString() + "," + pais.ToString();
                sql += ",'"+direccion+"'," + edocivil.ToString() + ","+cargo.ToString()+","+departamento.ToString();
                sql += ",'"+salario+"',"+tiponomina.ToString()+",'"+fingreso+"',"+statustrabajador.ToString()+",'"+fegreso+"')";
                Application.DoEvents();
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Application.DoEvents();
                    }
                    conn.Close();
                    sql = "SELECT id FROM fichatrabajador ";
                    sql += " WHERE Cedula = '" + cedula + "' ";
                    /*sql += " ORDER BY fichatrabajador.id desc ";*/
                    OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, conn);
                    conn.Open();
                    oDs = new DataSet();
                    oCmd.Fill(oDs);
                    conn.Close();
                    Application.DoEvents();
                    id = int.Parse(oDs.Tables[0].Rows[0]["id"].ToString());
                    string dependiente="";
                    int parentesco=0;
                    string fecha;
                    int[] idsdependientes = new int[dt.RowCount-1];
                    int filas = 0;
                    for (filas = 0; filas < dt.RowCount-1; filas++)
                    {
                        dependiente = dt.Rows[filas].Cells[0].Value.ToString();
                        parentesco = (int)dt.Rows[filas].Cells[1].Value;
                        fecha = dt.Rows[filas].Cells[2].Value.ToString();
                        sql = "INSERT INTO Dependientes ";
                        sql += " (NombreYApellido,Parentesco,FechaNacimiento)";
                        sql += " VALUES (";
                        sql += "'" + dependiente + "'," + parentesco.ToString() + ",'" + fecha + "')";
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                            Application.DoEvents();
                        }
                        conn.Close();
                        sql = "SELECT id FROM Dependientes ";
                        sql += " WHERE Dependientes.NombreYApellido = '" + dependiente + "' ";
                        sql += " ORDER BY Dependientes.id desc ";
                        conn.Open();
                        oCmd = new OleDbDataAdapter(sql, conn);
                        oDs = new DataSet();
                        oCmd.Fill(oDs);
                        conn.Close();
                        Application.DoEvents();
                        idsdependientes[filas] = int.Parse(oDs.Tables[0].Rows[0]["id"].ToString());
                    }
                    //agregamos la relacion entre trabajador y dependientes
                    for (int i = 0; i < filas; i++)
                    {
                        sql = "INSERT INTO [Trabajador-Dependientes] ";
                        sql += " (IdFichaTrabajador,IdDependientes)";
                        sql += " VALUES (";
                        sql += id.ToString() + "," + idsdependientes[i].ToString() + ")";
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                            Application.DoEvents();
                        }
                        conn.Close();
                    }
                } catch(Exception ex)
                    {
                    }
                conn.Close();
            }
        }

        #endregion fichadeltrabajador

        #region calendario

        public bool existe_feriado(DateTime fecha)
        {
            bool res = false;
            DataSet oDs;
            OleDbConnection oConn =
                    new System.Data.OleDb.OleDbConnection(stringdeconexion);

            string sql = "SELECT dia ";
            sql += "FROM Calendario ";
            sql += "WHERE dia=#" + fecha.Year.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Day.ToString() + "#";


            OleDbDataAdapter oCmd = new OleDbDataAdapter(sql, oConn);
            oConn.Open();
            oDs = new DataSet();
            oCmd.Fill(oDs);
            oConn.Close();
            Application.DoEvents();
            res = (oDs.Tables[0].Rows.Count > 0);

            return res;
        }

        public void agregar_feriado(DateTime fecha, string descripcion)
        {
            if (!existe_feriado(fecha))
            {

                OleDbConnection conn;
                DataSet oDs;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;
                int id = 0;


                sql = "INSERT INTO calendario ";
                sql += " (dia,descripcion) VALUES (#";
                sql += fecha.Year.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Day.ToString() + "#,'"+descripcion+"')";
                Application.DoEvents();
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Application.DoEvents();
                    }
                    conn.Close();
                }
                catch (Exception ex) { }
            }
        }

        public void borrar_feriado(DateTime fecha)
        {
            if (existe_feriado(fecha))
            {

                OleDbConnection conn;
                conn = new OleDbConnection(stringdeconexion);
                conn.Open();
                String sql;
                
                sql = "DELETE FROM calendario ";
                sql += " WHERE dia= #";
                sql += fecha.Year.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Day.ToString() + "# ";
                Application.DoEvents();
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Application.DoEvents();
                    }
                    conn.Close();
                }
                catch (Exception ex) { }
            }
        }

        #endregion calendario

    }
}
