using THWEB.Models;

namespace THWEB.Services
{
    public interface IReponsitoryP
    {
        public List<PublishersVM> GetALlPublishers();
        PublishersVM GetPublisher(int id);
        PublishersVM AddPublisher(PublishersVM publisher);
        void UpdatePublisher(int id,PublishersVM publisher);
        void DeletePublisher(int id);
    }
}
