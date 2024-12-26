using System.Text;
using Application.ImageStore.SaveImage;

namespace Infrastructure.Foundation.ImageStore.SaveImage;

public class ImageSaver : IImageSaver
{
    public string Save( string image )
    {
        string fileName = GenerateRandomPath( 20 );

        string folderPath = Path.Combine( Directory.GetCurrentDirectory(), "Images" );

        string filePath = Path.Combine( folderPath, fileName );

        if ( !Directory.Exists( folderPath ) )
        {
            Directory.CreateDirectory( folderPath );
        }

        byte[] imageBytes = Convert.FromBase64String( image );

        File.WriteAllBytes( filePath, imageBytes );

        return fileName;
    }

    private static string GenerateRandomPath( int length )
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        Random random = new();

        StringBuilder stringBuilder = new( length );

        for ( int i = 0; i < length; i++ )
        {
            stringBuilder.Append( chars[ random.Next( chars.Length ) ] );
        }

        return stringBuilder.ToString() + ".jpeg";
    }
}
