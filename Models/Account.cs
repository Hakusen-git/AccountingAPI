﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingAPI.Models
{
    public class Account
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        [Required]
        public string AccountType { get; set; }
        [Required]
        public string AccountLabel { get; set; }
        [Required]
        public int AccountAmount { get; set; }
        [Required]
        public string AccountDate { get; set; }

        [Required]
        public string CustomerID { get; set; }
    }
}
