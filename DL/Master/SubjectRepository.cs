﻿using AutoMapper;
using BO;
using BO.Master;
using DL.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DL.Master
{
    public class SubjectRepository : IRepository<BO.Master.Subject>
    {
        public ApiResponse<BO.Master.Subject> Add(BO.Master.Subject item)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BO.Master.Subject, SQL.Subject>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new SQL.Entities())
            {
                var response = new ApiResponse<BO.Master.Subject>();

                response.Item = item;

                try
                {
                    SQL.Subject _subject = iMapper.Map<BO.Master.Subject, SQL.Subject>(item);
                    _subject.RCT = DateTime.Now;
                    // SQL.questionpaper _question = mapper.Map(item);
                    //SQL.Question _question = dbcontext.Questions.FirstOrDefault();
                    dbcontext.Subjects.Add(_subject);
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
                dbcontext.Subjects.FirstOrDefault(it => it.Id == id).IsActive = false;
                dbcontext.SaveChanges();
            }
        }

        public BO.Master.Subject GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<BO.Master.Subject> GetByQuery(ListQuery<BO.Master.Subject> query)
        {
           var response = new ApiResponse<BO.Master.Subject>();

            var Subject = new List<BO.Master.Subject>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SQL.Subject, BO.Master.Subject>();
            });

            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new Entities())
            {
                try
                {
                    var _subjects = dbcontext.Subjects.Where(x => x.IsActive == true).OrderByDescending(x => x.Id).ToList();

                    foreach (var _subject in _subjects)
                    {
                        Subject.Add(iMapper.Map<SQL.Subject, BO.Master.Subject>(_subject));
                    }
                    response.Items = Subject;
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

        public ApiResponse<BO.Master.Subject> Update(BO.Master.Subject item)
        {
            using (var dbcontext = new Entities())
            {
                var response = new ApiResponse<BO.Master.Subject>();
                response.Item = item;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BO.Master.Subject, SQL.Subject>();
                });

                IMapper iMapper = config.CreateMapper();

                var dbitem = dbcontext.Subjects.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {
                    try
                    {
                        dbitem.Acronym = item.Acronym;
                        dbitem.Name = item.Name;
                        dbitem.Part = item.Part;
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
