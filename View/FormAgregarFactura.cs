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
    public partial class FormAgregarFactura : Form
    {
        private Controlador controlador;

        public FormAgregarFactura()
        {
            InitializeComponent();

            // Crear una instancia de la clase Controlador
            controlador = new Controlador();

            // Agregar columnas al DataGridView
            dataGridView4.Columns.Add("IDCliente", "ID Cliente");
            dataGridView4.Columns.Add("Nombre", "Nombre");
            dataGridView4.Columns.Add("Cuit", "CUIT");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAgregarFactura_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar qué RadioButton está seleccionado
            if (rbID.Checked)
            {
                // Si está seleccionado el RadioButton de ID, buscar por ID
                if (int.TryParse(textBuscar.Text, out int idCliente))
                {
                    // Llamar al método de búsqueda por ID en el controlador
                    Cliente clienteEncontrado = controlador.BuscarClientePorID(idCliente);

                    // Si se encontró un cliente, mostrar la información en el formulario
                    if (clienteEncontrado != null)
                    {
                        MostrarClienteEnFormulario(clienteEncontrado);
                    }
                    else
                    {
                        // Mostrar un mensaje indicando que no se encontró el cliente
                        MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar un mensaje indicando que el ID ingresado no es válido
                    MessageBox.Show("Ingrese un ID de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbNombre.Checked)
            {
                // Si está seleccionado el RadioButton de nombre, buscar por nombre
                string nombreCliente = textBuscar.Text;

                // Llamar al método de búsqueda por nombre en el controlador
                List<Cliente> clientesEncontrados = controlador.BuscarClientePorNombre(nombreCliente);

                // Mostrar los clientes encontrados en el DataGridView o en algún otro control
                MostrarClientesEnDataGridView(clientesEncontrados);
            }
            else
            {
                // Si no se seleccionó ningún RadioButton, mostrar un mensaje de error
                MessageBox.Show("Seleccione una opción de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarClienteEnFormulario(Cliente cliente)
        {
            // Limpiar las filas existentes en el DataGridView
            dataGridView4.Rows.Clear();

            // Agregar una nueva fila al DataGridView con la información del cliente
            dataGridView4.Rows.Add(cliente.idCliente, cliente.GetNombre(), cliente.GetCuit());
        }

       

        private void MostrarClientesEnDataGridView(List<Cliente> clientes)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dataGridView4.Rows.Clear();

            // Iterar sobre la lista de clientes y agregar cada cliente a una fila del DataGridView
            foreach (Cliente cliente in clientes)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dataGridView4.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dataGridView4.Rows[rowIndex];

                // Llenar la fila con los datos del cliente
                row.Cells["IDCliente"].Value = cliente.idCliente;
                row.Cells["Nombre"].Value = cliente.GetNombre();
                row.Cells["Cuit"].Value = cliente.GetCuit();
                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada en el DataGridView
            int rowIndex = dataGridView4.SelectedCells[0].RowIndex;

            // Obtener los valores de las celdas de la fila seleccionada
            DataGridViewRow row = dataGridView4.Rows[rowIndex];
            int idCliente = Convert.ToInt32(row.Cells["IDCliente"].Value);

            DateTime fechaEmision = dateTimePicker1.Value;
            int importe = Convert.ToInt32(textTotal.Text);

            // Crear una instancia de Factura con los datos del formulario
            Factura factura = new Factura(idCliente,fechaEmision,fechaEmision.AddMonths(1), importe);

            // Agregar factura a la base de datos
            controlador.AgregarFactura(factura);

            // Mostrar un mensaje de éxito
            MessageBox.Show("Factura agregada correctamente.");

            // Limpiar los campos del formulario
            dataGridView4.Refresh();
            textTotal.Text = "";
            textBuscar.Text = "";
        }

        private void FormAgregarFactura_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // cierra ventana
        }
    }
}
