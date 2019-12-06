namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Balance { get; set; }
        [XmlArray("Tickets")]
        public TicketDTO[] Tickets { get; set; }
    }

    [XmlType("Ticket")]
    public class TicketDTO
    {
       public int ProjectionId { get; set; }
       public decimal Price { get; set; }
    }
}
