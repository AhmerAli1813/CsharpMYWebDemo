using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Users
    {

        //	public int Id { get; set; } And public int EId { get; set; } if  u are taken this type name u doesn't need to given this ( [key]) 
        // b/c the complier auto generated key of entity  which u given in class name , class name have same of entity of your database

        [Key]
        //[Required] // this validation is used to required column Means you can't empty this column in Database
        public int U_Id { get; set; }

        [Required]
        // [StringLength(50)]  And 	[MaxLenght(50)]  IN  this validation is same as minar deffrence .... ap in do mein sa
        // sirf ak ko used QK bhai wo Database mein same type da ga nVarchar(50) hi da ga Ok
        [StringLength(50)]
        public string? U_Name { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)] // this is used for validation Email Address
        public string? U_Email { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = " you password length must be greater then 8"), MinLength(5, ErrorMessage = " you password length must be less  then 5")]
        [DataType(DataType.Password)]
        public string? U_Password { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Compare("U_Password")] // this is used of compare two colmun  on front base
        public string? U_ConfirmPassword { get; set; }

    }
}
