using PSIUWeb.Models;

namespace PSIUWeb.Data.Interface
{
    public interface IPatientRepository
    {        
        public Patient? GetPatientById(int id);

        public IQueryable<Patient>? GetPatients();

        public Patient? Update(Patient p);

        public Patient? Delete(int id);

        public Patient? Create(Patient p);
    }
}
