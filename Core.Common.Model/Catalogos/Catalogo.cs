using System.Collections.Generic;

namespace Core.Common.Model.Catalogos
{
    public class Catalogo
    {
        public Catalogo()
        {
            DetalleCatalogo Detalles = new DetalleCatalogo();
        }

        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public List<DetalleCatalogo> Detalles { get; set; }
    }    
}
