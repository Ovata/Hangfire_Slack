using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_slack.Interface
{
    public interface ISendSlackMessage
    {
        void SendNotification(string Text);
    }
}
