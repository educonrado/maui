using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace econradoT3.Model
{
    public class Contacto
    {


        public int ID;

        public Contacto(string identificacion, string nombre, string apellido, DateTime fecha, double salario, string aportes)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Fecha = fecha;
            Salario = salario;
            Aportes = aportes;
        }

        public string Identificacion {get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha { get; set; }
        public double Salario { get; set; }
        public string Aportes { get; set; }

        public override string? ToString() => $"Identificación: {Identificacion ?? "N/A"}, Nombre: {Nombre ?? "N/A"} {Apellido ?? "N/A"}, Fecha: {Fecha:yyyy-MM-dd}, Salario: {Salario:C}, Aporte IESS: {Aportes}";
    }
}
