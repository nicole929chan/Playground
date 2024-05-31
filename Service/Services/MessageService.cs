using Service.Services.Message;

namespace Service.Services;
public class MessageService
{
    public string GetContent(string type = "email")
    {
        IContentCreator creator;

        switch (type)
        {
            case "sms":
                creator = new SmsCreator();
                break;
            case "email":
                creator = new EmailCreator();
                break;
            default:
                throw new ArgumentException("Invalid content type");
        }

        IContent content = creator.CreateContent();

        return content.Generate();
    }
}
