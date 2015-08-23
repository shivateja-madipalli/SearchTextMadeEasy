using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWCF.Required_Classes
{
    public class SelectedFilesDetails
    {
        public string FileLocation { get; set; }
        //public string FileName { get; set; }
        public List<Words> searchedWords { get; set; }
    }
}