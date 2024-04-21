using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapingLib
{
    public class Processo
    {
        public string Numero { get; set; }=string.Empty;
        public string DataDistribuicao { get; set; }=string.Empty;
        public string ClasseJudicial { get; set; }=string.Empty;
        public string Assunto { get; set; }=string.Empty;
        public string Jurisdicao { get; set; }=string.Empty;
        public string OrgaoJulgador { get; set; }=string.Empty;
        public List<object> PublicoAlvo { get; set; } = new List<object>();
        public List<object> PoloPassivo { get; set; } = new List<object>();
        public List<object> Movimentacao { get; set; } = new List<object>();

    }
}