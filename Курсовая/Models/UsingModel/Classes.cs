using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Курсовая.Models.UsingModel
{
	/// <summary>
	/// Классы.
	/// </summary>
	[Table("Classes")]
	public class Classes
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// Наименование класса.
		/// </summary>
		[Column("ClassName")]
		public string ClassName { get; set; }
		/// <summary>
		/// За одного учащегося.
		/// </summary>
		[Column("PerStudent")]
		public decimal PerStudent { get; set; }
	}
}
