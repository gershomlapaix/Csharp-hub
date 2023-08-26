using EmailTester.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailTester.Controllers{
    [Route("/api/[controller]")]
    [ApiController]
    public class MailController: ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService){
            this.mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request){
            try
            {
                await mailService.SendEmailASync(request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
    }
}
}