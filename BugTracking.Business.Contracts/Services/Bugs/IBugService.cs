using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.Bugs
{
    public interface IBugService
    {
        void Create(BugViewModel model);

        BugViewModel Get(int id);

        List<BugViewModel> GetAll();

        List<BugViewModel> GetByUserId(int id);

        void Update(BugViewModel model);

        void Delete(int id);

        int OpenBugCount();
    }
}
