using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDeptWebApplication.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeDeptWebApplication.Models
{
    public class EmpDeptWebAppDBContext : DbContext
    {
        public EmpDeptWebAppDBContext()
        {
        }

        private readonly Helper _helper;
        public EmpDeptWebAppDBContext(DbContextOptions<EmpDeptWebAppDBContext> dbContextOptions, 
            Helper helper) : base(dbContextOptions)
        {
            _helper = helper;
        }


        #region Entities
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_helper.GetConnectionString("EmployeeDBContext"));
            }
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(entity =>
            {

                entity.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.FKDepartmentId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Dept_Emp");
            });

            //modelBuilder.Entity<Department>(entity => {
            //    entity.Property(x => x.IsActive).HasDefaultValue(false);
            //});

            base.OnModelCreating(modelBuilder);
        }

    }
}
