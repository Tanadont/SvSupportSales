using System;
using System.Collections.Generic;

namespace SvSupportSales.Entities;

public partial class MasSalesStructure
{
    public int Salesid { get; set; }

    public string? Position { get; set; }

    public string? Prefix { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Nickname { get; set; }

    public string? Telephone { get; set; }

    public string? Citizenid { get; set; }

    public string? Supervisorcitizenid { get; set; }

    public int? Teamid { get; set; }

    public int? Regionid { get; set; }

    public string? Regionname { get; set; }

    public string? Subbranch { get; set; }

    public string? Nameverified { get; set; }

    public DateTime? Opencodedate { get; set; }

    public bool? Closecodesale { get; set; }

    public string? Status { get; set; }

    public bool? Isactive { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public DateTime? Deleteddate { get; set; }

    public string? Deletedby { get; set; }
}
