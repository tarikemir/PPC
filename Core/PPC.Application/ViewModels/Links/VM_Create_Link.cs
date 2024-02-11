using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.ViewModels.Links
{
    public class VM_Create_Link
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public long ClickCount { get; set; }
    }
}
