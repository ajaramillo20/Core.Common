using System;

namespace Core.Common.Model.Transaccion.Base
{
    public class Mensaje
    {
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Mensaje() {
            Id = Guid.NewGuid();
            HuboError = false;
            FuenteError = "N/A";
            CodigoRespuesta = 10000;
            MensajeRespuesta = "Transacción Exitosa";
            CodigoInternoRespuesta = 10000;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="codigoRespuesta">Codigo de Respuesta</param>
        /// <param name="mensajeRespuesta">Mensaje de Respuesta</param>
        /// <param name="huboError">Flag de error</param>
        /// <param name="fuenteError">Namespace de la funte de error</param>
        public Mensaje(int codigoRespuesta, string mensajeRespuesta, bool huboError, string fuenteError, int codigoInternoRespuesta)
        {
            Id = Guid.NewGuid();
            HuboError = huboError;
            FuenteError = fuenteError;
            CodigoRespuesta = codigoRespuesta;
            MensajeRespuesta = mensajeRespuesta;
            CodigoInternoRespuesta = codigoInternoRespuesta;
        }

        /// <summary>
        ///  Identificador único para errores referenciales.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Flag que indica si una ejecución dio error o no
        /// </summary>
        public bool HuboError { get; }

        /// <summary>
        /// Namespace de la clase donde se origino el mensaje de error
        /// </summary>
        public string FuenteError { get; }

        /// <summary>
        /// Propiedad get que permite recuperar el código de respuesta de la ejecución
        /// </summary>
        public int CodigoRespuesta { get; }

        /// <summary>
        /// Mensaje descriptivo con la respuesta de la ejecución
        /// </summary>
        public string MensajeRespuesta { get; }

        /// <summary>
        /// Propiedad set que permite setear el código de respuesta de la ejecución
        /// </summary>
        public int CodigoInternoRespuesta { get; set; }
    }
}