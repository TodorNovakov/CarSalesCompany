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
        public Nullable<bool> ABS { get; set; }
        public Nullable<bool> ESP { get; set; }
        public Nullable<bool> ElectricWindows { get; set; }
        public Nullable<bool> ElectricSideMirrors { get; set; }
        public Nullable<bool> AirConditioner { get; set; }
        public Nullable<bool> AuxiliaryHeater { get; set; }
    
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}