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
                if (!string.IsNullOrEmpty(story.StoryName) && story.StoryPoints > 0)
                {
                    Stories st = new Stories()
                    {
                        StoryName = story.StoryName,
                        StoryPoint = story.StoryPoints
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

        public List<Story> GetAutoSelectedStoriesAsync(int storyPoint)
        {
            try
            {
                List<Story> lstStories = new List<Story>();
                var stories = this._unitofWork.StoriesRepository.FindAll(i =>i.StoryPoint<=storyPoint).OrderBy(i => i.StoryPoint).ToList();
                int maxsum = 0;
                long a = 0, b = 0;
                for (int i = 0; i < stories.Count; i++)
                {
                    for (int j = i + 1; j < stories.Count; j++)
                    {
                        var val = stories[i].StoryPoint + stories[j].StoryPoint;
                        if (val <= storyPoint && val > maxsum)
                        {
                            maxsum = val;
                            a = i;
                            b = j;
                        }
                    }
                }

                if (a > 0)
                {
                    int firsPair = Convert.ToInt32(a);
                    var firstStory = stories[firsPair];
                    lstStories.Add(new Story(){
                        StoryName= firstStory.StoryName,
                        StoryPoints= firstStory.StoryPoint
                    });
                }
                if (b > 0)
                {
                    int secPair = Convert.ToInt32(b);
                    var secondStory = stories[secPair];
                    lstStories.Add(new Story()
                    {
                        StoryName = secondStory.StoryName,
                        StoryPoints = secondStory.StoryPoint
                    });
                }

                return lstStories;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Exception occured at Story Service at Auto Select Stories");
                throw;
            }
        }
    }
}
