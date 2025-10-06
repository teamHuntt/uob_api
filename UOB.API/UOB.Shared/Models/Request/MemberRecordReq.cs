using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOB.Shared.Models.Request
{
    public class MemberRecordReq
    {
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
    }
}
