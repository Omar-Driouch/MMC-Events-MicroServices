namespace  Notifications.Services.EventToNotification
{
    public interface IEventToNotification
    {
        public Task<object> RequestMethod(string Services, string Request);
    }
}
