﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
