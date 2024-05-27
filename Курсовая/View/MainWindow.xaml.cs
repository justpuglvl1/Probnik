using System.Windows;
using Курсовая.Models.UsingModel;
using Курсовая.Presenters;
using Курсовая.View;

namespace Курсовая
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<General> Generals { get; set; }
		General general;
		Presenter presenter = new Presenter();

		public MainWindow()
		{
			InitializeComponent();
			Generals = presenter.GetGenerals();
			dtg.ItemsSource = Generals;
			int source1 = Generals.Where(x => x.Category == "СЗД").Count();
			int source2 = Generals.Where(x => x.Category == "I").Count();
			int source3 = Generals.Where(x => x.Category == "ВКК").Count();

			b1.Text = "СЗД - " + source1;
			b2.Text = "I - " + source2;
			b3.Text = "ВКК - " + source3;
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txt1.Text))
			{
				MessageBox.Show("Пусто");
			}
			else
			{
				List<General> newGenerals = Generals.Where(x => x.FullName == txt1.Text).ToList();
				dtg.ItemsSource = newGenerals;
				dtg.Items.Refresh();
			}
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			AddTeacher add = new AddTeacher();
			add.Show();
		}

		private void dtg_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			try
			{
				general = (General)dtg.SelectedItem;
			}
			catch
			{
				MessageBox.Show("Ошибка");
			}
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			EditTeacher editTeacher = new EditTeacher(general);
			editTeacher.Show();
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			presenter.DeleteGeneral(general);
			Generals = presenter.GetGenerals();
			dtg.ItemsSource = Generals;
			dtg.Items.Refresh(); MessageBox.Show("Учитель удален");
		}

		private void MenuItem_Click_2(object sender, RoutedEventArgs e)
		{
			Generals = presenter.GetGenerals();
			dtg.ItemsSource = Generals;
			dtg.Items.Refresh();
		}

		private void MenuItem_Click_3(object sender, RoutedEventArgs e)
		{
			presenter.ChartChek(general);
		}
	}
}