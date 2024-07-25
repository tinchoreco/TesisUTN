using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Recibo
{
    private int idRecibo;
    private int idFactura;
    private int idCliente;
    private double montoTotal;
    private DateTime fechaEmision;
    private string metodoPago;
    private string comentario; 

    // Constructor por defecto
    public Recibo()
    {
    }

    // Constructor con parámetros
    public Recibo(int idFactura, int idCliente, double montoTotal, DateTime fechaEmision, string metodoPago, string comentario)
    {
        this.idFactura = idFactura;
        this.idCliente = idCliente;
        this.montoTotal = montoTotal;
        this.fechaEmision = fechaEmision;
        this.metodoPago = metodoPago;
        this.comentario = comentario;
    }
    // Getters y Setters
    public int GetIdRecibo()
    {
        return idRecibo;
    }

    public void SetIdRecibo(int idRecibo)
    {
        this.idRecibo = idRecibo;
    }

    public int GetIdFactura()
    {
        return idFactura;
    }

    public void SetIdFactura(int idFactura)
    {
        this.idFactura = idFactura;
    }
    
    public int GetIdCliente()
    {
        return idCliente;
    }

    public void SetIdCliente(int idCliente)
    {
        this.idCliente = idCliente;
    }

    public double GetMontoTotal()
    {
        return montoTotal;
    }

    public void SetMontoTotal(double montoTotal)
    {
        this.montoTotal = montoTotal;
    }

    public DateTime GetFechaEmision()
    {
        return fechaEmision;
    }

    public void SetFechaEmision(DateTime fechaEmision)
    {
        this.fechaEmision = fechaEmision;
    }

    
    public string GetMetodoPago()
    {
        return metodoPago;
    }

    public void SetMetodoPago(string metodoPago)
    {
        this.metodoPago = metodoPago;
    }

    public string GetComentario()
    {
        return comentario;
    }

    public void SetComentario(string comentario)
    {
        this.comentario = comentario;
    }

    
}


