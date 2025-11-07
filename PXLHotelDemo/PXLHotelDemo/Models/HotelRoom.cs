using PXLHotelDemo.ModelValidators;
using System.ComponentModel.DataAnnotations;

namespace PXLHotelDemo.Models
{
    public class HotelRoom
    {
        public int HotelRoomId { get; set; }
        public int HotelId { get; set; }
        [Required, HotelRoomNameValidator]
        public string HotelRoomName { get; set; }
        [HotelRoomNumberValidator]
        public int HotelRoomNumber { get; set; }
    }
}
