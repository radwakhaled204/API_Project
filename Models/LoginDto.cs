﻿using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{

    public class LoginDto
    {
       [Required]
       public string userName { get; set; }

       [Required]
      public string password { get; set; }
    }
}