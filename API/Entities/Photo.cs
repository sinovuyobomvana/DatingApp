﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicID { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}