using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using RaspandoDados.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspandoDados
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rasparDados = new WebScraping();

            var aconcelhamento = rasparDados.PegarDados("https://www.editorafiel.com.br/aconselhamento-biblico");

            Console.WriteLine("Dados dos Livros de aconcelhamento");

            var apologetica = rasparDados.PegarDados("https://www.editorafiel.com.br/apologetica");

            Console.WriteLine("\nDados de Livros de apologética");

            var pamas = new ParamsDataTable("Fiel", @"C:\Users\kaiky\OneDrive\Documentos\Teste", new List<DataTables>
            {
                new DataTables("Aconcelhamentos", aconcelhamento),
                new DataTables("Apologética", apologetica)
            });

            Base.GenerateExcel(pamas);
        }
    }
}
