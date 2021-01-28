using System;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;
using System.Text;

namespace api_slack
{
    public class SlackClient
    {
        private readonly Encoding _enconding = new UTF8Encoding();
        public Uri _uri { get; }

        public SlackClient(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        public void PostMessage(string text, string username = null, string channel = null)
        {
            Payload payload = new Payload()
            {
                Channel = channel,
                Username = username,
                Text = text
            };

            PostMessage(payload);
        }

        public void PostMessage(Payload payload)
        {
            string payloadJson = JsonConvert.SerializeObject(payload);

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                var response = client.UploadValues(_uri, "POST", data);

                string responseText = _enconding.GetString(response);
            }
        }
    }
}
