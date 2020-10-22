using System.Collections.Generic;
using System.Linq;
using System.IO;
using GerenciadorXML.functions.contracts;
using System;

namespace GerenciadorXML.functions
{
    public class XMLManager : IXMLManager
    {
        private string _Folder;
        private List<FileInfo> _Files = new List<FileInfo>();
        private List<FileAccessKey> _SelectedFiles = new List<FileAccessKey>();
        private List<FileInfo> _AccessKeys = new List<FileInfo>();
        private List<FileAccessKey> _FilesAccessKeys = new List<FileAccessKey>();
        private List<FileAccessKey> _FilesCancelAccessKeys = new List<FileAccessKey>();

        public string Folder { 
            get {return _Folder;} 
            private set {_Folder = value;} 
            }

        public List<FileInfo> Files {
            get{ return _Files;}
            private set{ _Files = value;}
        }

        public List<FileAccessKey> SelectedFiles {
            get{return _SelectedFiles;}
            private set{_SelectedFiles = value;}
        }

        public List<FileInfo> AccessKeys {
            get{return _AccessKeys;}
            private set{_AccessKeys = value;}
        }

        public List<FileAccessKey> FilesAccessKeys {
            get{return _FilesAccessKeys;}
            private set{_FilesAccessKeys = value;}
        }

        public List<FileAccessKey> FilesCancelAccessKeys {
            get{return _FilesCancelAccessKeys;}
            set{_FilesCancelAccessKeys = value;}
            }

///////////////////Carrega todos os arquivos da pasta especificada/////////////////////////////////////////
        public void LoadFiles()
        {
            DirectoryInfo di = new DirectoryInfo(this.Folder);
            this.Files = di.GetFiles("*.xml", SearchOption.AllDirectories).ToList();
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////Armazena Todos os arquivos que contenham Id////////////////////////////////////
        public void GetFilesWithKeys()
        {
            Reader reader = new Reader();
            foreach (var item in this.Files)
            {
                var result = reader.GetAccessKey(item);
                if(result != null){
                    this.FilesAccessKeys.Add(new FileAccessKey{File = item, AccessKey = result});
                }
            }
        }
////////////////////////////////////////////////////////////////////////////////////////////////////        

/////////////////Armazena Todos os arquivos que contenham Id////////////////////////////////////
        public void GetFilesWithCancelKeys()
        {
            Reader reader = new Reader();
            foreach (var item in this.Files)
            {
                var result = reader.GetCancelAccessKey(item);
                if(result != null){
                    this.FilesCancelAccessKeys.Add(new FileAccessKey{File = item, AccessKey = result});
                }else{
                    
                }
            }
        }
////////////////////////////////////////////////////////////////////////////////////////////////////        

/////////////////Cria  a pasta de destino////////////////////////////////////
        public void CreateFolder(string path)
        {
            if(!Directory.Exists(path)){
                try{
                    Directory.CreateDirectory(path);
                    Console.WriteLine("Pasta criada !");
                }catch(Exception ex){
                    throw ex;
                }
            }
        }


////////////////////////////////////////////////////////////////////////////////////////////////////        

/////////////////Cria  a pasta de destino////////////////////////////////////
        public void SelectFiles()
        {
            foreach (var item in FilesCancelAccessKeys)
            {
                if(item.File.DirectoryName.Contains("canceladas")){
                    continue;
                }
                SelectedFiles.Add(item);
                var result = FilesAccessKeys.FirstOrDefault(x => x.AccessKey == item.AccessKey);
                if(result != null){
                    SelectedFiles.Add(result);
                }else{
                    Console.WriteLine($"Nota de venda não encontrado para a nota de cancelamento: {item.File.Name} {item.AccessKey}");
                }
                
            }
        }
////////////////////////////////////////////////////////////////////////////////////////////////////                
        public void DeleteFiles()
        {
            foreach(var item in SelectedFiles){
                if(item.File.Exists){
                    try{
                        item.File.Delete();
                        Console.WriteLine("Arquivo apagado " + item.File.FullName);
                    }catch(Exception ex){
                        throw ex;
                    }
                }
            }

        }
/////////////////Move os arquivos////////////////////////////////////
        public void MoveFiles()
        {
            FileInfo destFile;
            foreach(var item in SelectedFiles){
                try{                    
                    CreateFolder(item.File.Directory + @"\canceladas");
                    destFile = new FileInfo(item.File.Directory.FullName + @"\canceladas\" + item.File.Name);
                    if(!destFile.Exists){
                        File.Copy(item.File.FullName, destFile.FullName);
                    }else{
                        Console.WriteLine("Arquivo já existe no destino: " + destFile);
                    }
                    Console.WriteLine("Arquivo copiado " + item.File.FullName);
                }catch(FileNotFoundException ex){
                        Console.WriteLine("Arquivo não encontrado :" + item.File.FullName + "\n" + ex.Message);
                        continue;
                }catch(Exception ex){
                        throw ex;
                }
            }
        }
////////////////////////////////////////////////////////////////////////////////////////////////////

///////////////////////////Selecionar a pasta//////////////////////////////////////////////
        public void SetDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if(di.Exists){
                this.Folder = path;
            }else{
                throw new DirectoryNotFoundException();
            }
        }

        public void CompressFiles()
        {
            throw new NotImplementedException();
        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////