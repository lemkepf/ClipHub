using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Service;

namespace ClipHub.Code.Remote
{
    class RemoteStorage 
    {
        public Boolean addClipEntry(ClipHub.Code.Models.ClipboardEntry clip)
        {
            using (IServiceClient client = new ServiceStack.ServiceClient.Web.JsonServiceClient("http://localhost:51304/api/json/syncreply/AddClipboardEntry"))
            {
                ClipboardEntry clipreq = new ClipboardEntry();
                clipreq.clipboardContents = clip.clipboardContents;

                var request = new AddClipboardEntry();
                request.clip = clipreq;

                var response = client.Send<AddClipboardEntryResponse>(request);

            }

            return true;
        }
    }
}
