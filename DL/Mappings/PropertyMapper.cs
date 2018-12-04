using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappings
{
    public class PropertyMapper : IMappingProvider<Property, SQL.Property>
    {
        public BO.Master.Property Map(SQL.Property dbitem)
        {
            var item = new Property();
            item.Id = dbitem.Id;
            item.Name = dbitem.Name;
            item.Address1 = dbitem.Address1;
            item.Address2 = dbitem.Address2;
            item.Address3 = dbitem.Address3;
            item.City = dbitem.City;
            item.ContactPerson = dbitem.ContactPerson;
            item.Email = dbitem.Email;
            item.Pincode = dbitem.Pincode;
            item.Mobile = dbitem.Mobile;
            item.RCB = dbitem.RCB;
            item.RUB = dbitem.RUB;
            item.RCT = dbitem.RCT;
            item.RUT = dbitem.RUT;
            return item;
        }

        public SQL.Property Map(BO.Master.Property item)
        {
            throw new NotImplementedException();
        }
    }
}
