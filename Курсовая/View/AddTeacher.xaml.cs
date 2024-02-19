using System.Windows;
using Курсовая.Models;
using Курсовая.Models.UsingModel;
using Курсовая.Presenters;
using static System.Net.Mime.MediaTypeNames;

namespace Курсовая.View
{
	/// <summary>
	/// Логика взаимодействия для AddTeacher.xaml
	/// </summary>
	public partial class AddTeacher : Window
	{
		General general = new General();
		Presenter presenter = new Presenter();

		public AddTeacher()
		{
			InitializeComponent();
			cmbDevice1.ItemsSource = presenter.GetPost();
			cmbDevice2.ItemsSource = presenter.GetCategory();
			cmbDevice3.ItemsSource = presenter.GetClass();
		}

		private void cmbDevice_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			general.Post = cmbDevice1.SelectedItem as string;
		}

		private void cmbDevice2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			general.Category = cmbDevice2.SelectedItem as string;
		}

		private void cmbDevice3_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			general.Class = cmbDevice3.SelectedItem as string;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtName.Text) ||
				string.IsNullOrWhiteSpace(txtTeachingLoad.Text)||
				string.IsNullOrWhiteSpace(txtTeachingLoad.Text)||
				string.IsNullOrWhiteSpace(txtActivitie.Text)||
				string.IsNullOrWhiteSpace(txtSurcharges.Text)||
				string.IsNullOrWhiteSpace(txtExperience.Text)||
				string.IsNullOrWhiteSpace((string)cmbDevice2.SelectedItem)||
				string.IsNullOrWhiteSpace((string)cmbDevice1.SelectedItem))
			{

				MessageBox.Show("Пустое поле");
			}
			else
			{
				if(chek2.IsChecked == true)
				{
					if (string.IsNullOrWhiteSpace((string)cmbDevice3.SelectedItem) || string.IsNullOrWhiteSpace(txtChildrensOVZ.Text) || string.IsNullOrWhiteSpace(txtChildrens.Text))
						MessageBox.Show("Пустое поле");
					else 
					{
						general.FullName = txtName.Text;
						general.TeachingLoad = Convert.ToInt32(txtTeachingLoad.Text);
						general.TeachingLoadOVZ = Convert.ToInt32(txtTeachingLoadOVZ.Text);
						general.Activitie = Convert.ToInt32(txtActivitie.Text);
						general.Childrens = Convert.ToInt32(txtChildrens.Text);
						general.ChildrensOVZ = Convert.ToInt32(txtChildrensOVZ.Text);
						general.Surcharges = Convert.ToInt32(txtSurcharges.Text);
						general.Experience = Convert.ToInt32(txtExperience.Text);
						presenter.GetSalary(general);

						MessageBox.Show("Учитель добавлен");
						this.Close();
					}
				}
				else
				{
					general.FullName = txtName.Text;
					general.TeachingLoad = Convert.ToInt32(txtTeachingLoad.Text);
					general.TeachingLoadOVZ = Convert.ToInt32(txtTeachingLoadOVZ.Text);
					general.Activitie = Convert.ToInt32(txtActivitie.Text);
					general.Childrens = 0;
					general.ChildrensOVZ = 0;
					general.Surcharges = Convert.ToInt32(txtSurcharges.Text);
					general.Experience = Convert.ToInt32(txtExperience.Text);
					general.Class = "";
					presenter.GetSalary(general);

					MessageBox.Show("Учитель добавлен");
					this.Close();
				}
			};
		}

		private void chek1_Checked(object sender, RoutedEventArgs e)
		{
			general.Academic = true;
		}

		private void chek1_Unchecked(object sender, RoutedEventArgs e)
		{
			general.Academic = false;
		}

		private void chek2_Checked(object sender, RoutedEventArgs e)
		{
			general.ClasseTeacher = true;
		}

		private void chek2_Unchecked(object sender, RoutedEventArgs e)
		{
			general.ClasseTeacher = false;
		}

	}
}
