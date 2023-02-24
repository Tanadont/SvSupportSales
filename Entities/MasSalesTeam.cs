using System;
using System.Collections.Generic;

namespace SvSupportSales.Entities;

public partial class MasSalesTeam
{
    public int Salesstructureteamid { get; set; }

    public string? Salesstructureteamname { get; set; }

    public int? Orderby { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }
}
