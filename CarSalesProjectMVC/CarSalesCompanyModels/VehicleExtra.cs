//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarSalesCompanyModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleExtra
    {
        public VehicleExtra()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public int Id_Extras { get; set; }
        public bool ABS { get; set; }
        public bool ESP { get; set; }
        public bool ElectricWindows { get; set; }
        public bool ElectricSideMirrors { get; set; }
        public bool AirConditioner { get; set; }
        public bool AuxiliaryHeater { get; set; }
    
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
