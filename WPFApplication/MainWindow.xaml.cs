﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApplication.ViewModel;
using WPFApplication.Views;

namespace WPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl uc;
        public MainWindow()
        {
            InitializeComponent();
            uc = new UserControl();
            
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            
            uc = new Import();
            MainView.Children.Clear();
            MainView.Children.Add(uc);
            uc.Visibility = Visibility.Visible;

        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            uc = new Upload();
            MainView.Children.Clear();
            MainView.Children.Add(uc);
            uc.Visibility = Visibility.Visible;

        }
    }
}
