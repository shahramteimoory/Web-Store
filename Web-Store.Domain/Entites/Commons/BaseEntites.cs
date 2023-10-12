namespace Web_Store.Domain.Entites.Commons
{
    public abstract class BaseEntites<Tkey>
    {
        public Tkey Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }
    public abstract class BaseEntites : BaseEntites<long>
    {

    }
}
