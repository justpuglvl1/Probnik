using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Курсовая.Models.UsingModel
{
	/// <summary>
	/// Оклад.
	/// </summary>
	[Table("Salary")]
	public class Salary
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
		public string Name { get; set; }
		/// <summary>
		/// Ставка.
		/// </summary>
		[Column("Bet")]
		public decimal Bet { get; set; }
	}
}
