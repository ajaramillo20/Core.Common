using Core.Common.Model.Transaccion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.ExcepcionServicio
{
    public  class ExcepcionServicio : System.Exception
    {

        public ExcepcionServicio() {
            FuenteError = "MICROSERVICIOS";
            MensajeExcepcion = new Mensaje(9999, "Error en el proceso. Contacte al Administrador.", true, "Microservicios");            
        }

        public ExcepcionServicio(Mensaje mensaje, string fuenteError) { 
            FuenteError = fuenteError;
            MensajeExcepcion = mensaje;
        }

        public ExcepcionServicio(Exception exception, string fuenteError)
        {
            FuenteError = fuenteError;
            MensajeExcepcion = new Mensaje(exception.HResult, exception.Message, true, exception.Source);
        }
        
        public string FuenteError { get; set; }    
        public Mensaje MensajeExcepcion { get; }

    }
}
