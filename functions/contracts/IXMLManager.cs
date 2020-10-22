using System.Collections.Generic;
using System.IO;
namespace GerenciadorXML.functions.contracts
{
    public interface IXMLManager
    {
         string Folder { get; }
         List<FileInfo> Files { get;}
         List<FileAccessKey> SelectedFiles { get;}
         List<FileInfo> AccessKeys { get;}
         List<FileAccessKey> FilesAccessKeys { get; }
         List<FileAccessKey> FilesCancelAccessKeys { get; }
         void GetFilesWithKeys();
         void GetFilesWithCancelKeys();
         void SetDirectory(string path);
         void LoadFiles();
         void CreateFolder(string path);
         void CompressFiles();

    }
}