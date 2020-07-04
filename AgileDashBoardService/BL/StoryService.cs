using AgileDashBoardService.BL.Interfaces;
using AgileDashBoardService.Data.DB;
using AgileDashBoardService.Data.UnitofWork;
using AgileDashBoardService.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDashBoardService.BL
{
    public class StoryService : IStoryService
    {
        private readonly IUnitofWork _unitofWork;
        private ILogger<StoryService> _logger;

        public StoryService(IUnitofWork unitofWork, ILogger<StoryService> logger)
        {
            this._unitofWork = unitofWork;
            this._logger = logger;
        }
        public async Task<long> AddStoryAsync(Story story)
        {
            try
            {
                if (!string.IsNullOrEmpty(story.StoryName) && story.StoryPoint > 0)
                {
                    Stories st = new Stories()
                    {
                        StoryName = story.StoryName,
                        StoryPoint = story.StoryPoint
                    };


                    this._unitofWork.StoriesRepository.Add(st);
                    await this._unitofWork.CompleteAsync();
                    return st.Id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Exception occured at Story Service Add Story Method");
                throw;
            }


            return Convert.ToInt64(0);
        }

        public List<Stories> GetAll()
        {
            try
            {
                return this._unitofWork.StoriesRepository.FindAll().ToList();
            }
            catch(Exception ex)
            {
                this._logger.LogError("Exception occured at Story Service GetAll");
                throw;
            }
        }

        public List<Stories> GetAutoSelectedStoriesAsync(int storyPoint)
        {
            try
            {
                List<Stories> lstStories = new List<Stories>();
                lstStories = this._unitofWork.StoriesRepository.FindAll(i =>i.StoryPoint<=storyPoint).OrderBy(i => i.StoryPoint).ToList();
                int maxsum = 0;
                long? a=null , b=null;

                int sum = lstStories.Sum(i => i.StoryPoint);
                while (sum > storyPoint)
                {
                    var maxValue = lstStories.Max(i => i.StoryPoint);
                    lstStories.Remove(lstStories.Find(i => i.StoryPoint == maxValue));
                    sum = lstStories.Sum(i => i.StoryPoint);
                }
              
                return lstStories;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Exception occured at Story Service at Auto Select Stories");
                throw;
            }
        }

        public int RemoveAllStories()
        {
           try
            {
                var stories = this._unitofWork.StoriesRepository.FindAll().ToList();
                this._unitofWork.StoriesRepository.RemoveRange(stories);
                return this._unitofWork.Complete();
            }
            catch(Exception ex)
            {
                this._logger.LogError("Exception occured at Story Service at RemoveAllStories");
                throw;
            }
        }
    }
}
