﻿using AutoMapper;
using BO;
using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Master
{
    public class CourseRepository : IRepository<Course>
    {
        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SQL.Course, BO.Master.Course>();
        });

        public List<Course> ToList => throw new NotImplementedException();

        public ApiResponse<List<Course>> List()
        {
            var response = new ApiResponse<List<Course>>();
            var Courses = new List<Course>();

            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new SQL.Entities())
            {
                try
                {
                    var _courses = dbcontext.Courses.Where(x => x.IsActive == true).OrderByDescending(x => x.Id).ToList();

                    foreach (var _course in _courses)
                    {
                        Courses.Add(iMapper.Map<SQL.Course, BO.Master.Course>(_course));
                    }
                    response.Item = Courses;
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

        public ListQueryResult<Course> GetByQuery(ListQuery<Course> query)
        {
            var result = new ListQueryResult<Course>();
            using (var dbcontext = new SQL.Entities())
            {
                result.Items = new List<Course>();
                Mapper.Reset();
                Mapper.Initialize(conf => conf.CreateMap<SQL.Course, Course>());
                var lquery = dbcontext.Courses.Where(it => it.RCB == query.CurrentUserId && it.IsActive == true);
                if (lquery.Count() > 0)
                {
                    result.TotalRecords = lquery.Count();
                    foreach (var dbitem in lquery)
                    {
                        result.Items.Add(Mapper.Map<SQL.Course, Course>(dbitem));
                    }
                }
            }
            return result;
        }

        public Course GetById(long id)
        {
            IMapper iMapper = config.CreateMapper();

            var course = new Course();
            using (var dbcontext = new SQL.Entities())
            {
                course = iMapper.Map<SQL.Course, Course>(dbcontext.Courses.FirstOrDefault(x => x.Id == id));
            }
            return course;
        }

        public ApiResponse<Course> Add(Course item)
        {
            using (var dbcontext = new SQL.Entities())
            {
                var response = new ApiResponse<Course>();
                response.Item = item;
                var dbitem = new SQL.Course();
                try
                {
                    dbitem.Name = item.Name;
                    dbitem.Description = item.Description;
                    dbitem.PropertyId = item.PropertyId;
                    dbitem.RCB = item.RCB;
                    dbitem.RUB = item.RUB;
                    dbitem.RCT = DateTime.Now;
                    dbitem.RUT = DateTime.Now;
                    dbitem.IsActive = true;
                    dbcontext.Courses.Add(dbitem);

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

        public ApiResponse<Course> Update(Course item)
        {
            using (var dbcontext = new SQL.Entities())
            {
                var response = new ApiResponse<Course>();
                response.Item = item;

                var dbitem = dbcontext.Courses.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {
                    try
                    {
                        dbitem.Name = item.Name;
                        dbitem.Description = item.Description;
                        dbitem.RUB = item.RUB;
                        dbitem.RUT = DateTime.Now;
                        dbitem.IsActive = item.IsActive;
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
                    response.ErrorMessage = "No Course Found";

                }
                return response;
            }
        }

        public void Delete(long id)
        {
            using (var dbcontext = new SQL.Entities())
            {
                dbcontext.Courses.FirstOrDefault(it => it.Id == id).IsActive = false;
                dbcontext.SaveChanges();
            }
        }
    }
}
