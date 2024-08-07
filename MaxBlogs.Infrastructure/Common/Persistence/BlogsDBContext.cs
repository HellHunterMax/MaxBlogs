﻿using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Domain.BlogEntries;
using MaxBlogs.Domain.Blogs;
using MaxBlogs.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MaxBlogs.Infrastructure.Common.Persistence;
internal class BlogsDBContext : DbContext, IUnitOfWork
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BlogEntry> BlogsEntries { get; set; }

    public BlogsDBContext(DbContextOptions options) : base(options)
    {

    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
