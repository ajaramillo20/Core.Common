using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util.Helper.Datos
{
    public static class StringHelper
    {
        public static string ToJson(this object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }
    }
}
