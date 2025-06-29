namespace S.A.M.Data.Entities
{
    public class Menu
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public MenuLocation.MenuLocationEnum LocationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;
        public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public MenuLocation MenuLocation { get; set; }

    }
}
