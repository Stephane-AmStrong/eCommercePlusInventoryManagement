namespace DataTransfertObjects
{
    public record ItemCategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }

        public virtual ItemsReadDto[] Items { get; set; }
    }
}