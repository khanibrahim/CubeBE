using BO.Master;
using System;
using System.Linq;

namespace DL.Mappings
{
    public class UserMapper : IMappingProvider<Userdetail, SQL.Userdetail>
    {
        private PropertyMapper propertyMapper = new PropertyMapper();
        public BO.Master.Userdetail Map(SQL.Userdetail dbitem)
        {
            var dbcontext = new SQL.Entities();

            var user = new Userdetail();
            user.UserId = dbitem.UserId;
            user.Username = dbitem.UserName;
            user.Email = dbitem.Email;
            user.MobileNo = dbitem.MobileNo;
            var role = dbitem.Roles.FirstOrDefault();
            if (role != null)
            {
                user.RoleName = role.Name;
            }
            user.Property = propertyMapper.Map(dbcontext.Properties.FirstOrDefault(it => it.Id == dbitem.PropertyId));
            user.PropertyId = user.Property.Id;
            user.IsActive = dbitem.IsActive;
            return user;
        }

        public SQL.Userdetail Map(BO.Master.Userdetail item)
        {
            throw new NotImplementedException();
        }
    }
}
