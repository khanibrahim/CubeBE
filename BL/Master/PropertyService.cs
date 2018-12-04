using BO.Master;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Master
{
    public class PropertyService : IService<Property>
    {
        DL.Master.PropertyRepository repository = new DL.Master.PropertyRepository();

        public List<Property> ToList => throw new NotImplementedException();

        public Property Add(Property entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Property GetById(int Id)
        {
            return repository.GetById(Id);
        }

        public ListQueryResult<Property> GetByQuery(ListQuery<Property> query)
        {
            throw new NotImplementedException();
        }

        public Property Update(Property entity)
        {
            throw new NotImplementedException();
        }
    }
}
