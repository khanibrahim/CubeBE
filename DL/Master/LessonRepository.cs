using AutoMapper;
using BO;
using DL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using BO.Master;

namespace DL.Master
{
    public class LessonRepository : IRepository<BO.Master.Lesson>
    {
        

        public List<BO.Master.Lesson> ToList()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<BO.Master.Lesson> List()
        {
            throw new NotImplementedException();
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
                    _lesson.IsActive = true;
                    _lesson.RCB = item.RCB;
                    _lesson.RUB = item.RCB;
                    _lesson.RCT = DateTime.Now;
                    _lesson.RUT = DateTime.Now;
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
                dbcontext.Lessons.FirstOrDefault(it => it.Id == id).IsActive = false;
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
                SQL.Lesson lquery = dbcontext.Lessons.Where(x => x.IsActive == true).FirstOrDefault(it => it.Id == id);
                if (lquery != null)
                {
                    result = iMapper.Map<SQL.Lesson, BO.Master.Lesson>(lquery);
                };


                return result;
            }
        }

        public ApiResponse<BO.Master.Lesson> GetByQuery(ListQuery<BO.Master.Lesson> query)
        {
            var response = new ApiResponse<BO.Master.Lesson>();

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
                    var _lessons = dbcontext.Lessons.Where(x => x.IsActive == true &&x.Subject.IsActive==true);
                    if (query.Parameters != null) {
                        foreach (var p in query.Parameters) {
                            if (p.Name.ToLower() == "currentuserid") {
                                var val = long.Parse(p.Value);
                                _lessons = _lessons.Where(it => it.RCB == val);
                            }
                        }

                    }
                    foreach (var _lesson in _lessons)
                    {
                        var temp = iMapper.Map<SQL.Lesson, BO.Master.Lesson>(_lesson);
                        temp.Subject = new BO.Master.Subject() {Id=_lesson.Subject.Id,Name=_lesson.Subject.Name, Course=new BO.Master.Course() { Name =_lesson.Subject.Course.Name,Id=_lesson.Subject.Id} };
                        Lesson.Add(temp);

                    }
                    response.Items = Lesson;

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
