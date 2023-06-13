using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elfind.Data.Services
{
    public class ObjavaService
    {
        private readonly IDbContextFactory<ElfindContext> dbContextFactory;

        public ObjavaService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<int> DodajObjavu(Objava objava)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    objava.OdNastavnogOsoblja = await context.NastavnoOsoblje.SingleOrDefaultAsync(n => n.ID == objava.OdNastavnogOsoblja.ID);
                    objava.Forum = await context.Forum.SingleOrDefaultAsync(f => f.ID == objava.Forum.ID);

                    context.Objave.Add(objava);
                    await context.SaveChangesAsync();
                }
                return objava.ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public async Task<Objava> PreuzmiObjavu(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Objava objava = await context.Objave.SingleOrDefaultAsync(o => o.ID == ID);
                    return objava;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task ObrisiObjavu(int ID)
        {
            try
            {
                Objava objava = await PreuzmiObjavu(ID);
                if (objava == null)
                {
                    throw new Exception("Objava sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(objava);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Objava>> VratiSveObjave()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Objava> objave = await context.Objave
                        .Include(o => o.OdNastavnogOsoblja)
                        .Include(o => o.Forum)
                        .ToListAsync();
                    return objave;
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
