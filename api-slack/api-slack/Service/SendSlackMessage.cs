using api_slack.Interface;
using Microsoft.Extensions.Configuration;
using Slack.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api_slack.Service
{
    public class SendSlackMessage : ISendSlackMessage
    {
        private readonly string _webhook_url;
        private readonly string _username;
        private readonly string _channel;
        private readonly string _color;
        private readonly string _thumb_url;

        public SendSlackMessage(IConfiguration config)
        {
            _webhook_url = config["Slack:Webhook_url"];
            _username = config["Slack:Username"];
            _channel = config["Slack:Channel"];
            _color = config["Slack:Color"];
            _thumb_url = config["Slack:Thumb_url"];

        }

        public void SendNotification(string Text)
        {
            
            try
            {
                
                var slackClient = new SlackClient(_webhook_url);
                slackClient.PostMessage(Text, _username, _channel);
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong while posting to slack");
            }

        }
    }

}
