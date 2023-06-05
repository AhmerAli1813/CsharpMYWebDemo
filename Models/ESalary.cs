namespace AhmerMYWebDemo.Models
{
	public class ESalary
	{
		public enum Month
		{
			jan,feb,mar,apr,may,jun,jul,aug,sep,december,
		}
		public int Id { get; set; }
		public Month EMonth { get; set; }
		public DateTime Edate { get; set; }
		public float EAmount { get; set; }
		public Employees Employees { get; set; }
		public int EmployeesId { get; set; }
}
}
