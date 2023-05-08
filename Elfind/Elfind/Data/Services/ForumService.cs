using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ForumService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public ForumService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }   

        public void dodajForum(Forum forum)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Forum.Add(forum);
                context.SaveChanges();
            }
        }

        public Forum preuzmiForum(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Forum forum = context.Forum.SingleOrDefault(x => x.ID == ID);
                return forum;
            }
        }

        //public void azurirajForum(int ID)
        //{

        //}

        public void obrisiForum(int ID)
        {
            Forum forum = preuzmiForum(ID);
            if (forum == null)
            {
                throw new Exception("Forum sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(forum);
                context.SaveChanges();
            }

        }
    }
}
