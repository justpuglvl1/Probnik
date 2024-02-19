using Microsoft.EntityFrameworkCore.Metadata;
using Курсовая.Data;
using Курсовая.Models;
using Курсовая.Models.UsingModel;

namespace Курсовая.Presenters
{
	/// <summary>
	/// Обработчик.
	/// </summary>
	public class Presenter
	{
		ApplicationContext context = new ApplicationContext();
		Model model;

		public Presenter()
		{
			model = new Model(context);
		}

		public List<General> GetGenerals() 
			=> model.GetGenerals();
		public List<string> GetPost() 
			=> model.GetPost();

		public void GetSalary(General general) 
			=> model.GetSalary(general);
		public void EditSalary(General general) 
			=> model.EditSalary(general);

		public List<string> GetCategory() 
			=> model.GetCategory();

		public List<string> GetClass() 
			=> model.GetClass();

		public void DeleteGeneral(General general) 
			=> model.DeleteGeneral(general);
		public void ChartChek(General general) 
			=> model.ChartChek(general);
	}
}
