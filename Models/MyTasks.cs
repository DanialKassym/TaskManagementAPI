using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class MyTasks
    {
        [Column("id")]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
    }
}
