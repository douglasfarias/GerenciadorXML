using System.Xml;
using System;
using GerenciadorXML.functions;
using System.IO;

namespace GerenciadorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLManager xr = new XMLManager();
            xr.SetDirectory(@"\\suportefacilita\\Fiscal\\112020");
            Console.WriteLine($"Pasta: {xr.Folder}.");
            xr.LoadFiles();
            Console.WriteLine($"Pegou {xr.Files.Count} arquivos.");
            xr.GetFilesWithKeys();
            Console.WriteLine($"{xr.FilesAccessKeys.Count} arquivos com chave de acesso.");
            xr.GetFilesWithCancelKeys();
            Console.WriteLine($"{xr.FilesCancelAccessKeys.Count} arquivos com chave de cancelamento.");
            xr.SelectFiles();
            Console.WriteLine($"Selecionou {xr.SelectedFiles.Count} arquivos.");
            xr.MoveFiles();
            xr.DeleteFiles();
            Console.WriteLine("Fim");
            Console.Read();
        }
    }
}
