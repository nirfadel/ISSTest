using ISSTest.Core.Model;
using ISSTest.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssController : ControllerBase
    {
        private readonly IRepository _repository;
        public IssController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result =  _repository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody]IssModel issModel)
        {
            if (string.IsNullOrEmpty(issModel.message))
                return BadRequest();

            var result = _repository.SaveIss(issModel);

            return Ok(result);
        }
    }
}
