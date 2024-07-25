using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteFacturaRecibo
{
    public class Controlador
    {
        private ClienteDAO clienteDAO;
        private FacturaDAO facturaDAO;
        private ReciboDAO reciboDAO;

        public Controlador()
        {
            clienteDAO = new ClienteDAO();
            facturaDAO = new FacturaDAO();
            reciboDAO = new ReciboDAO();
        }

        public void AgregarCliente(Cliente cliente)
        {
            clienteDAO.AgregarCliente(cliente);
        }

        public void ModificarCliente(Cliente cliente)
        {
            clienteDAO.ModificarCliente(cliente);
        }

        public void EliminarCliente(int idCliente)
        {
            clienteDAO.EliminarCliente(idCliente);
        }

        public Cliente BuscarClientePorID(int idCliente)
        {
            return clienteDAO.BuscarClientePorId(idCliente);
        }

        public List<Cliente> BuscarClientePorNombre(string nombre)
        {
            return clienteDAO.BuscarClientesPorNombre(nombre);
        }

        public Factura BuscarFacturaPorId(int idFactura)
        {
            return facturaDAO.BuscarFacturaPorId(idFactura);
        }

        public List<Factura> BuscarFacturasPorFechaEmision(DateTime fechaEmision)
        {
            return facturaDAO.BuscarFacturasPorFechaEmision(fechaEmision);
        }

        public void AgregarFactura(Factura factura)
        {
            facturaDAO.AgregarFactura(factura);
        }

        public void ModificarFactura(Factura factura)
        {
            facturaDAO.ModificarFactura(factura);
        }

        public void EliminarFactura(int idFactura)
        {
            facturaDAO.EliminarFactura(idFactura);
        }

        public void AgregarRecibo(Recibo recibo)
        {
            reciboDAO.AgregarRecibo(recibo);
        }

        public void ModificarRecibo(Recibo recibo)
        {
            reciboDAO.ModificarRecibo(recibo);
        }

        public void EliminarRecibo(int idRecibo)
        {
            reciboDAO.EliminarRecibo(idRecibo);
        }

        public List<Factura> ObtenerFacturasPorIdCliente(int idCliente) 
        {
            return facturaDAO.ObtenerFacturasPorIdCliente(idCliente);

        }

        public Recibo BuscarReciboPorId(int idRecibo)
        {
            return reciboDAO.BuscarReciboPorId(idRecibo);
        }

        public List<Recibo> BuscarRecibosPorIdCliente(int idCliente)
        {
            return reciboDAO.BuscarRecibosPorIdCliente(idCliente);
        }

        public List<Recibo> BuscarRecibosPorFechaEmision(DateTime fechaEmision)
        {
            return reciboDAO.BuscarRecibosPorFechaEmision(fechaEmision);
        }
    }
}
