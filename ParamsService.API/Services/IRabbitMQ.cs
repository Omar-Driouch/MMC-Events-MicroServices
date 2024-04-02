namespace ParamsService.API.Services
{
    public interface IRabbitMQ
    {
        public Task<object> RequestMethod(string Services, string Request);
    }
}
