using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ScrapingLib
{
    public class HtmlDoc
    {
        private readonly HtmlWeb web;
        private HtmlDocument page = null;
        private readonly string id;

        public HtmlDoc(string id)
        {
            web = new HtmlWeb();
            this.id = id;
        }

        public async Task LoadPage()
        {
            try
            {
                string url = $"https://pje-consulta-publica.tjmg.jus.br/pje/ConsultaPublica/DetalheProcessoConsultaPublica/listView.seam?ca={id}";
                page = await web.LoadFromWebAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading page: {ex.Message}");
                // Handle or log the exception as needed
            }
        }

        private HtmlNode GetNode(string xpath)
        {
            return page?.DocumentNode.SelectSingleNode(xpath);
        }

        public string GetNodeInnerHtml(string xpath)
        {
            HtmlNode node = GetNode(xpath);
            return node != null ? WebUtility.HtmlDecode(node.InnerHtml.Trim()) : string.Empty;
        }

        public string GetNodeInnerText(string xpath)
        {
            HtmlNode node = GetNode(xpath);
            return node != null ? WebUtility.HtmlDecode(node.InnerText.Trim()) : string.Empty;
        }

        public string GetNodeInnerValue(string xpath)
        {
            HtmlNode node = GetNode(xpath);
            return node != null ? WebUtility.HtmlDecode(node.GetAttributeValue("value", string.Empty)) : string.Empty;
        }

        public dynamic GetPublicoAlvo(string xpath)
        {
            HtmlNodeCollection nodes = page?.DocumentNode.SelectNodes(xpath);
            List<object> list = new List<object>();
            if (nodes != null)
            {
                var tr = nodes.Descendants("tr");
                var allRows = tr.Where(x => x.SelectNodes("td") != null);
                int qtdRows = allRows.Count();
                for (int i = 1; i < qtdRows; i++)
                {
                    list.Add(new
                    {
                        Participante = WebUtility.HtmlDecode(allRows.ElementAt(i).SelectNodes("td")[0].InnerText.Trim()).Trim(),
                        Situacao = WebUtility.HtmlDecode(allRows.ElementAt(i).SelectNodes("td")[1].InnerText.Trim()).Trim()
                    });
                }
            }
            return list;
        }

        public dynamic GetMovimentacaoProcesso(string xpath)
        {
            HtmlNodeCollection nodes = page?.DocumentNode.SelectNodes(xpath);
            List<object> list = new List<object>();
            if (nodes != null)
            {
                var tr = nodes.Descendants("tr");
                var allRows = tr.Where(x => x.SelectNodes("td") != null);
                int qtdRows = allRows.Count();
                for (int i = 1; i < qtdRows; i++)
                {
                    list.Add(new
                    {
                        Movimento = WebUtility.HtmlDecode(allRows.ElementAt(i).SelectNodes("td")[0].InnerText.Trim()).Trim(),
                        Documento = WebUtility.HtmlDecode(allRows.ElementAt(i).SelectNodes("td")[1].InnerText.Trim()).Trim()
                    });
                }
            }
            return list;
        }

        public dynamic GetPoloPassivo(string xpath)
        {
            HtmlNodeCollection nodes = page?.DocumentNode.SelectNodes(xpath);
            List<object> list = new List<object>();
            if (nodes != null)
            {
                var tr = nodes.Descendants("tr");
                var allRows = tr.Where(x => x.SelectNodes("td") != null);
                int qtdRows = allRows.Count();
                for (int i = 1; i < qtdRows; i++)
                {
                    list.Add(new
                    {
                        Participante = WebUtility.HtmlDecode(allRows.ElementAt(i).SelectNodes("td")[0].InnerText.Trim()).Trim(),
                        Situacao = WebUtility.HtmlDecode(allRows.ElementAt(i).SelectNodes("td")[1].InnerText.Trim()).Trim()
                    });
                }
            }
            return list;
        }
    }
}
