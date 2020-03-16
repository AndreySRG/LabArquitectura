using System;
using System.Collections.Generic;
using BC;
using BW;
namespace DA
{
    public class MemoryStorage : IDA
    {
        private List<Album> ListaAlbumes = new List<Album>();

        public MemoryStorage()
        {

            //ListaAlbumes = new List<Album>{new Album {id = 1, title="maria", userId=1 }, new Album { id = 1, title = "maria", userId = 1 } };


        }
        public List<Album> obtenerLista()
        {
            return ListaAlbumes;
        }

        public bool agregarItem(Album album)
        {
            ListaAlbumes.Add(album);
            return true;
        }
    }
}
