using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentDTO
    {
        public string Name { get; set; }
        public CellDTO[] Cells { get; set; }
    }
    public class CellDTO
    {
        public int CellNumber { get; set; }
        public bool HasWindow { get; set; }
    }

}
