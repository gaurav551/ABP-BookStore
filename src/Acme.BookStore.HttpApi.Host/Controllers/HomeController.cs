using System;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore.Controllers
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return Redirect("~/swagger");
        }
        public ActionResult Post()
        {
             
            Logger.LogError("Hello");
            var jobId = BackgroundJob.Schedule(() => SendDelayedWelcomeMail("userName"),TimeSpan.FromMinutes(2));
            return Json(new {Name="Gaurav",Age =11});
        }
         public void SendDelayedWelcomeMail(string userName)
        {
            //Logic to Mail the user
            Console.WriteLine($"Welcome to our application, {userName}");
        }
    }
}
