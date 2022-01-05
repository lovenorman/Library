﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FjärdeOchSIstaFörsöket.Data;
using FjärdeOchSIstaFörsöket.Models;

namespace FjärdeOchSIstaFörsöket.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly FjärdeOchSIstaFörsöket.Data.ApplicationDbContext _context;

        public string SortOrder { get; set; }

        public IndexModel(FjärdeOchSIstaFörsöket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            Book = await _context.Books.Include(x => x.Author).ToListAsync();
            SortOrder = string.IsNullOrEmpty(sortOrder) ? "" : sortOrder;
            Book = SortOrder switch
            {
                "?sort=titleasc" => Book.OrderBy(b => b.Title).ToList(),
                "?sort=titledesc" => Book.OrderByDescending(b => b.Title).ToList(),
                "?sort=authorasc" => Book.OrderBy(b => b.Author.AuthorName).ToList(),
                "?sort=authordesc" => Book.OrderByDescending(b => b.Author.AuthorName).ToList(),
                "?sort=categoryasc" => Book.OrderBy(b => b.Category.ToString()).ToList(),
                "?sort=categorydesc" => Book.OrderByDescending(b => b.Category.ToString()).ToList(),
                _ => Book.OrderBy(b => b.Title).ToList()
            };
        }
    }
}
