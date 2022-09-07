using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace Core.Common.Util.Helper.API
{
    public static class ExcelFileHelper
    {

        //public static bool GenerarExcelEnRutaLocal<T>(IEnumerable<T> dt, string ruta, string nombreArchivo)
        //{
        //    XLWorkbook wb = new XLWorkbook();
        //    //wb.Worksheets.Add(dt, "WorksheetName");
        //    wb.AddWorksheet("sheetname").FirstCell().InsertTable(dt);
        //    wb.SaveAs(@"" + ruta + nombreArchivo +".xlsx");

        //    return true;
        //}

        //public static MemoryStream GenerarExcelParaDescarga<T>(IEnumerable<T> dt)
        //{
        //    MemoryStream fs = new MemoryStream();
        //    XLWorkbook wb = new XLWorkbook();

        //    wb.AddWorksheet("OPERACIONES").FirstCell().InsertTable(dt);
        //    wb.SaveAs(fs);

        //    fs.Position = 0;
        //    return fs;
        //}

        //public static MemoryStream GenerarExcelParaDescargaNew(string codigoIFI, List<ResultadoClasificacionOfertaCartera> listaOperacionesGAF)
        //{
        //    /*  IFI-004	BANCO DE GUAYAQUIL	0
        //        IFI-005	BANCO DE LOJA	0
        //        IFI-006	BANCO DEL PICHINCHA	0
        //        IFI-001	BANCO AMAZONAS	0
        //        IFI-009	BANCO CAPITAL	0
        //        IFI-013	COOPROGRESO	0
        //        IFI-015	PRODUBANCO	0
        //        IFI-016	COOPUCE	0
        //        IFI-008	BANCO GENERAL RUMIÑAHUI	1
        //        IFI-003	BANCO BOLIVARIANO	1
        //        IFI-007	BANCO INTERNACIONAL	1
        //        IFI-002	BANCO AUSTRO	1
        //        IFI-014	MUTUALISTA PICHINCHA	1
        //        IFI-012	COOP. TULCAN	1
        //        IFI-011	COOP. PABLO MUÑOZ VEGA	1
        //        IFI-017	RHOMY	1
        //        IFI-010	COOP. 29 OCTUBRE	1   */

        //    switch (codigoIFI)
        //    {

        //        case "IFI-007":  //BI
        //            return FormatosOfertaIFIs.ConstruirExcelOferta_BancoInternacional(listaOperacionesGAF);

        //        case "IFI-003":  //BB
        //            return FormatosOfertaIFIs.ConstruirExcelOferta_BancoBolivariano(listaOperacionesGAF);

        //        case "IFI-008":  //BGR
        //            return FormatosOfertaIFIs.ConstruirExcelOferta_BancoGeneralRuminiahui(listaOperacionesGAF);

        //        case "IFI-012":  //CT
        //            return FormatosOfertaIFIs.ConstruirExcelOferta_CooperativaTulcan(listaOperacionesGAF);

        //        case "IFI-014":  //MUPI
        //            return FormatosOfertaIFIs.ConstruirExcelOferta_MutualistaPichincha(listaOperacionesGAF);

        //        default:
        //            return FormatosOfertaIFIs.ConstruirExcelOferta_Default(listaOperacionesGAF);
        //    }
        //}




        //public static MemoryStream GenerarExcelFormatoIFI<T,R>(string codigoIFI, IEnumerable<T> datosBase, IEnumerable<R> datosParametros)
        //{
        //    MemoryStream fs = new MemoryStream();
        //    XLWorkbook wb = new XLWorkbook();

        //    wb.AddWorksheet("BASE BI").FirstCell().InsertTable(datosBase);
        //    wb.AddWorksheet("PARAMETROS").FirstCell().InsertTable(datosParametros);

        //    wb.SaveAs(fs);

        //    fs.Position = 0;
        //    return fs;
        //}

        //public static bool ValidarExtensionArchivo(Stream archivo)
        //{
        //    using (XLWorkbook workBook = new XLWorkbook(archivo))
        //    {
        //        IXLWorksheet workSheet = workBook.Worksheet(1);
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// Metodo para obtener los datos del archivo de "Respuesta de Oferta" y mapearlos en el objeto OFC_ESTADO_OPERACION
        ///// </summary>
        ///// <param name="archivo"></param>
        ///// <returns></returns>
        //public static List<OFC_ESTADO_OPERACION> ObtenerDatosRespuestaOfertaExcel(Stream archivo, DateTime fechaVenta)
        //{
        //    var listaRespuestas = new List<OFC_ESTADO_OPERACION>();

        //    if (archivo.Length == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        using (XLWorkbook workBook = new XLWorkbook(archivo))
        //        {
        //            IXLWorksheet workSheet = workBook.Worksheet(1);

        //            int cantidadRegistros = workSheet.RowsUsed().Count();
        //            int cantidadCampos = workSheet.ColumnsUsed().Count();

        //            if (cantidadCampos == 9)
        //            {
        //                for (int fila = 2; fila < cantidadRegistros + 1; fila++)
        //                {
        //                    listaRespuestas.Add(
        //                        new OFC_ESTADO_OPERACION()
        //                        {
        //                            IFI_CODIGO = workSheet.Cell(fila, 1).Value.ToString(),
        //                            OPERACION_GAF = Convert.ToInt32(workSheet.Cell(fila, 3).Value.ToString()),
        //                            //EST_OFERTA = true,
        //                            EST_RESPUESTA = true,
        //                            EST_FECHA_RESPUESTA = fechaVenta,
        //                            //EST_FECHA_OFERTA = DateTime.Now,
        //                            EST_TIPO_RESPUESTA = workSheet.Cell(fila, 4).Value.ToString(),
        //                            TPR_CODIGO_PRODUCTO = workSheet.Cell(fila, 8).Value.ToString(),
        //                            EST_OBSERVACION_RESPUESTA = workSheet.Cell(fila, 9).Value.ToString()
        //                        }
        //                    );
        //                }
        //                return listaRespuestas;
        //            }
        //            else
        //            {

        //                return null;

        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Metodo para obtener todos los datos que incluyen la hoja de un archivo excel, este metodo considera celdas vacias o con formato como si fueran informacion en blanco.
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        //public static object ObtenerDatosArchivExcel(Stream archivo)
        //{

        //    using (XLWorkbook workBook = new XLWorkbook(archivo))
        //    {
        //        //Read the first Sheet from Excel file.
        //        IXLWorksheet workSheet = workBook.Worksheet(1);

        //        //Create a new DataTable.
        //        DataTable dt = new DataTable();

        //        //Loop through the Worksheet rows.
        //        bool firstRow = true;
        //        foreach (IXLRow row in workSheet.Rows())
        //        {
        //            //Use the first row to add columns to DataTable.
        //            if (firstRow)
        //            {
        //                foreach (IXLCell cell in row.Cells())
        //                {
        //                    dt.Columns.Add(cell.Value.ToString());
        //                }
        //                firstRow = false;
        //            }
        //            else
        //            {
        //                //Add rows to DataTable.
        //                dt.Rows.Add();
        //                int i = 0;
        //                foreach (IXLCell cell in row.Cells())
        //                {
        //                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
        //                    i++;
        //                }
        //            }
        //        }
        //        return dt;
        //    }
        //}



    }
}
