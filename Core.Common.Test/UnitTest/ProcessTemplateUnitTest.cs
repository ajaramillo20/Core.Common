using Core.Common.Model.General;
using Core.Common.Test.General.BLL;
using Core.Common.Test.Modelos.ProcessTemplate;
using Core.Common.Util.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Core.Common.Test.UnitTest
{
    [TestClass]
    public class UnitTest1 : ControllerBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestRequest request = new TestRequest();
            request.DatoRequest001 = "1716308216";
            request.DatoRequest002 = "ObtenerDatosPrincipales";

            //TestTrx transaccion = new TestTrx();
            //EstructuraBase<TestTrx> respuesta2 = 
            //EstructuraBase <TestResponse> respuesta = CrudProcessTemplate<TestRequest,TestResponse>();

            //CrudProcessTemplate<TestTrx, TestResponse> crud = CrudProcessTemplate<TestTrx, TestResponse>(logica).;
            //crud.Insertar(respuesta2);


            TestTrx transaccion = this.GenerarTransaccion<TestTrx>();

            transaccion.DatoTrx001 = "";
            transaccion.DatoTrx002 = "SOY";
            transaccion.DatoTrx003 = "carlos";
            //TestResponse response = new TestResponse();
            //EstructuraBase<TestTrx> transaccion = new EstructuraBase<TestTrx>(transaccionReal);

            //TestInsertarObjetoIN logica = new TestInsertarObjetoIN();
            //EstructuraBase<TestResponse> respue = new CrudProcessTemplate<TestTrx, TestResponse>(new TestInsertarObjetoIN()).Insertar(transaccionReal);


            EstructuraBase<TestResponse> respue = this.Obtener<TestTrx, TestResponse, TestInsertarObjetoIN>(new TestInsertarObjetoIN(), transaccion);


            Console.WriteLine(respue.ToString());
        }
    }
}