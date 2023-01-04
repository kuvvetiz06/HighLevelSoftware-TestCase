using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MulakatProjesi.Models;

public class ContactVM
{
    // zorunlu, max 128 karakter
    [DisplayName("Ad Soyad"),Required(ErrorMessage ="{0} gereklidir"), MaxLength(128,ErrorMessage ="{0} max {1} karakter olmalıdır")]
    public string Name { get; set; }

    // zorunlu, max 10 min 10 karakter, geçerli bir telefon numarası olmak zorundadır. örn: 5555555555
    [DisplayName("Telefon"),Required(ErrorMessage ="{0} gereklidir"), MaxLength(10,ErrorMessage = "{0} max {1} karakter olmalıdır"), MinLength(10, ErrorMessage = "{0} min {1} karakter olmalıdır")]
    public string PhoneNumber { get; set; }

    // zorunlu, geçerli bir email adresi olması gerekir
    [DisplayName("E-Mail"),Required(ErrorMessage ="{0} gereklidir"), EmailAddress]
    public string Email { get; set; }

    // zorunlu, max 256 karakter
    [DisplayName("Mesaj"),Required(ErrorMessage ="{0} gereklidir"), MaxLength(256, ErrorMessage= "{0} max {1} karakter olmalıdır")]
    public string Message { get; set; }
}