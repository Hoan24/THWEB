using THWEB.Data;
using THWEB.Models;

namespace THWEB.Services
{
    public class ReP:IReponsitoryP
    {
        private readonly AppDbcontext _context;
        public ReP(AppDbcontext context) { _context = context; }

        public PublishersVM AddPublisher(PublishersVM publisher)
        {
            var _publ = new PublishersVM
            {

                Name = publisher.Name,
            };
            _context.Add(_publ);
            _context.SaveChanges();
            return new PublishersVM
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name,
            };
        }

        public void DeletePublisher(int id)
        {
            var publ=_context.publishers.SingleOrDefault(p=>p.PublisherId == id);
            if(publ != null)
            {
                _context.Remove(publ);
                _context.SaveChanges();
            }
           
        }

        public List<PublishersVM> GetALlPublishers()
        {
            var list = _context.publishers.Select(p => new PublishersVM
            {
                PublisherId=p.PublisherId,
                Name=p.Name,
            });
            return list.ToList();
        }

        public PublishersVM GetPublisher(int id)
        {
            var publ= _context.publishers.SingleOrDefault(p=>p.PublisherId==id);
            if (publ != null)
            {
                return new PublishersVM
                {
                    PublisherId = publ.PublisherId,
                    Name = publ.Name,
                };
            }
            return null;
        }

        public void UpdatePublisher(int id,PublishersVM publisher)
        {
            var publ=_context.publishers.SingleOrDefault(p=>p.PublisherId==id);
            publisher.Name = publisher.Name;
            _context.SaveChanges();
        }
    }
}
