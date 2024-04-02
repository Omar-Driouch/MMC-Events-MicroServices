namespace EventService.API.Services
{
    public interface IRabbitMQ
    {
        public Task<object> RequestMethod(string Services, string Request);
        public Task<object> DeleteMethod(string Services, string Request, Guid id);
    }
}
