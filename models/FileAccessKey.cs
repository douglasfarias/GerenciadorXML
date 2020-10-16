using System.IO;
using GerenciadorXML.models.contracts;

namespace GerenciadorXML
{
    public class FileAccessKey : IFileAccessKey
    {
        private FileInfo _File;
        private string _AccessKey;

        public FileInfo File { 
            get {return _File;} 
            set {_File = value;}
         }
        public string AccessKey { 
            get {return _AccessKey;} 
            set {_AccessKey = value;}
             }
    }
}