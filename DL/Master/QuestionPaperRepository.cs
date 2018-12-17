using AutoMapper;
using BO;
using BO.Master;
using DL.Mappings;
using DL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Master
{
    public class QuestionPaperRepository : IRepository<QuestionPaper>
    {
        private QuestionMapper mapper = new QuestionMapper();

        public List<QuestionPaper> ToList => throw new NotImplementedException();

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

        public ApiResponse<List<QuestionPaper>> List()
        {
            var response = new ApiResponse<List<QuestionPaper>>();
            var QuestionPapers = new List<QuestionPaper>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<questionpaper, QuestionPaper>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new SQL.CubeEntities())
            {
                try
                {
                    var _questionpapers = dbcontext.questionpapers.OrderByDescending(x => x.id).ToList();

                    foreach (var _questionpaper in _questionpapers)
                    {
                        QuestionPapers.Add(iMapper.Map<questionpaper, QuestionPaper>(_questionpaper));
                    }
                    response.Item = QuestionPapers;
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

        public ApiResponse<QuestionPaper> Add(QuestionPaper item)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionPaper, SQL.questionpaper>();
            });
            IMapper iMapper = config.CreateMapper();



            using (var dbcontext = new SQL.CubeEntities())
            {
                var response = new ApiResponse<QuestionPaper>();
                response.Item = item;

                //var dbitem = dbcontext.Questions.FirstOrDefault(it => it.id == item.Id);
                try
                {
                    SQL.questionpaper _question = iMapper.Map<QuestionPaper, SQL.questionpaper>(item);

                    // SQL.questionpaper _question = mapper.Map(item);
                    //SQL.Question _question = dbcontext.Questions.FirstOrDefault();
                    dbcontext.questionpapers.Add(_question);
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
                dbcontext.questionpapers.Remove(dbcontext.questionpapers.FirstOrDefault(it => it.id == id));
                dbcontext.SaveChanges();
            }
        }

        public QuestionPaper GetById(long id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<questionpaper, QuestionPaper>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new CubeEntities())
            {

                QuestionPaper result = new QuestionPaper();
                questionpaper lquery = dbcontext.questionpapers.FirstOrDefault(it => it.id == id);
                if (lquery != null)
                {
                    result = iMapper.Map<questionpaper, QuestionPaper>(lquery);
                };


                return result;
            }
        }

        public ListQueryResult<QuestionPaper> GetByQuery(ListQuery<QuestionPaper> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<QuestionPaper> Update(QuestionPaper item)
        {
            using (var dbcontext = new CubeEntities())
            {
                var response = new ApiResponse<QuestionPaper>();
                response.Item = item;

                var dbitem = dbcontext.questionpapers.FirstOrDefault(it => it.id == item.Id);

                if (dbitem != null)
                {

                    try
                    {
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
