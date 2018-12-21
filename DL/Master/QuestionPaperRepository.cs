using AutoMapper;
using BO;
using DL.Mappings;
using DL;
using DL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Master
{
    public class QuestionPaperRepository : IRepository<BO.Master.QuestionPaper>
    {
        private QuestionMapper mapper = new QuestionMapper();

        public List<BO.Master.QuestionPaper> ToList => throw new NotImplementedException();

        public ApiResponse<List<BO.Master.QuestionPaper>> List()
        {
            var response = new ApiResponse<List<BO.Master.QuestionPaper>>();
            var QuestionPapers = new List<BO.Master.QuestionPaper>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SQL.QuestionPaper, BO.Master.QuestionPaper>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new Entities())
            {
                try
                {
                    var _questionpapers = dbcontext.QuestionPapers.OrderByDescending(x => x.Id).ToList();

                    foreach (var _questionpaper in _questionpapers)
                    {
                        QuestionPapers.Add(iMapper.Map<SQL.QuestionPaper, BO.Master.QuestionPaper>(_questionpaper));
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

        public ApiResponse<BO.Master.QuestionPaper> Add(BO.Master.QuestionPaper item)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BO.Master.QuestionPaper, SQL.QuestionPaper>();
            });
            IMapper iMapper = config.CreateMapper();



            using (var dbcontext = new SQL.Entities())
            {
                var response = new ApiResponse<BO.Master.QuestionPaper>();
                response.Item = item;

                //var dbitem = dbcontext.Questions.FirstOrDefault(it => it.id == item.Id);
                try
                {
                    SQL.QuestionPaper _question = iMapper.Map<BO.Master.QuestionPaper, SQL.QuestionPaper>(item);

                    // SQL.questionpaper _question = mapper.Map(item);
                    //SQL.Question _question = dbcontext.Questions.FirstOrDefault();
                    dbcontext.QuestionPapers.Add(_question);
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
                dbcontext.QuestionPapers.Remove(dbcontext.QuestionPapers.FirstOrDefault(it => it.Id == id));
                dbcontext.SaveChanges();
            }
        }

        public BO.Master.QuestionPaper GetById(long id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SQL.QuestionPaper, BO.Master.QuestionPaper>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new Entities())
            {

                BO.Master.QuestionPaper result = new BO.Master.QuestionPaper();
                SQL.QuestionPaper lquery = dbcontext.QuestionPapers.FirstOrDefault(it => it.Id == id);
                if (lquery != null)
                {
                    result = iMapper.Map<SQL.QuestionPaper, BO.Master.QuestionPaper>(lquery);
                };


                return result;
            }
        }

        public ListQueryResult<BO.Master.QuestionPaper> GetByQuery(ListQuery<BO.Master.QuestionPaper> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<BO.Master.QuestionPaper> Update(BO.Master.QuestionPaper item)
        {
            using (var dbcontext = new Entities())
            {
                var response = new ApiResponse<BO.Master.QuestionPaper>();
                response.Item = item;

                var dbitem = dbcontext.QuestionPapers.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {

                    try
                    {
                        dbitem.Html = item.Html;
                        dbitem.SubjectId = item.SubjectId;
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
