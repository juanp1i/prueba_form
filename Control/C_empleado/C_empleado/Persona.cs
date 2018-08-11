using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_empleado
{
    public class Persona
    {
        //Atributos
        public String nombre { get; set; }
        public String sexo { get; set; }
        public int edad { get; set; }
        public String puesto { get; set; }
        public String foto { get; set; }
        public DateTime fechaIngreso { get; set; }

        //Constructores
        public Persona()
        {
            nombre = "";
            sexo = "";
            puesto = "";
            foto = "";
            edad = 0;
            fechaIngreso = DateTime.Now;
        }

        public Persona(string n, string s, string p, string fo, int e, DateTime f)
        {
            nombre = n;
            sexo = s;
            puesto = p;
            foto = fo;
            edad = e;
            fechaIngreso = f;
        }


        //Metodos
        public string Tipo_prestamo()
        {
            DateTime FechaActual = System.DateTime.Now;
            string prestamo = "";

            if (puesto.Equals("Presidente"))
                prestamo = "Especial";

            if (puesto.Equals("Abogado"))
                prestamo = "Ordinario";

            if (puesto.Equals("Ingeniero en Sistemas"))
                prestamo = "Normal";


            int diferencia = (fechaIngreso.Month - FechaActual.Month) + (12 * (FechaActual.Year - fechaIngreso.Year));
            if (puesto == "Tecnico")
            {
                if (diferencia >= 6)
                    prestamo = "Normal";

                else
                    prestamo = "Sin prestamo";
            }

            return prestamo;
        }

        public int sueldo_base()
        {
            int monto = 0;

            if (puesto.Equals("Presidente"))
                monto = 50000;

            if (puesto.Equals("Abogado"))
                monto = 30000;

            if (puesto.Equals("Ingeniero en Sistemas"))
                monto = 20000;

            if (puesto == "Tecnico")
                monto = 10000;

            return monto;
        }

        public int año_sabatico()
        {
            int asb = 0;

            if (puesto.Equals("Presidente"))
                asb = 3;

            else if (puesto.Equals("Abogado"))
                asb = 2;

            else if (puesto.Equals("Ingeniero en Sistemas"))
                asb = 1;

            else if (puesto == "Tecnico")
                asb = 0;

            return asb;
        }

        public int monto_prestamo()
        {

            if (Tipo_prestamo().Equals("Especial"))
                return 60000;

            else if (Tipo_prestamo().Equals("Ordinario"))
                return 30000;

            else if (Tipo_prestamo().Equals("Normal"))
                return 10000;

            else
                return 0;
        }

    }

    public class ArregloE
    {
        private Persona[] empleados;
        private int pos = 0;

        //Propiedades
        public Persona[] p_empleado
        {
            get { return empleados; }
        }        

        public int p_pos
        {
            get { return pos; }
        }


        //Constructor
        public ArregloE()
        {
            empleados = new Persona[5];
            pos = 5;
        }

        public ArregloE(int t)
        {
            empleados = new Persona[t];
            pos = t;
        }

        //Metodos
        public void ini_elemento(int p)
        {
            empleados[p] = new Persona();
        }

        public string llenar (string nom, string sex, string fo, string pue, int ed, DateTime fei, int pos)
        {
            empleados[pos] = new Persona();
            empleados[pos].nombre = nom;
            empleados[pos].sexo = sex;
            empleados[pos].puesto = pue;
            empleados[pos].foto = fo;
            empleados[pos].edad = ed;
            empleados[pos].fechaIngreso = fei;

            return null;
        }

        public string tipo_prestamos(int pos1)
        {
            return empleados[pos1].Tipo_prestamo();
        }

        public double sueldo_base(int pos1)
        {
            return empleados[pos1].sueldo_base();
        }

        public int año_sabatic(int pos1)
        {
            return empleados[pos1].año_sabatico();
        }

        public double monto_prestamos(int pos1)
        {
            return empleados[pos1].monto_prestamo();
        }

        public Persona buscar(string nom, int n)
        {
            
            for (int x = 0; x < n; x++)
            {
                if (nom.Equals(empleados[x].nombre))
                    return empleados[x];
            }

            return null;
        }
    }
}
