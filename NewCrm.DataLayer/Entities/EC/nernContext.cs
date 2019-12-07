using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class nernContext : DbContext
    {
        public nernContext()
        {
        }

        public nernContext(DbContextOptions<nernContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AdminAccess> AdminAccess { get; set; }
        public virtual DbSet<AdminAccessLog> AdminAccessLog { get; set; }
        public virtual DbSet<AdminStateListRole> AdminStateListRole { get; set; }
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<ApprovingRole> ApprovingRole { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ContractDoc> ContractDoc { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentParameter> EquipmentParameter { get; set; }
        public virtual DbSet<EquipmentParentRel> EquipmentParentRel { get; set; }
        public virtual DbSet<EquipmentType> EquipmentType { get; set; }
        public virtual DbSet<EquipmentTypeParameters> EquipmentTypeParameters { get; set; }
        public virtual DbSet<EquipmentTypePort> EquipmentTypePort { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<InfoDoc> InfoDoc { get; set; }
        public virtual DbSet<InstallData> InstallData { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobEducationalInfo> JobEducationalInfo { get; set; }
        public virtual DbSet<JobLang> JobLang { get; set; }
        public virtual DbSet<JobPersonalInfo> JobPersonalInfo { get; set; }
        public virtual DbSet<JobSkill> JobSkill { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<JobWorkHistory> JobWorkHistory { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<PersonalDoc> PersonalDoc { get; set; }
        public virtual DbSet<PersonalInfo> PersonalInfo { get; set; }
        public virtual DbSet<PostalCode> PostalCode { get; set; }
        public virtual DbSet<PreUniversityData> PreUniversityData { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategory { get; set; }
        public virtual DbSet<ServiceForm> ServiceForm { get; set; }
        public virtual DbSet<ServiceFormParameter> ServiceFormParameter { get; set; }
        public virtual DbSet<ServiceFormRequest> ServiceFormRequest { get; set; }
        public virtual DbSet<SignupPics> SignupPics { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SubService> SubService { get; set; }
        public virtual DbSet<SubServiceParameter> SubServiceParameter { get; set; }
        public virtual DbSet<SubjobTitle> SubjobTitle { get; set; }
        public virtual DbSet<SubsBuilding> SubsBuilding { get; set; }
        public virtual DbSet<TelecomCenter> TelecomCenter { get; set; }
        public virtual DbSet<TelecomCenterPreFix> TelecomCenterPreFix { get; set; }
        public virtual DbSet<UniStatusLog> UniStatusLog { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<UserRel> UserRel { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<WorldNern> WorldNern { get; set; }

        // Unable to generate entity type for table 'hibernate_sequence'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=crm.nern.ir;port=3306;user=seemsys;password=123456;database=nern");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PassChanged)
                    .HasColumnName("pass_changed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<AdminAccess>(entity =>
            {
                entity.ToTable("admin_access");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AccessVal)
                    .HasColumnName("access_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SubAccessVal)
                    .HasColumnName("sub_access_val")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<AdminAccessLog>(entity =>
            {
                entity.ToTable("admin_access_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdminAccessVal)
                    .HasColumnName("admin_access_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PageAccessVal)
                    .HasColumnName("page_access_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<AdminStateListRole>(entity =>
            {
                entity.ToTable("admin_state_list_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.StateId)
                    .HasColumnName("state_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("agent");

                entity.Property(e => e.AgentId)
                    .HasColumnName("agent_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AgentPos)
                    .HasColumnName("agent_pos")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FaxNo)
                    .HasColumnName("fax_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IntroCert)
                    .HasColumnName("intro_cert")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.IsPrimary)
                    .HasColumnName("is_primary")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobile_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NationalId)
                    .HasColumnName("national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Payment)
                    .HasColumnName("payment")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PrimaryAgent)
                    .HasColumnName("primary_agent")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SubSystemCode)
                    .HasColumnName("sub_system_code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SupportEmail)
                    .HasColumnName("support_email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TelNo)
                    .HasColumnName("tel_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TeleNo)
                    .HasColumnName("tele_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UniNationalId)
                    .HasColumnName("uni_national_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<ApprovingRole>(entity =>
            {
                entity.ToTable("approving_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.StateId)
                    .HasColumnName("state_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SubSystemVal)
                    .HasColumnName("sub_system_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniId)
                    .HasColumnName("uni_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UniTypeVal)
                    .HasColumnName("uni_type_val")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.MapCenterLat).HasColumnName("map_center_lat");

                entity.Property(e => e.MapCenterLng).HasColumnName("map_center_lng");

                entity.Property(e => e.MapZoom)
                    .HasColumnName("map_zoom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StateId)
                    .HasColumnName("state_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<ContractDoc>(entity =>
            {
                entity.ToTable("contract_doc");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.Document)
                    .HasColumnName("document")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.Extension)
                    .HasColumnName("extension")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EnName)
                    .HasColumnName("en_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FaName)
                    .HasColumnName("fa_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NumberCode)
                    .HasColumnName("number_code")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipment");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(4000)");

                entity.Property(e => e.EquipmentNo1)
                    .HasColumnName("equipment_no1")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EquipmentNo2)
                    .HasColumnName("equipment_no2")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EquipmentShoaNo)
                    .HasColumnName("equipment_shoa_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EquipmentTypeId)
                    .HasColumnName("equipment_type_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OwnerName)
                    .HasColumnName("owner_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SerialNo)
                    .HasColumnName("serial_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ShoaOwner)
                    .HasColumnName("shoa_owner")
                    .HasColumnType("bit(1)");
            });

            modelBuilder.Entity<EquipmentParameter>(entity =>
            {
                entity.ToTable("equipment_parameter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ParameterName)
                    .HasColumnName("parameter_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unit_name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<EquipmentParentRel>(entity =>
            {
                entity.ToTable("equipment_parent_rel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ChildId)
                    .HasColumnName("child_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<EquipmentType>(entity =>
            {
                entity.ToTable("equipment_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Ampere)
                    .HasColumnName("ampere")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CapacityUse)
                    .HasColumnName("capacity_use")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ElectronicSourceVal)
                    .HasColumnName("electronic_source_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IranManufactured)
                    .HasColumnName("iran_manufactured")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Manufacturer)
                    .HasColumnName("manufacturer")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PartNumber)
                    .HasColumnName("part_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TypeVal)
                    .HasColumnName("type_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Watt)
                    .HasColumnName("watt")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<EquipmentTypeParameters>(entity =>
            {
                entity.ToTable("equipment_type_parameters");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EquipmentParameterId)
                    .HasColumnName("equipment_parameter_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EquipmentTypeId)
                    .HasColumnName("equipment_type_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<EquipmentTypePort>(entity =>
            {
                entity.ToTable("equipment_type_port");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EquipmentTypeId)
                    .HasColumnName("equipment_type_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PortNo)
                    .HasColumnName("port_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PortUnitVal)
                    .HasColumnName("port_unit_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("feed_back");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AttachedFile)
                    .HasColumnName("attached_file")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.AttachedFileExtension)
                    .HasColumnName("attached_file_extension")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.PageAddress)
                    .HasColumnName("page_address")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RepairTimeStamp)
                    .HasColumnName("repair_time_stamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusVal)
                    .HasColumnName("status_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<InfoDoc>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PRIMARY");

                entity.ToTable("info_doc");

                entity.Property(e => e.DocId)
                    .HasColumnName("doc_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.DocDest)
                    .HasColumnName("doc_dest")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Owner)
                    .HasColumnName("owner")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PubDate)
                    .HasColumnName("pub_date")
                    .HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Writer)
                    .HasColumnName("writer")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<InstallData>(entity =>
            {
                entity.ToTable("install_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EquipmentId)
                    .HasColumnName("equipment_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ParentEquipmentId)
                    .HasColumnName("parent_equipment_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.TelecomCenterId)
                    .HasColumnName("telecom_center_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("job");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Expection)
                    .HasColumnName("expection")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.JobCode)
                    .HasColumnName("job_code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.JobLevel)
                    .HasColumnName("job_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.JobName)
                    .HasColumnName("job_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.JobSeekerNumbers)
                    .HasColumnName("job_seeker_numbers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.MinimiumDegree)
                    .HasColumnName("minimium_degree")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NeededRecord)
                    .HasColumnName("needed_record")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Skills)
                    .HasColumnName("skills")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.SubJob)
                    .HasColumnName("sub_job")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<JobEducationalInfo>(entity =>
            {
                entity.ToTable("job_educational_info");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Avg).HasColumnName("avg");

                entity.Property(e => e.Gerayesh)
                    .HasColumnName("gerayesh")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Madrak)
                    .HasColumnName("madrak")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersonalId)
                    .HasColumnName("personal_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Reshte)
                    .HasColumnName("reshte")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StateEdu)
                    .HasColumnName("state_edu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniCity)
                    .HasColumnName("uni_city")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UniCountry)
                    .HasColumnName("uni_country")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UniName)
                    .HasColumnName("uni_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UniType)
                    .HasColumnName("uni_type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<JobLang>(entity =>
            {
                entity.ToTable("job_lang");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LngQuiz)
                    .HasColumnName("lng_quiz")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.PersonalId)
                    .HasColumnName("personal_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ReadCol)
                    .HasColumnName("read_col")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Speech)
                    .HasColumnName("speech")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WriteCol)
                    .HasColumnName("write_col")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<JobPersonalInfo>(entity =>
            {
                entity.ToTable("job_personal_info");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Addres)
                    .HasColumnName("addres")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CodeMeli)
                    .HasColumnName("code_meli")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Family)
                    .HasColumnName("family")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.HomeNo)
                    .HasColumnName("home_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImgPerson).HasColumnName("img_person");

                entity.Property(e => e.Marriage)
                    .HasColumnName("marriage")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobile_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Nation)
                    .HasColumnName("nation")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ShenasNo)
                    .HasColumnName("shenas_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UseraccId)
                    .HasColumnName("useracc_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<JobSkill>(entity =>
            {
                entity.ToTable("job_skill");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ImgMadrak).HasColumnName("img_madrak");

                entity.Property(e => e.InstituteName)
                    .HasColumnName("institute_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MadrakScore)
                    .HasColumnName("madrak_score")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersonalId)
                    .HasColumnName("personal_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SelfLearn)
                    .HasColumnName("self_learn")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.TutName)
                    .HasColumnName("tut_name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("job_title");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PicFormat)
                    .HasColumnName("pic_format")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TitleName)
                    .HasColumnName("title_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TitlePic)
                    .HasColumnName("title_pic")
                    .HasColumnType("mediumblob");
            });

            modelBuilder.Entity<JobWorkHistory>(entity =>
            {
                entity.ToTable("job_work_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CompanyField)
                    .HasColumnName("company_field")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EndReason)
                    .HasColumnName("end_reason")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.JobPost)
                    .HasColumnName("job_post")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastSalary)
                    .HasColumnName("last_salary")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PersonalId)
                    .HasColumnName("personal_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NationalId)
                    .HasColumnName("national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Emphasize)
                    .HasColumnName("emphasize")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NewsDest)
                    .HasColumnName("news_dest")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasColumnType("varchar(4000)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<PersonalDoc>(entity =>
            {
                entity.HasKey(e => e.NationalId)
                    .HasName("PRIMARY");

                entity.ToTable("personal_doc");

                entity.Property(e => e.NationalId)
                    .HasColumnName("national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IntroCert)
                    .HasColumnName("intro_cert")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.NationalCard)
                    .HasColumnName("national_card")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.ShenasFpage)
                    .HasColumnName("shenas_fpage")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.StudentCard)
                    .HasColumnName("student_card")
                    .HasColumnType("mediumblob");
            });

            modelBuilder.Entity<PersonalInfo>(entity =>
            {
                entity.HasKey(e => e.NationalId)
                    .HasName("PRIMARY");

                entity.ToTable("personal_info");

                entity.HasIndex(e => e.Username)
                    .HasName("UK_k8cjnp6t2ny42ih4fqunoyehp")
                    .IsUnique();

                entity.Property(e => e.NationalId)
                    .HasColumnName("national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.FatherName)
                    .HasColumnName("father_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LegalPersonality)
                    .HasColumnName("legal_personality")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NationalCardNo)
                    .HasColumnName("national_card_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NeedChangePass)
                    .HasColumnName("need_change_pass")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ShenasNo)
                    .HasColumnName("shenas_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ShenasSerial)
                    .HasColumnName("shenas_serial")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SiteEmail)
                    .HasColumnName("site_email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.ToTable("postal_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EndCode)
                    .HasColumnName("end_code")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.StartCode)
                    .HasColumnName("start_code")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<PreUniversityData>(entity =>
            {
                entity.ToTable("pre_university_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SourceVal)
                    .HasColumnName("source_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniInternalCode)
                    .HasColumnName("uni_internal_code")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UniNationalCode)
                    .HasColumnName("uni_national_code")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EnName)
                    .HasColumnName("en_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FaName)
                    .HasColumnName("fa_name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("service_category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EnName)
                    .HasColumnName("en_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FaName)
                    .HasColumnName("fa_name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ServiceForm>(entity =>
            {
                entity.ToTable("service_form");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.OtherTerms)
                    .HasColumnName("other_terms")
                    .HasColumnType("varchar(4000)");

                entity.Property(e => e.PayPeriod)
                    .HasColumnName("pay_period")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PayTypeVal)
                    .HasColumnName("pay_type_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SlaVal)
                    .HasColumnName("sla_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubServiceId)
                    .HasColumnName("sub_service_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SubsDuration)
                    .HasColumnName("subs_duration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ServiceFormParameter>(entity =>
            {
                entity.ToTable("service_form_parameter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Deposit)
                    .HasColumnName("deposit")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.InitialCost)
                    .HasColumnName("initial_cost")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.OtherCost)
                    .HasColumnName("other_cost")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PeriodicPayment)
                    .HasColumnName("periodic_payment")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ServiceFormId)
                    .HasColumnName("service_form_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Specs)
                    .HasColumnName("specs")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Warranty)
                    .HasColumnName("warranty")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<ServiceFormRequest>(entity =>
            {
                entity.ToTable("service_form_request");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FinalSignedForm)
                    .HasColumnName("final_signed_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.Letter)
                    .HasColumnName("letter")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.PostReceipt)
                    .HasColumnName("post_receipt")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.ServiceFormContractDate)
                    .HasColumnName("service_form_contract_date")
                    .HasColumnType("date");

                entity.Property(e => e.ServiceFormContractNo)
                    .HasColumnName("service_form_contract_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ServiceFormParameterId)
                    .HasColumnName("service_form_parameter_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SignedForm)
                    .HasColumnName("signed_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.StatusVal)
                    .HasColumnName("status_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubsBuildingId)
                    .HasColumnName("subs_building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SubscriptionContractNo)
                    .HasColumnName("subscription_contract_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubscriptionDate)
                    .HasColumnName("subscription_date")
                    .HasColumnType("date");

                entity.Property(e => e.UniId)
                    .HasColumnName("uni_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<SignupPics>(entity =>
            {
                entity.ToTable("signup_pics");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.NationalcardPic).HasColumnName("nationalcard_pic");

                entity.Property(e => e.PersonalinfoId)
                    .HasColumnName("personalinfo_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ShenasPic).HasColumnName("shenas_pic");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.StateId)
                    .HasColumnName("state_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneCode)
                    .HasColumnName("phone_code")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SubService>(entity =>
            {
                entity.ToTable("sub_service");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ApproveSessionNo)
                    .HasColumnName("approve_session_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ApproveTypeVal)
                    .HasColumnName("approve_type_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CostTitle)
                    .HasColumnName("cost_title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EnName)
                    .HasColumnName("en_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ExclusiveTerms)
                    .HasColumnName("exclusive_terms")
                    .HasColumnType("varchar(4000)");

                entity.Property(e => e.FaName)
                    .HasColumnName("fa_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("service_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SlaMeasurement)
                    .HasColumnName("sla_measurement")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SubServiceParameter>(entity =>
            {
                entity.ToTable("sub_service_parameter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BronzeValue).HasColumnName("bronze_value");

                entity.Property(e => e.DiamondValue).HasColumnName("diamond_value");

                entity.Property(e => e.FaName)
                    .HasColumnName("fa_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GoldValue).HasColumnName("gold_value");

                entity.Property(e => e.SilverValue).HasColumnName("silver_value");

                entity.Property(e => e.SubServiceId)
                    .HasColumnName("sub_service_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UnitVal)
                    .HasColumnName("unit_val")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SubjobTitle>(entity =>
            {
                entity.ToTable("subjob_title");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SubtitleName)
                    .HasColumnName("subtitle_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TitelId)
                    .HasColumnName("titel_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<SubsBuilding>(entity =>
            {
                entity.ToTable("subs_building");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentEmail)
                    .HasColumnName("agent_email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentFax)
                    .HasColumnName("agent_fax")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentFname)
                    .HasColumnName("agent_fname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentId)
                    .HasColumnName("agent_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AgentLname)
                    .HasColumnName("agent_lname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentMobile)
                    .HasColumnName("agent_mobile")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentNationalId)
                    .HasColumnName("agent_national_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentPos)
                    .HasColumnName("agent_pos")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AgentTel)
                    .HasColumnName("agent_tel")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildingName)
                    .HasColumnName("building_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.DistanceToTelecom)
                    .HasColumnName("distance_to_telecom")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FiberCoreCount)
                    .HasColumnName("fiber_core_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstFossContract)
                    .HasColumnName("first_foss_contract")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FirstTel)
                    .HasColumnName("first_tel")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FreeFiberCoreCount)
                    .HasColumnName("free_fiber_core_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HaveFiber)
                    .HasColumnName("have_fiber")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.HaveFreeFiber)
                    .HasColumnName("have_free_fiber")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.MapLocLat).HasColumnName("map_loc_lat");

                entity.Property(e => e.MapLocLng).HasColumnName("map_loc_lng");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SecondFossContract)
                    .HasColumnName("second_foss_contract")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SecondTel)
                    .HasColumnName("second_tel")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TelecomName)
                    .HasColumnName("telecom_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UniId)
                    .HasColumnName("uni_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<TelecomCenter>(entity =>
            {
                entity.ToTable("telecom_center");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CenterAgentName)
                    .HasColumnName("center_agent_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CenterLat).HasColumnName("center_lat");

                entity.Property(e => e.CenterLng).HasColumnName("center_lng");

                entity.Property(e => e.CenterTel)
                    .HasColumnName("center_tel")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TelCityId)
                    .HasColumnName("tel_city_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TelecomCenterPreFix>(entity =>
            {
                entity.ToTable("telecom_center_pre_fix");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PreFixNo)
                    .HasColumnName("pre_fix_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TelecomCenterId)
                    .HasColumnName("telecom_center_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<UniStatusLog>(entity =>
            {
                entity.ToTable("uni_status_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ApprovalAdminId)
                    .HasColumnName("approval_admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ApprovalUniId)
                    .HasColumnName("approval_uni_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UniNationalId)
                    .HasColumnName("uni_national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UniStatus)
                    .HasColumnName("uni_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniSubStatus)
                    .HasColumnName("uni_sub_status")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(e => e.UniNationalId)
                    .HasName("PRIMARY");

                entity.ToTable("university");

                entity.HasIndex(e => e.SubscriptionContractNo)
                    .HasName("subscription_contract_no_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UniNationalId)
                    .HasColumnName("uni_national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CancellForm)
                    .HasColumnName("cancell_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ConfirmForm)
                    .HasColumnName("confirm_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EcoCode)
                    .HasColumnName("eco_code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EditForm)
                    .HasColumnName("edit_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.FaxNo)
                    .HasColumnName("fax_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.JameSeprate)
                    .HasColumnName("jame_seprate")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.MapLocLat).HasColumnName("map_loc_lat");

                entity.Property(e => e.MapLocLng).HasColumnName("map_loc_lng");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ReasonCancellForm)
                    .HasColumnName("reason_cancell_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.RequestForm)
                    .HasColumnName("request_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.SignatoryName)
                    .HasColumnName("signatory_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SignatoryNationalId)
                    .HasColumnName("signatory_national_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SignatoryPos)
                    .HasColumnName("signatory_pos")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SiteAddress)
                    .HasColumnName("site_address")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StateId)
                    .HasColumnName("state_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SubscriptionContractDate)
                    .HasColumnName("subscription_contract_date")
                    .HasColumnType("date");

                entity.Property(e => e.SubscriptionContractNo)
                    .HasColumnName("subscription_contract_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubscriptionExampleForm)
                    .HasColumnName("subscription_example_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.SubscriptionForm)
                    .HasColumnName("subscription_form")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.SubscriptionFormSigned)
                    .HasColumnName("subscription_form_signed")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.SubscriptionLetter)
                    .HasColumnName("subscription_letter")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.SubscriptionPostTicket)
                    .HasColumnName("subscription_post_ticket")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.TeleNo)
                    .HasColumnName("tele_no")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TopManagerName)
                    .HasColumnName("top_manager_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TopManagerPos)
                    .HasColumnName("top_manager_pos")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TypeVal)
                    .HasColumnName("type_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniName)
                    .HasColumnName("uni_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UniPublicEmail)
                    .HasColumnName("uni_public_email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UniStatus)
                    .HasColumnName("uni_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniStatusLog)
                    .HasColumnName("uni_status_log")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UniSubCode)
                    .HasColumnName("uni_sub_code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniSubStatus)
                    .HasColumnName("uni_sub_status")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserRel>(entity =>
            {
                entity.HasKey(e => e.RelId)
                    .HasName("PRIMARY");

                entity.ToTable("user_rel");

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.NationalId)
                    .HasColumnName("national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubSystemCode)
                    .HasColumnName("sub_system_code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniNationalId)
                    .HasColumnName("uni_national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UserRelStatus)
                    .HasColumnName("userRelStatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Validity)
                    .HasColumnName("validity")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("user_role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.NationalId)
                    .HasColumnName("national_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UserRoleVal)
                    .HasColumnName("user_role_val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Validity)
                    .HasColumnName("validity")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<WorldNern>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PRIMARY");

                entity.ToTable("world_nern");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NernName)
                    .HasColumnName("nern_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SiteUrl)
                    .HasColumnName("site_url")
                    .HasColumnType("varchar(255)");
            });
        }
    }
}
