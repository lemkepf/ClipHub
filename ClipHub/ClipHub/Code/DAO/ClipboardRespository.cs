using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClipHub.Code;
using ClipHub.Code.Models;

namespace ClipHub.Code.DAO
{
    public class ClipboardRespository : IClipboardRepository, IDisposable
    {
        private IDataAccess db; 

        public ClipboardRespository(String dbName)
        {
            db = new Db4oDataAccess(dbName);
        }

        public void Insert(ClipboardEntry item)
        {
            //check to see if already exist, if so, just update time then save. 
            ClipboardEntry oldItem = db.Where<ClipboardEntry>(a => a.clipboardContents == item.clipboardContents).ToList().FirstOrDefault();

            if (oldItem != null)
            {
                oldItem.dateClipped = item.dateClipped;
                db.Save(oldItem);
            }
            else
            {
                db.Save(item);
            }
        }

        public void Save(ClipboardEntry item)
        {
            db.Save(item);
        }

        public void Delete(ClipboardEntry item)
        {
            db.Delete(item);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<ClipboardEntry> getAllClipboardentryList()
        {
            return db.All<ClipboardEntry>().OrderByDescending(p => p.pinned == true).ThenByDescending(p => p.dateClipped).ToList();
        }

        public List<ClipboardEntry> getAllClipboardentryListFilter(String filterText)
        {
            return db.Where<ClipboardEntry>(a => a.clipboardContents.ToLower().Contains(filterText.ToLower())).OrderByDescending(p => p.pinned == true).ThenByDescending(p => p.dateClipped).ToList();
        }
    }
}
