namespace CpmPedido.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
