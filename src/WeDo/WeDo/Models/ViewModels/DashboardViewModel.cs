using System;
using WeDo.Models;

namespace WeDo.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int MetaId { get; set; }
        public int AtividadeId { get; set; }
        public string NomeAtividade { get; set; }
        public string DescricaoAtividade { get; set; }
        public string NomeMetaPai { get; set; }

        public StatusAtividade StatusHoje { get; set; }
        public StatusAtividade StatusOriginal { get; set; }
    }
}