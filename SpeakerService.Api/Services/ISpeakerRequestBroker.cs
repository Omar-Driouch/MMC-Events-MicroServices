namespace SpeakerService.API.Services
{
    public interface ISpeakerRequestBroker
    {
        public string RequestInfoFromEvents(string Services, string Request);
    }
}
