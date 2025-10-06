using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Shared.Common;

namespace UOB.Repository.EF.Entities
{
    public class Book : EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;

        // Navigation
        public ICollection<MemberRecord>? MemberRecords { get; set; }

    }
}
