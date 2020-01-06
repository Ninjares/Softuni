using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public BookId[] Books { get; set; }

    }
    public class BookId
    {
        public int? Id { get; set; }
    }
}
