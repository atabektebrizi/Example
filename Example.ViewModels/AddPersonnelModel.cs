using Example.DomainLayer.Shared;

namespace Example.ViewModels;

public class AddPersonnelModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public GenderType Gender { get; set; }
    public DateTime BirthDate { get; set; }

    public int DistrictId { get; set; }
}
