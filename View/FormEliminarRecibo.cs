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
    public partial class FormEliminarRecibo : Form
    {
        private Controlador controlador;
        public FormEliminarRecibo()
        {
            InitializeComponent();

            controlador = new Controlador();

            // Agregar columnas Recibo al DataGridView
            dGVEliminarRecibo.Columns.Add("IDRecibo", "ID Recibo");
            dGVEliminarRecibo.Columns.Add("IDFactura", "ID Factura");
            dGVEliminarRecibo.Columns.Add("IDCliente", "ID Cliente");
            dGVEliminarRecibo.Columns.Add("FechaEmision", "Fecha de Emisión");
            dGVEliminarRecibo.Columns.Add("Importe", "Importe");
            dGVEliminarRecibo.Columns.Add("Comentario", "Comentario");

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la  Ventana
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // Verificar qué RadioButton está seleccionado
            if (rbID.Checked)
            {
                // Si está seleccionado el RadioButton de ID, buscar por ID
                if (int.TryParse(txtBuscar.Text, out int idRecibo))
                {
                    // Llamar al método de búsqueda por ID en el controlador
                    Recibo reciboEncontrada = controlador.BuscarReciboPorId(idRecibo);

                    // Si se encontró un cliente, mostrar la información en el formulario
                    if (reciboEncontrada != null)
                    {
                        MostrarReciboEnFormulario(reciboEncontrada);
                    }
                    else
                    {
                        // Mostrar un mensaje indicando que no se encontró la Recibo
                        MessageBox.Show("Recibo no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar un mensaje indicando que el ID ingresado no es válido
                    MessageBox.Show("Ingrese un ID de Recibo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbidCliente.Checked)
            {
                // Si está seleccionado el RadioButton de nombre, buscar por nombre
                int idCliente = Convert.ToInt32(txtBuscar.Text);

                // Llamar al método de búsqueda por nombre en el controlador
                List<Recibo> recibosEncontrados = controlador.BuscarRecibosPorIdCliente(idCliente);

                // Mostrar los clientes encontrados en el DataGridView o en algún otro control
                MostrarRecibosEnDataGridView(recibosEncontrados);
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
            dGVEliminarRecibo.Rows.Clear();

            // Agregar una nueva fila al DataGridView con la información del Factura
            dGVEliminarRecibo.Rows.Add(recibo.GetIdRecibo(), recibo.GetIdCliente(), recibo.GetFechaEmision(), recibo.GetMontoTotal(), recibo.GetComentario());
        }

        private void MostrarRecibosEnDataGridView(List<Recibo> recibos)
        {
            // Limpiar el DataGridView antes de mostrar nuevos datos
            dGVEliminarRecibo.Rows.Clear();

            // Iterar sobre la lista de recibos y agregar cada recibo a una fila del DataGridView
            foreach (Recibo recibo in recibos)
            {
                // Crear una nueva fila en el DataGridView
                int rowIndex = dGVEliminarRecibo.Rows.Add();

                // Obtener la fila recién creada
                DataGridViewRow row = dGVEliminarRecibo.Rows[rowIndex];

                // Llenar la fila con los datos del Recibo
                row.Cells["IDRecibo"].Value = recibo.GetIdRecibo();
                row.Cells["IDFactura"].Value = recibo.GetIdFactura();
                row.Cells["IDCliente"].Value = recibo.GetIdCliente();
                row.Cells["FechaEmision"].Value = recibo.GetFechaEmision();
                row.Cells["Importe"].Value = recibo.GetMontoTotal();
                row.Cells["Comentario"].Value = recibo.GetComentario();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dGVEliminarRecibo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener los valores de las celdas de la fila seleccionada
                DataGridViewRow row = dGVEliminarRecibo.Rows[e.RowIndex];
                int idRecibo = Convert.ToInt32(row.Cells["IDRecibo"].Value);

                // Puedes mostrar estos datos en un MessageBox para confirmar la eliminación
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de eliminar el recibo '{idRecibo}'?", "Eliminar Recibo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    Controlador controlador = new Controlador();
                    // Llama al método para eliminar el recibo utilizando el ID obtenido
                    controlador.EliminarRecibo(idRecibo);

                    // Actualiza el DataGridView después de eliminar el recibo
                    dGVEliminarRecibo.Rows.Remove(row);
                }
            }
            dGVEliminarRecibo.Refresh();
        }
    }
}
