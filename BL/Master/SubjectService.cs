using BO;
using BO.Master;
using DL;
using DL.Master;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class SubjectService : IService<Subject>
    {
        public ApiResponse<Subject> Add(Subject entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Subject GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Subject> GetByQuery(ListQuery<Subject> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Subject> Update(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
