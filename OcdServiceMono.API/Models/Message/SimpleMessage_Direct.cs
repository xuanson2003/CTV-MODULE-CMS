namespace OcdServiceMono.API.Models.Message
{
    public record SimpleMessage_Direct
    {
        public string Type { get; set; }
        public string Text { get; set; }
    }
}
