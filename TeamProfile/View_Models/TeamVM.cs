using System.ComponentModel.DataAnnotations;

namespace TeamProfile.View_Models
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        public string? Position { get; set; }
        public string? University { get; set; }
        public string? Mobile { get; set; }
        public string? Portfolio { get; set; }
    }
}
