using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SvSupportSales.Entities;

public partial class TransSaleRegister
{
    public int Salesregisterid { get; set; }

    public int? Companyid { get; set; }

    public string? Companycode { get; set; }

    public string? Companyname { get; set; }

    public int? Branchid { get; set; }

    public string? Branchname { get; set; }

    public string? Branchcode { get; set; }

    public string? Branchsapcode { get; set; }

    public int? Salesstructureteamid { get; set; }

    public string? Salesstructureteamname { get; set; }

    public string? Salesstructureteamcode { get; set; }

    public string? Documentno { get; set; }

    public string? Documentstatuscode { get; set; }

    public DateTime? Documentdate { get; set; } 

    public int? Registertype { get; set; }

    public string? Salestype { get; set; }

    public string? Position { get; set; }

    public string? Supervisorcitizenid { get; set; }

    public string? Prefix { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Citizenid { get; set; }

    public DateTime? Dateofbirth { get; set; }

    public string? Telephone { get; set; }

    public string? Addressno { get; set; }

    public string? Moo { get; set; }

    public string? Soi { get; set; }

    public string? Building { get; set; }

    public string? Floorno { get; set; }

    public string? Roomno { get; set; }

    public string? Road { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? Subdistrictcode { get; set; }

    public string? Subdistrictnameth { get; set; }

    public string? Districtcode { get; set; }

    public string? Districtnameth { get; set; }

    public string? Provincecode { get; set; }

    public string? Provincenameth { get; set; }

    public string? Locationcode { get; set; }

    public string? Bank { get; set; }

    public string? Bankaccount { get; set; }

    public string? Verificationresultdescription { get; set; }

    public DateTime? Verrifydate { get; set; }

    public string? Rejectedcode { get; set; }

    public string? Verificationremark { get; set; }

    public bool? Isdocumentcompleted { get; set; }

    public string? Salestatus { get; set; }

    public decimal? Totalofsale { get; set; }

    public int? Totalofunit { get; set; }

    public bool? Isactive { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public DateTime? Deleteddate { get; set; }

    public string? Deletedby { get; set; }
}
