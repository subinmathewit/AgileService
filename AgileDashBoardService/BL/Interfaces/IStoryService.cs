using AgileDashBoardService.Data.DB;
using AgileDashBoardService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDashBoardService.BL.Interfaces
{
    public interface IStoryService
    {
        public Task<long> AddStoryAsync(Story story);
        public List<Stories> GetAutoSelectedStoriesAsync(int storyPoint );
        public List<Stories> GetAll();
        public int RemoveAllStories();
    }
}
