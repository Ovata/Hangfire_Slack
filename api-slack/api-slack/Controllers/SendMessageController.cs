using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_slack.Interface;
using api_slack.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_slack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private ISendSlackMessage _sendSlackMessage;

        public SendMessageController(ISendSlackMessage sendSlackMessage)
        {
            _sendSlackMessage = sendSlackMessage;
        }

        [HttpPost]
        public IActionResult SendSlackMessage(SlackModel slackModel)
        {
            try
            {
                _sendSlackMessage.SendNotification(slackModel.Text);
                return Ok("Slack Message Sent Successfully");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}