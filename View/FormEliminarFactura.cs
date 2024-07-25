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
    public partial class FormEliminarFactura : Form
    {
        Controlador controlador;

        public FormEliminarFactura()
        {
            InitializeComponent();

            controlador = new Controlador();

            // Agregar columnas Factura al DataGridView
            dGVEliminarFactura.Columns.Add("IDFactura", "ID Factura");
            dGVEliminarFactura.Columns.Add("IDCliente", "ID Cliente");
            dGVEliminarFactura.Columns.Add("FechaEmision", "Fecha de Emisión");
            dGVEliminarFactura.Columns.Add("FechaVencimiento", "Fecha de Vencimiento");
            dGVEliminarFactura.Columns.Add("Estado", "Estado");
            dGVEliminarFactura.Columns.Add("Importe", "Importe");
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            // Verificar qué RadioButton está seleccionado
            if (rbID.Checked)
            {
                // Si está seleccionado el RadioButton de ID, buscar por ID
                if (int.TryParse(txtBuscar.Text, out int idFactura))
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
                        // Mostrar un mensaje indicando que no se encontró la Factura
                        MessageBox.Show("Factura no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar un mensaje indicando que el ID ingresado no es válido
                    MessageBox.Show("Ingrese un ID de Factura válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbidCliente.Checked)
            {
                // Si está seleccionado el RadioButton de nombre, buscar por nombre
                int idCliente = Convert.ToInt32(txtBuscar.Text);

                // Llamar al método de búsqueda por nombre en el controlador
                List<Factura> clientesEncontrados = controlador.ObtenerFacturasPorIdCliente(idCliente);

                // Mostrar los clientes encontrados en el DataGridView o en algún otro control
                MostrarFacturasEnDataGridView(clientesEncontrados);
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
            dGVEliminarFactura.Rows.Clear();

            // Agregar una nueva fila al DataGridView con la información del Factura
            dGVEliminarFactura.Rows.Add(factura.idFactura, factura.GetidCliente(), factura.FechaEmision, factura.FechaVencimiento, factura.GetImporte());
        }

        private void MostrarFacturasEnDataGridView(List<Factura> Facturas)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dGVEliminarFactura.Rows.Clear();

            // Iterar sobre la lista de Facturas y agregar cada Factura a una fila del DataGridView
            foreach (Factura factura in Facturas)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dGVEliminarFactura.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dGVEliminarFactura.Rows[rowIndex];

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
            DataGridViewRow row = dGVEliminarFactura.Rows[rowIndex];
            int idFactura = Convert.ToInt32(row.Cells["IDFactura"].Value);
            int idCliente = Convert.ToInt32(row.Cells["idCliente"].Value);
            DateTime fechaEmision = Convert.ToDateTime(row.Cells["FechaEmision"].Value);
            DateTime fechaVencimiento = Convert.ToDateTime(row.Cells["FechaVencimiento"].Value);
            string Estado = row.Cells["Estado"].Value.ToString();
            int total = Convert.ToInt32(row.Cells["Importe"].Value);


            // Crear un objeto Factura con los datos obtenidos
            Factura facturaSeleccionado = new Factura(idCliente, fechaEmision, fechaEmision.AddMonths(1), total);
            facturaSeleccionado.idFactura = idFactura;

            return facturaSeleccionado;
        }
        
        private void dGVEliminarFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener los valores de las celdas de la fila seleccionada
                DataGridViewRow row = dGVEliminarFactura.Rows[e.RowIndex];
                int idFactura = Convert.ToInt32(row.Cells["IDFactura"].Value);

                // Puedes mostrar estos datos en un MessageBox para confirmar la eliminación
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de eliminar la factura '{idFactura}'?", "Eliminar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llama al método para eliminar el cliente utilizando el ID obtenido
                    controlador.EliminarFactura(idFactura);

                    // Actualiza el DataGridView después de eliminar el cliente

                    dGVEliminarFactura.Rows.Remove(row);
                }
            }
            dGVEliminarFactura.Refresh();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar Ventana
        }
    }
}
