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

        public List<Question> ToList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ApiResponse<Question> List(int Id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Question> Add(Question item)
        {

            using (var dbcontext = new SQL.Entities())
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
            using (var dbcontext = new SQL.Entities())
            {
                dbcontext.Questions.FirstOrDefault(it => it.Id == id).IsActive = false;
                dbcontext.SaveChanges();
            }
        }

        public Question GetById(long id)
        {
            using (var dbcontext = new SQL.Entities())
            {

                var result = new Question();
                var lquery = dbcontext.Questions.Where(x => x.IsActive == true).FirstOrDefault(it => it.Id == id);
                if (lquery != null)
                {
                    result = mapper.Map(lquery);
                }


                return result;
            }
        }

        public ApiResponse<Question> GetByQuery(ListQuery<Question> query)
        {
            var response = new ApiResponse<Question>();
            var Questions = new List<Question>();

            using (var dbcontext = new SQL.Entities())
            {
                try
                {
                    List<SQL.Question> _questions;



                    
                        //_questions = (from q in dbcontext.Questions
                        //              join l in dbcontext.Lessons
                        //              on q.LessonId equals l.Id
                        //              where l.SubjectId == Id && q.IsActive == true
                        //              select q).ToList();

                    
                        _questions = dbcontext.Questions.Where(x => x.IsActive == true).OrderByDescending(x => x.Id).ToList();
                  

                    foreach (var _question in _questions)
                    {
                        Questions.Add(mapper.Map(_question));
                    }
                    //context.ForEach(x => Questionss.Add(mapper.Map(x)));
                    //Questionss.Add(mapper.Map(context));
                    response.Items = Questions;
                    response.Success = true;
                }
                catch (Exception e)
                {
                    response.Success = false;
                    response.ErrorMessage = e.Message;
                }
                return response;
            }
            throw new NotImplementedException();
        }

        public ApiResponse<Question> Update(Question item)
        {
            using (var dbcontext = new SQL.Entities())
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
