using BO;
using BO.Master;
using DL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Master
{
    public class PropertyRepository : IRepository<Property>
    {
        private PropertyMapper mapper = new PropertyMapper();

        public List<Property> ToList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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
            using (var dbcontext = new SQL.Entities())
            {

                var result = new Property();
                var lquery = dbcontext.Properties.FirstOrDefault(it => it.Id == id);
                if (lquery != null)
                {
                    result = mapper.Map(lquery);
                }


                return result;
            }
        }

        public ApiResponse<Property> GetByQuery(ListQuery<Property> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Property> Update(Property item)
        {
            using (var dbcontext = new SQL.Entities())
            {
                var response = new ApiResponse<Property>();
                response.Item = item;

                var dbitem = dbcontext.Properties.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {

                    try
                    {
                        dbitem.Name = item.Name;
                        dbitem.Slogan = item.Slogan;
                        dbitem.Logo = item.Logo;

                        dbitem.PhoneNo = item.PhoneNo;
                        dbitem.Email = item.Email;

                        dbitem.ContactPerson = item.ContactPerson;
                        dbitem.Mobile = item.Mobile;

                        dbitem.Address1 = item.Address1;
                        dbitem.Address2 = item.Address2;
                        dbitem.Address3 = item.Address3;
                        dbitem.City = item.City;
                        dbitem.Pincode = item.Pincode;

                        dbitem.RUB = item.RUB;
                        dbitem.RUT = DateTime.Now;

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
