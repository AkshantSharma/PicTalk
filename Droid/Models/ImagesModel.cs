using PicTalk.Droid;
namespace PicTalk.Droid.Models
{
    public class ImagesModel
    {
        public int Images { get; set; }
    }


    public class ImagesCatalog
    {

        // Built-in tree catalog (could be replaced with a database)
        static ImagesModel[] BuiltInCatalog =
            {
            new ImagesModel { Images=Resource.Mipmap.a},
            new ImagesModel { Images=Resource.Mipmap.b},
            new ImagesModel { Images=Resource.Mipmap.c},
            new ImagesModel { Images=Resource.Mipmap.d},
            new ImagesModel { Images=Resource.Mipmap.e},
            new ImagesModel { Images=Resource.Mipmap.f},
            new ImagesModel { Images=Resource.Mipmap.g},
            new ImagesModel { Images=Resource.Mipmap.h},
            new ImagesModel { Images=Resource.Mipmap.i},
            new ImagesModel { Images=Resource.Mipmap.j},
            new ImagesModel { Images=Resource.Mipmap.k},
            new ImagesModel { Images=Resource.Mipmap.l},
            new ImagesModel { Images=Resource.Mipmap.m},
            new ImagesModel { Images=Resource.Mipmap.n},
            new ImagesModel { Images=Resource.Mipmap.o},
            new ImagesModel { Images=Resource.Mipmap.p},
            new ImagesModel { Images=Resource.Mipmap.q},
            new ImagesModel { Images=Resource.Mipmap.r},
            };

        private ImagesModel[] ImageModels;


        // Create an instance copy of the built-in Image catalog:
        public ImagesCatalog() { ImageModels = BuiltInCatalog; }

        // Indexer (read only) for accessing a Image page:
        public ImagesModel this[int i] { get { return ImageModels[i]; } }

        // Returns the number of Image pages in the catalog:
        public int Catalogs { get { return ImageModels.Length; } }
    }
}