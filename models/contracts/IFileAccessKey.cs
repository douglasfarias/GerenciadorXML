using System.IO;

namespace GerenciadorXML.models.contracts
{
    public interface IFileAccessKey
    {
         FileInfo File { get; set; }
         string AccessKey { get; set; }
    }
}