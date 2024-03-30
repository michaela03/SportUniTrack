using System.ComponentModel.DataAnnotations;

namespace SportUniTrack.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; } 
        public int EquipmentId { get; set; } 
        public DateTime BorrowedAt { get; set; } 
        public DateTime? ReturnedAt { get; set; }
    }
}
