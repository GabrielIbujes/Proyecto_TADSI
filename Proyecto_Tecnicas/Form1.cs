using Proyecto_Tecnicas.Datos;
using Proyecto_Tecnicas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Tecnicas
{
    public partial class Form1 : Form
    {
        DataTable tabla;
        Usuario dato = new Usuario();

        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }

       

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Iniciar();
            Limpiar();
            Consultar();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Iniciar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Nombre de Vinil");
            tabla.Columns.Add("Tamaño");
            tabla.Columns.Add("Tipo");
            tabla.Columns.Add("Color");
            grilla.DataSource = tabla;
        }

        private void Guardar()
        {
            UsuarioModelo modelo = new UsuarioModelo()
            {
                Nombre = txtnombre.Text,
                Edad = float.Parse(txtedad.Text),
                Tipo = txttipo.Text,
                Color = txtcolor.Text
            };
            dato.Guardar(modelo);
        } 

        private void Consultar()
        {
            foreach (var item in dato.Consultar())
            {
                DataRow fila = tabla.NewRow();
                fila["Nombre de Vinil"] = item.Nombre;
                fila["Tamaño"] = item.Edad;
                fila["Tipo"] = item.Tipo;
                fila["Color"] = item.Color;
                tabla.Rows.Add();
               
            }
        }

        private void Limpiar()
        {
            txtnombre.Text = "";
            txtedad.Text = "";
            txttipo.Text = "";
            txtcolor.Text = "";

        }

    
    }
}
