//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Utilities.Common
//{
//    class Http
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Utilities.Common
{
    public class Http
    {
        #region SingleTon Instance
        private static Http _instancia;

        private static object syncRoot = new Object();

        public Http() { }

        public static Http Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (syncRoot)
                    {
                        _instancia = new Http();

                    }
                }
                return _instancia;
            }
        }
        #endregion

        /// <summary>
        /// Get estandar que retorna el string del resultado del recurso
        /// </summary>
        /// <param name="url">URL del recurso que se obtiene por Get</param>
        /// <returns>String del resultado del Get</returns>
        public string Get(string url)
        {
            try
            {
                Uri urlApi = new Uri(url);

                HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(urlApi);

                HttpWebResponse response = (HttpWebResponse)http.GetResponse();

                string resultado = "";

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    resultado = sr.ReadToEnd();
                }

                return resultado;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                string error = response.Headers["X-Error-Cause"];
                throw;
            }
        }

        /// <summary>
        /// Get que serializa según sea el objeto que se le pase por parámetro
        /// </summary>
        /// <typeparam name="T">Tipo Genérico</typeparam>
        /// <param name="url">URL del recurso que se obtiene por Get</param>
        /// <param name="obj">Tipo de Objeto al que serializará el Get </param>
        /// <returns>Objeto del tipo que se le pase por parametro como tipo</returns>
        public object Get<T>(string url, T obj)
        {
            Uri urlApi = new Uri(url);

            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(urlApi);

            HttpWebResponse response = (HttpWebResponse)http.GetResponse();

            string responseJson = "";

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                responseJson = sr.ReadToEnd();
            }

            T resultado = JsonConvert.DeserializeObject<T>(responseJson);

            return resultado;
        }

    }
}

