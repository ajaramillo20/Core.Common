using Core.Common.Model.Catalogos;
using Core.Common.Model.General;

namespace Core.Common.Util.Helper.Datos
{
    public static class CatalogosHelper
    {
        private static DetalleCatalogo GetObtenerItemPorDefecto()
        {
            return new DetalleCatalogo(ConstantesCatalogo.ID_DEFAULT, ConstantesCatalogo.CODIGO_DEFAULT, ConstantesCatalogo.VALOR_DEFAULT, ConstantesCatalogo.NOMBRE_DEFAULT);
        }

        public static Catalogo ObtenerCatalogoPorNombre(string nombreCatalogo, bool defaultItem = false)
        {
            try
            {
                //using (BDDRiesgosEntities BDDRiesgos = new BDDRiesgosEntities())
                //{

                //    CAT_CABECERA_CATALOGO Catalogo = BDDRiesgos.CAT_CABECERA_CATALOGO
                //                            .Where(x => x.CCA_NOMBRE == nombreCatalogo).FirstOrDefault();

                //    List<CAT_DETALLE_CATALOGO> listaDetalles = BDDRiesgos.CAT_DETALLE_CATALOGO
                //                                    .Where(x => x.CCA_CODIGO == Catalogo.CCA_CODIGO && x.DCA_ESTADO == true)
                //                                    .ToList();

                //    List<DetalleCatalogo> listaDetalleCatalogo = new List<DetalleCatalogo>();

                //    if (defaultItem)
                //        listaDetalleCatalogo.Add(GetObtenerItemPorDefecto());

                //    foreach (var item in listaDetalles)
                //    {
                //        DetalleCatalogo detalleCatalogo = new DetalleCatalogo();

                //        detalleCatalogo.Id = item.DCA_ID;
                //        detalleCatalogo.CodigoCatalogo = item.CCA_CODIGO;
                //        detalleCatalogo.CodigoDetalle = item.DCA_CODIGO;
                //        detalleCatalogo.Estado = item.DCA_ESTADO;
                //        detalleCatalogo.Valor = item.DCA_VALOR;
                //        detalleCatalogo.Nombre = item.DCA_NOMBRE;
                //        detalleCatalogo.Descripcion = item.DCA_DESCRIPCION;

                //        listaDetalleCatalogo.Add(detalleCatalogo);
                //    }

                //    Catalogo resultCatalogo = new Catalogo()
                //    {
                //        Id = Catalogo.CCA_ID,
                //        Codigo = Catalogo.CCA_CODIGO,
                //        Nombre = Catalogo.CCA_NOMBRE,
                //        Descripcion = Catalogo.CCA_DESCRIPCION,
                //        Estado = Catalogo.CCA_ESTADO,
                //        Detalles = listaDetalleCatalogo
                //    };

                //    return resultCatalogo;
                //}
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public static Catalogo ObtenerCatalogoIFIS(bool defaultItem = false)
        {
            try
            {
                //using (BDDRiesgosEntities BDDRiesgos = new BDDRiesgosEntities())
                //{
                //    List<VTC_INSTITUCION_FINANCIERA> listaDetalles = BDDRiesgos.VTC_INSTITUCION_FINANCIERA
                //                                    .Where(x => x.IFI_ESTADO == true)
                //                                    .ToList();

                //    List<DetalleCatalogo> listaDetalleCatalogo = new List<DetalleCatalogo>();

                //    if (defaultItem)
                //        listaDetalleCatalogo.Add(GetObtenerItemPorDefecto());

                //    foreach (var item in listaDetalles)
                //    {
                //        DetalleCatalogo detalleCatalogo = new DetalleCatalogo();

                //        detalleCatalogo.Id = item.IFI_ID;
                //        detalleCatalogo.CodigoCatalogo = "IFIS";
                //        detalleCatalogo.CodigoDetalle = item.IFI_CODIGO;
                //        detalleCatalogo.Estado = item.IFI_ESTADO;

                //        detalleCatalogo.Valor = item.IFI_CODIGO;
                //        detalleCatalogo.Nombre = item.IFI_NOMBRE;

                //        listaDetalleCatalogo.Add(detalleCatalogo);
                //    }

                //    Catalogo resultCatalogo = new Catalogo()
                //    {
                //        Id = 1,
                //        Nombre = "IFIS",
                //        Descripcion = "CATALOGO DE IFIS",
                //        Detalles = listaDetalleCatalogo
                //    };

                //    return resultCatalogo;
                //}
                return null;
            }
            catch (Exception)
            {

                throw;
            }


        }






        public static Catalogo ObtenerCatalogoParametrosEvaluacion(bool defaultItem = false)
        {
            try
            {
                //using (BDDRiesgosEntities BDDRiesgos = new BDDRiesgosEntities())
                //{
                //    List<OFC_PARAMETRO_EVALUACION> listaDetalles = BDDRiesgos.OFC_PARAMETRO_EVALUACION
                //                                    .Where(x => x.PEV_ESTADO == true)
                //                                    .ToList();

                //    List<DetalleCatalogo> listaDetalleCatalogo = new List<DetalleCatalogo>();

                //    if (defaultItem)
                //        listaDetalleCatalogo.Add(GetObtenerItemPorDefecto());

                //    foreach (var item in listaDetalles)
                //    {
                //        DetalleCatalogo detalleCatalogo = new DetalleCatalogo();

                //        detalleCatalogo.Id = item.PEV_ID;
                //        detalleCatalogo.CodigoCatalogo = "PARAM-EVALUACION";
                //        detalleCatalogo.CodigoDetalle = item.PEV_CODIGO;
                //        detalleCatalogo.Estado = item.PEV_ESTADO;

                //        detalleCatalogo.Valor = item.PEV_CODIGO;
                //        detalleCatalogo.Nombre = item.PEV_DESCRIPCION;
                //        //detalleCatalogo.Descripcion = item.des;

                //        listaDetalleCatalogo.Add(detalleCatalogo);
                //    }

                //    Catalogo resultCatalogo = new Catalogo()
                //    {
                //        Id = 1,
                //        Nombre = "IFIS",
                //        Descripcion = "CATALOGO DE IFIS",
                //        Detalles = listaDetalleCatalogo
                //    };

                //    return resultCatalogo;
                //}
                return null;
            }
            catch (Exception)
            {

                throw;
            }


        }



    }
}
