using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileDashBoardService.BL.Interfaces;
using AgileDashBoardService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgileDashBoardService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        private readonly ILogger<StoryController> _logger;
        public StoryController(IStoryService storySerivce, ILogger<StoryController> logger)
        {
            this._storyService = storySerivce;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Story st)
        {
            try
            {
                if (st != null)
                {
                    var id = await this._storyService.AddStoryAsync(st);
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }

            catch (Exception ex)
            {
                this._logger.LogError("Exception occured at Story Controller at Add Story");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> AutoSelect(int storyPoint)
        {
            try
            {

                var lst =  this._storyService.GetAutoSelectedStoriesAsync(storyPoint);
                return Ok(lst);


               
            }

            catch (Exception ex)
            {
                this._logger.LogError("Exception occured at Story Controller at Add Story");
                throw;
            }
        }
    }
}