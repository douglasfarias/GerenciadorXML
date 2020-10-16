using System.IO;

namespace GerenciadorXML.functions.contracts
{
    public interface IReader
    {
         string GetAccessKey(FileInfo file);
         string GetCancelAccessKey(FileInfo file);
    }
}