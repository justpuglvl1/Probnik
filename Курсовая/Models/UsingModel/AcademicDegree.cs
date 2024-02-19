using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Курсовая.Models.UsingModel
{
	/// <summary>
	/// Ученая степень.
	/// </summary>
	[Table("AcademicDegree")]
	public class AcademicDegree
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// Наименование должности.
		/// </summary>
		[Column("Name")]
		public bool Name { get; set; }
		/// <summary>
		/// Множитель.
		/// </summary>
		[Column("Bet")]
		public decimal Bet { get; set; }
	}
}
