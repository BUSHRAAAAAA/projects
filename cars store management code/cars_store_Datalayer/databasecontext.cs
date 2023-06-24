using cars_store_Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace cars_store_Datalayer

{//عملية وراثة للكلاس المسؤول عن قواعد البيانات
      public class databasecontext:DbContext{

        public DbSet <Cars> tabel_cars { get; set; }//create table_cars from class cars using DbSet
        public DbSet <parts> tabel_parts { get; set; }//create tabel_parts from class parts using DbSet
        public DbSet <sales> tabel_sales { get; set; }//create tabel_sales  from class sales using DbSet
        public DbSet <suppliers> tabel_suppliers { get; set; }//create table_suppliers from class suppliers using DbSet
        public DbSet <coustomer> tabel_Costomer { get; set; }//create table_Costomer from class Costomer using DbSet

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//انشاء اتصال بالسيرفر الذي يحوي قاعدة البيانات mydatabase
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB;" +
                " Initial catalog= MyDataBase");
        }
        //تابع لاضافة جدول كسر العلاقة وامكانية
        //اضافة خصائص للجدول بدل انشاءالجدول باستخدام عملية ميكريشن
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<parts>()
                 .HasMany(pa => pa.listcars)
                 .WithMany(pa => pa.listparts)
                 .UsingEntity<parts_cars>();


        }

    }
}