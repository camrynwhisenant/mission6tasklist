using System;
using Microsoft.EntityFrameworkCore;

namespace mission6.Models
{
    public class TaskContext : DbContext
    {
        //constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Task>().HasData(
                new Task
                {
                    TaskID = 1,
                    TaskName = "Mission 6 Project",
                    Quadrant = 1,
                    Completed = false,
                    DueDate = "2/9",
                    Categoryid = 2,
                },
                new Task
                {
                    TaskID = 2,
                    TaskName = "Authorization Lab",
                    Quadrant = 2,
                    Completed = false,
                    DueDate = "2/10",
                    Categoryid = 2,
                }
                );

            mb.Entity<Category>().HasData(
                new Category { Categoryid = 1, CategoryName = "Home" },
                new Category { Categoryid = 2, CategoryName = "School" },
                new Category { Categoryid = 3, CategoryName = "Work" },
                new Category { Categoryid = 4, CategoryName = "Church" });
        }
    }
}