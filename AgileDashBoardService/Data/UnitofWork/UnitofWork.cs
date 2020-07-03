using AgileDashBoardService.Data.DB;
using AgileDashBoardService.Data.Repositories;
using AgileDashBoardService.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDashBoardService.Data.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AgileDbContext _context;
        private IEFRepository<Stories> _userRepository;
      
        public UnitofWork(AgileDbContext context)
        {
            this._context = context;

        }

        public IEFRepository<Stories> StoriesRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new EFRepository<Stories>(this._context);
                }

                return this._userRepository;
            }
        }

      
        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

    }
}
