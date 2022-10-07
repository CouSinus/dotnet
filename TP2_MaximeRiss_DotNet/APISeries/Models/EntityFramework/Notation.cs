using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISeries.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public partial class Notation
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [Column("ser_id")]
        public int SerieId { get; set; }


        [Column("not_note")]
        [Range(0,5)]
        public int Note { get; set; }


        [InverseProperty("NotesUtilisateur")]
        public virtual Utilisateur UtilisateurNotant { get; set; }

        [InverseProperty("NotesSerie")]
        public virtual Serie SerieNotee { get; set; }
    }
}
