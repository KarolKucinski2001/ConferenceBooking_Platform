using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Models
{
    public class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentId { get; set; } // Klucz główny

        // Klucz obcy do Room
        public int RoomId { get; set; }
        [Required]
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipmentName { get; set; }

        [Range(1, 20, ErrorMessage = "Quantity out of range")]
        public int Quantity { get; set; }
    }
}
