namespace Service.Services.Message;
internal class SmsCreator : IContentCreator
{
    public override IContent CreateContent()
    {
        return new SmsContent();
    }
}
