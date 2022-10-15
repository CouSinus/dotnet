using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISeries.Models.EntityFramework
{
    public partial class Serie
    {
        public int SerieId { get; set; }
        
        public string Titre { get; set; }

        public string? Resume { get; set; }

        public int? NbSaisons { get; set; }

        public int? NbEpisodes { get; set; }

        public int? AnneCreation { get; set; }

        public string? Network { get; set; }

        [InverseProperty(nameof(Notation.SerieNotee))]
        public virtual ICollection<Notation> NotesSerie { get; set; }
    }
}
