﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace Курсовая
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow window = new MainWindow();
			window.Show();
		}
	}

}
