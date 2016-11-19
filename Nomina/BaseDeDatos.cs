using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    interface BaseDeDatos
    {

        string[][] obtener_menu(ref MenuStrip mnu);
         //string[][] obtener_sub_menu(string menu);

        void llenarGridSexo(ref DataGridView grid);
        void llenarComboSexo(ref ComboBox control);
        void agregar_sexo(string sexo);
        void actualizar_sexo(int idx, string sexo);
        void eliminar_sexo(int idx);

        void llenarGridEstadoCivil(ref DataGridView grid);
        void llenarComboEstadoCivil(ref ComboBox control);
        void agregar_EstadoCivil(string EstadoCivil);
        void actualizar_EstadoCivil(int idx, string EstadoCivil);
        void eliminar_EstadoCivil(int idx);

        void llenarGridCargo(ref DataGridView grid);
        void llenarComboCargo(ref ComboBox control);
        void agregar_Cargo(string Cargo);
        void actualizar_Cargo(int idx, string Cargo);
        void eliminar_Cargo(int idx);

        void llenarGridDepartamento(ref DataGridView grid);
        void llenarComboDepartamento(ref ComboBox control);
        void agregar_Departamento(string Departamento);
        void actualizar_Departamento(int idx, string Departamento);
        void eliminar_Departamento(int idx);

        void llenarGridTiposNomina(ref DataGridView grid);
        void llenarComboTiposNomina(ref ComboBox control);
        void agregar_TiposNomina(string TiposNomina);
        void actualizar_TiposNomina(int idx, string TiposNomina);
        void eliminar_TiposNomina(int idx);

        void llenarGridEstadoTrabajador(ref DataGridView grid);
        void llenarComboEstadoTrabajador(ref ComboBox control);
        void agregar_EstadoTrabajador(string TiposNomina);
        void actualizar_EstadoTrabajador(int idx, string TiposNomina);
        void eliminar_EstadoTrabajador(int idx);

        void llenarGridParentesco(ref DataGridView grid);
        void llenarComboParentesco(ref ComboBox control);
        void llenarComboParentesco(ref DataGridViewComboBoxColumn d);
        void agregar_Parentesco(string Parentesco);
        void actualizar_Parentesco(int idx, string Parentesco);
        void eliminar_Parentesco(int idx);

        void llenarGridPais(ref DataGridView d);
        void llenarComboPais(ref ComboBox control);
        void llenarComboPais(ref DataGridViewComboBoxColumn control);
        void agregar_Pais(string Pais);
        void eliminar_Pais(int idx);
        void actualizar_Pais(int idx, string Pais);

        void llenarGridEstado(ref DataGridView d, int paisseleccionado);
        void llenarComboEstado(int pais,ref ComboBox control);
        void llenarComboEstado(int pais,ref DataGridViewComboBoxColumn control);
        void agregar_Estado(int idpais,string Estado);
        void eliminar_Estado(int idx);
        void actualizar_Estado(int idpais, int idestado, string Estado);

        void llenarGridMunicipio(ref DataGridView d, int estado);
        void llenarComboMunicipio(int estado, ref ComboBox control);
        void llenarComboMunicipio(int estado, ref DataGridViewComboBoxColumn control);
        void agregar_Municipio(int idestado, string Municipio);
        void eliminar_Municipio(int idx);
        void actualizar_Municipio(int idpais, int idmunicipio, string Municipio);

        void listadetrabajadores(ref DataGridView grid);
        void leerdependientes(int idtrabajador, ref DataGridView grid);
        void agregar_Ficha_del_trabajador(string nombre, string apellido, string fnac,
            string cedula, int sexo, int edocivil, string telefonos, int pais, int estado, int municipio,
            string direccion, int statustrabajador, int departamento, int cargo, string fingreso,
            string fegreso, int tiponomina, string salario, DataGridView dt);
    }
}
