using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOB.Services.Books
{
    public class BooksDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }

    }
}
