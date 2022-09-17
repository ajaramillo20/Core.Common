using Core.Common.Model.Transaccion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.ExcepcionServicio
{
    public class ExcepcionServicio : System.Exception
    {
        public ExcepcionServicio(Exception exception)
        {
            Mensaje = new Mensaje(exception.HResult, exception.Message, true, exception.Source);
        }

        public ExcepcionServicio(int codigoInternoError)
        {
            CodigoInternoRespuesta = codigoInternoError;
        }

        public Mensaje Mensaje { get; set; }
        public int CodigoInternoRespuesta { get; set; }
    }
}
