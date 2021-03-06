﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreProject.Models.ORM.Entities
{
    public class BookGenre:BaseEntity
    {
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }

        public int GenreID { get; set; }
        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }
    }
}
