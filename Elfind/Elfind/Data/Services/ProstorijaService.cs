using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ProstorijaService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public ProstorijaService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
    }
}
