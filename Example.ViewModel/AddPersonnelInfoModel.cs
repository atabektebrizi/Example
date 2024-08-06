using Example.DomainLayer.Shared;

namespace Example.ViewModel;

public class AddPersonnelInfoModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
}
