using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDashBoardService.Data.DB
{
    public class Stories
    {
        public long Id { get; set; }
        public string StoryName { get; set; }
        public int StoryPoint { get; set; }
    }
}
