using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDeptWebApplication.Models
{
    public class EmpDeptWebAppDBContext : DbContext
    {
        public EmpDeptWebAppDBContext()
        {
        }

        public EmpDeptWebAppDBContext(DbContextOptions<EmpDeptWebAppDBContext> dbContextOptions):base(dbContextOptions)
        {
        }


        #region Entities
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-UOENECT\\SQLEXPRESS;Database=EmpDeptWebAppDB;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(entity => {

                entity.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.FKDepartmentId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Dept_Emp");
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
