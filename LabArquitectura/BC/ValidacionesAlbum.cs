using System;
using System.Collections.Generic;
using System.Text;

namespace BC
{
    public class ValidacionesAlbum
    {
        public const string  letra = "q"; 

        
        public bool validarRepetidos(List<Album> lista, Album album)
        {
            var encontrado = lista.Find(x => x.id == album.id);
            if (encontrado != null)
            {
                return true;//encuentra repetido
            }
            return false;
        }
        public bool buscarPorLetraInicial(Album album)
        {
            //var encontrado = lista.Find(x => x.id == album.id);

            if (album.title.ToString().StartsWith(letra))
            {
                return true;
            }
            return false;
        }



    }
}
