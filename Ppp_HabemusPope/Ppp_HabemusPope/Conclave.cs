using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppp_HabemusPope
{
    public class Conclave
    {
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;
        public static int cantidadVotaciones;
        public static DateTime fechaVotacion;

        public Conclave()
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
            this._cardenales = new List<Cardenal>();
            Conclave.fechaVotacion = DateTime.Now;
            Conclave.cantidadVotaciones = 0;
        }
        
        /*private static Conclave()
        {
            Conclave.fechaVotacion = DateTime.Now;
            Conclave.cantidadVotaciones = 0;
        }*/
        
        private Conclave(int cantidadcardenales)
            :this()
        {
            this._cantMaxCardenales = cantidadcardenales;
        }

        public Conclave(int cantidadcardenales, string lugareleccion)
            :this(cantidadcardenales)
        {
            
        }

        public static implicit operator Conclave(int cantidadcardenales)
        {
            return new Conclave(cantidadcardenales);
        }
        
        public static explicit operator bool(Conclave con)
        {
            return con._habemusPapa;
        }

        private bool HayLugar()
        { 
            if(this._cardenales.Count <= this._cantMaxCardenales)
            {
                return false;
            }

            return true;
        }

        private string MostrarCardenales() 
        {

            StringBuilder str = new StringBuilder();
            str.Append("-----------Cardenales----------");
            foreach (var item in this._cardenales)
            {
                str.AppendLine(Cardenal.Mostrar(item));
                str.AppendLine("----------------------------");
            }

            return str.ToString();
        }

        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.Append("Lugar: "+this._lugarEleccion+"Fecha: "+ Conclave.fechaVotacion + "CanVotos: " + Conclave.cantidadVotaciones);
            
            if (this._habemusPapa)
                str.AppendLine("HABEMUS PAPA " + this._papa.getNombreYNombrePapal());
            else
                str.AppendLine("NON HABEMUS PAPA");

            str.AppendLine(this.MostrarCardenales());

            return str.ToString();
        }

        public static bool operator ==(Conclave conc, Cardenal cardenal)
        {
            foreach (var item in conc._cardenales)
            {
                if (item == cardenal)
                    return true; 
            }

            return false;
        }

        public static bool operator !=(Conclave conc, Cardenal cardenal)
        {
            foreach (var item in conc._cardenales)
            {
                if (item == cardenal)
                    return false;
            }

            return true;
        }

        public static Conclave operator +(Conclave con, Cardenal cardenal)
        {
            if (con == cardenal)
                Console.WriteLine("No hay mas lugar!!!");
                return con;
            if (!(con == cardenal))
                Console.WriteLine("No hay mas lugar!!!");
                return con;

            con._cardenales.Add(cardenal);

            return con;
        }

        public static void VotarPapa(Conclave con)
        {
            Random rnd = new Random();
            int indicePapal;

            for (int i = 0; i < con._cardenales.Count; i++)
            {
                indicePapal = rnd.Next(0, con._cardenales.Count);
                con._cardenales[indicePapal]++;

            }
        }

        private void ContarVotos(Conclave con)
        {
            int ganador=0;
            Cardenal papa = null;
            
            foreach (var item in this._cardenales)
            {
                if (item.getCantidadVotosRecibidos() > ganador)
                {
                    ganador = item.getCantidadVotosRecibidos();
                    papa = item;
                }
                if (item.getCantidadVotosRecibidos() == ganador)
                {
                    papa = null;
                }
            }

            if (papa != null)
            {
                con._papa = papa;
                con._habemusPapa = true;
            }
            else
                con._habemusPapa = false;
        }
    }
}
