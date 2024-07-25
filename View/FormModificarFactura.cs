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
    public partial class FormModificarFactura : Form
    {
        private Controlador controlador = new Controlador();

        public FormModificarFactura()
        {
            InitializeComponent();

            // Crear una instancia de la clase Controlador
            controlador = new Controlador();

            // Agregar columnas al DataGridView
            dataGridView5.Columns.Add("IDFactura", "ID Factura");
            dataGridView5.Columns.Add("IDCliente", "ID Cliente");
            dataGridView5.Columns.Add("FechaEmision", "Fecha de Emisión");
            dataGridView5.Columns.Add("FechaVencimiento", "Fecha de Vencimiento");
            dataGridView5.Columns.Add("Estado", "Estado");
            dataGridView5.Columns.Add("Importe", "Importe");

        }

        private void FormModificarFactura_Load(object sender, EventArgs e)
        {

        }

        private void rbID_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar qué RadioButton está seleccionado
            if (rbID.Checked)
            {
                // Si está seleccionado el RadioButton de ID, buscar por ID
                if (int.TryParse(textBuscar.Text, out int idFactura))
                {
                    // Llamar al método de búsqueda por ID en el controlador
                    Factura facturaEncontrada = controlador.BuscarFacturaPorId(idFactura);

                    // Si se encontró un cliente, mostrar la información en el formulario
                    if (facturaEncontrada != null)
                    {
                        MostrarFacturaEnFormulario(facturaEncontrada);
                    }
                    else
                    {
                        // Mostrar un mensaje indicando que no se encontró el cliente
                        MessageBox.Show("Factura no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar un mensaje indicando que el ID ingresado no es válido
                    MessageBox.Show("Ingrese un ID de Factura válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbNombre.Checked)
            {
                // Si está seleccionado el RadioButton de nombre, buscar por nombre
                DateTime fechaEmision = dateTimePicker1.Value;

                // Llamar al método de búsqueda por nombre en el controlador
                List<Factura> facturasEncontradas = controlador.BuscarFacturasPorFechaEmision(fechaEmision);

                // Mostrar los Facturas encontrados en el DataGridView o en algún otro control
                MostrarFacturasEnDataGridView(facturasEncontradas);
            }
            else
            {
                // Si no se seleccionó ningún RadioButton, mostrar un mensaje de error
                MessageBox.Show("Seleccione una opción de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarFacturaEnFormulario(Factura factura)
        {
            // Limpiar las filas existentes en el DataGridView
            dataGridView5.Rows.Clear();

            // Agregar una nueva fila al DataGridView con la información del Factura
            dataGridView5.Rows.Add(factura.idFactura, factura.GetidCliente(), factura.FechaEmision, factura.FechaVencimiento, factura.GetImporte());
        }

        private void MostrarFacturasEnDataGridView(List<Factura> Facturas)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dataGridView5.Rows.Clear();

            // Iterar sobre la lista de Facturas y agregar cada Factura a una fila del DataGridView
            foreach (Factura factura in Facturas)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dataGridView5.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dataGridView5.Rows[rowIndex];

                // Llenar la fila con los datos del Factura
                row.Cells["IDFactura"].Value = factura.idFactura;
                row.Cells["IDCliente"].Value = factura.GetidCliente();
                row.Cells["FechaEmision"].Value = factura.FechaEmision;
                row.Cells["FechaVencimiento"].Value = factura.FechaVencimiento;
                row.Cells["Estado"].Value = factura.GetEstado();
                row.Cells["Importe"].Value = factura.GetImporte();
                
            }
        }

        private Factura ObtenerFacturaSeleccionada(int rowIndex)
        {
            // Obtener los valores de las celdas de la fila seleccionada
            DataGridViewRow row = dataGridView5.Rows[rowIndex];
            int idFactura = Convert.ToInt32(row.Cells["IDFactura"].Value);
            int idCliente = Convert.ToInt32(row.Cells["idCliente"].Value);
            DateTime fechaEmision = Convert.ToDateTime(row.Cells["FechaEmision"].Value);
            DateTime fechaVencimiento = Convert.ToDateTime(row.Cells["FechaVencimiento"].Value);
            string Estado = row.Cells["Estado"].Value.ToString();
            int total = Convert.ToInt32(row.Cells["Importe"].Value);
            

            // Crear un objeto Factura con los datos obtenidos
            Factura facturaSeleccionado = new Factura(idCliente,fechaEmision,fechaEmision.AddMonths(1),total);
            facturaSeleccionado.idFactura = idFactura;

            return facturaSeleccionado;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada en el DataGridView
            int rowIndex = dataGridView5.SelectedCells[0].RowIndex;

            // Obtener el cliente seleccionado en esa fila
            Factura facturaSeleccionado = ObtenerFacturaSeleccionada(rowIndex);

            // Actualizar los datos del Factura en la base de datos
            controlador.ModificarFactura(facturaSeleccionado);

            // Actualizar el DataGridView para reflejar los cambios
            dataGridView5.Refresh();

            // Mostrar un mensaje de éxito al usuario
            MessageBox.Show("Factura actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la ventana
        }
    }
}
