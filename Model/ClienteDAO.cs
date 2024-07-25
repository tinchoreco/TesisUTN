using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ClienteDAO
{
    private MySqlConnection conexion;
    private string url = "server=localhost;port=3306;database=clientefacturarecibo;uid=root;password=123456";

    public ClienteDAO()
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

    public void AgregarCliente(Cliente cliente)
    {
        string sql = "INSERT INTO clientes (nombre, direccion, cuit, telefono, ciudad, pais, codigoPostal) " +
                     "VALUES (@Nombre, @Direccion, @Cuit, @Telefono, @Ciudad, @Pais, @CodigoPostal)";
        try
        {
            MySqlCommand command = new MySqlCommand(sql, conexion);
            command.Parameters.AddWithValue("@Nombre", cliente.GetNombre());
            command.Parameters.AddWithValue("@Direccion", cliente.GetDireccion());
            command.Parameters.AddWithValue("@Cuit", cliente.GetCuit());
            command.Parameters.AddWithValue("@Telefono", cliente.GetTelefono());
            command.Parameters.AddWithValue("@Ciudad", cliente.GetCiudad());
            command.Parameters.AddWithValue("@Pais", cliente.GetPais());
            command.Parameters.AddWithValue("@CodigoPostal", cliente.GetCodigoPostal());
            command.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Error al agregar cliente: " + e.Message);
        }
    }

    public void ModificarCliente(Cliente cliente)
    {
        string query = "UPDATE clientes SET nombre = @Nombre, cuit = @Cuit, " +
                       "telefono = @Telefono, direccion = @Direccion, ciudad = @Ciudad, pais = @Pais, codigoPostal = @CodigoPostal " +
                       "WHERE idClientes = @idClientes";
        MySqlCommand cmd = new MySqlCommand(query, conexion);
        cmd.Parameters.AddWithValue("@Nombre", cliente.GetNombre());
        cmd.Parameters.AddWithValue("@Cuit", cliente.GetCuit());
        cmd.Parameters.AddWithValue("@Telefono", cliente.GetTelefono());
        cmd.Parameters.AddWithValue("@Direccion", cliente.GetDireccion());
        cmd.Parameters.AddWithValue("@Ciudad", cliente.GetCiudad());
        cmd.Parameters.AddWithValue("@Pais", cliente.GetPais());
        cmd.Parameters.AddWithValue("@CodigoPostal", cliente.GetCodigoPostal());
        cmd.Parameters.AddWithValue("@idClientes", cliente.idCliente);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Error al modificar cliente: " + e.Message);
            // Mostrar el mensaje de error en un MessageBox
            MessageBox.Show("Error al modificar cliente: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void EliminarCliente(int IDCliente)
    {
        string sql = "DELETE FROM clientes WHERE idClientes = @idClientes";
        try
        {
            MySqlCommand command = new MySqlCommand(sql, conexion);
            command.Parameters.AddWithValue("@idClientes", IDCliente);
            command.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Error al eliminar cliente: " + e.Message);
            // Mostrar el mensaje de error en un MessageBox
            MessageBox.Show("Error al modificar cliente: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public Cliente BuscarClientePorId(int idCliente)
    {
        Cliente cliente = null;
        string sql = "SELECT * FROM clientes WHERE IDClientes = @IDClientes";
        try
        {
            MySqlCommand command = new MySqlCommand(sql, conexion);
            command.Parameters.AddWithValue("@idClientes", idCliente);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    cliente = new Cliente();
                    cliente.idCliente = reader.GetInt32("idClientes");
                    cliente.SetNombre(reader.GetString("nombre"));
                    cliente.SetDireccion(reader.GetString("direccion"));
                    cliente.SetCuit(reader.GetString("cuit"));
                    cliente.SetTelefono(reader.GetString("telefono"));
                    cliente.SetCiudad(reader.GetString("ciudad"));
                    cliente.SetPais(reader.GetString("pais"));
                    cliente.SetCodigoPostal(reader.GetString("codigoPostal"));
                }
            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Error al buscar cliente por ID: " + e.Message);
        }
        return cliente;
    }

    public List<Cliente> BuscarClientesPorNombre(string nombre)
    {
        List<Cliente> clientesEncontrados = new List<Cliente>();

        string sql = "SELECT * FROM clientes WHERE nombre LIKE @Nombre";

        try
        {
            MySqlCommand command = new MySqlCommand(sql, conexion);
            command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Crear una instancia de Cliente y agregarla a la lista de clientes encontrados
                    int idCliente = reader.GetInt32("IDClientes");
                    string nombreCliente = reader.GetString("nombre");
                    string direccion = reader.GetString("direccion");
                    string cuit = reader.GetString("cuit");
                    string telefono = reader.GetString("telefono");
                    string ciudad = reader.GetString("ciudad");
                    string pais = reader.GetString("pais");
                    string codigoPostal = reader.GetString("codigoPostal");

                    Cliente cliente = new Cliente(nombreCliente, direccion, cuit, telefono, ciudad, pais, codigoPostal);
                    cliente.idCliente = idCliente;
                    clientesEncontrados.Add(cliente);
                }
            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Error al buscar clientes por nombre: " + e.Message);
        }

        return clientesEncontrados;
    }

    public void CerrarConexion()
    {
        if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
        {
            conexion.Close();
        }
    }
}

