using PSIUWeb.Models;

namespace PSIUWeb.Data.Interface
{
    public interface IPsychologistRepository
    {
        public Psychologist? GetPsychologistById(int id);

        public IQueryable<Psychologist>? GetPsychologists();

        public Psychologist? Update(Psychologist p);

        public Psychologist? Delete(int id);

        public Psychologist? Create(Psychologist p);
    }
}
