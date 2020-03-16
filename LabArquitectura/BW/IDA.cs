using System;
using System.Collections.Generic;
using System.Text;
using BC;

namespace BW
{
    public interface IDA
    {
        List<Album> obtenerLista();
        bool agregarItem(Album item);
    }
}
