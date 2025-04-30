using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace FrontendWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> FilteredProducts { get; set; }

        public ObservableCollection<string> SortOptions { get; } = new ObservableCollection<string> { "По возрастанию", "По убыванию" };
        public ObservableCollection<string> MetalOptions { get; } = new ObservableCollection<string> { "Все", "Золото", "Серебро" };
        public ObservableCollection<string> InsertOptions { get; } = new ObservableCollection<string> { "Все", "Бриллиант", "Изумруд" };

        private string searchKey;
        public string SearchKey
        {
            get => searchKey;
            set
            {
                searchKey = value;
                OnPropertyChanged(nameof(SearchKey));
                FilterProducts();
            }
        }

        public int SelectedPriceOption { get; set; }
        public int SelectedWeightOption { get; set; }
        public int SelectedMetalOption { get; set; }
        public int SelectedInsertOption { get; set; }

        public ICommand ShowAllCommand { get; }
        public ICommand ShowNecklacesCommand { get; }
        public ICommand ShowRingsCommand { get; }
        public ICommand ShowEarringsCommand { get; }
        public ICommand ShowWristwearCommand { get; }
        public ICommand SelectItemToFavoriteCommand { get; }
        public ICommand SelectItemToCartCommand { get; }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
           MainFrame.Navigate(new AddProductPage(MainFrame));
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;


            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Кольцо", Price = 2500, Image = "ring.png", IsInCart = false, IsInFavorites = false, Metal = "Золото", Insert = "Бриллиант" },
                new Product { Name = "Серьги", Price = 1500, Image = "earrings.png", IsInCart = false, IsInFavorites = true, Metal = "Серебро", Insert = "Изумруд" }
            };

            FilteredProducts = new ObservableCollection<Product>(Products);

            ShowAllCommand = new RelayCommand(_ => FilterProducts());
            ShowNecklacesCommand = new RelayCommand(_ => FilterByType("Ожерелье"));
            ShowRingsCommand = new RelayCommand(_ => FilterByType("Кольцо"));
            ShowEarringsCommand = new RelayCommand(_ => FilterByType("Серьги"));
            ShowWristwearCommand = new RelayCommand(_ => FilterByType("Браслет"));

            SelectItemToFavoriteCommand = new RelayCommand(p =>
            {
                if (p is Product prod) prod.IsInFavorites = !prod.IsInFavorites;
                RefreshFiltered();
            });

            SelectItemToCartCommand = new RelayCommand(p =>
            {
                if (p is Product prod) prod.IsInCart = !prod.IsInCart;
                RefreshFiltered();
            });
        }

        private void FilterByType(string type)
        {
            FilteredProducts = new ObservableCollection<Product>(
                Products.Where(p => p.Name.Contains(type, StringComparison.OrdinalIgnoreCase))
            );
            OnPropertyChanged(nameof(FilteredProducts));
        }

        private void FilterProducts()
        {
            var filtered = Products.Where(p =>
                (string.IsNullOrEmpty(SearchKey) || p.Name.Contains(SearchKey, StringComparison.OrdinalIgnoreCase)) &&
                (SelectedMetalOption == 0 || p.Metal == MetalOptions[SelectedMetalOption]) &&
                (SelectedInsertOption == 0 || p.Insert == InsertOptions[SelectedInsertOption])
            ).ToList();

            if (SelectedPriceOption == 1)
                filtered = filtered.OrderByDescending(p => p.Price).ToList();
            else
                filtered = filtered.OrderBy(p => p.Price).ToList();

            FilteredProducts = new ObservableCollection<Product>(filtered);
            OnPropertyChanged(nameof(FilteredProducts));
        }

        private void RefreshFiltered()
        {
            FilteredProducts = new ObservableCollection<Product>(FilteredProducts);
            OnPropertyChanged(nameof(FilteredProducts));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object>? canExecute;

        public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => canExecute == null || canExecute(parameter!);
        public void Execute(object? parameter) => execute(parameter!);
        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }

    public class Product : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Metal { get; set; }
        public string Insert { get; set; }

        private bool isInFavorites;
        public bool IsInFavorites
        {
            get => isInFavorites;
            set { isInFavorites = value; OnPropertyChanged(nameof(IsInFavorites)); }
        }

        private bool isInCart;
        public bool IsInCart
        {
            get => isInCart;
            set { isInCart = value; OnPropertyChanged(nameof(IsInCart)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
