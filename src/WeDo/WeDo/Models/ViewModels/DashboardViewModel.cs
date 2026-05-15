using System;
using WeDo.Models;

namespace WeDo.Models.ViewModels

{
    //essa classe é para ser usada na dashboard, onde o usuário pode ver um resumo das suas metas, status e notificações
    //ela nao tem uma tabela no banco de dados, é apenas um modelo para passar os dados para a view
    public class DashboardViewModel
    {

        public int AtividadeId { get; set; }
        public string NomeAtividade { get; set; }
        public string DescricaoAtividade { get; set; }
        public StatusAtividade StatusHoje { get; set; }

        //aqui tem o nome da meta pai, para mostrar na dashboard, caso a atividade seja uma submeta
        public string NomeMetaPai { get; set; }

    }
}
