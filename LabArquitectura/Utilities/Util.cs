using System;
using Utilities.Common;

namespace Utilities
{
    public class Util
    {
        #region SingleTon Instance
        private static Util _instancia;

        private static object syncRootBLL = new Object();

        public Util() { }

        public static Util Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (syncRootBLL)
                    {
                        _instancia = new Util();

                    }
                }
                return _instancia;
            }
        }
        #endregion


        /// <summary>
        /// Utilidades para Http
        /// </summary>
        public Http Http
        {
            get
            {
                return Http.Instancia;
            }
        }

        /// <summary>
        /// Utilidades para Http
        /// </summary>
        public Config Config
        {
            get
            {
                return Config.Instancia;
            }
        }

    }
}
