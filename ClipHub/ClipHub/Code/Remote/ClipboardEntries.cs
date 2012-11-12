using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface.ServiceModel;

namespace ClipHub.Code.Remote
{
    //Request DTO
    public class AddClipboardEntry
    {
        public ClipboardEntry clip { get; set; }

    }

    //Response DTO
    public class AddClipboardEntryResponse
    {
        public string Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; } //Where Exceptions get auto-serialized
    }

    public class ClipboardEntry
    {
        // Declare a Name property of type string:
        public string clipboardContents { get; set; }
        public String applicationClippedFrom { get; set; }
        public Object dataClipboardContents { get; set; }
        public DateTime dateClipped { get; set; }
        public Boolean pinned { get; set; }
        public string userId { get; set; }
        public Boolean blobStored { get; set; }
    }

}
