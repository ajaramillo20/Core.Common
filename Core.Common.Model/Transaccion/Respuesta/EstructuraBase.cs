using Core.Common.Model.Transaccion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Transaccion.Respuesta
{
    public class EstructuraBase<T>
        where T : class
    {

        public EstructuraBase()
        {
            Meta = new Meta();
            Mensaje = new Mensaje();
            Links = new Link();
        }

        /// <summary>
        /// Constructor con parámetro
        /// </summary>
        /// <param name="item">Objeto con el que se inicializa la clase</param>
        public EstructuraBase(T item)
        {
            Data = item;
            Meta = new Meta();
            Mensaje = new Mensaje();
            Links = new Link();
        }

        /// <summary>
        /// Transacción a procesar
        /// </summary>
        public T Data { get; set; }

        public Link Links { get; set; }

        //
        // Summary:
        //     Estadística del proceso de la hora de entrada y salida
        public Meta Meta { get; set; }
        //
        // Summary:
        //     Código y mensaje de la respuesta del proceso
        public Mensaje Mensaje { get; set; }

    }
}
