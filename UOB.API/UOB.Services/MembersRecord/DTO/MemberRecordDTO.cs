﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOB.Services.MembersRecord.DTO
{
    public class MemberRecordDTO
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = null!;
        public Guid MemberId { get; set; }
        public string MemberName { get; set; } = null!;
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
