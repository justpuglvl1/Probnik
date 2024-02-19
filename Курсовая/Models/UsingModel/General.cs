using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Курсовая.Models.UsingModel
{
	/// <summary>
	/// 
	/// </summary>
	[Table("General")]
	public class General
	{
		/// <summary>
		/// 
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// ФИО.
		/// </summary>
		[Column("FullName")]
		public string FullName { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		[Column("Post")]
		public string Post { get; set; }

		/// <summary>
		/// Категория.
		/// </summary>
		[Column("Category")]
		public string Category { get; set; }

		/// <summary>
		/// Класс.
		/// </summary>
		[Column("Class")]
		public string Class { get; set; }

		/// <summary>
		/// Ученая степень.
		/// </summary>
		[Column("Academic")]
		public bool Academic { get; set; }

		/// <summary>
		/// Педнагрузка.
		/// </summary>
		[Column("TeachingLoad")]
		public int TeachingLoad { get; set; }

		/// <summary>
		/// Педназгрузка ОВЗ.
		/// </summary>
		[Column("TeachingLoadOVZ")]
		public int TeachingLoadOVZ { get; set; }

		/// <summary>
		/// Внеурочная детяельность.
		/// </summary>
		[Column("Activitie")]
		public int Activitie { get; set; }

		/// <summary>
		/// Количество детей в классе.
		/// </summary>
		[Column("Childrens")]
		public int Childrens { get; set; }

		/// <summary>
		/// Количество детей в классе с ОВЗ.
		/// </summary>
		[Column("ChildrensOVZ")]
		public int ChildrensOVZ { get; set; }

		/// <summary>
		/// Классное руководство.
		/// </summary>
		[Column("ClasseTeacher")]
		public bool ClasseTeacher { get; set; }

		/// <summary>
		/// Доплаты.
		/// </summary>
		[Column("Surcharges")]
		public decimal Surcharges { get; set; }

		/// <summary>
		/// Доплаты.
		/// </summary>
		[Column("Salary")]
		public decimal Salary { get; set; }

		/// <summary>
		/// Стаж.
		/// </summary>
		[Column("Experience")]
		public int Experience { get; set; }
	}
}
