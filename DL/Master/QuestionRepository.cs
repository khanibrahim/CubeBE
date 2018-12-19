using BO;
using BO.Master;
using DL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Master
{
    public class QuestionRepository : IRepository<Question>
    {
        private QuestionMapper mapper = new QuestionMapper();

        public List<Question> ToList => throw new NotImplementedException();

        //public ListQueryResult<Question> GetByQuery()
        //{
        //    var Listqueryresult = new ListQueryResult<Question>();
        //    var Questions = new List<Question>();

        //    using (var dbcontext = new SQL.CubeEntities())
        //    {
        //        dbcontext.Questions.ToList().ForEach(x => Questions.Add(mapper.Map(x)));
        //        Listqueryresult.Items = Questions;
        //        return Listqueryresult;
        //    }
        ////}

        public ApiResponse<List<Question>> List()
        {
            var response = new ApiResponse<List<Question>>();
            var Questions = new List<Question>();

            using (var dbcontext = new SQL.CubeEntities())
            {
                try
                {
                    var _questions = dbcontext.Questions.OrderByDescending(x => x.Id).ToList();

                    foreach (var _question in _questions)
                    {
                        Questions.Add(mapper.Map(_question));
                    }
                    //context.ForEach(x => Questionss.Add(mapper.Map(x)));
                    //Questionss.Add(mapper.Map(context));
                    response.Item = Questions;
                    response.Success = true;
                }
                catch (Exception e)
                {
                    response.Success = false;
                    response.ErrorMessage = e.Message;
                }
                return response;
            }
        }

        public ApiResponse<Question> Add(Question item)
        {

            using (var dbcontext = new SQL.CubeEntities())
            {
                var response = new ApiResponse<Question>();
                response.Item = item;

                //var dbitem = dbcontext.Questions.FirstOrDefault(it => it.id == item.Id);
                try
                {
                    SQL.Question _question = mapper.Map(item);
                    //SQL.Question _question = dbcontext.Questions.FirstOrDefault();
                    dbcontext.Questions.Add(_question);
                    dbcontext.SaveChanges();
                    response.Success = true;
                }
                catch (Exception e)
                {

                    response.Success = false;
                    response.ErrorMessage = e.Message;
                    response.DetailedError = e;

                }

                return response;
            }
        }

        public void Delete(long id)
        {
            using (var dbcontext = new SQL.CubeEntities())
            {
                dbcontext.Questions.Remove(dbcontext.Questions.FirstOrDefault(it => it.Id == id));
                dbcontext.SaveChanges();
            }
        }

        public Question GetById(long id)
        {
            using (var dbcontext = new SQL.CubeEntities())
            {

                var result = new Question();
                var lquery = dbcontext.Questions.FirstOrDefault(it => it.Id == id);
                if (lquery != null)
                {
                    result = mapper.Map(lquery);
                }


                return result;
            }
        }

        public ListQueryResult<Question> GetByQuery(ListQuery<Question> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Question> Update(Question item)
        {
            using (var dbcontext = new SQL.CubeEntities())
            {
                var response = new ApiResponse<Question>();
                response.Item = item;

                var dbitem = dbcontext.Questions.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {

                    try
                    {
                        dbitem.Question1 = item.Question1;
                        dbitem.LessonId = item.LessonId;

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
                    response.ErrorMessage = "No Question Found";

                }
                return response;
            }
        }
    }
}
