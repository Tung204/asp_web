﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectA.Models;

namespace ProjectA.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<SanPham> SanPham { get; set; }
		public DbSet<TheLoai> TheLoai { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }
	}
}
