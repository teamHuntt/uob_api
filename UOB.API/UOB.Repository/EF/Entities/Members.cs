using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Shared.Common;

namespace UOB.Repository.EF.Entities
{
    public class Members: EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<MemberRecord>? MemberRecords { get; set; }
    }
}
