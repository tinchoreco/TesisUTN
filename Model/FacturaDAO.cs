using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClienteFacturaRecibo
{
    public class FacturaDAO
    {
        private MySqlConnection conexion;
        private string url = "server=localhost;port=3306;database=clientefacturarecibo;uid=root;password=123456";

        public FacturaDAO()
        {
            try
            {
                conexion = new MySqlConnection(url);
                conexion.Open();
                Console.WriteLine("Estado de la conexión: " + conexion.State);
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + e.Message);
            }
        }

        public void AgregarFactura(Factura factura)
        {
            string query = "INSERT INTO facturas (idCliente, Total, estado, FechaEmision, FechaVencimiento) VALUES (@idCliente, @Total, @estado, @FechaEmision, @FechaVencimiento)";
            
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idCliente", factura.GetidCliente());
                cmd.Parameters.AddWithValue("@Total", factura.GetImporte());
                cmd.Parameters.AddWithValue("@estado", factura.GetEstado());
                cmd.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                cmd.Parameters.AddWithValue("@FechaVencimiento", factura.FechaVencimiento);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al agregar factura: " + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void ModificarFactura(Factura factura)
        {
            string query = "UPDATE facturas SET idCliente = @idCliente, Total = @Total, estado = @Estado WHERE idFactura = @idFactura";
            

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idCliente", factura.GetidCliente());
                cmd.Parameters.AddWithValue("@Total", factura.GetImporte()); // Suponiendo que GetImporte() devuelve el total de la factura
                cmd.Parameters.AddWithValue("@Estado", factura.GetEstado());
                cmd.Parameters.AddWithValue("@idFactura", factura.idFactura);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al modificar factura: " + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void EliminarFactura(int idFactura)
        {
            string query = "DELETE FROM facturas WHERE idFactura = @idFactura";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@idFactura", idFactura);

            try
            {
                
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al eliminar factura: " + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public Factura BuscarFacturaPorId(int idFactura)
        {
            Factura factura = null;
            string sql = "SELECT * FROM facturas WHERE idFactura = @IdFactura";
            try
            {
                MySqlCommand command = new MySqlCommand(sql, conexion);
                command.Parameters.AddWithValue("@IdFactura", idFactura);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        factura = new Factura();
                        factura.idFactura = reader.GetInt32("idFactura");
                        factura.SetidCliente(reader.GetInt32("idCliente"));
                        factura.FechaEmision = reader.GetDateTime("FechaEmision");
                        factura.FechaVencimiento = reader.GetDateTime("FechaVencimiento");
                        factura.SetImporte(Convert.ToDouble(reader.GetDecimal("Total")));
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al buscar factura por ID: " + e.Message);
            }
            return factura;
        }

        public List<Factura> BuscarFacturasPorFechaEmision(DateTime fechaEmision)
        {
            List<Factura> facturasEncontradas = new List<Factura>();

            string sql = "SELECT * FROM facturas WHERE FechaEmision = @FechaEmision";

            try
            {
                MySqlCommand command = new MySqlCommand(sql, conexion);
                command.Parameters.AddWithValue("@FechaEmision", fechaEmision);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Crear una instancia de Factura y agregarla a la lista de facturas encontradas
                        Factura factura = new Factura();
                        factura.idFactura = reader.GetInt32("idFactura");
                        factura.SetidCliente(reader.GetInt32("idCliente"));
                        factura.FechaEmision = reader.GetDateTime("FechaEmision");
                        factura.FechaVencimiento = reader.GetDateTime("FechaVencimiento");
                        factura.SetImporte(Convert.ToDouble(reader.GetDecimal("Total")));
                        facturasEncontradas.Add(factura);
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al buscar facturas por fecha de emisión: " + e.Message);
            }

            return facturasEncontradas;
        }

        public List<Factura> ObtenerFacturasPorIdCliente(int idCliente)
        {
            List<Factura> facturas = new List<Factura>();

            try
            {
               

                string consulta = "SELECT * FROM Facturas WHERE idCliente = @IdCliente";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Factura factura = new Factura();
                        factura.idFactura = reader.GetInt32("IDFactura");
                        factura.SetidCliente(reader.GetInt32("idCliente"));
                        factura.FechaEmision = reader.GetDateTime("FechaEmision");
                        factura.FechaVencimiento = reader.GetDateTime("FechaVencimiento");
                        factura.SetImporte(Convert.ToDouble(reader.GetDecimal("Total")));

                        facturas.Add(factura);
                    }
                    // Itera sobre las filas del resultado y muestra cada una en la consola
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i].ToString() + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener las facturas del cliente: " + ex.Message);
            }

            return facturas;
        }

    }
}

