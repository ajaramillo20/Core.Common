using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Catalogos
{
    public class DetalleCatalogo
    {
        public DetalleCatalogo() { }

        public DetalleCatalogo(int id, string codigoDetalle, string valor, string nombre)
        {
            this.Id = id;
            this.CodigoDetalle = codigoDetalle;
            this.Valor = valor;
            this.Nombre = nombre;
        }

        public int Id { get; set; }

        public string CodigoCatalogo { get; set; }

        public string CodigoDetalle { get; set; }

        public string Valor { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

    }
}
