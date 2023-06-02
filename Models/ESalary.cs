namespace AhmerMYWebDemo.Models
{
	public class ESalary
	{
		public int Id { get; set; }
		public string? EMonth { get; set; }
		public DateTime Edate { get; set; }
		public float EAmount { get; set; }
		public Employees Employees { get; set; }
		public int EmployeesId { get; set; }
}
}
