﻿using BookStoreProject.Models.Attributes;
using BookStoreProject.Models.ORM.Context;
using BookStoreProject.Models.ORM.Entities;
using BookStoreProject.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreProject.Controllers
{
    [SiteAuth]
    public class SiteBookController : SiteBaseController
    {

        private readonly BookContext _bookcontext;
        public SiteBookController(BookContext bookcontext) : base(bookcontext)
        {
            _bookcontext = bookcontext;
        }


        public IActionResult Index()
        {

            List<BookVM> model = _bookcontext.Books.Include(q => q.BookCategories).ThenInclude(BookCategories => BookCategories.Category).Include(q => q.BookPersons).ThenInclude(BookPerson => BookPerson.Person).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Select(q => new BookVM()
            {
                BookID = q.ID,
                Name = q.Name,
                PublishDate = q.PublishDate,
                Publisher = q.Publisher,
                Edition = q.Edition,
                Imagepath=q.Imagepath,
                BookPersons = q.BookPersons.Where(q => q.IsDeleted == false).ToList()

            }).ToList();

            return View(model);
        }

        
       
        public IActionResult BookDetail(int id)
        {
            Book book = _bookcontext.Books.Include(q => q.BookCategories).ThenInclude(BookCategories => BookCategories.Category).Include(q => q.BookPersons).ThenInclude(BookPersons => BookPersons.Person).Include(q=>q.Comments).ThenInclude(Comments=>Comments.User).Include(q=>q.UserPoints).ThenInclude(UserPoints => UserPoints.USer).FirstOrDefault(q => q.ID == id);

            BookVM model = new BookVM();
            model.Name = book.Name;
            model.PublishDate = book.PublishDate;
            model.Publisher = book.Publisher;
            model.Edition = book.Edition;
            model.Imagepath = book.Imagepath;
            model.BookCategories = book.BookCategories.Where(q => q.IsDeleted == false).ToList();
            model.BookPersons = book.BookPersons.Where(q => q.IsDeleted == false).ToList();
            model.Comments = book.Comments.Where(q => q.IsDeleted == false).ToList();
            model.UserPoints = book.UserPoints.Where(q => q.IsDeleted == false).ToList();

            return View(model);
        }

    }
}