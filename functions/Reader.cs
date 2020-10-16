using System.IO;
using System.Xml;
using GerenciadorXML.functions.contracts;

namespace GerenciadorXML.functions
{
    public class Reader : IReader
    {
        public string GetAccessKey(FileInfo file)
        {
            using(XmlReader reader = XmlReader.Create(file.FullName)){
                while(reader.Read()){
                        if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "infCFe")){
                            if(reader.HasAttributes){
                               return reader.GetAttribute("Id");
                            }else{
                                return null;
                            }
                        }
                    }
                            return null;
                }
        }

        public string GetCancelAccessKey(FileInfo file)
        {

            using(XmlReader reader = XmlReader.Create(file.FullName)){
                while(reader.Read()){
                        if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "infCFe")){
                            if(reader.HasAttributes){
                               return reader.GetAttribute("chCanc");
                            }else{
                                return null;
                            }
                        }
                    }
                            return null;
                }
            }
        }
}