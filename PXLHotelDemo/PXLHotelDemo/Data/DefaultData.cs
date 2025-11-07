using PXLHotelDemo.Models;

namespace PXLHotelDemo.Data
{
    public static class DefaultData
    {
        public static IEnumerable<Hotel> Hotels => GetHotels();
        public static IEnumerable<HotelRoom> HotelRooms => GetHotelRooms();

        private static IEnumerable<Hotel> GetHotels()
        { 
            List<Hotel> hotels = new ();
            Hotel hotel = new Hotel();
            hotel.HotelName = "Mirage";
            hotel.HotelCountry = "BE";
            hotels.Add(hotel);

            hotel = new();
            hotel.HotelName = "Piramide";
            hotel.HotelCountry = "NL";
            hotels.Add (hotel);

            return hotels;
            
        }

        private static IEnumerable<HotelRoom> GetHotelRooms()
        {
            List<HotelRoom> hotelRooms = new();
            HotelRoom hotelRoom1 = new ();
            hotelRoom1.HotelId = 1;
            hotelRoom1.HotelRoomNumber = 13;
            hotelRoom1.HotelRoomName = "Dracula";
            hotelRooms.Add(hotelRoom1);

            HotelRoom hotelRoom2 = new();
            hotelRoom2.HotelId = 1;
            hotelRoom2.HotelRoomNumber = 14;
            hotelRoom2.HotelRoomName = "Scream";
            hotelRooms.Add(hotelRoom2);

            HotelRoom hotelRoom3 = new();
            hotelRoom3.HotelId = 2;
            hotelRoom3.HotelRoomNumber = 13;
            hotelRoom3.HotelRoomName = "Dracula";
            hotelRooms.Add(hotelRoom3);

            HotelRoom hotelRoom4 = new();
            hotelRoom4.HotelId = 2;
            hotelRoom4.HotelRoomNumber = 14;
            hotelRoom4.HotelRoomName = "London Bridge";
            hotelRooms.Add(hotelRoom4);

            return hotelRooms;
        }
    }
}
