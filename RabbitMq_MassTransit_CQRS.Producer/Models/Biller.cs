namespace RabbitMq_MassTransit_CQRS.Producer.Models
{
    public class Biller
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameMmr { get; set; }
        public bool IsActive { get; set; }
    }
}
