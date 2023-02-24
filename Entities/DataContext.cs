using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SvSupportSales.Entities;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MasBranch> MasBranches { get; set; }

    public virtual DbSet<MasDocumentStatus> MasDocumentStatuses { get; set; }

    public virtual DbSet<MasSalesPosition> MasSalesPositions { get; set; }

    public virtual DbSet<MasSalesStructure> MasSalesStructures { get; set; }

    public virtual DbSet<MasSalesTeam> MasSalesTeams { get; set; }

    public virtual DbSet<TransSaleRegister> TransSaleRegisters { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MasBranch>(entity =>
        {
            entity.HasKey(e => e.Branchid).HasName("mas_branch_pk");

            entity.ToTable("mas_branch");

            entity.Property(e => e.Branchid)
                .ValueGeneratedNever()
                .HasColumnName("branchid");
            entity.Property(e => e.Addressno)
                .HasMaxLength(100)
                .HasColumnName("addressno");
            entity.Property(e => e.Building)
                .HasMaxLength(100)
                .HasColumnName("building");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Districtcode)
                .HasMaxLength(50)
                .HasColumnName("districtcode");
            entity.Property(e => e.Districtnameth)
                .HasMaxLength(150)
                .HasColumnName("districtnameth");
            entity.Property(e => e.Floorno)
                .HasMaxLength(10)
                .HasColumnName("floorno");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Latitude)
                .HasMaxLength(100)
                .HasColumnName("latitude");
            entity.Property(e => e.Locationcode)
                .HasMaxLength(6)
                .HasColumnName("locationcode");
            entity.Property(e => e.Longitude)
                .HasMaxLength(100)
                .HasColumnName("longitude");
            entity.Property(e => e.Moo)
                .HasMaxLength(10)
                .HasColumnName("moo");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Orderby).HasColumnName("orderby");
            entity.Property(e => e.Provincecode)
                .HasMaxLength(50)
                .HasColumnName("provincecode");
            entity.Property(e => e.ProvincenameTh)
                .HasMaxLength(150)
                .HasColumnName("provincename_th");
            entity.Property(e => e.Road)
                .HasMaxLength(100)
                .HasColumnName("road");
            entity.Property(e => e.Roomno)
                .HasMaxLength(10)
                .HasColumnName("roomno");
            entity.Property(e => e.Sapcode)
                .HasMaxLength(50)
                .HasColumnName("sapcode");
            entity.Property(e => e.Soi)
                .HasMaxLength(100)
                .HasColumnName("soi");
            entity.Property(e => e.Subdistrictcode)
                .HasMaxLength(50)
                .HasColumnName("subdistrictcode");
            entity.Property(e => e.SubdistrictnameTh)
                .HasMaxLength(150)
                .HasColumnName("subdistrictname_th");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<MasDocumentStatus>(entity =>
        {
            entity.HasKey(e => e.Documentstatusid).HasName("mas_document_status_pk");

            entity.ToTable("mas_document_status");

            entity.Property(e => e.Documentstatusid)
                .ValueGeneratedNever()
                .HasColumnName("documentstatusid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Documentstatuscode)
                .HasMaxLength(50)
                .HasColumnName("documentstatuscode");
            entity.Property(e => e.Documentstatusname)
                .HasMaxLength(50)
                .HasColumnName("documentstatusname");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Orderby).HasColumnName("orderby");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<MasSalesPosition>(entity =>
        {
            entity.HasKey(e => e.Positionid).HasName("mas_sales_position_pk");

            entity.ToTable("mas_sales_position");

            entity.Property(e => e.Positionid)
                .ValueGeneratedNever()
                .HasColumnName("positionid");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Levelsequence).HasColumnName("levelsequence");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Parentlevelcode)
                .HasMaxLength(50)
                .HasColumnName("parentlevelcode");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<MasSalesStructure>(entity =>
        {
            entity.HasKey(e => e.Salesid).HasName("mas_sales_structure_pk");

            entity.ToTable("mas_sales_structure");

            entity.Property(e => e.Salesid).HasColumnName("salesid");
            entity.Property(e => e.Citizenid)
                .HasMaxLength(13)
                .HasColumnName("citizenid");
            entity.Property(e => e.Closecodesale).HasColumnName("closecodesale");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Deletedby)
                .HasMaxLength(50)
                .HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleteddate");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Nameverified)
                .HasMaxLength(255)
                .HasColumnName("nameverified");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .HasColumnName("nickname");
            entity.Property(e => e.Opencodedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("opencodedate");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.Prefix)
                .HasMaxLength(20)
                .HasColumnName("prefix");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Regionname)
                .HasMaxLength(255)
                .HasColumnName("regionname");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Subbranch)
                .HasMaxLength(255)
                .HasColumnName("subbranch");
            entity.Property(e => e.Supervisorcitizenid)
                .HasMaxLength(13)
                .HasColumnName("supervisorcitizenid");
            entity.Property(e => e.Teamid).HasColumnName("teamid");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<MasSalesTeam>(entity =>
        {
            entity.HasKey(e => e.Salesstructureteamid).HasName("mas_sales_team_pk");

            entity.ToTable("mas_sales_team");

            entity.Property(e => e.Salesstructureteamid)
                .ValueGeneratedNever()
                .HasColumnName("salesstructureteamid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Orderby).HasColumnName("orderby");
            entity.Property(e => e.Salesstructureteamname)
                .HasMaxLength(150)
                .HasColumnName("salesstructureteamname");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<TransSaleRegister>(entity =>
        {
            entity.HasKey(e => e.Salesregisterid).HasName("trans_sale_register_pk");

            entity.ToTable("trans_sale_register");

            entity.Property(e => e.Salesregisterid)
                .ValueGeneratedNever()
                .HasColumnName("salesregisterid");
            entity.Property(e => e.Addressno)
                .HasMaxLength(200)
                .HasColumnName("addressno");
            entity.Property(e => e.Bank)
                .HasMaxLength(20)
                .HasColumnName("bank");
            entity.Property(e => e.Bankaccount)
                .HasMaxLength(20)
                .HasColumnName("bankaccount");
            entity.Property(e => e.Branchcode)
                .HasMaxLength(255)
                .HasColumnName("branchcode");
            entity.Property(e => e.Branchid).HasColumnName("branchid");
            entity.Property(e => e.Branchname)
                .HasMaxLength(255)
                .HasColumnName("branchname");
            entity.Property(e => e.Branchsapcode)
                .HasMaxLength(50)
                .HasColumnName("branchsapcode");
            entity.Property(e => e.Building)
                .HasMaxLength(100)
                .HasColumnName("building");
            entity.Property(e => e.Citizenid)
                .HasMaxLength(13)
                .HasColumnName("citizenid");
            entity.Property(e => e.Companycode)
                .HasMaxLength(50)
                .HasColumnName("companycode");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Companyname)
                .HasMaxLength(255)
                .HasColumnName("companyname");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Deletedby)
                .HasMaxLength(50)
                .HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleteddate");
            entity.Property(e => e.Districtcode)
                .HasMaxLength(50)
                .HasColumnName("districtcode");
            entity.Property(e => e.Districtnameth)
                .HasMaxLength(150)
                .HasColumnName("districtnameth");
            entity.Property(e => e.Documentdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("documentdate");
            entity.Property(e => e.Documentno)
                .HasMaxLength(50)
                .HasColumnName("documentno");
            entity.Property(e => e.Documentstatuscode)
                .HasMaxLength(50)
                .HasColumnName("documentstatuscode");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Floorno)
                .HasMaxLength(10)
                .HasColumnName("floorno");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Isdocumentcompleted).HasColumnName("isdocumentcompleted");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Latitude)
                .HasMaxLength(100)
                .HasColumnName("latitude");
            entity.Property(e => e.Locationcode)
                .HasMaxLength(6)
                .HasColumnName("locationcode");
            entity.Property(e => e.Longitude)
                .HasMaxLength(100)
                .HasColumnName("longitude");
            entity.Property(e => e.Moo)
                .HasMaxLength(10)
                .HasColumnName("moo");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.Prefix)
                .HasMaxLength(20)
                .HasColumnName("prefix");
            entity.Property(e => e.Provincecode)
                .HasMaxLength(50)
                .HasColumnName("provincecode");
            entity.Property(e => e.Provincenameth)
                .HasMaxLength(150)
                .HasColumnName("provincenameth");
            entity.Property(e => e.Registertype).HasColumnName("registertype");
            entity.Property(e => e.Rejectedcode)
                .HasMaxLength(50)
                .HasColumnName("rejectedcode");
            entity.Property(e => e.Road)
                .HasMaxLength(100)
                .HasColumnName("road");
            entity.Property(e => e.Roomno)
                .HasMaxLength(10)
                .HasColumnName("roomno");
            entity.Property(e => e.Salesstructureteamcode)
                .HasMaxLength(50)
                .HasColumnName("salesstructureteamcode");
            entity.Property(e => e.Salesstructureteamid).HasColumnName("salesstructureteamid");
            entity.Property(e => e.Salesstructureteamname)
                .HasMaxLength(150)
                .HasColumnName("salesstructureteamname");
            entity.Property(e => e.Salestatus)
                .HasMaxLength(50)
                .HasColumnName("salestatus");
            entity.Property(e => e.Salestype)
                .HasMaxLength(20)
                .HasColumnName("salestype");
            entity.Property(e => e.Soi)
                .HasMaxLength(100)
                .HasColumnName("soi");
            entity.Property(e => e.Subdistrictcode)
                .HasMaxLength(50)
                .HasColumnName("subdistrictcode");
            entity.Property(e => e.Subdistrictnameth)
                .HasMaxLength(150)
                .HasColumnName("subdistrictnameth");
            entity.Property(e => e.Supervisorcitizenid)
                .HasMaxLength(13)
                .HasColumnName("supervisorcitizenid");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
            entity.Property(e => e.Totalofsale)
                .HasPrecision(18, 4)
                .HasColumnName("totalofsale");
            entity.Property(e => e.Totalofunit).HasColumnName("totalofunit");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
            entity.Property(e => e.Verificationremark).HasColumnName("verificationremark");
            entity.Property(e => e.Verificationresultdescription).HasColumnName("verificationresultdescription");
            entity.Property(e => e.Verrifydate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("verrifydate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
