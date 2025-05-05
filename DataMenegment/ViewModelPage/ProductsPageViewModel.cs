using ClickerApp.ViewModels.Base;
using DataMenegment.ViewModel;
using StoreDB.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataMenegment.ViewModelPage
{
    public class ProductsPageViewModel : BaseViewModel
    {
        private readonly IProductService _productService;

        public ObservableCollection<Product> Products { get; set; }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public ICommand LoadProductsCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand AddToFavoritesCommand { get; }

        public ProductsPageViewModel(IProductService productService)
        {
            _productService = productService;
            Products = new ObservableCollection<Product>();

            LoadProductsCommand = new RelayCommand(LoadProducts);
            AddToCartCommand = new RelayCommand<Product>(AddToCart);
            AddToFavoritesCommand = new RelayCommand<Product>(AddToFavorites);

            LoadProducts();
        }

        private void LoadProducts()
        {
            Products.Clear();
            var items = _productService.GetAllProducts();
            foreach (var item in items)
                Products.Add(item);
        }

        private void AddToCart(Product product)
        {
            CartService.Instance.Add(product);
        }

        private void AddToFavorites(Product product)
        {
            FavoritesService.Instance.Add(product);
        }
    }
}
