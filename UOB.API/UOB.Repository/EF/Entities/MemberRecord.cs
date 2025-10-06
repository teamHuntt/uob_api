using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Shared.Common;

namespace UOB.Repository.EF.Entities
{
    public class MemberRecord: EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid MemberId { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }

        // Navigation properties
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;

        [ForeignKey(nameof(MemberId))]
        public Members Member { get; set; } = null!;
    }
}
