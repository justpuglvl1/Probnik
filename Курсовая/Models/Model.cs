using Microsoft.Win32;
using OfficeOpenXml;
using System.IO;
using System.Windows;
using Курсовая.Data;
using Курсовая.Models.UsingModel;

namespace Курсовая.Models
{
	public class Model 
	{
		public ApplicationContext context { get; set; }

		public Model(ApplicationContext _context)
		{
			context = _context;
		}

		public Model() { }

		public void DeleteGeneral(General general)
		{
			context.Generals.Remove(general);
			context.SaveChanges();
		}

		public void EditGeneral(General general)
		{
			context.Generals.Update(general);
			context.SaveChanges();
		}

		public List<General> GetGenerals()
		{
			return context.Generals.ToList();
		}

		public void GetSalary(General general)
		{
			general.Salary = CalculateSalary(general);

			context.Generals.Add(general);
			context.SaveChanges();
		}


		public void EditSalary(General general)
		{
			general.Salary = CalculateSalary(general);

			context.Generals.Update(general);
			context.SaveChanges();
		}

		decimal CalculateSalary(General general)
		{
			decimal mainCategory = Convert.ToDecimal(context.Categorys.Where(x => x.CategoryName == general.Category).Select(x => x.CategoryBet).FirstOrDefault());
			decimal mainAcademicDegrees = Convert.ToDecimal(context.AcademicDegrees.Where(x => x.Name == general.Academic).Select(x => x.Bet).FirstOrDefault());
			decimal classes = Convert.ToDecimal(context.Classes.Where(x => x.ClassName == general.Class).Select(x => x.PerStudent).FirstOrDefault());
			decimal mainSalary = Convert.ToDecimal(context.Salarys.Where(x => x.Name == general.Post).Select(x => x.Bet).FirstOrDefault());
			decimal exp = Convert.ToDecimal(context.AdditionalPayments.Where(x => x.Min >= general.Experience && x.Max <= general.Experience).Select(x => x.Bet).FirstOrDefault());

			decimal salary = mainSalary *
							 mainCategory *
							 mainAcademicDegrees;

			decimal experience = mainSalary * exp - mainSalary;

			decimal hour = mainSalary * mainCategory * mainAcademicDegrees * (general.TeachingLoad + general.TeachingLoadOVZ * 1.2m) / 18m;

			decimal activitie = Convert.ToDecimal(general.Activitie) / 18m * 10100m;

			decimal payClasses = classes * general.TeachingLoad + general.TeachingLoadOVZ * 200m;

			return salary + experience + hour + activitie + payClasses;
		}

		public List<string> GetPost()
		{
			return (List<string>)context.Salarys.Select(x => x.Name).ToList();
		}
		public List<string> GetCategory()
		{
			return (List<string>)context.Categorys.Select(x => x.CategoryName).ToList();
		}
		public List<string> GetClass()
		{
			return (List<string>)context.Classes.Select(x => x.ClassName).ToList();
		}

		public void ChartChek(General meters)
		{
			try
			{
				var excel = Generate(meters);
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "Эксель файл (.xlsx)|.xlsx";

				if (saveFileDialog.ShowDialog() == true)
					File.WriteAllBytes(saveFileDialog.FileName, excel);

				MessageBox.Show("Файл сохранен");
			}
			catch
			{
				MessageBox.Show("Закройте файл");
			}
		}

		public byte[] Generate(General meters)
		{
			decimal mainCategory = Convert.ToDecimal(context.Categorys.Where(x => x.CategoryName == meters.Category).Select(x => x.CategoryBet).FirstOrDefault());
			decimal mainAcademicDegrees = Convert.ToDecimal(context.AcademicDegrees.Where(x => x.Name == meters.Academic).Select(x => x.Bet).FirstOrDefault());
			decimal classes = Convert.ToDecimal(context.Classes.Where(x => x.ClassName == meters.Class).Select(x => x.PerStudent).FirstOrDefault());
			decimal mainSalary = Convert.ToDecimal(context.Salarys.Where(x => x.Name == meters.Post).Select(x => x.Bet).FirstOrDefault());
			int exp = Convert.ToInt32(context.AdditionalPayments.Where(x => x.Min >= meters.Experience && x.Max <= meters.Experience).Select(x => x.Bet).FirstOrDefault());

			decimal salary = mainSalary *
							 mainCategory *
							 mainAcademicDegrees;

			decimal experience = mainSalary * exp - mainSalary;

			decimal hour = mainSalary * mainCategory * mainAcademicDegrees * (Convert.ToDecimal(meters.TeachingLoad) + Convert.ToDecimal(meters.TeachingLoadOVZ) * 1.2m) / 18m;

			decimal chek = Convert.ToDecimal(meters.Activitie) / 18m;

            decimal activitie = chek * 10100m;

			decimal payClasses = classes * meters.TeachingLoad + meters.TeachingLoadOVZ * 200m;

			var package = new ExcelPackage();
			var worksheet = package.Workbook.Worksheets
				.Add("МБ-2");
			worksheet.Cells[2, 2, 2, 8].Merge = true;
			worksheet.Cells[2, 2, 2, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
			worksheet.Cells[2, 2].Value = "Муниципальное автономное общеобразовательное учреждение";

			worksheet.Cells[3, 2, 3, 8].Merge = true;
			worksheet.Cells[3, 2, 3, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
			worksheet.Cells[3, 2].Value = "«Средняя общеобразовательная школа № ___»";

			worksheet.Cells[4, 2, 4, 8].Merge = true;
			worksheet.Cells[4, 2, 4, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
			worksheet.Cells[4, 2].Value = "Городской округ Первоуральск";

			worksheet.Cells[6, 2, 6, 8].Merge = true;
			worksheet.Cells[6, 2, 6, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
			worksheet.Cells[6, 2].Value = "ПРИКАЗ";

			worksheet.Cells[7, 2].Value = DateTime.Now.ToString("dd.MM.yyyy");
			worksheet.Cells[7, 8].Value = "№___";

			worksheet.Cells[9, 2, 9, 8].Merge = true;
			worksheet.Cells[9, 2, 9, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
			worksheet.Cells[9, 2].Value = "Об оплате труда в " + $"{DateTime.Now.Year - 1}" + $" - {DateTime.Now.Year}" + "учебном году";

			worksheet.Cells[10, 2, 10, 8].Merge = true;
			worksheet.Cells[10, 2, 10, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
			worksheet.Cells[10, 2].Value = $"учителю {meters.FullName}";

			worksheet.Cells[12, 2, 16, 8].Merge = true;
			worksheet.Cells[12, 2, 16, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[12, 2, 16, 8].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
			worksheet.Cells[12, 2, 16, 8].Style.WrapText = true;
			worksheet.Cells[12, 2].Value = "\tВ соответствии с учебным планом МАОУ СОШ № __ на" + $"{DateTime.Now.Year - 1 }" + $"- {DateTime.Now.Year}" + $" учебный год, утвержденного приказом от {DateTime.Now.ToString("dd.MM.yyyy")}г. " +
										   "№ 192 «Об утверждении учебного плана на " + $"{DateTime.Now.Year - 1}" + $"- {DateTime.Now.Year}" + $" учебный год, в связи с началом учебного года, письменным согласием с дополнительным " +
										   $"соглашением с работником от {DateTime.Now.ToString("dd.MM.yyyy")}г.";

			worksheet.Cells[18, 2, 18, 8].Merge = true;
			worksheet.Cells[18, 2, 18, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
			worksheet.Cells[18, 2].Value = $"ПРИКАЗЫВАЮ:";

			worksheet.Cells[19, 2, 21, 8].Merge = true;
			worksheet.Cells[19, 2, 21, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[19, 2, 21, 8].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
			worksheet.Cells[19, 2, 21, 8].Style.WrapText = true;
			worksheet.Cells[19, 2].Value = $"1.\tНа основании Положения об оплату труда работников МАОУ СОШ № ___, утвержденного приказом от {DateTime.Now.ToString("dd.MM.yyyy")}г. № 202 установить {meters.FullName} следующие выплаты: ";

			worksheet.Cells[22, 3, 22, 8].Merge = true;
			worksheet.Cells[22, 3, 22, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[22, 3].Value = $"Установленный оклад {Decimal.Round(mainSalary, 2)}";

			worksheet.Cells[23, 3, 23, 8].Merge = true;
			worksheet.Cells[23, 3, 23, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[23, 3].Value = $"За стаж {Decimal.Round(experience, 2)}";

			worksheet.Cells[24, 3, 24, 8].Merge = true;
			worksheet.Cells[24, 3, 24, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[24, 3].Value = $"За часы педагогической нагрузки {decimal.Round(hour, 2)}";

			worksheet.Cells[25, 3, 25, 8].Merge = true;
			worksheet.Cells[25, 3, 25, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[25, 3].Value = $"За внеурочную деятельность {decimal.Round(activitie, 2)}";

			worksheet.Cells[26, 3, 26, 8].Merge = true;
			worksheet.Cells[26, 3, 26, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[26, 3].Value = $"За классное руководство {Decimal.Round(payClasses, 2)}";

			worksheet.Cells[27, 3, 27, 8].Merge = true;
			worksheet.Cells[27, 3, 27, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[27, 3].Value = $"Иная доплата {Decimal.Round(meters.Surcharges, 2)}";

			worksheet.Cells[29, 2, 30, 8].Merge = true;
			worksheet.Cells[29, 2, 30, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
			worksheet.Cells[29, 2, 30, 8].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
			worksheet.Cells[29, 2, 30, 8].Style.WrapText = true;
			worksheet.Cells[29, 2].Value = $"2.\tРекомендовано бухгалтерии принять к руководству и исполнению настоящий приказ.";

			worksheet.Cells[32, 3].Value = $"Директор";

			return package.GetAsByteArray();
		}
	}
}
