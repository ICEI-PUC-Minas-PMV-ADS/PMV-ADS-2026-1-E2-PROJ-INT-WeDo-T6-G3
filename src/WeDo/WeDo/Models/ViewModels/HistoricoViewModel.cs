using WeDo.Models;

namespace WeDo.Models.ViewModels
{
    public class HistoricoViewModel
    {
        public List<Meta> Metas { get; set; } = new();
        public int MesAtual { get; set; }
        public int AnoAtual { get; set; }
        public List<Categoria> Categorias { get; set; } = new();
        public int? CategoriaFiltradaId { get; set; }

        public int MesAnterior => MesAtual == 1 ? 12 : MesAtual - 1;
        public int AnoMesAnterior => MesAtual == 1 ? AnoAtual - 1 : AnoAtual;
        public int MesSeguinte => MesAtual == 12 ? 1 : MesAtual + 1;
        public int AnoMesSeguinte => MesAtual == 12 ? AnoAtual + 1 : AnoAtual;

        public string NomeMes => new DateTime(AnoAtual, MesAtual, 1).ToString("MMMM yyyy",
            new System.Globalization.CultureInfo("pt-BR"));

        public int PrimeiroDiaSemana => (int)new DateTime(AnoAtual, MesAtual, 1).DayOfWeek;
        public int TotalDiasMes => DateTime.DaysInMonth(AnoAtual, MesAtual);
    }
}
