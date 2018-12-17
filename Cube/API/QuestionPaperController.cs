﻿using BL.Master;
using BO.Master;
using System.Collections.Generic;
using System.Web.Http;

namespace Cube.API
{
    public class QuestionPaperController : ApiController
    {
        private QuestionPaperService service = new QuestionPaperService();

        private UserService userService = new BL.Master.UserService();

        public List<QuestionPaper> Get()
        {
            return service.List().Item;
        }

        public string Get(int id)
        {
            return "value";
        }

        public List<QuestionPaper> Post(QuestionPaper item)
        {
            service.Add(item);
            return service.List().Item;
        }

        public List<QuestionPaper> Put(int id, QuestionPaper item)
        {
            service.Update(item);
            return service.List().Item;
        }

        public List<QuestionPaper> Delete(int id)
        {
            service.Delete(id);
            return service.List().Item;
        }
    }
}