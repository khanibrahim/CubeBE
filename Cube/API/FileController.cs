using BL.Master;
using BO.Master;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cube.API
{
    public class FileController : ApiController
    {
        private FileService service = new FileService();

        private UserService userService = new BL.Master.UserService();

        public List<File> Get()
        {
            return service.List().Item;
        }

        public List<File> Get(int id)
        {
            return service.GetById(id, "Question");
        }

        //public File Get(int id)
        //{
        //    return service.GetById(id);
        //}

        public List<File> Post(FileRaw file)
        {
            var substr = file.FileBinary.Substring(22);
            File item = new File()
            {
                Id = file.Id,
                FileName = file.FileName,
                FileType = file.FileType,
                FileBinary = Convert.FromBase64String(substr),
                ParentTableCode = file.ParentTableCode,
                ParentTableName = file.ParentTableName,
                RCB = 1,
                RUB = 1,
                RCT = file.RCT,
                RUT = file.RUT,
                IsActive = file.IsActive
            };

            service.Add(item);
            return service.GetById((long)file.ParentTableCode, "Question");
        }

        public List<File> Put(File item)
        {
            service.Update(item);
            return service.List().Item;
        }

        public List<File> Delete(int id)
        {
            service.Delete(id);
            return service.List().Item;
        }

    }

    public class FileRaw : BO.Base
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileBinary { get; set; }
        public string ParentTableName { get; set; }
        public int? ParentTableCode { get; set; }

    }
}
