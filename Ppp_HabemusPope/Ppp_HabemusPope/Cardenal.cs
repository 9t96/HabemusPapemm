using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppp_HabemusPope
{
    public class Cardenal
    {
        private int _cantVotosRecibidos;
        private ENacionalidades _nacionalidad;
        private string _nombre;
        private string _nombrePapal;


        private Cardenal()
        {
            this._cantVotosRecibidos = 0;   
        }

        public Cardenal(string nombre, string nombrepapal)
            :this()
        {
            this._nombre = nombre;
            this._nombrePapal = nombrepapal;
        }

        public Cardenal(string nombre, string nombrepapal, ENacionalidades nacionalidad)
            :this(nombre,nombrepapal)
        {
            this._nacionalidad = nacionalidad;
        }

        public int getCantidadVotosRecibidos()
        {
            return this._cantVotosRecibidos;
        }

        public string getNombreYNombrePapal()
        {
            StringBuilder str = new StringBuilder();

            str.Append("El cardenal ");
            str.Append(this._nombre);
            str.Append(" se llamara");
            str.Append(this._nombrePapal);

            return str.ToString();
        }

        private string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.Append(this.getNombreYNombrePapal());
            str.AppendLine("Nacionalidad: " + this._nacionalidad.ToString());

            return str.ToString();
        }

        public static string Mostrar(Cardenal cardenal)
        {
            return cardenal.Mostrar();
        }

        public static bool operator ==(Cardenal c1, Cardenal c2)
        {
            if (c1._nombrePapal == c2._nombrePapal && c1._nombre == c2._nombre && c1._nacionalidad == c2._nacionalidad)
                return true;

            return false;
        }

        public static bool operator !=(Cardenal c1, Cardenal c2)
        {
            if (c1._nombrePapal == c2._nombrePapal && c1._nombre == c2._nombre && c1._nacionalidad == c2._nacionalidad)
                return false;

            return true;
        }

        public static Cardenal operator ++(Cardenal c1)
        {
            c1._cantVotosRecibidos+=1;

            return c1;
        }
    }
}