using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SvSupportSales.Entities;

namespace SvSupportSales.Repositories
{
    public interface IMasterRepository
    {
        List<MasSalesStructure>? FindMasSalesStructure(string? name, bool supervisor, int? limit);

        List<MasBranch>? FindMasBranch(string? name, int? limit);

        List<MasSalesTeam>? FindMasSalesTeam(string? salesstructureteamname, int? limit);

        List<MasSalesPosition>? FindMasSalesPosition(string? name, int? limit);

        List<MasDocumentStatus>? FindMasDocumentStatus(string? documentstatusname, int? limit);
    }
    public class MasterRepository : IMasterRepository
    {
        private DataContext context;

        public MasterRepository(DataContext context)
        {
            this.context = context;
        }

        public List<MasSalesStructure>? FindMasSalesStructure(string? name, bool supervisor, int? limit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM mas_sales_structure WHERE isactive = true ");
            if (name != null && name.Trim().Length > 0)
            {
                stringBuilder.Append($"AND concat(prefix,' ',firstName,' ',lastName) ILIKE '%{name}%' ");
            }
            if (supervisor)
            {
                stringBuilder.Append("AND position != 'DS' ");
            }
            stringBuilder.Append("ORDER BY concat(prefix,' ',firstName,' ',lastName) ASC ");
            if(limit != null && limit > 0)
            {
                stringBuilder.AppendFormat("limit {0}", limit);
            }
            return context.MasSalesStructures.FromSqlRaw(stringBuilder.ToString()).ToList();
        }
        public List<MasBranch>? FindMasBranch(string? name, int? limit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM mas_branch WHERE isactive = true ");
            if (name != null && name.Trim().Length > 0)
            {
                stringBuilder.Append($"AND name ILIKE '%{name}%' ");
            }
            stringBuilder.Append("ORDER BY name ASC ");
            if (limit != null && limit > 0)
            {
                stringBuilder.AppendFormat("limit {0}", limit);
            }
            return context.MasBranches.FromSqlRaw(stringBuilder.ToString()).ToList();
        }

        public List<MasSalesTeam>? FindMasSalesTeam(string? salesstructureteamname, int? limit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM mas_sales_team WHERE isactive = true ");
            if (salesstructureteamname != null && salesstructureteamname.Trim().Length > 0)
            {
                stringBuilder.Append($"AND salesstructureteamname ILIKE '%{salesstructureteamname}%' ");
            }
            stringBuilder.Append("ORDER BY orderby ");
            if (limit != null && limit > 0)
            {
                stringBuilder.AppendFormat("limit {0}", limit);
            }
            return context.MasSalesTeams.FromSqlRaw(stringBuilder.ToString()).ToList();
        }

        public List<MasSalesPosition>? FindMasSalesPosition(string? name, int? limit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM mas_sales_position WHERE isactive = true ");
            if (name != null && name.Trim().Length > 0)
            {
                stringBuilder.Append($"AND name ILIKE '%{name}%' ");
            }
            stringBuilder.Append("ORDER BY name ASC ");
            if (limit != null && limit > 0)
            {
                stringBuilder.AppendFormat("limit {0}", limit);
            }
            return context.MasSalesPositions.FromSqlRaw(stringBuilder.ToString()).ToList();
        }

        public List<MasDocumentStatus>? FindMasDocumentStatus(string? documentstatusname, int? limit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM mas_document_status WHERE isactive = true ");
            if (documentstatusname != null && documentstatusname.Trim().Length > 0)
            {
                stringBuilder.Append($"AND documentstatusname ILIKE '%{documentstatusname}%' ");
            }
            stringBuilder.Append("ORDER BY orderby ");
            if (limit != null && limit > 0)
            {
                stringBuilder.AppendFormat("limit {0}", limit);
            }
            return context.MasDocumentStatuses.FromSqlRaw(stringBuilder.ToString()).ToList();
        }

    }
}
