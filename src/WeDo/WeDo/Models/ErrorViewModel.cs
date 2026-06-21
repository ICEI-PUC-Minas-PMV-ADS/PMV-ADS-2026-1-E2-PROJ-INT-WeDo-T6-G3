namespace WeDo.Models
{
    public class ErrorViewModel
    {
#pragma warning disable CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
        public string? RequestId { get; set; }
#pragma warning restore CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
