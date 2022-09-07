using AutoMapper;

namespace Core.Common.Util.Helper.API
{
    public static class AutoMapperHelper
    {

        public static ModeloAPI MapeoDinamicoSimpleAutoMapper<ModeloAPI, ModeloBDD>(ModeloBDD objEntrada)
        {
            var configuracionMapper = new MapperConfiguration(conf => conf.CreateMap<ModeloBDD, ModeloAPI>());
            var mapper = new Mapper(configuracionMapper);
            var objetoMapeado = mapper.Map<ModeloBDD, ModeloAPI>(objEntrada);
            return objetoMapeado;
        }


        public static List<ModeloAPI> MapeoDinamicoListasAutoMapper<ModeloAPI, ModeloBDD>(List<ModeloBDD> objEntrada)
        {
            var configuracionMapper = new MapperConfiguration(conf => conf.CreateMap<ModeloBDD, ModeloAPI>());
            var mapper = new Mapper(configuracionMapper);

            List<ModeloAPI> listaMapeada = new List<ModeloAPI>();

            foreach (var item in objEntrada)
            {
                var objetoMapeado = mapper.Map<ModeloBDD, ModeloAPI>(item);
                listaMapeada.Add(objetoMapeado);
            }

            return listaMapeada;
        }
    }
}
