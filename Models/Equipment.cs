using System.ComponentModel.DataAnnotations;

namespace SportUniTrack.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // Име на оборудването
        public string Description { get; set; } // Описание
        public int Quantity { get; set; } // Налично количество
    }
}
