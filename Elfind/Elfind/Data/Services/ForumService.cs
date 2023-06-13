using Elfind.Data.Model;
using Elfind.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ForumService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public ForumService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajForumAsync(Forum forum)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Forum.Add(forum);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Forum> PreuzmiForumAsync(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Forum forum = await context.Forum.SingleOrDefaultAsync(x => x.ID == ID);
                    return forum;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task ObrisiForumAsync(int ID)
        {
            try
            {
                Model.Forum forum = await PreuzmiForumAsync(ID);
                if (forum == null)
                {
                    throw new Exception("Forum sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(forum);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Objava>> VratiSveObjave(int forumId)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Forum forum = await context.Forum
                        .Include(f => f.Objave)
                        .SingleOrDefaultAsync(f => f.ID == forumId);

                    if (forum != null)
                    {
                        return forum.Objave.ToList();
                    }
                    else
                    {
                        throw new Exception("Forum sa datim ID-jem ne postoji!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
