﻿using Example.DomainLayer.Shared;

namespace Example.DomainLayer;

public class City : BaseClass
{    
    public string Name { get; set; }      
    public virtual ICollection<District> Districts { get; set; } = new List<District>(); 
}
