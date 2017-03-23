using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetcoretest.Models
{
    public class TicketingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Project { get; set; }
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ticketing.sqlite");
        }
    }

    public class Customer
    {
        [Key]        
        public int IDCustomer{get;set;}        
        public string Name {get;set;}
        public string Description {get;set;}
        
    }
    public class Project{
        [Key]
        public int IDProject{get;set;}        
        public string Name{get;set;}
        public List<Contact> CustomerContacts {get;set;}
        public List<Point> CustomerPoints {get;set;}
    }
    public class Contact
    {
        [Key]
        public int IDContact{get;set;}        
        public string Name {get;set;}

        public string EmailAddress {get;set;}
    }
    public class Task
    {
        [Key]
        public int IDTask{get;set;}        
        public int Points {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
    }
    public class Point
    {
        [Key]
        public int IDOrder {get;set;}
        public int pointsCount{get;set;}
        public DateTime DeadlineDate {get;set;}
    }
}