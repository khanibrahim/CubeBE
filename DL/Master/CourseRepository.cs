using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using AutoMapper;

namespace DL.Master
{
    public class CourseRepository:IRepository<Course>
    {
     
        public List<Course> ToList => throw new NotImplementedException();

         public ListQueryResult<Course> GetByQuery(ListQuery<Course> query)
        {
            var result = new ListQueryResult<Course>();
            using (var dbcontext = new SQL.CubeEntities())
            {       
                result.Items = new List<Course>();
                Mapper.Reset();
                Mapper.Initialize(conf => conf.CreateMap<SQL.Course, Course>());
                var lquery = dbcontext.Courses.Where(it => it.RCB == query.CurrentUserId && it.IsActive == true);
                if (lquery.Count() > 0) {
                    result.TotalRecords = lquery.Count();
                    foreach(var dbitem in lquery)
                    {
                        result.Items.Add(Mapper.Map<SQL.Course, Course>(dbitem));
                    }
                }
            }
            return result;
        }

        public Course GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Course> Add(Course item)
        {
            using (var dbcontext = new SQL.CubeEntities())
            {
                var response = new ApiResponse<Course>();
                response.Item = item;
                var dbitem = new SQL.Course();
                    try
                    {
                        // / Mapper.Reset();
                        //Mapper.Initialize(conf => conf.CreateMap<Course, SQL.Course>());
                        //Mapper.Map(item, dbitem);
                       // dbitem = Mapper.Map<Course, SQL.Course>(item);
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
            using (var dbcontext = new SQL.CubeEntities())
            {
                var response = new ApiResponse<Course>();
                response.Item = item;

                var dbitem = dbcontext.Courses.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {
                    try
                    {
                      // / Mapper.Reset();
                        //Mapper.Initialize(conf => conf.CreateMap<Course, SQL.Course>());
                        //Mapper.Map(item, dbitem);
                       // dbitem = Mapper.Map<Course, SQL.Course>(item);
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
            using (var dbcontext = new SQL.CubeEntities()) {
                var item = dbcontext.Courses.FirstOrDefault(it => it.Id == id);
                item.IsActive = false;
                dbcontext.SaveChanges();
            }
        }
    }
}
