using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_slack
{
    public class SlackTest
    {
        void TestPostMessage()
        {
            string urlToken = "https://{your_account}.slack.com/services/hooks/incoming-webhook?token={https://hooks.slack.com/services/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}";


            SlackClient client = new SlackClient(urlToken);

            client.PostMessage(username: "kamleshbhor",
                       text: "THIS IS A TEST MESSAGE!!",
                       channel: "#general");
        }
    }
}
