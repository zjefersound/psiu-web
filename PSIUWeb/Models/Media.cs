using System.ComponentModel.DataAnnotations;

namespace PSIUWeb.Models
{
    public class Media
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string MediaType { get; set; }

    }
}
