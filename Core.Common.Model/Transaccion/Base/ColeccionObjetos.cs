using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Transaccion.Base
{
    public class ColeccionObjetos<T> : List<T>
    {
        protected int _intTotalRegistros;

        IList<T> data { get; set; }

        public static bool IsReadOnly { get; set; }



        public ColeccionObjetos() { }

        public ColeccionObjetos(IList<T> lstLista)
        {
            data = lstLista;
        }



    }
}
