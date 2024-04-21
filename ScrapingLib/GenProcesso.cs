using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScrapingLib;

namespace ScrapingLib
{
    public class GenProcesso
    {
        public async Task<string> Processo(string id)
        {
            var doc = new HtmlDoc(id);
            await doc.LoadPage();
            string numero = doc.GetNodeInnerHtml("//*[@id='j_id132:processoTrfViewView:j_id138']/div/div[2]/div");
            string datadist = doc.GetNodeInnerHtml("//*[@id='j_id132:processoTrfViewView:j_id150']/div/div[2]");
            string classeJud = doc.GetNodeInnerHtml("//*[@id='j_id132:processoTrfViewView:j_id161']/div/div[2]");
            string assunto = doc.GetNodeInnerHtml("//*[@id='j_id132:processoTrfViewView:j_id172']/div/div[2]/div/text()");
            string jurisdicao = doc.GetNodeInnerHtml("//*[@id='j_id132:processoTrfViewView:j_id185']/div/div[2]");
            string orgaojulgador = doc.GetNodeInnerHtml("//*[@id='j_id132:processoTrfViewView:j_id209']/div/div[2]");
            var publicAlvo = doc.GetPublicoAlvo("//*[@id='j_id132:processoPartesPoloAtivoResumidoList']");
            var poloPassivo = doc.GetPublicoAlvo("//*[@id='j_id132:processoPartesPoloPassivoResumidoList']");
            var movimento = doc.GetMovimentacaoProcesso("//*[@id='j_id132:processoEvento']");
            Processo m = new Processo
            {
                Numero = numero,
                DataDistribuicao = datadist,
                ClasseJudicial = classeJud,
                Assunto = assunto,
                Jurisdicao=jurisdicao,
                OrgaoJulgador = orgaojulgador,
                PublicoAlvo = publicAlvo,
                PoloPassivo = poloPassivo,
                Movimentacao = movimento
            };
            return  JsonConvert.SerializeObject(m);
        }
    }
}