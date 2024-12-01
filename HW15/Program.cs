// See https://aka.ms/new-console-template for more information
using HW15.Data;

Console.WriteLine("Hello, World!");
AppDbContext appDbContext = new AppDbContext();

appDbContext.Database.EnsureCreated();
