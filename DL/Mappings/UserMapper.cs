using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappings
{
    public class UserMapper : IMappingProvider<Userdetail, SQL.Userdetail>
    {
        PropertyMapper propertyMapper = new PropertyMapper();
        public BO.Master.Userdetail Map(SQL.Userdetail dbitem)
        {

            var user = new Userdetail();
            user.UserId = dbitem.UserId;
            user.Username = dbitem.UserName;
            user.Email = dbitem.Email;
            user.MobileNo = dbitem.MobileNo;
            var role = dbitem.Roles.FirstOrDefault();
            if (role != null) {
                user.RoleName = role.Name;
            }
            user.Property = propertyMapper.Map(dbitem.Property);
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
