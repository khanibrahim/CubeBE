using BO;
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

        public ApiResponse<Property> Add(Property item)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Property GetById(long id)
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

        public ApiResponse<Property> Update(Property item)
        {
            using (var dbcontext = new SQL.CubeEntities()) {
                var response = new ApiResponse<Property>();
                response.Item = item;

                var dbitem = dbcontext.Properties.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {

                    try
                    {
                        dbitem.Address1 = item.Address1;
                        dbitem.Address2 = item.Address2;
                        dbitem.Address3 = item.Address3;
                        dbitem.Name = item.Name;
                        dbitem.Mobile = item.Mobile;

                        //add all paramters
                        dbitem.RUB = item.RUB;
                        dbitem.RCT = DateTime.Now;
                        dbcontext.SaveChanges();
                        response.Success = true;
                    }
                    catch (Exception e)
                    {

                        response.Success = false;
                        response.ErrorMessage = e.Message;
                        response.DetailedError = e;
                        
                    }
                    }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "No Property Found";
                    
                }
                return response;
            }
        }
    }
}
