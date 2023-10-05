using PSIUWeb.Data.Interface;
using PSIUWeb.Models;
using System.Linq;

namespace PSIUWeb.Data.EF
{
    public class EFPsychologistRepository : IPsychologistRepository
    {
        private AppDbContext context;

        public EFPsychologistRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Psychologist? Create(Psychologist p)
        {
            try
            {
                context.Psychologists?.Add(p);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return p;
        }

        public Psychologist? Delete(int id)
        {
            Psychologist? p = GetPsychologistById(id);

            if (p == null)
                return null;

            context.Psychologists?.Remove(p);
            context.SaveChanges();

            return p;


        }

        public Psychologist? GetPsychologistById(int id)
        {
            Psychologist? p =
                context
                    .Psychologists?
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

            return p;

        }

        public IQueryable<Psychologist>? GetPsychologists()
        {
            return context.Psychologists;
        }

        public Psychologist? Update(Psychologist p)
        {
            try
            {
                context.Psychologists?.Update(p);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return p;
        }
    }
}
