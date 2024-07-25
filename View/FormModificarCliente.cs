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
    public partial class FormModificarCliente : Form
    {
        private Controlador controlador = new Controlador();
        public FormModificarCliente()
        {
            InitializeComponent();

            // Crear una instancia de la clase Controlador
            controlador = new Controlador();

            // Agregar columnas al DataGridView
            dataGridView1.Columns.Add("IDCliente", "ID Cliente");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Cuit", "CUIT");
            dataGridView1.Columns.Add("Telefono", "Teléfono");
            dataGridView1.Columns.Add("Direccion", "Dirección");
            dataGridView1.Columns.Add("Ciudad", "Ciudad");
            dataGridView1.Columns.Add("Pais", "País");
            dataGridView1.Columns.Add("CodigoPostal", "Código Postal");
        }

        private void button1_Click(object sender, EventArgs e)
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
            dataGridView1.Rows.Clear();

            // Crear una nueva fila y asignar los valores directamente al constructor
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1,
                cliente.idCliente,
                cliente.GetNombre(),
                cliente.GetCuit(),
                cliente.GetTelefono(),
                cliente.GetDireccion(),
                cliente.GetCiudad(),
                cliente.GetPais(),
                cliente.GetCodigoPostal());

            // Agregar la fila al DataGridView
            dataGridView1.Rows.Add(row);
        }

        private void MostrarClientesEnDataGridView(List<Cliente> clientes)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dataGridView1.Rows.Clear();

            // Iterar sobre la lista de clientes y agregar cada cliente a una fila del DataGridView
            foreach (Cliente cliente in clientes)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dataGridView1.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Llenar la fila con los datos del cliente
                row.Cells["IDCliente"].Value = cliente.idCliente;
                row.Cells["Nombre"].Value = cliente.GetNombre();
                row.Cells["Cuit"].Value = cliente.GetCuit();
                row.Cells["Telefono"].Value = cliente.GetTelefono();
                row.Cells["Direccion"].Value = cliente.GetDireccion();
                row.Cells["Ciudad"].Value = cliente.GetCiudad();
                row.Cells["Pais"].Value = cliente.GetPais();
                row.Cells["CodigoPostal"].Value = cliente.GetCodigoPostal();
            }
        }

        private Cliente ObtenerClienteSeleccionado(int rowIndex)
        {
            // Obtener los valores de las celdas de la fila seleccionada
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            int idCliente = Convert.ToInt32(row.Cells["IDCliente"].Value);
            string nombre = row.Cells["Nombre"].Value.ToString();
            string direccion = row.Cells["Direccion"].Value.ToString();
            string cuit = row.Cells["Cuit"].Value.ToString();
            string telefono = row.Cells["Telefono"].Value.ToString();
            string ciudad = row.Cells["Ciudad"].Value.ToString();
            string pais = row.Cells["Pais"].Value.ToString();
            string codigoPostal = row.Cells["CodigoPostal"].Value.ToString();

            // Crear un objeto Cliente con los datos obtenidos
            Cliente clienteSeleccionado = new Cliente(nombre, direccion, cuit, telefono, ciudad, pais, codigoPostal);
            clienteSeleccionado.idCliente = idCliente;

            return clienteSeleccionado;
        }

        private void FormModificarCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada en el DataGridView
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

            // Obtener el cliente seleccionado en esa fila
            Cliente clienteSeleccionado = ObtenerClienteSeleccionado(rowIndex);

            // Actualizar los datos del cliente en la base de datos
            controlador.ModificarCliente(clienteSeleccionado);

            // Actualizar el DataGridView para reflejar los cambios
            dataGridView1.Refresh();

            // Mostrar un mensaje de éxito al usuario
            MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
