namespace ParamsService.API.Services
{
    public interface INotificationsServer
    {
        public Task<object> SendNotificationVia(string ServicesOfNotification, string ParticipantID, string EventID);
        public Task<object> RequestDatafromParticipants(string Services, string ParticipantID);
    }
}
