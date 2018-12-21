using AutoMapper;
using BO;
using DL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Master
{
    public class LessonRepository : IRepository<BO.Master.Lesson>
    {

        public List<BO.Master.Lesson> ToList => throw new NotImplementedException();

        public ApiResponse<List<BO.Master.Lesson>> List()
        {
            var response = new ApiResponse<List<BO.Master.Lesson>>();

            var Lesson = new List<BO.Master.Lesson>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SQL.Lesson, BO.Master.Lesson>();
            });

            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new Entities())
            {
                try
                {
                    var _lessons = dbcontext.Lessons.OrderByDescending(x => x.Id).ToList();

                    foreach (var _lesson in _lessons)
                    {
                        Lesson.Add(iMapper.Map<SQL.Lesson, BO.Master.Lesson>(_lesson));
                    }
                    response.Item = Lesson;
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

        public ApiResponse<BO.Master.Lesson> Add(BO.Master.Lesson item)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BO.Master.Lesson, SQL.Lesson>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new SQL.Entities())
            {
                var response = new ApiResponse<BO.Master.Lesson>();

                response.Item = item;

                try
                {
                    SQL.Lesson _lesson = iMapper.Map<BO.Master.Lesson, SQL.Lesson>(item);
                    dbcontext.Lessons.Add(_lesson);
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
                dbcontext.Lessons.Remove(dbcontext.Lessons.FirstOrDefault(it => it.Id == id));
                dbcontext.SaveChanges();
            }
        }

        public BO.Master.Lesson GetById(long id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SQL.Lesson, BO.Master.Lesson>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new Entities())
            {

                BO.Master.Lesson result = new BO.Master.Lesson();
                SQL.Lesson lquery = dbcontext.Lessons.FirstOrDefault(it => it.Id == id);
                if (lquery != null)
                {
                    result = iMapper.Map<SQL.Lesson, BO.Master.Lesson>(lquery);
                };


                return result;
            }
        }

        public ListQueryResult<BO.Master.Lesson> GetByQuery(ListQuery<BO.Master.Lesson> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<BO.Master.Lesson> Update(BO.Master.Lesson item)
        {
            using (var dbcontext = new Entities())
            {
                var response = new ApiResponse<BO.Master.Lesson>();
                response.Item = item;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BO.Master.Lesson, SQL.Lesson>();
                });

                IMapper iMapper = config.CreateMapper();

                var dbitem = dbcontext.Lessons.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {
                    try
                    {
                        dbitem.Name = item.Name;
                        dbitem.SubjectId = item.SubjectId;
                        dbitem.Unit = item.Unit;
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
                    response.ErrorMessage = "No Lesson Found";

                }
                return response;
            }
        }
    }
}
