namespace RickWebApi.Infrastructure.Emails
{
    public class EmailMessage
    {
        public string From { get; }

        public string To { get; }

        public string Content { get; }

        public EmailMessage(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;

        }
    }
}
