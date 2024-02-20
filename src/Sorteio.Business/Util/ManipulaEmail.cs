using System;
using System.Net;
using System.Net.Mail;

public static class ManipulaEmail
{
    public static void EnviarEmail(string destinatario, string assunto, string nomeParticipante, int numero, string nomeSorteio)
    {
        try
        {
            
            string htmlBody = $@"
            <!DOCTYPE html>
            <html lang='en'>
              <head>
                <meta charset='UTF-8' />
                <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                <title>Email de Sorteio</title>
                <style>
                  .ticket {{
                    width: 300px;
                    padding: 20px;
                    background-color: #f9f9f9;
                    border: 2px dashed #ccc;
                    border-radius: 10px;
                    text-align: center;
                  }}
                  .ticket-number {{
                    font-size: 24px;
                    font-weight: bold;
                    margin-top: 20px;
                  }}
                </style>
              </head>
              <body style='font-family: Arial, sans-serif'>
                <div style='max-width: 600px; margin: 0 auto; padding: 20px'>
                  <div style='background-color: #f9f9f9; border-radius: 10px; padding: 20px; text-align: center; margin-top: 20px'>
                    <p style='font-size: 18px'>Muito bem, {nomeParticipante}!</p>
                    <p style='font-size: 18px'>Esse é o seu número {numero} para o sorteio {nomeSorteio}.</p>
                    <div style='text-align: center'>
                      <div class='ticket'>
                        <h2>Meu Sorteio</h2>
                        <p>Descrição do Sorteio</p>
                        <hr />
                        <span class='ticket-number'>Número: {numero}</span>
                      </div>
                    </div>
                    <p style='font-size: 18px'>Boa Sorte!!</p>
                  </div>
                </div>
              </body>
            </html>";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("*****@email.com");
                mail.To.Add(destinatario);
                mail.Subject = assunto;
                mail.Body = htmlBody;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("*****@gmail.com", "*******");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            Console.WriteLine("E-mail enviado com sucesso para: " + destinatario);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao enviar o e-mail: " + ex.Message);
        }
    }
}
