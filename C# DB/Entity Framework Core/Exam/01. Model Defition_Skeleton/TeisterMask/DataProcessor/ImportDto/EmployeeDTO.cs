using System.Collections.Generic;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<int> Tasks { get; set; } = new List<int>();
    }
}
