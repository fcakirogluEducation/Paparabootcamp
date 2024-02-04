namespace TokenAuth.Repository.Models.ManyToMany
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public List<Teacher>? Teachers { get; set; }
    }
}