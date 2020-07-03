using AgileDashBoardService.Data.DB;
using AgileDashBoardService.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDashBoardService.Data.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IEFRepository<Stories> StoriesRepository { get; }        
        int Complete();
        Task<int> CompleteAsync();
    }
}
