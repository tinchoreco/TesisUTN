using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteFacturaRecibo.View
{
    public partial class FormAgregarRecibo : Form
    {
        private Controlador controlador = new Controlador();

        public FormAgregarRecibo()
        {
            InitializeComponent();

            // Agregar columnas Cliennte al DataGridView
            dataGridViewCliente.Columns.Add("IDCliente", "ID Cliente");
            dataGridViewCliente.Columns.Add("Nombre", "Nombre");
            dataGridViewCliente.Columns.Add("Cuit", "CUIT");
            dataGridViewCliente.Columns.Add("Telefono", "Teléfono");
            dataGridViewCliente.Columns.Add("Direccion", "Dirección");
            dataGridViewCliente.Columns.Add("Ciudad", "Ciudad");
            dataGridViewCliente.Columns.Add("Pais", "País");
            dataGridViewCliente.Columns.Add("CodigoPostal", "Código Postal");

            // Agregar columnas Factura al DataGridView
            dataGridViewFactura.Columns.Add("IDFactura", "ID Factura");
            dataGridViewFactura.Columns.Add("IDCliente", "ID Cliente");
            dataGridViewFactura.Columns.Add("FechaEmision", "Fecha de Emisión");
            dataGridViewFactura.Columns.Add("FechaVencimiento", "Fecha de Vencimiento");
            dataGridViewFactura.Columns.Add("Estado", "Estado");
            dataGridViewFactura.Columns.Add("Importe", "Importe");
        }

        private void FormAgregarRecibo_Load(object sender, EventArgs e)
        {
            // Agregar opciones al ComboBox
            comboBox1.Items.Add("Bank Transfer");
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Credit Card");
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Verificar qué RadioButton está seleccionado
            if (rbID.Checked)
            {
                // Si está seleccionado el RadioButton de ID, buscar por ID
                if (int.TryParse(txtBuscarCliente.Text, out int idCliente))
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
                string nombreCliente = txtBuscarCliente.Text;

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
            dataGridViewCliente.Rows.Clear();

            // Agregar una nueva fila al DataGridView con la información del cliente
            dataGridViewCliente.Rows.Add(cliente.idCliente, cliente.GetNombre(), cliente.GetCuit(), cliente.GetTelefono(), cliente.GetDireccion(), cliente.GetCiudad(), cliente.GetPais(), cliente.GetCodigoPostal());
        }

        private void MostrarClientesEnDataGridView(List<Cliente> clientes)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dataGridViewCliente.Rows.Clear();

            // Iterar sobre la lista de clientes y agregar cada cliente a una fila del DataGridView
            foreach (Cliente cliente in clientes)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dataGridViewCliente.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dataGridViewCliente.Rows[rowIndex];

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

        private void dataGridViewCliente_SelectionChanged(object sender, EventArgs e)
        {
            
            // Verificar si hay una fila seleccionada
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                
                // Obtener el ID del cliente seleccionado
                int idCliente = Convert.ToInt32(dataGridViewCliente.SelectedRows[0].Cells["IDCliente"].Value);

                // Consultar las facturas del cliente seleccionado en la base de datos
                List<Factura> facturasCliente = ObtenerFacturasCliente(idCliente);

                // Actualizar el DataGridView de facturas con las facturas del cliente seleccionado
                mostrarFacturasEnDataGridView(facturasCliente);
            }
            
        }

        private void mostrarFacturasEnDataGridView(List<Factura> facturas)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dataGridViewFactura.Rows.Clear();

           

            // Iterar sobre la lista de clientes y agregar cada cliente a una fila del DataGridView
            foreach (Factura factura in facturas)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dataGridViewFactura.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dataGridViewFactura.Rows[rowIndex];

                // Llenar la fila con los datos de la factura
                row.Cells["IDFactura"].Value = factura.idFactura;
                row.Cells["IDCliente"].Value = factura.GetidCliente();
                row.Cells["FechaEmision"].Value = factura.FechaEmision.ToString("dd/MM/yyyy"); // Formato personalizado para la fecha de emisión
                row.Cells["FechaVencimiento"].Value = factura.FechaVencimiento.ToString("dd/MM/yyyy"); // Formato personalizado para la fecha de vencimiento
                row.Cells["Estado"].Value = factura.GetEstado(); // Asegúrate de tener un atributo "Estado" en la clase Factura
                row.Cells["Importe"].Value = factura.GetImporte();

                Console.WriteLine(factura.idFactura);

            }
            // Actualizar el DataGridView para reflejar los cambios
            dataGridViewFactura.Refresh();
        }

        private List<Factura> ObtenerFacturasCliente(int idCliente)
        {
            List<Factura> facturasCliente = new List<Factura>();
            
            
            facturasCliente = controlador.ObtenerFacturasPorIdCliente(idCliente);
            
            return facturasCliente;
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            
            // Verificar si hay una fila seleccionada
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                // Obtener el ID del cliente seleccionado
                int idCliente = Convert.ToInt32(dataGridViewCliente.SelectedRows[0].Cells["IDCliente"].Value);

                // Consultar las facturas del cliente seleccionado en la base de datos
                List<Factura> facturasCliente = ObtenerFacturasCliente(idCliente);

                foreach(Factura factura in facturasCliente)
                {
                    Console.WriteLine(factura.idFactura);
                }


                // Actualizar el DataGridView de facturas con las facturas del cliente seleccionado
                mostrarFacturasEnDataGridView(facturasCliente);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada en el DataGridView
            int rowIndexFactura = dataGridViewFactura.SelectedCells[0].RowIndex;
            int rowIndexCliente = dataGridViewCliente.SelectedCells[0].RowIndex;

            // Obtener los valores de las celdas de la fila seleccionada
            DataGridViewRow rowFactura = dataGridViewFactura.Rows[rowIndexFactura];
            DataGridViewRow rowCliente = dataGridViewCliente.Rows[rowIndexCliente];

            int idFactura = Convert.ToInt32(rowFactura.Cells["IDFactura"].Value);
            int idCliente = Convert.ToInt32(rowCliente.Cells["IDCliente"].Value);
            double importe = Convert.ToDouble(txtTotal.Text);
            DateTime fechaEmision = dateTimePicker1.Value;
            string metodoPago = comboBox1.SelectedItem.ToString();
            string comentario = richTextBox1.Text;

            // Obtener el recibo seleccionado en esa fila
            Recibo nuevoRecibo = new Recibo(idFactura, idCliente, importe, fechaEmision, metodoPago, comentario);

            
            // Actualizar los datos del recibo en la base de datos
            controlador.AgregarRecibo(nuevoRecibo);

            // Actualizar el DataGridView para reflejar los cambios
            dataGridViewFactura.Refresh();

            // Mostrar un mensaje de éxito al usuario
            MessageBox.Show("Recibo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // cierra la ventana
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda que se hace clic es la celda que contiene la flecha de la izquierda
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Obtener el valor de la celda "Importe" de la fila seleccionada
                object importe = dataGridViewFactura.Rows[e.RowIndex].Cells["Importe"].Value;

                // Verificar si el valor de la celda no es nulo antes de asignarlo al TextBox
                if (importe != null)
                {
                    txtTotal.Text = importe.ToString();
                    comboBox1.SelectedItem = "Cash";
                }
                else
                {
                    txtTotal.Text = ""; // Opcional: Si el valor es nulo, se puede asignar un valor predeterminado
                    comboBox1.SelectedItem = "Cash";
                }
            }
        }

    }
}
