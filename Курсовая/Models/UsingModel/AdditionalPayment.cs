using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Курсовая.Models.UsingModel
{
	/// <summary>
	/// Доплата за стаж.
	/// </summary>
	[Table("AdditionalPayment")]
	public class AdditionalPayment
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// От.
		/// </summary>
		[Column("Min")]
		public int Min { get; set; }
		/// <summary>
		/// До.
		/// </summary>
		[Column("Max")]
		public int Max { get; set; }
		/// <summary>
		/// Ставка.
		/// </summary>
		[Column("Bet")]
		public decimal Bet { get; set; }
	}
}
