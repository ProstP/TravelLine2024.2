using Application.ImageStore.LoadImage;

namespace Infrastructure.Foundation.ImageStore.LoadImage;

public class ImageLoader : IImageLoader
{
    public string Load( string name )
    {
        string rootPath = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot" );
        string folderPath = Path.Combine( rootPath, "Images" );

        string filePath = Path.Combine( folderPath, name );

        if ( !Directory.Exists( folderPath ) )
        {
            return "";
        }

        if ( !File.Exists( filePath ) )
        {
            return "";
        }

        return "http://localhost:5208/Images/" + name;
    }
}
