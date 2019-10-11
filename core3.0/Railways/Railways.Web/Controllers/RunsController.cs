using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Railways.Data;
using Railways.Entities;

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

        [Route("runs")]
        public IEnumerable<Run> GetRuns()
        {
            using (railwayContext)
            {
                var runs = railwayContext.Runs.Include(x=>x.Route).ToList();
                return runs;
            }
        }
    }
}