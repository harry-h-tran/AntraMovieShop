using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entity
{
    public class Genre
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(24)")]
        [Required(ErrorMessage = "Genre Name is Required")]
        public string Name { get; set; }
    }
}
