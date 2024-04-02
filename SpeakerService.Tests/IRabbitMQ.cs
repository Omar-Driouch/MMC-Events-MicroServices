namespace SpeakerService.Tests
{
    public interface IRabbitMQ
    {
        public string Call(string message);
    }
}
