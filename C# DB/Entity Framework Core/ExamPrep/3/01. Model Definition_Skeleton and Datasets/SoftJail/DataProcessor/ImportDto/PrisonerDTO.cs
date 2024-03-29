﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerDTO
    {
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        [Required]
        public string IncarcerationDate { get; set; }
        public string ReleaseDate { get; set; }
        public decimal? Bail { get; set; }
        public int CellId { get; set; }
        public MailDTO[] Mails { get; set; }
    }

    public class MailDTO
    {
        public string Description { get; set; }
        public string Sender { get; set; }
        public string Address { get; set; }
    }
}
