namespace DataTransfertObjects
{
    public record ItemCategoriesReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
    }
}