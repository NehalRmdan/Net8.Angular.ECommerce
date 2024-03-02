using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ILogger<BuggyController> _logger;
        private readonly StoreContext _storeContext;

        public BuggyController(StoreContext storeContext,ILogger<BuggyController> logger)
        {
            _storeContext = storeContext;
            _logger = logger;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            var item= _storeContext.Products.Find(44);
            if(item is null)
             return NotFound(new APIResponse(404));

             return Ok();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var item= _storeContext.Products.Find(44);
            
            var x= item.ToString();

             return Ok();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
           
             return BadRequest(new APIResponse(400));
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetBadRequest(int id)
        {
           
             return Ok();
        }


    }
}