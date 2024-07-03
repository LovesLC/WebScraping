using EasyAutomationFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspandoDados.Models;

namespace RaspandoDados.Driver
{
    public class WebScraping : Web
    {
        public DataTable PegarDados(string link)
        {
            if (driver == null)
            {
                StartBrowser();
            }

            var objetos = new List<Objetos>();

            Navigate(link);

            var elements = GetValue(TypeElement.Xpath, "/html/body/div[3]/main/div[2]/div/div/div[2]/div[2]").element.FindElements(By.ClassName("item"));

            foreach (var element in elements)
            {
                Objetos obj = new Objetos();
                obj.Titulo = element.FindElement(By.ClassName("product-name")).Text;
                obj.Preco = element.FindElement(By.ClassName("product-price")).Text;

                objetos.Add(obj);
            }

            return Base.ConvertTo(objetos);
        }
    }
}
