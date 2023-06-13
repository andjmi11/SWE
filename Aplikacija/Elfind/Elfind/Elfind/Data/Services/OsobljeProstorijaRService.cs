using Elfind.Data.Models;
using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class OsobljeProstorijaRService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public OsobljeProstorijaRService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajOsobljeProstorijaR(OsobljeProstorijaR opr)
        {
            try
            { 
                using (var context = dbContextFactory.CreateDbContext())
                {
                   

                    opr.Prostorija = await context.Prostorije.SingleOrDefaultAsync(n => n.ID == opr.Prostorija.ID);
                    opr.NastavnoOsoblje = await context.NastavnoOsoblje.SingleOrDefaultAsync(n => n.ID == opr.NastavnoOsoblje.ID);

                    ProstorijaService pService = new ProstorijaService(dbContextFactory);
                    Prostorija prostorija = await pService.PreuzmiProstoriju(opr.Prostorija.ID);

                    NastavnoOsobljeService nService = new NastavnoOsobljeService(dbContextFactory);
                    NastavnoOsoblje nastavnoOsolje = await nService.PreuzmiNastavnoOsobljeAsync(opr.NastavnoOsoblje.ID);

                    prostorija.NastavnoOsobljeR.Add(opr);
                    nastavnoOsolje.RezProstorije.Add(opr);

                    context.OsobljeProstorijaRSpoj.Add(opr);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
