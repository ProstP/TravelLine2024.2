using Application.ImageStore.LoadImage;

namespace Infrastructure.Foundation.ImageStore.LoadImage;

public class ImageLoader : IImageLoader
{
    public string Load( string path )
    {
        string folderPath = Path.Combine( Directory.GetCurrentDirectory(), "Images" );

        string filePath = Path.Combine( folderPath, path );

        if ( !Directory.Exists( folderPath ) )
        {
            return "";
        }

        if ( !File.Exists( filePath ) )
        {
            return "";
        }

        byte[] imageBytes = File.ReadAllBytes( filePath );

        string imageBase64 = Convert.ToBase64String( imageBytes );

        return imageBase64;
    }
}
