using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteFacturaRecibo
{
    public partial class FormAgregarCliente : Form
    {
        public FormAgregarCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string nombre = textNombre.Text;
            string email = textEmail.Text;
            string cuit = textCuit.Text;
            string telefono = textTelefono.Text;
            string direccion = textDireccion.Text;
            string ciudad = textCiudad.Text;
            string pais = textPais.Text;
            string codigoPostal = textCodigoPostal.Text;

            // Crear una instancia del controlador
            Controlador controlador = new Controlador();

            // Crear una instancia del cliente con los datos del formulario
            Cliente cliente = new Cliente(nombre, cuit, telefono, direccion, ciudad, pais, codigoPostal);

            // Agregar el cliente a la base de datos
            controlador.AgregarCliente(cliente);

            // Mostrar un mensaje de éxito
            MessageBox.Show("Cliente agregado correctamente.");

            // Limpiar los campos del formulario
            LimpiarCampos();
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            textNombre.Text = "";
            textEmail.Text = "";
            textCuit.Text = "";
            textTelefono.Text = "";
            textDireccion.Text = "";
            textCiudad.Text = "";
            textPais.Text = "";
            textCodigoPostal.Text = "";
        }

        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la ventana
        }
    }
    
}
