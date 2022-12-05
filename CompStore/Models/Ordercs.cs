namespace CompStore.Models
{
    public class Ordercs
    {
        public int Id { get; set; } 
        public string User { get; set; } // имя фамилия покупателя
        public string Address { get; set; } // адрес покупателя
        public string ContactPhone { get; set; } // контактный телефон покупателя
        public int LaptopID { get; set; } // ссылка на связанную модель Phone
        public Laptop Laptop { get; set; }
    }
}
