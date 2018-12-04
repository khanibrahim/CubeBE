using BO.Master;
using DL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Master
{
    public class PropertyRepository : IRepository<Property>
    {
         PropertyMapper mapper = new PropertyMapper();

        public List<Property> ToList => throw new NotImplementedException();

        public Property Add(Property item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Property GetById(int id)
        {
            using (var dbcontext = new SQL.CubeEntities())
            {
               
               var result= new Property();
                var lquery = dbcontext.Properties.FirstOrDefault(it => it.Id == id );
                if (lquery != null)
                {
                    result = mapper.Map(lquery);
                }
                
                
                return result;
            }
        }

        public ListQueryResult<Property> GetByQuery(ListQuery<Property> query)
        {
            throw new NotImplementedException();
        }

        public Property Update(Property item)
        {
            throw new NotImplementedException();
        }
    }
}
