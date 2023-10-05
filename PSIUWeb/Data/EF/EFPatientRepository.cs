using PSIUWeb.Data.Interface;
using PSIUWeb.Models;
using System.Linq;

namespace PSIUWeb.Data.EF
{
    public class EFPatientRepository : IPatientRepository
    {
        private AppDbContext context;

        public EFPatientRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Patient? Create(Patient p)
        {
            try
            {
                context.Patients?.Add(p);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return p;
        }

        public Patient? Delete(int id)
        {
            Patient? p = GetPatientById(id);
            
            if (p == null)            
                return null;

            context.Patients?.Remove(p);
            context.SaveChanges();

            return p;
            

        }

        public Patient? GetPatientById(int id)
        {
            Patient? p = 
                context
                    .Patients?
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

            return p;

        }

        public IQueryable<Patient>? GetPatients()
        {
            return context.Patients;
        }

        public Patient? Update(Patient p)
        {
            try
            {
                context.Patients?.Update(p);
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
