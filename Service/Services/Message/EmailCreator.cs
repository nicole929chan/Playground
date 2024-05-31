namespace Service.Services.Message;
internal class EmailCreator : IContentCreator
{
    public override IContent CreateContent()
    {
        return new EmailContent();
    }
}