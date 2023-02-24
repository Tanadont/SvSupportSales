using System;
using System.Collections.Generic;

namespace SvSupportSales.Entities;

public partial class MasBranch
{
    public int Branchid { get; set; }

    public int? Companyid { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Sapcode { get; set; }

    public string? Addressno { get; set; }

    public string? Moo { get; set; }

    public string? Soi { get; set; }

    public string? Building { get; set; }

    public string? Floorno { get; set; }

    public string? Roomno { get; set; }

    public string? Road { get; set; }

    public string? Subdistrictcode { get; set; }

    public string? SubdistrictnameTh { get; set; }

    public string? Districtcode { get; set; }

    public string? Districtnameth { get; set; }

    public string? Provincecode { get; set; }

    public string? ProvincenameTh { get; set; }

    public string? Locationcode { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public int? Orderby { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }
}
