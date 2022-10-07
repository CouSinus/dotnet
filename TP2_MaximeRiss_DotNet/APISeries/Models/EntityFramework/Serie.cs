using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISeries.Models.EntityFramework
{
    [Table("t_e_serie_ser")]
    public partial class Serie
    {
        [Key]
        [Column("ser_id")]
        public int SerieId { get; set; }

        [Column("ser_titre")]
        [StringLength(100)]
        public string Titre { get; set; }

        [Column("ser_resume")]
        public string? Resume { get; set; }

        [Column("ser_nbsaisons")]
        public int? NbSaisons { get; set; }

        [Column("ser_nbepisodes")]
        public int? NbEpisodes { get; set; }

        [Column("ser_anneecreation")]
        public int? AnneCreation { get; set; }

        [Column("ser_network")]
        [StringLength(50)]
        public string? Network { get; set; }

        [InverseProperty(nameof(Notation.SerieNotee))]
        public virtual ICollection<Notation> NotesSerie { get; set; }
    }
}
