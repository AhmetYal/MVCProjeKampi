using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingServices
    {
        IHeadingDal _heading;

        public HeadingManager(IHeadingDal heading)
        {
            _heading = heading;
        }

        public Heading GetByID(int id)
        {
            return _heading.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _heading.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _heading.Insert(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _heading.Update(heading);
        }

        public void HeadingDelete(Heading heading)
        {            
            _heading.Update(heading);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _heading.List(x=>x.WriterID== id);
        }
    }
}
