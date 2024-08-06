using Example.DomainLayer.Shared;

namespace Example.DomainLayer;

public class District : BaseClass
{
    public int CityId { get; set; }
    public City City { get; set; }

    public string Name { get; set; }    

    public virtual ICollection<Personnel> Personnels { get; set; }=new List<Personnel>();
}
