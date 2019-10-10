using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Railways.Data;

namespace Railways.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunsController : ControllerBase
    {
        private readonly RailwaysContext railwayContext;
        public RunsController(RailwaysContext context)
        {
            railwayContext = context;
        }

        [Route("/")]
        public IEnumerable<string> GetRuns()
        {
            railwayContext.Runs.Add(new Entities.Run { RunTime = DateTime.UtcNow });
            railwayContext.Runs.Add(new Entities.Run { RunTime = DateTime.UtcNow });
            railwayContext.SaveChanges();
            var runs = railwayContext.Runs.Select(x => x.Id.ToString());
            return runs;
        }
    }
}