﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClipboardPro.Code.Models
{
    public class ClipboardEntry
    {
        public String clipboardContents { get; set; }
        public DateTime dateClipped { get; set; }
        public int ID { get; set; }

        public String clipboardShort()
        {
            return this.clipboardContents.Substring(0, 50);
        }
    }
}