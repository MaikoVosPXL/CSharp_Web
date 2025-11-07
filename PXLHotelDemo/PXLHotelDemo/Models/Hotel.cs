using PXLHotelDemo.ModelValidators;
using System.ComponentModel.DataAnnotations;

namespace PXLHotelDemo.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [Required, StringLength(50)]
        public string HotelName { get; set; }
        [Required, HotelCountryValidator]
        public string HotelCountry { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
