using System;
using WeDo.Models;

namespace WeDo.Models.ViewModels
{
    // ViewModel que une os dados da Meta e da Atividade Diária.
    // Serve exclusivamente para transportar os dados do banco para a tela da Dashboard de forma organizada.
    public class DashboardViewModel
    {
        // Chaves de identificação no banco de dados
        public int MetaId { get; set; }
        public int AtividadeId { get; set; }

        // Dados visuais que serão impressos no HTML
        public string NomeAtividade { get; set; }
        public string DescricaoAtividade { get; set; }
        public string NomeMetaPai { get; set; }

        // Status atual que o usuário seleciona no Dropdown da tela
        public StatusAtividade StatusHoje { get; set; }

        // Guarda o status exato que veio do banco no carregamento da página.
        // Utilizado no Controller para comparar com o 'StatusHoje' e evitar idas desnecessárias ao banco de dados se o usuário não alterou nada.
        public StatusAtividade StatusOriginal { get; set; }
    }
}