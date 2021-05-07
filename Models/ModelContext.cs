using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AqInternetAgent> AqInternetAgents { get; set; }
        public virtual DbSet<AqInternetAgentPriv> AqInternetAgentPrivs { get; set; }
        public virtual DbSet<AqQueue> AqQueues { get; set; }
        public virtual DbSet<AqQueueTable> AqQueueTables { get; set; }
        public virtual DbSet<AqSchedule> AqSchedules { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Help> Helps { get; set; }
        public virtual DbSet<Loantable> Loantables { get; set; }
        public virtual DbSet<Marriagetable> Marriagetables { get; set; }
        public virtual DbSet<MviewAdvAjg> MviewAdvAjgs { get; set; }
        public virtual DbSet<MviewAdvFjg> MviewAdvFjgs { get; set; }
        public virtual DbSet<MviewAdvLevel> MviewAdvLevels { get; set; }
        public virtual DbSet<MviewAdvLog> MviewAdvLogs { get; set; }
        public virtual DbSet<MviewEvaluation> MviewEvaluations { get; set; }
        public virtual DbSet<MviewException> MviewExceptions { get; set; }
        public virtual DbSet<MviewFilter> MviewFilters { get; set; }
        public virtual DbSet<MviewFilterinstance> MviewFilterinstances { get; set; }
        public virtual DbSet<MviewLog> MviewLogs { get; set; }
        public virtual DbSet<MviewRecommendation> MviewRecommendations { get; set; }
        public virtual DbSet<MviewWorkload> MviewWorkloads { get; set; }
        public virtual DbSet<Papertable> Papertables { get; set; }
        public virtual DbSet<Paymenttable> Paymenttables { get; set; }
        public virtual DbSet<Problemtable> Problemtables { get; set; }
        public virtual DbSet<ProductPriv> ProductPrivs { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<SchedulerJobArg> SchedulerJobArgs { get; set; }
        public virtual DbSet<SchedulerProgramArg> SchedulerProgramArgs { get; set; }
        public virtual DbSet<SqlplusProductProfile> SqlplusProductProfiles { get; set; }
        public virtual DbSet<Todoitem> Todoitems { get; set; }
        public virtual DbSet<Usertable> Usertables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=system;PASSWORD=new0878952737;DATA SOURCE=localhost:1521/XE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<AqInternetAgent>(entity =>
            {
                entity.HasKey(e => e.AgentName)
                    .HasName("SYS_C002326");

                entity.ToTable("AQ$_INTERNET_AGENTS");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("AGENT_NAME");

                entity.Property(e => e.Protocol)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PROTOCOL");

                entity.Property(e => e.Spare1)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("SPARE1");
            });

            modelBuilder.Entity<AqInternetAgentPriv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AQ$_INTERNET_AGENT_PRIVS");

                entity.HasIndex(e => new { e.AgentName, e.DbUsername }, "UNQ_PAIRS")
                    .IsUnique();

                entity.Property(e => e.AgentName)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("AGENT_NAME");

                entity.Property(e => e.DbUsername)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("DB_USERNAME");

                entity.HasOne(d => d.AgentNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AgentName)
                    .HasConstraintName("AGENT_MUST_BE_CREATED");
            });

            modelBuilder.Entity<AqQueue>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("AQ$_QUEUES_PRIMARY");

                entity.ToTable("AQ$_QUEUES");

                entity.HasIndex(e => new { e.Name, e.TableObjno }, "AQ$_QUEUES_CHECK")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.Eventid, e.TableObjno }, "I1_QUEUES");

                entity.Property(e => e.Oid)
                    .ValueGeneratedNever()
                    .HasColumnName("OID");

                entity.Property(e => e.BaseQueue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BASE_QUEUE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EnableFlag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ENABLE_FLAG");

                entity.Property(e => e.Eventid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EVENTID");

                entity.Property(e => e.MaxRetries)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_RETRIES");

                entity.Property(e => e.MemoryThreshold)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MEMORY_THRESHOLD");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.NetworkName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("NETWORK_NAME");

                entity.Property(e => e.Properties)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PROPERTIES");

                entity.Property(e => e.QueueComment)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("QUEUE_COMMENT");

                entity.Property(e => e.RetTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RET_TIME");

                entity.Property(e => e.RetryDelay)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RETRY_DELAY");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_NAME");

                entity.Property(e => e.Sharded)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SHARDED");

                entity.Property(e => e.SubOid).HasColumnName("SUB_OID");

                entity.Property(e => e.TableObjno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TABLE_OBJNO");

                entity.Property(e => e.Usage)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USAGE");
            });

            modelBuilder.Entity<AqQueueTable>(entity =>
            {
                entity.HasKey(e => e.Objno)
                    .HasName("AQ$_QUEUE_TABLES_PRIMARY");

                entity.ToTable("AQ$_QUEUE_TABLES");

                entity.HasIndex(e => new { e.Objno, e.Schema, e.Flags }, "I1_QUEUE_TABLES");

                entity.Property(e => e.Objno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OBJNO");

                entity.Property(e => e.Flags)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FLAGS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Schema)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("SCHEMA");

                entity.Property(e => e.SortCols)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SORT_COLS");

                entity.Property(e => e.TableComment)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("TABLE_COMMENT");

                entity.Property(e => e.Timezone)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("TIMEZONE");

                entity.Property(e => e.UdataType)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UDATA_TYPE");
            });

            modelBuilder.Entity<AqSchedule>(entity =>
            {
                entity.HasKey(e => new { e.Oid, e.Destination })
                    .HasName("AQ$_SCHEDULES_PRIMARY");

                entity.ToTable("AQ$_SCHEDULES");

                entity.HasIndex(e => e.Jobno, "AQ$_SCHEDULES_CHECK")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Destination)
                    .HasMaxLength(390)
                    .IsUnicode(false)
                    .HasColumnName("DESTINATION");

                entity.Property(e => e.Duration)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DURATION");

                entity.Property(e => e.Jobno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("JOBNO");

                entity.Property(e => e.LastTime)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_TIME");

                entity.Property(e => e.Latency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("LATENCY");

                entity.Property(e => e.NextTime)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NEXT_TIME");

                entity.Property(e => e.StartTime)
                    .HasColumnType("DATE")
                    .HasColumnName("START_TIME");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("BLOG");

                entity.Property(e => e.Blogid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BLOGID");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Salary)
                    .HasPrecision(10)
                    .HasColumnName("SALARY");
            });

            modelBuilder.Entity<Help>(entity =>
            {
                entity.HasKey(e => new { e.Topic, e.Seq })
                    .HasName("HELP_TOPIC_SEQ");

                entity.ToTable("HELP");

                entity.Property(e => e.Topic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOPIC");

                entity.Property(e => e.Seq)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQ");

                entity.Property(e => e.Info)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("INFO");
            });

            modelBuilder.Entity<Loantable>(entity =>
            {
                entity.HasKey(e => e.KLoan)
                    .HasName("LOANTABLE_PK");

                entity.ToTable("LOANTABLE");

                entity.Property(e => e.KLoan)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("K_LOAN");

                entity.Property(e => e.Confirmdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONFIRMDATE");

                entity.Property(e => e.Depositdate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEPOSITDATE");

                entity.Property(e => e.Loanamount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOANAMOUNT");

                entity.Property(e => e.Loandate)
                    .HasColumnType("DATE")
                    .HasColumnName("LOANDATE");

                entity.Property(e => e.Loantype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOANTYPE");

                entity.Property(e => e.SId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("S_ID");

                entity.Property(e => e.SmId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SM_ID")
                    .HasDefaultValueSql("null");

                entity.Property(e => e.UId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_ID");

                entity.Property(e => e.UmId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("UM_ID")
                    .HasDefaultValueSql("null  ");
            });

            modelBuilder.Entity<Marriagetable>(entity =>
            {
                entity.HasKey(e => e.KMarriage)
                    .HasName("MARRIAGETABLE_PK");

                entity.ToTable("MARRIAGETABLE");

                entity.Property(e => e.KMarriage)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("K_MARRIAGE");

                entity.Property(e => e.MFname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("M_FNAME");

                entity.Property(e => e.MLname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("M_LNAME");

                entity.Property(e => e.MPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("M_PHONE");

                entity.Property(e => e.MSalary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("M_SALARY");

                entity.Property(e => e.MTel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("M_TEL");

                entity.Property(e => e.UId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_ID");
            });

            modelBuilder.Entity<MviewAdvAjg>(entity =>
            {
                entity.HasKey(e => e.Ajgid)
                    .HasName("MVIEW$_ADV_AJG_PK");

                entity.ToTable("MVIEW$_ADV_AJG");

                entity.Property(e => e.Ajgid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AJGID#");

                entity.Property(e => e.Ajgdes)
                    .IsRequired()
                    .HasColumnType("LONG RAW")
                    .HasColumnName("AJGDES");

                entity.Property(e => e.Ajgdeslen)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AJGDESLEN");

                entity.Property(e => e.Frequency)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FREQUENCY");

                entity.Property(e => e.Hashvalue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HASHVALUE");

                entity.Property(e => e.Runid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUNID#");

                entity.HasOne(d => d.Run)
                    .WithMany(p => p.MviewAdvAjgs)
                    .HasForeignKey(d => d.Runid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MVIEW$_ADV_AJG_FK");
            });

            modelBuilder.Entity<MviewAdvFjg>(entity =>
            {
                entity.HasKey(e => e.Fjgid)
                    .HasName("MVIEW$_ADV_FJG_PK");

                entity.ToTable("MVIEW$_ADV_FJG");

                entity.Property(e => e.Fjgid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FJGID#");

                entity.Property(e => e.Ajgid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AJGID#");

                entity.Property(e => e.Fjgdes)
                    .IsRequired()
                    .HasColumnType("LONG RAW")
                    .HasColumnName("FJGDES");

                entity.Property(e => e.Fjgdeslen)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FJGDESLEN");

                entity.Property(e => e.Frequency)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FREQUENCY");

                entity.Property(e => e.Hashvalue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HASHVALUE");

                entity.HasOne(d => d.Ajg)
                    .WithMany(p => p.MviewAdvFjgs)
                    .HasForeignKey(d => d.Ajgid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MVIEW$_ADV_FJG_FK");
            });

            modelBuilder.Entity<MviewAdvLevel>(entity =>
            {
                entity.HasKey(e => new { e.Runid, e.Levelid })
                    .HasName("MVIEW$_ADV_LEVEL_PK");

                entity.ToTable("MVIEW$_ADV_LEVEL");

                entity.Property(e => e.Runid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUNID#");

                entity.Property(e => e.Levelid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LEVELID#");

                entity.Property(e => e.Columnlist)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("COLUMNLIST");

                entity.Property(e => e.Dimobj)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DIMOBJ#");

                entity.Property(e => e.Flags)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FLAGS");

                entity.Property(e => e.Levelname)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("LEVELNAME");

                entity.Property(e => e.Tblobj)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TBLOBJ#");

                entity.HasOne(d => d.Run)
                    .WithMany(p => p.MviewAdvLevels)
                    .HasForeignKey(d => d.Runid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MVIEW$_ADV_LEVEL_FK");
            });

            modelBuilder.Entity<MviewAdvLog>(entity =>
            {
                entity.HasKey(e => e.Runid)
                    .HasName("MVIEW$_ADV_LOG_PK");

                entity.ToTable("MVIEW$_ADV_LOG");

                entity.Property(e => e.Runid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUNID#");

                entity.Property(e => e.Completed)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPLETED");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ERROR_CODE");

                entity.Property(e => e.Filterid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FILTERID#");

                entity.Property(e => e.Message)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.RunBegin)
                    .HasColumnType("DATE")
                    .HasColumnName("RUN_BEGIN");

                entity.Property(e => e.RunEnd)
                    .HasColumnType("DATE")
                    .HasColumnName("RUN_END");

                entity.Property(e => e.RunType)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUN_TYPE");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.Uname)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("UNAME");
            });

            modelBuilder.Entity<MviewEvaluation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MVIEW_EVALUATIONS");

                entity.Property(e => e.BenefitToCostRatio)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BENEFIT_TO_COST_RATIO");

                entity.Property(e => e.CumulativeBenefit)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUMULATIVE_BENEFIT");

                entity.Property(e => e.Frequency)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FREQUENCY");

                entity.Property(e => e.MviewName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("MVIEW_NAME");

                entity.Property(e => e.MviewOwner)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("MVIEW_OWNER");

                entity.Property(e => e.Rank)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RANK");

                entity.Property(e => e.Runid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUNID");

                entity.Property(e => e.StorageInBytes)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STORAGE_IN_BYTES");
            });

            modelBuilder.Entity<MviewException>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MVIEW_EXCEPTIONS");

                entity.Property(e => e.BadRowid)
                    .HasColumnType("ROWID")
                    .HasColumnName("BAD_ROWID");

                entity.Property(e => e.DimensionName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("DIMENSION_NAME");

                entity.Property(e => e.Owner)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OWNER");

                entity.Property(e => e.Relationship)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("RELATIONSHIP");

                entity.Property(e => e.Runid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUNID");

                entity.Property(e => e.TableName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("TABLE_NAME");
            });

            modelBuilder.Entity<MviewFilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MVIEW_FILTER");

                entity.Property(e => e.DateValue1)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_VALUE1");

                entity.Property(e => e.DateValue2)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_VALUE2");

                entity.Property(e => e.Filterid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FILTERID");

                entity.Property(e => e.NumValue1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUM_VALUE1");

                entity.Property(e => e.NumValue2)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUM_VALUE2");

                entity.Property(e => e.StrValue)
                    .HasMaxLength(1028)
                    .IsUnicode(false)
                    .HasColumnName("STR_VALUE");

                entity.Property(e => e.Subfilternum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SUBFILTERNUM");

                entity.Property(e => e.Subfiltertype)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SUBFILTERTYPE");
            });

            modelBuilder.Entity<MviewFilterinstance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MVIEW_FILTERINSTANCE");

                entity.Property(e => e.DateValue1)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_VALUE1");

                entity.Property(e => e.DateValue2)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_VALUE2");

                entity.Property(e => e.Filterid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FILTERID");

                entity.Property(e => e.NumValue1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUM_VALUE1");

                entity.Property(e => e.NumValue2)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUM_VALUE2");

                entity.Property(e => e.Runid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUNID");

                entity.Property(e => e.StrValue)
                    .HasMaxLength(1028)
                    .IsUnicode(false)
                    .HasColumnName("STR_VALUE");

                entity.Property(e => e.Subfilternum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SUBFILTERNUM");

                entity.Property(e => e.Subfiltertype)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SUBFILTERTYPE");
            });

            modelBuilder.Entity<MviewLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MVIEW_LOG");

                entity.Property(e => e.Completed)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPLETED");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ERROR_CODE");

                entity.Property(e => e.Filterid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FILTERID");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.RunBegin)
                    .HasColumnType("DATE")
                    .HasColumnName("RUN_BEGIN");

                entity.Property(e => e.RunEnd)
                    .HasColumnType("DATE")
                    .HasColumnName("RUN_END");

                entity.Property(e => e.Status)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.Type)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<MviewRecommendation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MVIEW_RECOMMENDATIONS");

                entity.Property(e => e.AllTables)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ALL_TABLES");

                entity.Property(e => e.BenefitToCostRatio)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BENEFIT_TO_COST_RATIO");

                entity.Property(e => e.FactTables)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FACT_TABLES");

                entity.Property(e => e.GroupingLevels)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("GROUPING_LEVELS");

                entity.Property(e => e.MviewName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("MVIEW_NAME");

                entity.Property(e => e.MviewOwner)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("MVIEW_OWNER");

                entity.Property(e => e.PctPerformanceGain)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PCT_PERFORMANCE_GAIN");

                entity.Property(e => e.QueryText)
                    .HasColumnType("LONG")
                    .HasColumnName("QUERY_TEXT");

                entity.Property(e => e.RecommendationNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECOMMENDATION_NUMBER");

                entity.Property(e => e.RecommendedAction)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("RECOMMENDED_ACTION");

                entity.Property(e => e.Runid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RUNID");

                entity.Property(e => e.StorageInBytes)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STORAGE_IN_BYTES");
            });

            modelBuilder.Entity<MviewWorkload>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MVIEW_WORKLOAD");

                entity.Property(e => e.Application)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("APPLICATION");

                entity.Property(e => e.Cardinality)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARDINALITY");

                entity.Property(e => e.Frequency)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FREQUENCY");

                entity.Property(e => e.ImportTime)
                    .HasColumnType("DATE")
                    .HasColumnName("IMPORT_TIME");

                entity.Property(e => e.Lastuse)
                    .HasColumnType("DATE")
                    .HasColumnName("LASTUSE");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OWNER");

                entity.Property(e => e.Priority)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnType("LONG")
                    .HasColumnName("QUERY");

                entity.Property(e => e.Queryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUERYID");

                entity.Property(e => e.Responsetime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RESPONSETIME");

                entity.Property(e => e.Resultsize)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RESULTSIZE");

                entity.Property(e => e.Workloadid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WORKLOADID");
            });

            modelBuilder.Entity<Papertable>(entity =>
            {
                entity.HasKey(e => e.KPaper)
                    .HasName("PAPERTABLE_PK");

                entity.ToTable("PAPERTABLE");

                entity.Property(e => e.KPaper)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("K_PAPER");

                entity.Property(e => e.Evidence)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EVIDENCE");

                entity.Property(e => e.Evidencedate)
                    .HasColumnType("DATE")
                    .HasColumnName("EVIDENCEDATE");

                entity.Property(e => e.UId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_ID");
            });

            modelBuilder.Entity<Paymenttable>(entity =>
            {
                entity.HasKey(e => e.KPaymentt)
                    .HasName("PAYMENTTABLE_PK");

                entity.ToTable("PAYMENTTABLE");

                entity.Property(e => e.KPaymentt)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("K_PAYMENTT");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Batch)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BATCH");

                entity.Property(e => e.Batchamount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BATCHAMOUNT");

                entity.Property(e => e.Lastpaid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LASTPAID");

                entity.Property(e => e.Loanamount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOANAMOUNT");

                entity.Property(e => e.Timepaid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIMEPAID");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.UId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_ID");
            });

            modelBuilder.Entity<Problemtable>(entity =>
            {
                entity.HasKey(e => e.KProblem)
                    .HasName("PROBLEMTABLE_PK");

                entity.ToTable("PROBLEMTABLE");

                entity.Property(e => e.KProblem)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("K_PROBLEM");

                entity.Property(e => e.Detail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DETAIL");

                entity.Property(e => e.Loantype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOANTYPE");

                entity.Property(e => e.Surety)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SURETY");

                entity.Property(e => e.UId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_ID");
            });

            modelBuilder.Entity<ProductPriv>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PRODUCT_PRIVS");

                entity.Property(e => e.Attribute)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("ATTRIBUTE");

                entity.Property(e => e.CharValue)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("CHAR_VALUE");

                entity.Property(e => e.DateValue)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_VALUE");

                entity.Property(e => e.LongValue)
                    .HasColumnType("LONG")
                    .HasColumnName("LONG_VALUE");

                entity.Property(e => e.NumericValue)
                    .HasColumnType("NUMBER(15,2)")
                    .HasColumnName("NUMERIC_VALUE");

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Scope)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE");

                entity.Property(e => e.Userid)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("PROVINCES");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.GeographyId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("GEOGRAPHY_ID")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.NameTh)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME_TH");
            });

            modelBuilder.Entity<SchedulerJobArg>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SCHEDULER_JOB_ARGS");

                entity.Property(e => e.ArgumentName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ARGUMENT_NAME");

                entity.Property(e => e.ArgumentPosition)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ARGUMENT_POSITION");

                entity.Property(e => e.ArgumentType)
                    .HasMaxLength(257)
                    .IsUnicode(false)
                    .HasColumnName("ARGUMENT_TYPE");

                entity.Property(e => e.JobName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("JOB_NAME");

                entity.Property(e => e.OutArgument)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("OUT_ARGUMENT");

                entity.Property(e => e.Owner)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OWNER");

                entity.Property(e => e.Value)
                    .IsUnicode(false)
                    .HasColumnName("VALUE");
            });

            modelBuilder.Entity<SchedulerProgramArg>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SCHEDULER_PROGRAM_ARGS");

                entity.Property(e => e.ArgumentName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ARGUMENT_NAME");

                entity.Property(e => e.ArgumentPosition)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ARGUMENT_POSITION");

                entity.Property(e => e.ArgumentType)
                    .HasMaxLength(257)
                    .IsUnicode(false)
                    .HasColumnName("ARGUMENT_TYPE");

                entity.Property(e => e.DefaultValue)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_VALUE");

                entity.Property(e => e.MetadataAttribute)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("METADATA_ATTRIBUTE");

                entity.Property(e => e.OutArgument)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("OUT_ARGUMENT");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OWNER");

                entity.Property(e => e.ProgramName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PROGRAM_NAME");
            });

            modelBuilder.Entity<SqlplusProductProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SQLPLUS_PRODUCT_PROFILE");

                entity.Property(e => e.Attribute)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("ATTRIBUTE");

                entity.Property(e => e.CharValue)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("CHAR_VALUE");

                entity.Property(e => e.DateValue)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_VALUE");

                entity.Property(e => e.LongValue)
                    .HasColumnType("LONG")
                    .HasColumnName("LONG_VALUE");

                entity.Property(e => e.NumericValue)
                    .HasColumnType("NUMBER(15,2)")
                    .HasColumnName("NUMERIC_VALUE");

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Scope)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE");

                entity.Property(e => e.Userid)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<Todoitem>(entity =>
            {
                entity.ToTable("TODOITEM");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CreationTs)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("CREATION_TS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Done)
                    .HasPrecision(1)
                    .HasColumnName("DONE");
            });

            modelBuilder.Entity<Usertable>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("USERTABLE_PK");

                entity.ToTable("USERTABLE");

                entity.Property(e => e.UId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_ID");

                entity.Property(e => e.UAffiliation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_AFFILIATION");

                entity.Property(e => e.UDivision)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_DIVISION");

                entity.Property(e => e.UFname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_FNAME");

                entity.Property(e => e.ULname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_LNAME");

                entity.Property(e => e.ULoan)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_LOAN");

                entity.Property(e => e.UPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_PHONE");

                entity.Property(e => e.UPosition)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_POSITION");

                entity.Property(e => e.USalary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("U_SALARY");

                entity.Property(e => e.USalaryid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_SALARYID");

                entity.Property(e => e.UStartdate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_STARTDATE");

                entity.Property(e => e.UStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_STATUS");

                entity.Property(e => e.UTel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_TEL");

                entity.Property(e => e.UTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_TITLE");

                entity.Property(e => e.UType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("U_TYPE");
            });

            modelBuilder.HasSequence("LOGMNR_DIDS$");

            modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");

            modelBuilder.HasSequence("LOGMNR_SEQ$");

            modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");

            modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
