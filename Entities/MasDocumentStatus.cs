using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SvSupportSales.Entities;

public partial class MasDocumentStatus
{
    public int Documentstatusid { get; set; }

    public string? Documentstatuscode { get; set; }

    public string? Documentstatusname { get; set; }

    public int? Orderby { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    [NotMapped]
    public string getId { get; set; }
}
