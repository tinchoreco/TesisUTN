using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Factura
{
    public int? idFactura { get; set; }
    private int idCliente;
    private DateTime fechaEmision;
    private DateTime fechaVencimiento;
    private double importe;
    private String estado;

    // Constructor
    public Factura()
    {

    }

    public Factura(int idCliente, DateTime fechaEmision, DateTime fechaVencimiento, double importe)
    {
        this.idCliente = idCliente;
        this.fechaEmision = fechaEmision;
        this.fechaVencimiento = fechaVencimiento;
        this.importe = importe;
        this.estado = "pendiente";
    }

    public int GetidCliente()
    {
        return idCliente;
    }

    public void SetidCliente(int idCliente)
    {
        this.idCliente = idCliente;
    }

    public double GetImporte()
    {
        return importe;
    }

    public void SetImporte(double importe)
    {
        this.importe = importe;
    }

    public string GetEstado()
    {
        return estado;
    }

    public void SetEstado(string estado)
    {
        this.estado = estado;
    }

    public DateTime FechaEmision
    {
        get { return fechaEmision; }
        set { fechaEmision = value; }
    }

    // Getter y Setter para fechaVencimiento
    public DateTime FechaVencimiento
    {
        get { return fechaVencimiento; }
        set { fechaVencimiento = value; }
    }
}
