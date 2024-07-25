using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cliente
{
    public int? idCliente { get; set; }
    private string nombre;
    private string cuit;
    private string telefono;
    private string direccion;
    private string ciudad;
    private string pais;
    private string codigoPostal;

    // Constructor
    public Cliente(string nombre, string cuit, string telefono, string direccion, string ciudad, string pais, string codigoPostal)
    {
        this.nombre = nombre;
        this.cuit = cuit;
        this.telefono = telefono;
        this.direccion = direccion;
        this.ciudad = ciudad;
        this.pais = pais;
        this.codigoPostal = codigoPostal;
    }

    // Constructor sin argumentos
    public Cliente()
    {
    }

    // Getters y Setters
    public string GetNombre()
    {
        return nombre;
    }

    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }
    
    public string GetCuit()
    {
        return cuit;
    }

    public void SetCuit(string cuit)
    {
        this.cuit = cuit;
    }

    public string GetTelefono()
    {
        return telefono;
    }

    public void SetTelefono(string telefono)
    {
        this.telefono = telefono;
    }

    public string GetDireccion()
    {
        return direccion;
    }

    public void SetDireccion(string direccion)
    {
        this.direccion = direccion;
    }

    public string GetCiudad()
    {
        return ciudad;
    }

    public void SetCiudad(string ciudad)
    {
        this.ciudad = ciudad;
    }

    public string GetPais()
    {
        return pais;
    }

    public void SetPais(string pais)
    {
        this.pais = pais;
    }

    public string GetCodigoPostal()
    {
        return codigoPostal;
    }

    public void SetCodigoPostal(string codigoPostal)
    {
        this.codigoPostal = codigoPostal;
    }
}

