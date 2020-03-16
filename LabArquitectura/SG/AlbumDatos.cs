using BW;
using BC;

namespace SG
{
    public class AlbumDatos : ISG
    {
        private Utilities.Util _util;
        public AlbumDatos()
        {
            _util = Utilities.Util.Instancia;
        }

        //private string url = "http://jsonplaceholder.typicode.com/albums/1";

        public Album TraerAlbumsExternosAsync(int id)
        {
            string Url = _util.Config.ObtenerConfiguracion("URL_EXT_API_ALBUM") + id;
            
            Album albumExterno = new Album();

            albumExterno = (Album)_util.Http.Get(Url, new Album());

            return albumExterno;
        }
        //public Album TraerAlbumsExternosAsync(int id)
        //{

        //    var cliente = new HttpClient();

        //    var peticion = cliente.GetAsync($"{url}/{id}").GetAwaiter().GetResult();

        //    if (peticion.IsSuccessStatusCode) {

        //        var texto = peticion.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        //        /*Album albumExterno = JsonSerializer.Deserialize<Album>(texto);*/
        //        Album albumExterno = JsonConvert.DeserializeObject<Album>(texto);

        //        return albumExterno;

        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }
}
