namespace Restourant.Models;

public enum OrderStatus
    :byte
{
    Pending,          // Buyurtma kutilmoqda
    Confirmed,       // Buyurtma tasdiqlandi
    InProgress,      // Buyurtma jarayonda
    Shipped,         // Buyurtma jo'natildi
    Delivered,       // Buyurtma yetkazildi
    Canceled,        // Buyurtma bekor qilindi
    Returned,        // Buyurtma qaytarildi
    Refunded         // Buyurtma uchun pul qaytarildi
}
