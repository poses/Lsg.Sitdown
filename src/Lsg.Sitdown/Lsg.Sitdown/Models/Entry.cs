﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lsg.Sitdown.Models
{
    public class Entry
    {
        public int Id;
        public string Username { get; set; }
        public string Yesterday { get; set; }
        public string Today { get; set; }
        public string Obstacles { get; set; }
    }
}
