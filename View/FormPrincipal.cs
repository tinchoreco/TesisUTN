using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClienteFacturaRecibo.View;

namespace ClienteFacturaRecibo

{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de clientes
            FormAgregarCliente formClientes = new FormAgregarCliente();

            // Mostrar el formulario de clientes
            formClientes.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de Eliminar clientes
            FormEliminarCliente formEliminarClientes = new FormEliminarCliente();

            // Mostrar el formulario de clientes
            formEliminarClientes.Show();
        }

        private void ModificarCliente_Click(object sender, EventArgs e)
        {
            //Crear una instancia del formulario de Modificar clientes
            FormModificarCliente formModificarCliente = new FormModificarCliente();

            // Mostrar el formulario de clientes
            formModificarCliente.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Creamos una instancia del formulario Agregar Factura
            FormAgregarFactura formAgregarFactura = new FormAgregarFactura();

            // Mostrar el formulario de Factura
            formAgregarFactura.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Creamos una instancia del fomrulario Modificar Factura
            FormModificarFactura formModificarFactura = new FormModificarFactura();

            //Mostramos el formulario de Factura
            formModificarFactura.Show();
        }

        private void coneccionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            //Creamos una instancia del fomrulario Modificar Factura
            FormAgregarRecibo formAgregarRecibo = new FormAgregarRecibo();

            //Mostramos el formulario de Factura
            formAgregarRecibo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Creamos una instancia del fomrulario Modificar Factura
            FormEliminarFactura formEliminarFactura = new FormEliminarFactura();

            //Mostramos el formulario de Factura
            formEliminarFactura.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Creamos una instancia del fomrulario Modificar Factura
            FormModificarRecibo formModificarRecibo = new FormModificarRecibo();

            //Mostramos el formulario de Factura
            formModificarRecibo.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Creamos una instancia del fomrulario Eliminar Factura
            FormEliminarRecibo formElimnarRecibo = new FormEliminarRecibo();

            //Mostramos el formulario de Factura
            formElimnarRecibo.Show();
        }
    }
}
