using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    class Model
    {
        private String[] dataBaseList = { "Access" };
        private int baseDeDatos;
        BaseDeDatos db;
        public void seleccionarBaseDeDatos(int idx)
        {
            baseDeDatos = idx;
            switch (idx)
            {
                case 0:     db = new Access();
                            break;
                default:    db = new Access();
                            break;
            }

        }
        public void listaDeBasesDeDatos(ref DataGridView d)
        {

        }
        #region sexo
        public void llenarGridSexo( ref DataGridView d)
        {
            db.llenarGridSexo(ref d);
        }
        public void llenarComboSexo(ref ComboBox d)
        {
            db.llenarComboSexo(ref d);
        }
        public void guardarSexo(string sexo)
        {
            db.agregar_sexo(sexo);
        }
        public void cambiarSexo(int idx,string sexo)
        {
            db.actualizar_sexo(idx,sexo);
        }
        public void borrarSexo(int idx)
        {
            db.eliminar_sexo(idx);
        }
#endregion sexo;

        #region estadocivil
        public void llenarGridEstadoCivil(ref DataGridView d)
        {
            db.llenarGridEstadoCivil(ref d);
        }
        public void llenarComboEstadoCivil(ref ComboBox d)
        {
            db.llenarComboEstadoCivil(ref d);
        }
        public void guardarEstadoCivil(string EstadoCivil)
        {
            db.agregar_EstadoCivil(EstadoCivil);
        }
        public void cambiarEstadoCivil(int idx, string EstadoCivil)
        {
            db.actualizar_EstadoCivil(idx, EstadoCivil);
        }
        public void borrarEstadoCivil(int idx)
        {
            db.eliminar_EstadoCivil(idx);
        }
        #endregion estadocivil

        #region cargo
        public void llenarGridCargo(ref DataGridView d)
        {
            db.llenarGridCargo(ref d);
        }
        public void llenarComboCargo(ref ComboBox d)
        {
            db.llenarComboCargo(ref d);
        }
        public void guardarCargo(string Cargo)
        {
            db.agregar_Cargo(Cargo);
        }
        public void cambiarCargo(int idx, string Cargo)
        {
            db.actualizar_Cargo(idx, Cargo);
        }
        public void borrarCargo(int idx)
        {
            db.eliminar_Cargo(idx);
        }
        #endregion cargo

        #region departamento
        public void llenarDepartamento(ref DataGridView d)
        {
            db.llenarGridDepartamento(ref d);
        }
        public void llenarComboDepartamento(ref ComboBox d)
        {
            db.llenarComboDepartamento(ref d);
        }
        public void guardarDepartamento(string Departamento)
        {
            db.agregar_Departamento(Departamento);
        }
        public void cambiarDepartamento(int idx, string Departamento)
        {
            db.actualizar_Departamento(idx, Departamento);
        }
        public void borrarDepartamento(int idx)
        {
            db.eliminar_Departamento(idx);
        }
        #endregion departamento

        #region tiposnomina
        public void llenarGridTiposNomina(ref DataGridView d)
        {
            db.llenarGridTiposNomina(ref d);
        }
        public void llenarComboTiposNomina(ref ComboBox d)
        {
            db.llenarComboTiposNomina(ref d);
        }
        public void guardarTiposNomina(string Departamento)
        {
            db.agregar_TiposNomina(Departamento);
        }
        public void cambiarTiposNomina(int idx, string Departamento)
        {
            db.actualizar_TiposNomina(idx, Departamento);
        }
        public void borrarTiposNomina(int idx)
        {
            db.eliminar_TiposNomina(idx);
        }
        #endregion tiposnomina

        #region estadostrabajador
        public void llenarGridEstadoTrabajador(ref DataGridView d)
        {
            db.llenarGridEstadoTrabajador(ref d);
        }
        public void llenarComboEstadoTrabajador(ref ComboBox d)
        {
            db.llenarComboEstadoTrabajador(ref d);
        }
        public void guardarEstadoTrabajador(string EstadoTrabajador)
        {
            db.agregar_EstadoTrabajador(EstadoTrabajador);
        }
        public void cambiarEstadoTrabajador(int idx, string EstadoTrabajador)
        {
            db.actualizar_EstadoTrabajador(idx, EstadoTrabajador);
        }
        public void borrarEstadoTrabajador(int idx)
        {
            db.eliminar_EstadoTrabajador(idx);
        }
        #endregion estadostrabajador

        #region parentesco
        public void llenarGridParentesco(ref DataGridView d)
        {
            db.llenarGridParentesco(ref d);
        }
        public void llenarComboParentesco(ref ComboBox d)
        {
            db.llenarComboParentesco(ref d);
        }
        public void llenarComboParentesco(ref DataGridViewComboBoxColumn d)
        {
            db.llenarComboParentesco(ref d);
        }
        
        public void guardarParentesco(string Parentesco)
        {
            db.agregar_Parentesco(Parentesco);
        }
        public void cambiarParentesco(int idx, string Parentesco)
        {
            db.actualizar_Parentesco(idx, Parentesco);
        }
        public void borrarParentesco(int idx)
        {
            db.eliminar_Parentesco(idx);
        }
        #endregion parentesco

        #region fichatrabajador

        public void lista_de_trabajadores(ref DataGridView dt)
        {
            db.listadetrabajadores(ref dt);
        }

        public void leerdependientes(int idtrabajador, ref DataGridView dt)
        {
            db.leerdependientes(idtrabajador, ref dt);
        }

        public void guardarFichaTrabajador(string nombre, string apellido, string fnac,
            string cedula, int sexo, int edocivil, string telefonos, int pais, int estado, int municipio,
            string direccion, int statustrabajador, int departamento, int cargo, string fingreso,
            string fegreso, int tiponomina, string salario, DataGridView dt)
        {
            db.agregar_Ficha_del_trabajador(nombre, apellido, fnac,
            cedula, sexo, edocivil, telefonos, pais, estado, municipio,
            direccion, statustrabajador, departamento, cargo, fingreso,
            fegreso, tiponomina, salario,dt);
        }


        #endregion fichatrabajador

        #region pais

        public void llenarGridPais(ref DataGridView d)
        {
            db.llenarGridPais(ref d);
        }

        public void llenarComboPais(ref ComboBox d)
        {
            db.llenarComboPais(ref d);
        }

        public void guardarPais(string Pais)
        {
            db.agregar_Pais(Pais);
        }
        public void cambiarPais(int idx, string Pais)
        {
            db.actualizar_Pais(idx, Pais);
        }
        public void borrarPais(int idx)
        {
            db.eliminar_Pais(idx);
        }                             

        #endregion pais

        #region estado

        public void llenarGridEstado(ref DataGridView d, int paisseleccionado)
        {
            db.llenarGridEstado(ref d, paisseleccionado);
        }

        public void llenarComboEstado(int pais,ref ComboBox d)
        {
            db.llenarComboEstado(pais,ref d);
        }

        public void guardarEstado(int pais,string Estado)
        {
            db.agregar_Estado(pais,Estado);
        }
        public void cambiarEstado(int idpais, int idestado, string Estado)
        {
            db.actualizar_Estado(idpais, idestado,Estado);
        }
        public void borrarEstado(int idx)
        {
            db.eliminar_Estado(idx);
        }

        #endregion estado

        #region municipio

        public void llenarGridMunicipio(ref DataGridView d, int estado)
        {
            db.llenarGridMunicipio(ref d, estado);
        }

        public void llenarComboMunicipio(int estado, ref ComboBox d)
        {
            db.llenarComboMunicipio(estado, ref d);
        }

        public void guardarMunicipio(int estado, string Municipio)
        {
            db.agregar_Municipio(estado, Municipio);
        }
        public void cambiarMunicipio(int idestado, int idmunicipio, string Municipio)
        {
            db.actualizar_Municipio(idestado, idmunicipio, Municipio);
        }
        public void borrarMunicipio(int idx)
        {
            db.eliminar_Municipio(idx);
        }

        #endregion municipio
    }
}
