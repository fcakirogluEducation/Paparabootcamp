using System.Security.AccessControl;

namespace TokenAuth.Repository.Models.ManyToMany
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<Student>? Students { get; set; }
    }
}