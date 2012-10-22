using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Db4objects.Db4o.Config.Attributes;

namespace ClipHub.Code.Models
{
    public class ClipboardEntry
    {
        [Indexed]
        public string mclipboardContents;

        // Declare a Name property of type string:
        public string clipboardContents
        {
            get
            {
                return mclipboardContents;
            }
            set
            {
                mclipboardContents = value;
            }
        }

        public String getClipboardContents()
        {
            return this.clipboardContents;
        }

        public String applicationClippedFrom { get; set; }
        public Object dataClipboardContents { get; set; }
        public DateTime dateClipped { get; set; }
        public Boolean pinned { get; set; }
        public int ID { get; set; }

        public void setToClipboard()
        {
            App.skipNextPaste = true;

            Clipboard.SetText(this.clipboardContents, TextDataFormat.Text);
        }


    }
}
