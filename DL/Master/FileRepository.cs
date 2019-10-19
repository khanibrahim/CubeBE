using AutoMapper;
using BO;
using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Master
{
    public class FileRepository : IRepository<BO.Master.File>
    {
        public List<File> ToList;

        

        public ApiResponse<List<File>> List()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SQL.FileRepository, BO.Master.File>();
            });
            var response = new ApiResponse<List<File>>();
            var Files = new List<File>();

            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new SQL.Entities())
            {
                try
                {
                    var _files = dbcontext.FileRepositories.OrderByDescending(x => x.Id).ToList();

                    foreach (var _file in _files)
                    {
                        Files.Add(iMapper.Map<SQL.FileRepository, BO.Master.File>(_file));
                    }
                    response.Item = Files;
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

        public ApiResponse<File> GetByQuery(ListQuery<File> query)
        {
            var result = new ApiResponse<File>();
            using (var dbcontext = new SQL.Entities())
            {
                result.Items = new List<File>();
                Mapper.Reset();
                Mapper.Initialize(conf => conf.CreateMap<SQL.FileRepository, File>());
                var lquery = dbcontext.FileRepositories.Where(it => it.RCB == query.CurrentUserId && it.IsActive == true);
                if (lquery.Count() > 0)
                {
                    result.TotalRecords = lquery.Count();
                    foreach (var dbitem in lquery)
                    {
                        result.Items.Add(Mapper.Map<SQL.FileRepository, File>(dbitem));
                    }
                }
            }
            return result;
        }

        public File GetById(long id)
        {
            throw new NotImplementedException();
        }

        public List<File> GetById(long ParentId, string ParentName)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SQL.FileRepository, BO.Master.File>();
            });
            IMapper iMapper = config.CreateMapper();

            var file = new List<File>();
            using (var dbcontext = new SQL.Entities())
            {
                var files = dbcontext.FileRepositories.Where(x => x.ParentTableCode == ParentId && x.ParentTableName == ParentName);


                foreach (var _file in files)
                {
                    file.Add(iMapper.Map<SQL.FileRepository, File>(_file));
                }

            }
            return file;
        }

        public ApiResponse<File> Add(File item)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<File, SQL.FileRepository>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var dbcontext = new SQL.Entities())
            {
                var response = new ApiResponse<File>();
                response.Item = item;
                var dbitem = new SQL.FileRepository();
                try
                {
                    SQL.FileRepository frep = iMapper.Map<File, SQL.FileRepository>(item);
                    dbcontext.FileRepositories.Add(frep);
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

        public ApiResponse<File> Update(File item)
        {
            using (var dbcontext = new SQL.Entities())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<File, SQL.FileRepository>();
                });
                IMapper iMapper = config.CreateMapper();
                var response = new ApiResponse<File>();
                response.Item = item;

                var dbitem = dbcontext.FileRepositories.FirstOrDefault(it => it.Id == item.Id);

                if (dbitem != null)
                {
                    try
                    {
                        dbitem.FileName = item.FileName;
                        dbitem.FileType = item.FileType;
                        dbitem.FileBinary = item.FileBinary;
                        dbitem.ParentTableName = item.ParentTableName;
                        dbitem.ParentTableCode = item.ParentTableCode;
                        dbitem.RUB = item.RUB;
                        dbitem.RUT = DateTime.Now;
                        dbitem.IsActive = item.IsActive.Value;
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
                    response.ErrorMessage = "No File Found";

                }
                return response;
            }
        }

        public void Delete(long id)
        {
            using (var dbcontext = new SQL.Entities())
            {
                dbcontext.FileRepositories.FirstOrDefault(it => it.Id == id).IsActive = false;
                dbcontext.SaveChanges();
            }
        }
    }
}
