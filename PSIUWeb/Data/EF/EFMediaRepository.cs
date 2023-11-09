using PSIUWeb.Data.Interface;
using PSIUWeb.Models;
using System.Linq;

namespace PSIUWeb.Data.EF
{
    public class EFMediaRepository : IMediaRepository
    {
        private AppDbContext context;

        public EFMediaRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Media? Create(Media m)
        {
            try
            {
                context.Medias?.Add(m);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return m;
        }

        public Media? Delete(int id)
        {
            Media? m = GetMediaById(id);

            if (m == null)
                return null;

            context.Medias?.Remove(m);
            context.SaveChanges();

            return m;


        }

        public Media? GetMediaById(int id)
        {
            Media? m =
                context
                    .Medias?
                    .Where(m => m.Id == id)
                    .FirstOrDefault();

            return m;

        }

        public IQueryable<Media>? GetMedias()
        {
            return context.Medias;
        }

        public Media? Update(Media m)
        {
            try
            {
                context.Medias?.Update(m);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return m;
        }
    }
}
