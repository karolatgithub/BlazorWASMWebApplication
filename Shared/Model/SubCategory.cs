﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASMWebApplication.Shared.Model
{

    public class SubCategory
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
