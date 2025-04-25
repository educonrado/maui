using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace econradoT3.Model
{
    internal class Contacto
    {


        public int ID;

        public Contacto(string identificacion, string nombre, string apellido, DateTime fecha, double salario)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Fecha = fecha;
            Salario = salario;
        }

        public string Identificacion {get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha { get; set; }
        public double Salario { get; set; }
    }
}
