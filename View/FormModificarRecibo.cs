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
    

    public partial class FormModificarRecibo : Form
    {
        private Controlador controlador;

        public FormModificarRecibo()
        {
            InitializeComponent();

            controlador = new Controlador();

            // Agregar columnas Recibo al DataGridView
            dGVModificarRecibo.Columns.Add("IDRecibo", "ID Recibo");
            dGVModificarRecibo.Columns.Add("IDFactura", "ID Factura");
            dGVModificarRecibo.Columns.Add("IDCliente", "ID Cliente");
            dGVModificarRecibo.Columns.Add("Importe", "Importe");
            dGVModificarRecibo.Columns.Add("FechaEmision", "Fecha de Emisión");
            dGVModificarRecibo.Columns.Add("MetodoPago", "Fecha de Pago");
            dGVModificarRecibo.Columns.Add("Comentario", "Comentario");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra ventana
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar qué RadioButton está seleccionado
            if (rbID.Checked)
            {
                // Si está seleccionado el RadioButton de ID, buscar por ID
                if (int.TryParse(txtBuscar.Text, out int idRecibo))
                {
                    // Llamar al método de búsqueda por ID en el controlador
                    Recibo reciboEncontrado = controlador.BuscarReciboPorId(idRecibo);

                    // Si se encontró un cliente, mostrar la información en el formulario
                    if (reciboEncontrado != null)
                    {
                        MostrarReciboEnFormulario(reciboEncontrado);
                    }
                    else
                    {
                        // Mostrar un mensaje indicando que no se encontró el cliente
                        MessageBox.Show("Recibo no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar un mensaje indicando que el ID ingresado no es válido
                    MessageBox.Show("Ingrese un ID de Recibo válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbNombre.Checked)
            {
                // Si está seleccionado el RadioButton de nombre, buscar por nombre
                DateTime fechaEmision = dTPRecibo.Value;

                // Llamar al método de búsqueda por nombre en el controlador
                List<Recibo> recibosEncontradas = controlador.BuscarRecibosPorFechaEmision(fechaEmision);

                // Mostrar los Recibos encontrados en el DataGridView o en algún otro control
                MostrarRecibosEnDataGridView(recibosEncontradas);
            }
            else
            {
                // Si no se seleccionó ningún RadioButton, mostrar un mensaje de error
                MessageBox.Show("Seleccione una opción de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarReciboEnFormulario(Recibo recibo)
        {
            // Limpiar las filas existentes en el DataGridView
            dGVModificarRecibo.Rows.Clear();

            // Crear una nueva fila y asignar los valores directamente al constructor
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dGVModificarRecibo,
                recibo.GetIdRecibo(),
                recibo.GetIdFactura(),
                recibo.GetIdCliente(),
                recibo.GetMontoTotal(),
                recibo.GetFechaEmision(),
                recibo.GetMetodoPago(),
                recibo.GetComentario());

            // Agregar la fila al DataGridView
            dGVModificarRecibo.Rows.Add(row);
        }


        private void MostrarRecibosEnDataGridView(List<Recibo> Recibos)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dGVModificarRecibo.Rows.Clear();

            // Iterar sobre la lista de Facturas y agregar cada Factura a una fila del DataGridView
            foreach (Recibo recibo in Recibos)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dGVModificarRecibo.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dGVModificarRecibo.Rows[rowIndex];

                // Llenar la fila con los datos del Recibo
                row.Cells["IDRecibo"].Value = recibo.GetIdRecibo();
                row.Cells["IDFactura"].Value = recibo.GetIdFactura();
                row.Cells["IDCliente"].Value = recibo.GetIdCliente();
                row.Cells["FechaEmision"].Value = recibo.GetFechaEmision();
                row.Cells["Importe"].Value = recibo.GetMontoTotal();
                row.Cells["MetodoPago"].Value = recibo.GetMetodoPago();
                row.Cells["Comentario"].Value = recibo.GetComentario();

            }
        }

        private Recibo ObtenerReciboSeleccionado(int rowIndex)
        {
            // Obtener los valores de las celdas de la fila seleccionada
            DataGridViewRow row = dGVModificarRecibo.Rows[rowIndex];
            int idRecibo = Convert.ToInt32(row.Cells["IDRecibo"].Value);
            int idFactura = Convert.ToInt32(row.Cells["IDFactura"].Value);
            int idCliente = Convert.ToInt32(row.Cells["IDCliente"].Value);
            double importe = Convert.ToDouble(row.Cells["Importe"].Value);
            DateTime fechaEmision = Convert.ToDateTime(row.Cells["FechaEmision"].Value);
            string metodoPago = row.Cells["MetodoPago"].Value.ToString();
            string comentario = row.Cells["Comentario"].Value.ToString();



            // Crear un objeto Factura con los datos obtenidos
            Recibo reciboSeleccionado = new Recibo(idFactura, idCliente, importe, fechaEmision,metodoPago, comentario);
            reciboSeleccionado.SetIdRecibo(idRecibo);

            return reciboSeleccionado;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada en el DataGridView
            int rowIndex = dGVModificarRecibo.SelectedCells[0].RowIndex;

            // Obtener el recibo seleccionado en esa fila
            Recibo reciboSeleccionado = ObtenerReciboSeleccionado(rowIndex);

            // Actualizar los datos del recibo en la base de datos
            controlador.ModificarRecibo(reciboSeleccionado);

            // Actualizar el DataGridView para reflejar los cambios
            dGVModificarRecibo.Refresh();

            // Mostrar un mensaje de éxito al usuario
            MessageBox.Show("Recibo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
