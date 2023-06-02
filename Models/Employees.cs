using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmerMYWebDemo.Models
{
	[Table("TblEmployee")] // this is used for ... if your table name is change in DB so given name here in [Table] in DataAnnotations
	public class Employees
	{

	//	public int Id { get; set; } And public int EId { get; set; } if  u are taken this type name u doen't need to given this ( [key]) 
	// b/c the complier auto genrated key of enitity  which u given in class name , class name have same of enitity of your database

		[Key]
		//[Required] // this validaton is used to required cloumn Means you can't empty this column in Database
		public int E_Id { get; set; }

		[Required]
		// [StringLength(50)]  And 	[MaxLenght(50)]  IN  this validation is same as minar deffrence .... ap in do mein sa
		// sirf ak ko used QK bhai wo Database mein same type da ga nVarchar(50) hi da ga Ok
		[StringLength(50)]
		public string? E_Name { get; set; }
		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)] // this is used for validation Email Address
		public string? E_Email { get; set; }


		[Required]
		[MaxLength(20 , ErrorMessage = " you leght id icrease")  , MinLength(5 , ErrorMessage = " you leght id deicrease")]
		[DataType(DataType.Password)]


		public string? E_Password { get; set;}

		[Required]
		[StringLength(250)]
		public string? E_Address { get; set; }
		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		[Compare("E_Password")] // this is used of compare two colmun  on front base
		public string? E_ConfirmPassword { get; set; }

		
	}
}
