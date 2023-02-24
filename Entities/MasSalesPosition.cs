using System;
using System.Collections.Generic;

namespace SvSupportSales.Entities;

public partial class MasSalesPosition
{
    public int Positionid { get; set; }

    public string? Parentlevelcode { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? Levelsequence { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }
}
