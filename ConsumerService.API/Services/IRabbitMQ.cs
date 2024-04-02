namespace ConsumerService.API.Services
{
    public interface IRabbitMQ
    {
        public string Call(string message, string Services);
    }
}
