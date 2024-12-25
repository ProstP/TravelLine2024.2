using Application.ImageStore.DeleteImage;

namespace Infrastructure.Foundation.ImageStore.DeleteImage;

public class ImageDeleter : IImageDeleter
{
    public void Delete( string path )
    {
        string folderPath = Path.Combine( Directory.GetCurrentDirectory(), "Images" );

        string filePath = Path.Combine( folderPath, path );
        
        if ( File.Exists( filePath ) )
        {
            File.Delete( filePath );
        }
    }
}
