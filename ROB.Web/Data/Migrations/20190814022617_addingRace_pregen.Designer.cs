﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ROB.Web.Data;

namespace ROB.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190814022617_addingRace_pregen")]
    partial class addingRace_pregen
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ROB.Web.Models.AttributeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeType");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("AttributeModel");
                });

            modelBuilder.Entity("ROB.Web.Models.CharacterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.Property<int?>("RaceId");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("CharacterModel");
                });

            modelBuilder.Entity("ROB.Web.Models.ChildSkillModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ParentSkillId");

                    b.HasKey("Id");

                    b.HasIndex("ParentSkillId");

                    b.ToTable("ChildSkillModel");
                });

            modelBuilder.Entity("ROB.Web.Models.LanguageGroupTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("LanguageType");

                    b.HasKey("Id");

                    b.ToTable("LanguageGroupTypeModel");
                });

            modelBuilder.Entity("ROB.Web.Models.LanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupTypeId");

                    b.Property<string>("LanguageName");

                    b.Property<string>("TypeName");

                    b.Property<bool>("Written");

                    b.HasKey("Id");

                    b.HasIndex("GroupTypeId");

                    b.ToTable("LanguageModel");
                });

            modelBuilder.Entity("ROB.Web.Models.ModifierModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalModifiers");

                    b.Property<int?>("AttributeToModifyId");

                    b.Property<int?>("ChildSkillToModifyId");

                    b.Property<string>("Description");

                    b.Property<bool>("EffectAllParentSkills");

                    b.Property<bool>("EffectAllTrainedParentSkills");

                    b.Property<int>("Modifier");

                    b.Property<bool>("MultiplyByLevel");

                    b.Property<int?>("ParentSkillToModifyId");

                    b.Property<int?>("RaceModelId");

                    b.Property<int?>("TechniqueModelId");

                    b.HasKey("Id");

                    b.HasIndex("AttributeToModifyId");

                    b.HasIndex("ChildSkillToModifyId");

                    b.HasIndex("ParentSkillToModifyId");

                    b.HasIndex("RaceModelId");

                    b.HasIndex("TechniqueModelId");

                    b.ToTable("ModifierModel");
                });

            modelBuilder.Entity("ROB.Web.Models.ParentSkillModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<int?>("FirstAttributeId");

                    b.Property<int>("MyProperty");

                    b.Property<string>("Name");

                    b.Property<int?>("SecondAttributeId");

                    b.HasKey("Id");

                    b.HasIndex("FirstAttributeId");

                    b.HasIndex("SecondAttributeId");

                    b.ToTable("ParentSkillModel");
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_ChildSkill_LinkModel", b =>
                {
                    b.Property<int>("ChildSkillId");

                    b.Property<int>("PregenProfessionArchetypeId");

                    b.HasKey("ChildSkillId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_ChildSkill_LinkModel");
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_ParentSkill_LinkModel", b =>
                {
                    b.Property<int>("ParentSkillId");

                    b.Property<int>("PregenProfessionArchetypeId");

                    b.HasKey("ParentSkillId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_ParentSkill_LinkModel");
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_Talent_LinkModel", b =>
                {
                    b.Property<int>("TalentId");

                    b.Property<int>("PregenProfessionArchetypeId");

                    b.HasKey("TalentId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_Talent_LinkModel");
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_Technique_LinkModel", b =>
                {
                    b.Property<int>("TechniqueId");

                    b.Property<int>("PregenProfessionArchetypeId");

                    b.HasKey("TechniqueId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_Technique_LinkModel");
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PregenProfessionArchetypeModel");
                });

            modelBuilder.Entity("ROB.Web.Models.RaceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionBrief");

                    b.Property<int>("FirstAttributeModifier");

                    b.Property<int?>("FirstModifiedAttributeId");

                    b.Property<int>("HeightInches");

                    b.Property<int>("LifeSpanYears");

                    b.Property<int>("Luck");

                    b.Property<string>("Name");

                    b.Property<int>("SecondAttributeModifier");

                    b.Property<int?>("SecondModifiedAttributeId");

                    b.Property<int>("Size");

                    b.Property<int>("Sprint");

                    b.Property<int>("Tactical");

                    b.Property<int>("Walk");

                    b.Property<int>("WeightLBS");

                    b.HasKey("Id");

                    b.HasIndex("FirstModifiedAttributeId");

                    b.HasIndex("SecondModifiedAttributeId");

                    b.ToTable("RaceModel");
                });

            modelBuilder.Entity("ROB.Web.Models.TalentGroupTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("GroupName");

                    b.HasKey("Id");

                    b.ToTable("TalentGroupTypeModel");
                });

            modelBuilder.Entity("ROB.Web.Models.TalentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Benefit");

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("TalentGroupId");

                    b.HasKey("Id");

                    b.HasIndex("TalentGroupId");

                    b.ToTable("TalentModel");
                });

            modelBuilder.Entity("ROB.Web.Models.TalentPrerequisiteLink", b =>
                {
                    b.Property<int?>("TalentId");

                    b.Property<int?>("PrerequisiteId");

                    b.HasKey("TalentId", "PrerequisiteId");

                    b.HasIndex("PrerequisiteId");

                    b.ToTable("TalentPrerequisiteLink");
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueGameRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionBrief");

                    b.Property<int>("TechniqueGroupTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TechniqueGroupTypeId");

                    b.ToTable("TechniqueGameRequirement");
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueGameRequirementLink", b =>
                {
                    b.Property<int?>("GameRequirementId");

                    b.Property<int?>("TechniqueId");

                    b.HasKey("GameRequirementId", "TechniqueId");

                    b.HasIndex("TechniqueId");

                    b.ToTable("TechniqueGameRequirementsLink");
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueGroupTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("TechniqueGroupType");

                    b.HasKey("Id");

                    b.ToTable("TechniqueGroupTypeModel");
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<int>("DurationLengthType");

                    b.Property<int>("MinimumLevelRequirement");

                    b.Property<string>("Notes");

                    b.Property<int>("TechniqueGroupTypeId");

                    b.Property<string>("TechniqueName");

                    b.HasKey("Id");

                    b.HasIndex("TechniqueGroupTypeId");

                    b.ToTable("TechniqueModel");
                });

            modelBuilder.Entity("ROB.Web.Models.TechniquePrerequisiteLink", b =>
                {
                    b.Property<int?>("TechniqueModelId");

                    b.Property<int?>("PrerequisiteId");

                    b.HasKey("TechniqueModelId", "PrerequisiteId");

                    b.HasIndex("PrerequisiteId");

                    b.ToTable("TechniquePrerequisitesLink");
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueTalentPrerequisiteLink", b =>
                {
                    b.Property<int?>("TalentId");

                    b.Property<int?>("TechniqueId");

                    b.HasKey("TalentId", "TechniqueId");

                    b.HasIndex("TechniqueId");

                    b.ToTable("TechniqueTalentPrerequisiteLinks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROB.Web.Models.CharacterModel", b =>
                {
                    b.HasOne("ROB.Web.Models.RaceModel", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("ROB.Web.Models.ChildSkillModel", b =>
                {
                    b.HasOne("ROB.Web.Models.ParentSkillModel", "ParentSkill")
                        .WithMany("ChildSkills")
                        .HasForeignKey("ParentSkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROB.Web.Models.LanguageModel", b =>
                {
                    b.HasOne("ROB.Web.Models.LanguageGroupTypeModel", "GroupType")
                        .WithMany()
                        .HasForeignKey("GroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROB.Web.Models.ModifierModel", b =>
                {
                    b.HasOne("ROB.Web.Models.AttributeModel", "AttributeToModify")
                        .WithMany()
                        .HasForeignKey("AttributeToModifyId");

                    b.HasOne("ROB.Web.Models.ChildSkillModel", "ChildSkillToModify")
                        .WithMany()
                        .HasForeignKey("ChildSkillToModifyId");

                    b.HasOne("ROB.Web.Models.ParentSkillModel", "ParentSkillToModify")
                        .WithMany()
                        .HasForeignKey("ParentSkillToModifyId");

                    b.HasOne("ROB.Web.Models.RaceModel")
                        .WithMany("Modifiers")
                        .HasForeignKey("RaceModelId");

                    b.HasOne("ROB.Web.Models.TechniqueModel")
                        .WithMany("Modifiers")
                        .HasForeignKey("TechniqueModelId");
                });

            modelBuilder.Entity("ROB.Web.Models.ParentSkillModel", b =>
                {
                    b.HasOne("ROB.Web.Models.AttributeModel", "FirstAttribute")
                        .WithMany()
                        .HasForeignKey("FirstAttributeId");

                    b.HasOne("ROB.Web.Models.AttributeModel", "SecondAttribute")
                        .WithMany()
                        .HasForeignKey("SecondAttributeId");
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_ChildSkill_LinkModel", b =>
                {
                    b.HasOne("ROB.Web.Models.ChildSkillModel", "ChildSkill")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROB.Web.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("ChildSkills")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_ParentSkill_LinkModel", b =>
                {
                    b.HasOne("ROB.Web.Models.ParentSkillModel", "ParentSkill")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROB.Web.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("TrainedParentSkills")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_Talent_LinkModel", b =>
                {
                    b.HasOne("ROB.Web.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("Talents")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROB.Web.Models.TalentModel", "Talent")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROB.Web.Models.PregenProfessionArchetype_Technique_LinkModel", b =>
                {
                    b.HasOne("ROB.Web.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("Techniques")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROB.Web.Models.TechniqueModel", "Technique")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROB.Web.Models.RaceModel", b =>
                {
                    b.HasOne("ROB.Web.Models.AttributeModel", "FirstModifiedAttribute")
                        .WithMany()
                        .HasForeignKey("FirstModifiedAttributeId");

                    b.HasOne("ROB.Web.Models.AttributeModel", "SecondModifiedAttribute")
                        .WithMany()
                        .HasForeignKey("SecondModifiedAttributeId");
                });

            modelBuilder.Entity("ROB.Web.Models.TalentModel", b =>
                {
                    b.HasOne("ROB.Web.Models.TalentGroupTypeModel", "TalentGroup")
                        .WithMany()
                        .HasForeignKey("TalentGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROB.Web.Models.TalentPrerequisiteLink", b =>
                {
                    b.HasOne("ROB.Web.Models.TalentModel", "Prerequisite")
                        .WithMany("TalentBases")
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROB.Web.Models.TalentModel", "Talent")
                        .WithMany("TalentPrerequisites")
                        .HasForeignKey("TalentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueGameRequirement", b =>
                {
                    b.HasOne("ROB.Web.Models.TechniqueGroupTypeModel", "TechniqueGroupType")
                        .WithMany()
                        .HasForeignKey("TechniqueGroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueGameRequirementLink", b =>
                {
                    b.HasOne("ROB.Web.Models.TechniqueGameRequirement", "GameRequirement")
                        .WithMany("TechniqueGameRequirements")
                        .HasForeignKey("GameRequirementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROB.Web.Models.TechniqueModel", "Technique")
                        .WithMany("GameRequirements")
                        .HasForeignKey("TechniqueId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueModel", b =>
                {
                    b.HasOne("ROB.Web.Models.TechniqueGroupTypeModel", "TechniqueGroupType")
                        .WithMany()
                        .HasForeignKey("TechniqueGroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROB.Web.Models.TechniquePrerequisiteLink", b =>
                {
                    b.HasOne("ROB.Web.Models.TechniqueModel", "Prerequisite")
                        .WithMany("TechniqueBases")
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROB.Web.Models.TechniqueModel", "Technique")
                        .WithMany("TechniquePrerequisites")
                        .HasForeignKey("TechniqueModelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROB.Web.Models.TechniqueTalentPrerequisiteLink", b =>
                {
                    b.HasOne("ROB.Web.Models.TalentModel", "TalentPrerequisite")
                        .WithMany("TechniqueConnection")
                        .HasForeignKey("TalentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROB.Web.Models.TechniqueModel", "Technique")
                        .WithMany("TalentPrerequisites")
                        .HasForeignKey("TechniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
