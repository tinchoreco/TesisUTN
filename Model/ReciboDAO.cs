using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClienteFacturaRecibo
{
    public class ReciboDAO
    {
        private MySqlConnection conexion;
        private string connectionString = "server=localhost;port=3306;database=clientefacturarecibo;uid=root;password=123456";

        public ReciboDAO()
        {
            conexion = new MySqlConnection(connectionString);
            conexion.Open();
        }

        public void AgregarRecibo(Recibo recibo)
        {
            try
            {
                string query = "INSERT INTO Recibos (idFactura, idCliente, FechaEmision, MontoTotal, MetodoPago, Comentario) " +
                               "VALUES (@IdFactura, @IdCliente, @FechaEmision, @MontoTotal, @MetodoPago, @Comentario)";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdFactura", recibo.GetIdFactura());
                comando.Parameters.AddWithValue("@IdCliente", recibo.GetIdCliente());
                comando.Parameters.AddWithValue("@FechaEmision", recibo.GetFechaEmision());
                comando.Parameters.AddWithValue("@MontoTotal", recibo.GetMontoTotal());
                comando.Parameters.AddWithValue("@MetodoPago", recibo.GetMetodoPago());
                comando.Parameters.AddWithValue("@Comentario", recibo.GetComentario());
               
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar recibo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void ModificarRecibo(Recibo recibo)
        {
            try
            {
                string query = "UPDATE Recibos SET idFactura = @IdFactura, idCliente = @IdCliente, " +
                               "FechaEmision = @FechaEmision, MontoTotal = @MontoTotal, MetodoPago = @MetodoPago, " +
                               "Comentario = @Comentario WHERE idRecibo = @IdRecibo";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdFactura", recibo.GetIdFactura());
                comando.Parameters.AddWithValue("@IdCliente", recibo.GetIdCliente());
                comando.Parameters.AddWithValue("@FechaEmision", recibo.GetFechaEmision());
                comando.Parameters.AddWithValue("@MontoTotal", recibo.GetMontoTotal());
                comando.Parameters.AddWithValue("@MetodoPago", recibo.GetMetodoPago());
                comando.Parameters.AddWithValue("@Comentario", recibo.GetComentario());
                comando.Parameters.AddWithValue("@IdRecibo", recibo.GetIdRecibo());
                
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar recibo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void EliminarRecibo(int idRecibo)
        {
            try
            {
                string query = "DELETE FROM Recibos WHERE idRecibos = @idRecibos";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idRecibos", idRecibo);
                
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar recibo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public Recibo BuscarReciboPorId(int idRecibo)
        {

            Recibo recibo = null;
            string sql = "SELECT * FROM recibos WHERE idRecibos = @idRecibos";
            try
            {
                MySqlCommand command = new MySqlCommand(sql, conexion);
                command.Parameters.AddWithValue("@idRecibos", idRecibo);
                

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recibo = new Recibo();
                        recibo.SetIdRecibo(reader.GetInt32("idRecibos"));
                        recibo.SetIdFactura(reader.GetInt32("idFactura"));
                        recibo.SetIdCliente(reader.GetInt32("idCliente"));
                        recibo.SetMontoTotal(Convert.ToDouble(reader.GetDecimal("montoTotal")));
                        recibo.SetFechaEmision(reader.GetDateTime("fechaEmision"));
                        recibo.SetMetodoPago(reader.GetString("metodoPago"));
                        recibo.SetComentario(reader.GetString("comentario"));
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al buscar recibo por ID: " + e.Message);
            }
            return recibo;
        }

        public List<Recibo> BuscarRecibosPorFechaEmision(DateTime fechaEmision)
        {
            List<Recibo> recibosEncontrados = new List<Recibo>();

            string sql = "SELECT * FROM recibos WHERE fechaEmision = @FechaEmision";

            try
            {
                MySqlCommand command = new MySqlCommand(sql, conexion);
                command.Parameters.AddWithValue("@FechaEmision", fechaEmision);
                

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Crear una instancia de Recibo y agregarla a la lista de recibos encontrados
                        Recibo recibo = new Recibo();
                        recibo.SetIdRecibo(reader.GetInt32("idRecibos"));
                        recibo.SetIdFactura(reader.GetInt32("idFactura"));
                        recibo.SetIdCliente(reader.GetInt32("idCliente"));
                        recibo.SetMontoTotal(Convert.ToDouble(reader.GetDecimal("montoTotal")));
                        recibo.SetFechaEmision(reader.GetDateTime("fechaEmision"));
                        recibo.SetMetodoPago(reader.GetString("metodoPago"));
                        recibo.SetComentario(reader.GetString("comentario"));
                        recibosEncontrados.Add(recibo);
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al buscar recibos por fecha de emisión: " + e.Message);
            }

            return recibosEncontrados;
        }

        public List<Recibo> BuscarRecibosPorIdCliente(int idCliente)
        {
            List<Recibo> recibos = new List<Recibo>();
            string sql = "SELECT * FROM recibos WHERE idCliente = @IdCliente";
            try
            {
                MySqlCommand command = new MySqlCommand(sql, conexion);
                command.Parameters.AddWithValue("@IdCliente", idCliente);
                

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Recibo recibo = new Recibo();
                        recibo.SetIdRecibo(reader.GetInt32("idRecibos"));
                        recibo.SetIdFactura(reader.GetInt32("idFactura"));
                        recibo.SetIdCliente(reader.GetInt32("idCliente"));
                        recibo.SetFechaEmision(reader.GetDateTime("FechaEmision"));
                        recibo.SetMontoTotal(Convert.ToDouble(reader.GetDecimal("MontoTotal")));
                        recibo.SetComentario(reader.GetString("Comentario"));

                        recibos.Add(recibo);
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error al buscar recibos por ID de cliente: " + e.Message);
            }
            return recibos;
        }




    }
}
