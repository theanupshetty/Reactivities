using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;

namespace API.Controllers
{

    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });

        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Domain.Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command { MyActivity = activity }));

        }

        [HttpPut]
        public async Task<IActionResult> EditActivity(Guid Id, [FromBody] Domain.Activity activity)
        {
            activity.Id = Id;
            return Ok(await Mediator.Send(new Edit.Command { MyActivity = activity }));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid Id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = Id }));

        }
    }
}