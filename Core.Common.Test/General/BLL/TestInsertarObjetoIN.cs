using Core.Common.BusinessLogic.ProcessTemplate;
using Core.Common.Model.General;
using Core.Common.Model.Transaccion;
using Core.Common.Test.Modelos.ProcessTemplate;
using Core.Common.Util.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Test.General.BLL
{
    public class TestInsertarObjetoIN : IObtener<TestTrx, TestResponse>
    {
        public void AgregarInformacion(TestTrx objetoTransaccional)
        {
            objetoTransaccional.DatoTrx001 = "AgregarInformacion";
            objetoTransaccional.DatoTrx002 = "AgregarInformacion";
            objetoTransaccional.DatoTrx004++;
        }

        public TestResponse ArmaraPaginaRespuesta(TestTrx objetoTransaccional)
        {
            throw null;
        }

        public TestResponse ArmarObjetoRespuesta(TestTrx objetoTransaccional)
        {
            if (objetoTransaccional.Resultado.CodigoRespuesta == (int)Error.OperacionExitosa)
            {
                TestResponse respuesta = new TestResponse();
                return MapHelper.MapeoDinamicoRespuesta(objetoTransaccional, respuesta);
            }
            else
                return null;
        }

        public void ValidarInformacion(TestTrx objetoTransaccional)
        {
            objetoTransaccional.DatoTrx004++;
        }
    }
}
