namespace Posts_project.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
        public string Description { get; set; }
    }
}