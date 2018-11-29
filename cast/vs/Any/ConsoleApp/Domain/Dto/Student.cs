
namespace ConsoleApp.Domain.Dto
{
    public class StudentDto : PersonalDto
    {
        public long ClassId { get; set; }

        public string School { get; set; }

        public int Post { get; set; }

    }
}