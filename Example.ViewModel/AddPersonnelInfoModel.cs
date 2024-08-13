using Example.DomainLayer.Shared;
using System.ComponentModel.DataAnnotations;

namespace Example.ViewModel;

public class AddPersonnelInfoModel
{
    public int Id { get; set; }

    [Required(ErrorMessage ="İsim girilmesi zorunludur.")]
    [StringLength(100, ErrorMessage ="İsim max karakter sayısı 100.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Doğum Tarihi girilmesi zorunludur.")]
    [DataType(DataType.Date,ErrorMessage ="Data tipi tarih olması lazım.")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Cinsiyet girilmesi zorunludur.")]
    public GenderType Gender { get; set; }

    [Required(ErrorMessage = "Şehir girilmesi zorunludur.")]
    [StringLength(100, ErrorMessage = "Max karakter sayısı 100.")]
    public string CityName { get; set; }

    [StringLength(100, ErrorMessage = "İlçe max karakter sayısı 100.")]
    public string DistrictName { get; set; }
}
