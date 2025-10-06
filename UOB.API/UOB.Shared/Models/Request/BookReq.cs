using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOB.Shared.Models.Request
{
    public class BookReq
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;
    }
}
