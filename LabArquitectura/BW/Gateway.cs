using System;
using System.Collections.Generic;
using BC;

namespace BW
{

    public class Gateway
    {
        List<Album> listaInterna;
               
        Respuesta _respuesta;

        readonly ISG _interfaceSG;
        readonly IDA _interfaceDA;

        public Gateway(ISG isg, IDA ida)
        {
            _interfaceSG = isg;
            _interfaceDA = ida;                        
            _respuesta = new Respuesta();

        }

        public Respuesta agregarAlbum(Album album)
        {
            #region Validaciones
            string tituloResultadoValidaciones;

            Boolean validacionesAprobadas = ejecutarValidaciones(album, out tituloResultadoValidaciones); 
            #endregion

            if (!validacionesAprobadas)
            {
                _respuesta.estado = false;
                _respuesta.titulo = tituloResultadoValidaciones;
                return _respuesta;
            }
            
            #region Agregar Album
            Album albumExterno = _interfaceSG.TraerAlbumsExternosAsync(album.id);
            
            if(_interfaceDA.agregarItem(albumExterno))
            {
                _respuesta.titulo = $"El Album: { albumExterno.title}, si inicia con la letra Q y se agregó";
            }


            #endregion

            return _respuesta;
        }

       //public Respuesta obtenerAlbumExterno(int id)
       // {
       //     albumExterno = interfaceSG.TraerAlbumsExternosAsync(id);
            
       // }
        public Boolean ejecutarValidaciones(Album album, out string tituloResultado)
        {
            ValidacionesAlbum validaciones = new ValidacionesAlbum();

            Boolean estadoValidacion = false;
            
            tituloResultado = string.Empty;

            #region Repetidos en repositorio interno
            List<Album> listaInterna = _interfaceDA.obtenerLista();

            if (listaInterna.Count > 0)//Validar si existen repetidos, solo cuando existan valores
            {
                estadoValidacion = validaciones.validarRepetidos(listaInterna, album);

                if (estadoValidacion)
                {
                    tituloResultado = $"El Album, ya existe registrado";

                    return false;

                }
            }

            
            #endregion
                        
            Album albumExterno = _interfaceSG.TraerAlbumsExternosAsync(album.id);

            #region Existencia de album en repositorio externo
            if (albumExterno == null)
            {
                tituloResultado = $"El Album, no existe en el repositorio externo";

                return false;
            } 
            #endregion


            #region Busqueda por Letra
            estadoValidacion = validaciones.buscarPorLetraInicial(albumExterno);

            if (!estadoValidacion)
            {

                tituloResultado = $"El Album: { albumExterno.title}, no inicia con la letra Q";

                return false;

            }
            #endregion

            return true;
            
        }

        public List<Album> ObtenerLista()
        {
            return _interfaceDA.obtenerLista();
        }

        
    }
}
