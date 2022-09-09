using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Entity.Concrete
{
    //Addition of category, filling the blank messages
    [Table("IncomeExpenses")]
    public class IncomeExpense
    {
        [Key]
        [Display(Name="ID")]
        [Required(ErrorMessage ="This Area Isn't Blank")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public string Name { get; set; }

        [Display(Name="Explanation")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public string Explanation { get; set; }

        [Display(Name="Price")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public float Price { get; set; }

        [Display(Name="Price")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public float AveragePrice { get; set; }

        [Display(Name="IsIncome")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public bool IsIncome { get; set; }

        [Display(Name="IsExpense")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public bool IsExpense { get; set; }

        [Display(Name="IsOneTime")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public bool IsOneTime { get; set; }

        [Display(Name = "Image Path")]
        [Required(ErrorMessage = "This Area Isn't Blank")]
        public string ImagePath { get; set; }
    }
}
