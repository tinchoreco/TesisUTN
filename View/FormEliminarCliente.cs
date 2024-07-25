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
    public partial class FormEliminarCliente : Form
    {
        private Controlador controlador;
        public FormEliminarCliente()
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

            // Habilitar la edición de todas las celdas en el DataGridView
            dataGridView1.ReadOnly = false;

            // Habilitar la edición solo en las columnas específicas
            dataGridView1.Columns["Nombre"].ReadOnly = false;
            dataGridView1.Columns["Direccion"].ReadOnly = false;
            dataGridView1.Columns["Cuit"].ReadOnly = false;
            dataGridView1.Columns["Telefono"].ReadOnly = false;
            dataGridView1.Columns["Ciudad"].ReadOnly = false;
            dataGridView1.Columns["Pais"].ReadOnly = false;
            dataGridView1.Columns["CodigoPostal"].ReadOnly = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

            // Agregar una nueva fila al DataGridView con la información del cliente
            dataGridView1.Rows.Add(cliente.idCliente, cliente.GetNombre(), cliente.GetCuit(), cliente.GetTelefono(), cliente.GetDireccion(), cliente.GetCiudad(), cliente.GetPais(), cliente.GetCodigoPostal());
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtiene los datos de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                int idCliente = Convert.ToInt32(filaSeleccionada.Cells["IDCliente"].Value);
                string nombreCliente = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);

                // Puedes mostrar estos datos en un MessageBox para confirmar la eliminación
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de eliminar al cliente '{nombreCliente}'?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llama al método para eliminar el cliente utilizando el ID obtenido
                    controlador.EliminarCliente(idCliente);

                    // Actualiza el DataGridView después de eliminar el cliente
                    
                    dataGridView1.Rows.Remove(filaSeleccionada);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbID_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    
}
