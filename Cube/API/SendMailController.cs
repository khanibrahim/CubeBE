using System.Net.Mail;
using System.Web.Http;
using BL.Master;

namespace Cube.API
{
    public class SendMailController : ApiController
    {
        QuestionPaperService service = new QuestionPaperService();
        // GET: SendMail
        public void Get(int id)
        {
            var QuestionPaper = service.GetById(id);

            MailMessage mail = new MailMessage();
            mail.To.Add("");
            mail.From = new MailAddress("");
            mail.Subject = QuestionPaper.Name;
            string Body = QuestionPaper.Html;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("", ""); 
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}