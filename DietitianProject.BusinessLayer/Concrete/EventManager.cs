using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Abstract;
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

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void TDelete(Event t)
        {
            _eventDal.Delete(t);
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
        }

        public void TUpdate(Event t)
        {
            _eventDal.Update(t);
        }
    }
}
