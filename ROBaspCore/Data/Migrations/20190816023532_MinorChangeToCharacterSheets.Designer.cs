﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ROBaspCore.Data;

namespace ROBaspCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190816023532_MinorChangeToCharacterSheets")]
    partial class MinorChangeToCharacterSheets
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

            modelBuilder.Entity("ROBaspCore.Models.AttributeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeType");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("AttributeModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_ChildSkill_Link", b =>
                {
                    b.Property<int?>("CharacterSheetId");

                    b.Property<int?>("ChildSkillId");

                    b.HasKey("CharacterSheetId", "ChildSkillId");

                    b.HasIndex("ChildSkillId");

                    b.ToTable("CharacterSheet_ChildSkill_Link");
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_ParentSkill_Link", b =>
                {
                    b.Property<int?>("CharacterSheetId");

                    b.Property<int?>("ParentSkillId");

                    b.HasKey("CharacterSheetId", "ParentSkillId");

                    b.HasIndex("ParentSkillId");

                    b.ToTable("CharacterSheet_ParentSkill_Link");
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_Talent_Link", b =>
                {
                    b.Property<int?>("CharacterSheetId");

                    b.Property<int?>("TalentId");

                    b.HasKey("CharacterSheetId", "TalentId");

                    b.HasIndex("TalentId");

                    b.ToTable("CharacterSheet_Talent_Link");
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_Technique_Link", b =>
                {
                    b.Property<int?>("CharacterSheetId");

                    b.Property<int?>("TechniqueId");

                    b.HasKey("CharacterSheetId", "TechniqueId");

                    b.HasIndex("TechniqueId");

                    b.ToTable("CharacterSheet_Technique_Link");
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agile");

                    b.Property<int>("Attractive");

                    b.Property<int>("Charismatic");

                    b.Property<int>("Headstrong");

                    b.Property<int>("Knowledgeable");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int>("Precision");

                    b.Property<int?>("RaceId");

                    b.Property<int>("Robust");

                    b.Property<int>("Strong");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("CharacterSheetModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.ChildSkillModel", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.LanguageGroupTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("LanguageType");

                    b.HasKey("Id");

                    b.ToTable("LanguageGroupTypeModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.LanguageModel", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.ModifierModel", b =>
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

                    b.Property<bool?>("IsStatic");

                    b.Property<int>("Modifier");

                    b.Property<bool>("MultiplyByLevel");

                    b.Property<int?>("ParentSkillToModifyId");

                    b.Property<int?>("RaceModelId");

                    b.Property<string>("StaticSkillSufix");

                    b.Property<string>("StaticSkillToModify");

                    b.Property<int?>("TechniqueModelId");

                    b.HasKey("Id");

                    b.HasIndex("AttributeToModifyId");

                    b.HasIndex("ChildSkillToModifyId");

                    b.HasIndex("ParentSkillToModifyId");

                    b.HasIndex("RaceModelId");

                    b.HasIndex("TechniqueModelId");

                    b.ToTable("ModifierModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.ParentSkillModel", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_ChildSkill_LinkModel", b =>
                {
                    b.Property<int?>("ChildSkillId");

                    b.Property<int?>("PregenProfessionArchetypeId");

                    b.HasKey("ChildSkillId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_ChildSkill_LinkModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_ParentSkill_LinkModel", b =>
                {
                    b.Property<int?>("ParentSkillId");

                    b.Property<int?>("PregenProfessionArchetypeId");

                    b.HasKey("ParentSkillId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_ParentSkill_LinkModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_Talent_LinkModel", b =>
                {
                    b.Property<int?>("TalentId");

                    b.Property<int?>("PregenProfessionArchetypeId");

                    b.HasKey("TalentId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_Talent_LinkModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_Technique_LinkModel", b =>
                {
                    b.Property<int?>("TechniqueId");

                    b.Property<int?>("PregenProfessionArchetypeId");

                    b.HasKey("TechniqueId", "PregenProfessionArchetypeId");

                    b.HasIndex("PregenProfessionArchetypeId");

                    b.ToTable("PregenProfessionArchetype_Technique_LinkModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PregenProfessionArchetypeModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.RaceModel", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.TalentGroupTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("GroupName");

                    b.HasKey("Id");

                    b.ToTable("TalentGroupTypeModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.TalentModel", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.TalentPrerequisiteLink", b =>
                {
                    b.Property<int?>("TalentId");

                    b.Property<int?>("PrerequisiteId");

                    b.HasKey("TalentId", "PrerequisiteId");

                    b.HasIndex("PrerequisiteId");

                    b.ToTable("TalentPrerequisiteLink");
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueGameRequirement", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.TechniqueGameRequirementLink", b =>
                {
                    b.Property<int?>("GameRequirementId");

                    b.Property<int?>("TechniqueId");

                    b.HasKey("GameRequirementId", "TechniqueId");

                    b.HasIndex("TechniqueId");

                    b.ToTable("TechniqueGameRequirementsLink");
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueGroupTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("TechniqueGroupType");

                    b.HasKey("Id");

                    b.ToTable("TechniqueGroupTypeModel");
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueModel", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.TechniquePrerequisiteLink", b =>
                {
                    b.Property<int?>("TechniqueModelId");

                    b.Property<int?>("PrerequisiteId");

                    b.HasKey("TechniqueModelId", "PrerequisiteId");

                    b.HasIndex("PrerequisiteId");

                    b.ToTable("TechniquePrerequisitesLink");
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueTalentPrerequisiteLink", b =>
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

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_ChildSkill_Link", b =>
                {
                    b.HasOne("ROBaspCore.Models.CharacterSheetModel", "CharacterSheet")
                        .WithMany("ChildSkills")
                        .HasForeignKey("CharacterSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.ChildSkillModel", "ChildSkill")
                        .WithMany("CharacterSheets")
                        .HasForeignKey("ChildSkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_ParentSkill_Link", b =>
                {
                    b.HasOne("ROBaspCore.Models.CharacterSheetModel", "CharacterSheet")
                        .WithMany("ParentSkills")
                        .HasForeignKey("CharacterSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.ParentSkillModel", "ParentSkill")
                        .WithMany("CharacterSheets")
                        .HasForeignKey("ParentSkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_Talent_Link", b =>
                {
                    b.HasOne("ROBaspCore.Models.CharacterSheetModel", "CharacterSheet")
                        .WithMany("Talents")
                        .HasForeignKey("CharacterSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.TalentModel", "Talent")
                        .WithMany("CharacterSheets")
                        .HasForeignKey("TalentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheet_Technique_Link", b =>
                {
                    b.HasOne("ROBaspCore.Models.CharacterSheetModel", "CharacterSheet")
                        .WithMany("Techniques")
                        .HasForeignKey("CharacterSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.TechniqueModel", "Technique")
                        .WithMany("CharacterSheets")
                        .HasForeignKey("TechniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.CharacterSheetModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.RaceModel", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("ROBaspCore.Models.ChildSkillModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.ParentSkillModel", "ParentSkill")
                        .WithMany("ChildSkills")
                        .HasForeignKey("ParentSkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.LanguageModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.LanguageGroupTypeModel", "GroupType")
                        .WithMany()
                        .HasForeignKey("GroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.ModifierModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.AttributeModel", "AttributeToModify")
                        .WithMany()
                        .HasForeignKey("AttributeToModifyId");

                    b.HasOne("ROBaspCore.Models.ChildSkillModel", "ChildSkillToModify")
                        .WithMany()
                        .HasForeignKey("ChildSkillToModifyId");

                    b.HasOne("ROBaspCore.Models.ParentSkillModel", "ParentSkillToModify")
                        .WithMany()
                        .HasForeignKey("ParentSkillToModifyId");

                    b.HasOne("ROBaspCore.Models.RaceModel", "RaceModel")
                        .WithMany("Modifiers")
                        .HasForeignKey("RaceModelId");

                    b.HasOne("ROBaspCore.Models.TechniqueModel", "TechniqueModel")
                        .WithMany("Modifiers")
                        .HasForeignKey("TechniqueModelId");
                });

            modelBuilder.Entity("ROBaspCore.Models.ParentSkillModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.AttributeModel", "FirstAttribute")
                        .WithMany()
                        .HasForeignKey("FirstAttributeId");

                    b.HasOne("ROBaspCore.Models.AttributeModel", "SecondAttribute")
                        .WithMany()
                        .HasForeignKey("SecondAttributeId");
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_ChildSkill_LinkModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.ChildSkillModel", "ChildSkill")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("ChildSkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("ChildSkills")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_ParentSkill_LinkModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.ParentSkillModel", "ParentSkill")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("ParentSkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("TrainedParentSkills")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_Talent_LinkModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("Talents")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.TalentModel", "Talent")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("TalentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.PregenProfessionArchetype_Technique_LinkModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.PregenProfessionArchetypeModel", "PregenProfessionArchetype")
                        .WithMany("Techniques")
                        .HasForeignKey("PregenProfessionArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.TechniqueModel", "Technique")
                        .WithMany("PregenProfessionArchetypeLink")
                        .HasForeignKey("TechniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.RaceModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.AttributeModel", "FirstModifiedAttribute")
                        .WithMany()
                        .HasForeignKey("FirstModifiedAttributeId");

                    b.HasOne("ROBaspCore.Models.AttributeModel", "SecondModifiedAttribute")
                        .WithMany()
                        .HasForeignKey("SecondModifiedAttributeId");
                });

            modelBuilder.Entity("ROBaspCore.Models.TalentModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.TalentGroupTypeModel", "TalentGroup")
                        .WithMany()
                        .HasForeignKey("TalentGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.TalentPrerequisiteLink", b =>
                {
                    b.HasOne("ROBaspCore.Models.TalentModel", "Prerequisite")
                        .WithMany("TalentBases")
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROBaspCore.Models.TalentModel", "Talent")
                        .WithMany("TalentPrerequisites")
                        .HasForeignKey("TalentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueGameRequirement", b =>
                {
                    b.HasOne("ROBaspCore.Models.TechniqueGroupTypeModel", "TechniqueGroupType")
                        .WithMany()
                        .HasForeignKey("TechniqueGroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueGameRequirementLink", b =>
                {
                    b.HasOne("ROBaspCore.Models.TechniqueGameRequirement", "GameRequirement")
                        .WithMany("TechniqueGameRequirements")
                        .HasForeignKey("GameRequirementId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROBaspCore.Models.TechniqueModel", "Technique")
                        .WithMany("GameRequirements")
                        .HasForeignKey("TechniqueId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueModel", b =>
                {
                    b.HasOne("ROBaspCore.Models.TechniqueGroupTypeModel", "TechniqueGroupType")
                        .WithMany()
                        .HasForeignKey("TechniqueGroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniquePrerequisiteLink", b =>
                {
                    b.HasOne("ROBaspCore.Models.TechniqueModel", "Prerequisite")
                        .WithMany("TechniqueBases")
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ROBaspCore.Models.TechniqueModel", "Technique")
                        .WithMany("TechniquePrerequisites")
                        .HasForeignKey("TechniqueModelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ROBaspCore.Models.TechniqueTalentPrerequisiteLink", b =>
                {
                    b.HasOne("ROBaspCore.Models.TalentModel", "TalentPrerequisite")
                        .WithMany("TechniqueConnection")
                        .HasForeignKey("TalentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ROBaspCore.Models.TechniqueModel", "Technique")
                        .WithMany("TalentPrerequisites")
                        .HasForeignKey("TechniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
