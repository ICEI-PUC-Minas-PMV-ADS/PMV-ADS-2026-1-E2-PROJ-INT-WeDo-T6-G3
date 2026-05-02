using System;
using System.Net.Mail;

namespace WeDo.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        // Método para enviar email
        public async Task EnviarEmailAsync(string emailDestino, string assunto, string mensagemHtml)
        {
            // pega as credenciais do email do arquivo de configuração
            var emailOrigem = _config["EmailConfig:EmailOrigem"];
            var senhaApp = _config["EmailConfig:SenhaApp"];
            var host = _config["EmailConfig:Host"];
            var porta = int.Parse(_config["EmailConfig:Porta"]);

            // monta o email
            var mailMessage = new MailMessage(emailOrigem, emailDestino, assunto, mensagemHtml)
            {
                IsBodyHtml = true,// Permite HTML no corpo do email
            };
            //chama o carteiro(servidor google)
            using (var smtpClient = new SmtpClient(host, porta))
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(emailOrigem, senhaApp);
                smtpClient.EnableSsl = true; // o google exige SSL para conexões seguras

                await smtpClient.SendMailAsync(mailMessage);// Envia o email de forma assíncrona para nao travar a tela do usuario
            }

        }
    }
}
