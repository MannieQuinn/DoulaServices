﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoulaServices.Models.DoMo
{
    public class ListItem
    {
        public int DoMoId { get; set; }
        public int DoulaId { get; set; }
        public int MotherId { get; set; }
        public string Notes { get; set; }
    }
}