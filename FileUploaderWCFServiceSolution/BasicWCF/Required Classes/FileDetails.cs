using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWCF.Required_Classes
{
    public class FileDetails
    {
        public string FileLocation { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
    }
}