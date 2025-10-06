using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOB.Shared.Common
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string? UpdatedBy { get; set; }
    }
    public abstract class EntityBase : IAuditableEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
