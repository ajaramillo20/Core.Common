using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Common.Test.General.BLL;
using Core.Common.Test.Modelos.ProcessTemplate;
using Microsoft.AspNetCore.Mvc;

namespace xUnitTest.Common.UnitTest
{
    public class ProcessTemplateTestDebe : ControllerBase
    {
        [Fact]
        public void EjecutarArquitecturaCompleta()
        {
            //Preparar
            TestRequest request = new TestRequest();
            request.DatoRequest001 = "1716308216";
            request.DatoRequest002 = "ObtenerDatosPrincipales";

            //Actuar
            TestTrx transaccion = this.GenerarTransaccion<TestTrx>();
            transaccion.DatoTrx001 = "";
            transaccion.DatoTrx002 = "SOY";
            transaccion.DatoTrx003 = "carlos";
            transaccion.Endpoint.LogicaInyectada = "ObtenerListaUsuarios";
            EstructuraBase<TestResponse> respue = this.ObtenerTodos<TestTrx, TestResponse, ObtenerListaUsuariosIN>(new ObtenerListaUsuariosIN(), transaccion);

            //Confirmar
            Assert.True(respue!=null);
        }
    }
}