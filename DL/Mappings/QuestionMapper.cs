﻿using BO.Master;

namespace DL.Mappings
{
    public class QuestionMapper : IMappingProvider<Question, SQL.Question>
    {
        public BO.Master.Question Map(SQL.Question dbitem)
        {
            var item = new Question();
            item.Id = dbitem.Id;
            item.Question1 = dbitem.Question1;
            item.LessonId = dbitem.LessonId;
            item.RCB = dbitem.RCB;
            item.RUB = dbitem.RUB;
            item.RCT = dbitem.RCT;
            item.RUT = dbitem.RUT;
            item.IsActive = dbitem.IsActive;
            return item;
        }

        //internal Property Map(long propertyId)
        //{
        //    var item = new Property();
        //    return item;
        //}

        public SQL.Question Map(BO.Master.Question _item)
        {
            var item = new SQL.Question();
            item.Id = (int)_item.Id;
            item.Question1 = _item.Question1;
            item.LessonId = _item.LessonId;
            item.RCB = _item.RCB;
            item.RUB = _item.RUB;
            item.RCT = _item.RCT;
            item.RUT = _item.RUT;
            item.IsActive = _item.IsActive;
            return item;
        }
    }
}
