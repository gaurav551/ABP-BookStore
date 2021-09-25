namespace Acme.BookStore.Application.EmailServices
{
    using System.IO;
    using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
    using Volo.Abp.Emailing.Templates;
    using Volo.Abp.TextTemplating;

    namespace MyProject
{
    public  class EmailService : ITransientDependency
    {
        private readonly IEmailSender _emailSender;


        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
          
        }

        public async Task DoItAsync()
        {
             //Locate the HTML file.
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\Email.html";
            //Open File In StreamReader
            StreamReader str = new StreamReader(FilePath);
            //Read File and Store in string.
            string MailText = str.ReadToEnd();
              str.Close();
            //Replace text in html file with custom text.
            string mailText = MailText.Replace("[username]", "Gaurav").Replace("[email]", "ToEmail").Replace("[heading]","HEY WHATSUP");
            
             
            await _emailSender.SendAsync(
                "gaurav.ga6@gmail.com",     // target email address
                "Email subject",         // subject
                mailText  // email body
            );
            
        }
    }
}

}