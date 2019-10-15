using BO;
using BO.Master;
using DL;
using DL.Master;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class FileService : IService<BO.Master.File>
    {
        private FileRepository repository = new FileRepository();

        public List<File> ToList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ApiResponse<List<File>> List()
        {
            return repository.List();
        }

        public ApiResponse<File> Add(File entity)
        {
            return repository.Add(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public File GetById(long id)
        {
            throw new NotImplementedException();
        }

        public List<File> GetById(long ParentId, string ParentName)
        {
            return repository.GetById(ParentId, ParentName);
        }

        public ListQueryResult<File> GetByQuery(ListQuery<File> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<File> Update(File entity)
        {
            return repository.Update(entity);
        }
    }
}
