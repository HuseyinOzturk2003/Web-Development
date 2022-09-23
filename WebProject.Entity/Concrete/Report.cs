﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Entity.Concrete
{
    //Creating the database table here
    //Table attribute for its name, key for its ID, Display for its look on the display, Required for required data
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] --> Once data is entered to the table, the id value of the table will increase one by one
    //For code first style database


    [Table("Reports")]
    public class Report
    {
        [Key]
        [Display(Name ="ID")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name ="Income Expense Table ID")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public int IncomeExpenseTableID { get; set; }

        [Display(Name ="Count")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public int Count { get; set; }

        [Display(Name ="Total")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public float Total { get; set; }
    }
}
