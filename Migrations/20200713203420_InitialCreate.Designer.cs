﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using adventure_cli._data;

namespace adventure_cli.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200713203420_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("adventure_cli._models.characterData.ArmorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArmorRating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentDurability")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoldValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxDurability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Armor_Tbl");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorRating = 2,
                            CurrentDurability = 5,
                            GoldValue = 10,
                            MaxDurability = 5,
                            Name = "Leather Armor"
                        },
                        new
                        {
                            Id = 2,
                            ArmorRating = 2,
                            CurrentDurability = 5,
                            GoldValue = 10,
                            MaxDurability = 5,
                            Name = "Leather Armor 1"
                        },
                        new
                        {
                            Id = 3,
                            ArmorRating = 2,
                            CurrentDurability = 5,
                            GoldValue = 10,
                            MaxDurability = 5,
                            Name = "Leather Armor 2"
                        },
                        new
                        {
                            Id = 4,
                            ArmorRating = 2,
                            CurrentDurability = 5,
                            GoldValue = 10,
                            MaxDurability = 5,
                            Name = "Leather Armor 3"
                        },
                        new
                        {
                            Id = 5,
                            ArmorRating = 2,
                            CurrentDurability = 5,
                            GoldValue = 10,
                            MaxDurability = 5,
                            Name = "Leather Armor 4"
                        });
                });

            modelBuilder.Entity("adventure_cli._models.characterData.CharacterData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dexterity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intelligence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Max_HP")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<int>("XP")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Character_Tbl");

                    b.HasData(
                        new
                        {
                            Id = 999,
                            Dexterity = 2,
                            HP = 10,
                            Intelligence = 1,
                            Level = 0,
                            Max_HP = 10,
                            Name = "Django",
                            Strength = 3,
                            Type = "Player",
                            XP = 0
                        },
                        new
                        {
                            Id = 1,
                            Dexterity = 2,
                            HP = 10,
                            Intelligence = 2,
                            Level = 0,
                            Max_HP = 10,
                            Name = "Enemy 1",
                            Strength = 2,
                            Type = "Enemy",
                            XP = 20
                        },
                        new
                        {
                            Id = 2,
                            Dexterity = 2,
                            HP = 10,
                            Intelligence = 2,
                            Level = 0,
                            Max_HP = 10,
                            Name = "Enemy 2",
                            Strength = 2,
                            Type = "Enemy",
                            XP = 20
                        },
                        new
                        {
                            Id = 3,
                            Dexterity = 2,
                            HP = 10,
                            Intelligence = 2,
                            Level = 0,
                            Max_HP = 10,
                            Name = "Enemy 3",
                            Strength = 2,
                            Type = "Enemy",
                            XP = 20
                        });
                });

            modelBuilder.Entity("adventure_cli._models.characterData.PotionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoldValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HealValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Potion_Tbl");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GoldValue = 5,
                            HealValue = 3,
                            Name = "Lesser Healing Potion"
                        },
                        new
                        {
                            Id = 2,
                            GoldValue = 10,
                            HealValue = 6,
                            Name = "Healing Potion"
                        },
                        new
                        {
                            Id = 3,
                            GoldValue = 15,
                            HealValue = 9,
                            Name = "Greater Healing Potion"
                        });
                });

            modelBuilder.Entity("adventure_cli._models.characterData.WeaponData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentDurability")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoldValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxDamage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxDurability")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinDamage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Weapon_Tbl");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentDurability = 5,
                            GoldValue = 15,
                            MaxDamage = 4,
                            MaxDurability = 5,
                            MinDamage = 2,
                            Name = "Longsword"
                        },
                        new
                        {
                            Id = 2,
                            CurrentDurability = 3,
                            GoldValue = 2,
                            MaxDamage = 2,
                            MaxDurability = 3,
                            MinDamage = 1,
                            Name = "Fat Stick"
                        },
                        new
                        {
                            Id = 3,
                            CurrentDurability = 5,
                            GoldValue = 8,
                            MaxDamage = 3,
                            MaxDurability = 5,
                            MinDamage = 1,
                            Name = "Dagger"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
