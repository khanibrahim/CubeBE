using BO;
using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Master
{
    public class ExaminationService : IService<Examination>
    {

        private DL.Master.ExaminationRepository repository = new DL.Master.ExaminationRepository();
        public ApiResponse<Examination> Add(Examination entity)
        {
            return repository.Add(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public Examination GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Examination> GetByQuery(ListQuery<Examination> query)
        {
            return repository.GetByQuery(query);
        }

        public ApiResponse<Examination> Update(Examination entity)
        {
            return repository.Update(entity);
        }
    }
}
