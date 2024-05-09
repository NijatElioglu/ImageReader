using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageReader.Models
{
    public class Files
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string FileName { get; set; }
        public bool IsDeleted { get; set; }
        public int OcrStatus { get; set; }
        public string OcrRegionCode { get; set; }

    }
}
