using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public float SueldoBase { get; set; }
        public Empleado(string nombre)
        {
            Nombre = nombre;
        }

        public virtual float CalcularSueldo()
        {
            return SueldoBase;
        }
    }

    class Temporal : Empleado
	{
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
		public Temporal(string nombre)
            : base(nombre)
        {}

	}

    class Freelance : Empleado
	{
        public float PrecioHora { get; set; }
        public float HorasMes { get; set; }

		public Freelance(string nombre)
            : base(nombre)
        {}

        public override float CalcularSueldo()
        {
            return PrecioHora * HorasMes;
        }
	}

    class Fijo : Empleado
	{
        public int AniosEmpresa { get; set; }
        public float ComplementoAnual { get; set; }

		public Fijo(string nombre)
            : base(nombre)
        {}

        public override float CalcularSueldo()
        {
            return SueldoBase + (ComplementoAnual * AniosEmpresa);
        }
	}
    class Program
    {
        

        static void Main(string[] args)
        {
            Fijo empFijo = new Fijo("Fidel") {
                SueldoBase = 1500,
                AniosEmpresa = 5,
                ComplementoAnual = 120
            };
            Freelance empFreelance = new Freelance("Freddy") {
                HorasMes = 60,
                PrecioHora = 15
            };
            Temporal empTemp = new Temporal("Tomas") {
                SueldoBase = 2300
            };
            List<Empleado> empleados = new List<Empleado> { };
            empleados.Add(empFijo);
            empleados.Add(empTemp);
            empleados.Add(empFreelance);
            calcularSueldos(empleados);

            Console.ReadKey();
        }

        private static void calcularSueldos(List<Empleado> empleados)
        {
            foreach (var empleado in empleados)
            {
                Console.WriteLine("Nombre:{0} Sueldo:{1}", empleado.Nombre, empleado.CalcularSueldo());
            }
        }
    }
}
