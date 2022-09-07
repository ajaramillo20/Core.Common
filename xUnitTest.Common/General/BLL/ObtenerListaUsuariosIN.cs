using Core.Common.Model.General;
using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Common.Test.Modelos.ProcessTemplate;
using Core.Common.Util.Helper.API;

namespace Core.Common.Test.General.BLL
{
    public class ObtenerListaUsuariosIN : IObtenerTodos<TestTrx, TestResponse>
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


        public void ValidarInformacion(TestTrx objetoTransaccional)
        {
            objetoTransaccional.DatoTrx004++;
        }
    }
}
