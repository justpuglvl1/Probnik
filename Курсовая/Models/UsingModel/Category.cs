using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Курсовая.Models.UsingModel
{
	/// <summary>
	/// Категории.
	/// </summary>
	[Table("Category")]
	public class Category
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// Наименование должности.
		/// </summary>
		[Column("CategoryName")]
		public string CategoryName { get; set; }
		/// <summary>
		/// Множитель.
		/// </summary>
		[Column("CategoryBet")]
		public decimal CategoryBet { get; set; }
	}
}
