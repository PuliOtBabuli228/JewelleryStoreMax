﻿using DataMenegment.ViewModel;
using DataMenegment.ViewModelPage;
using System;
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

namespace FrontendWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        Frame Frame { get; set; }

        public ProductsPage(Frame frame)
        {
            InitializeComponent();
            DataContext = new ProductsPageViewModel(new ProductService());
            AddProductViewModel viewModel = new AddProductViewModel();
            this.DataContext = viewModel;
            Frame = frame;
        }
    }
}
