//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Utilities.Common
//{
//    class Config
//    {
//    }
//}


using System;
using System.Collections.Generic;
using System.IO;
//using System.Configuration;

namespace Utilities.Common
{
    public class Config
    {
        #region SingleTon Instance
        private static Config _instancia;

        private static object syncRoot = new Object();

        public Config() { }

        public static Config Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (syncRoot)
                    {
                        _instancia = new Config();

                    }
                }
                return _instancia;
            }
        }
        #endregion

        #region Constantes de configuración

        private Dictionary<string, string> ConstantesDeConfiguracion = new Dictionary<string, string>()
        {
        {
                "URL_EXT_API_ALBUM", "http://jsonplaceholder.typicode.com/albums/"}

        };
        #endregion


        
        /// <summary>
        /// Obtiene un valor de configuración
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Valor de configuracion</returns>
        public String ObtenerConfiguracion(string key)
        {
            string valor = "";

            ConstantesDeConfiguracion.TryGetValue(key, out valor);

            return valor;
        }
    }
}

