using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.UnitOfWork;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventDal _eventDal;
        private readonly IUowDal _uowDal;

        public EventManager(IEventDal eventDal, IUowDal uowDal)
        {
            _eventDal = eventDal;
            _uowDal = uowDal;
        }

        public void TDelete(Event t)
        {
            _eventDal.Delete(t);
            _uowDal.Save();
        }

        public Event TGetById(int id)
        {
            return _eventDal.GetById(id);
        }

        public List<Event> TGetList()
        {
            return _eventDal.GetList();
        }

        public void TInsert(Event t)
        {
            _eventDal.Insert(t);
            _uowDal.Save();
        }

        public void TUpdate(Event t)
        {
            _eventDal.Update(t);
            _uowDal.Save();
        }
    }
}
