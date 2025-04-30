using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using StoreDB.Service;
using System.Threading.Tasks;
using ClickerApp.ViewModels.Base;
using StoreDB.ContextDB;

namespace DataMenegment.ViewModelPage
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly SQLServerDBContext _context = new();
        private Product _selectedProduct;
        private string _searchTerm;

        public ProductsPageViewModel()
        {
            // Инициализация коллекции товаров
            Products = new ObservableCollection<Product>(_context.Products.ToList());

            // Инициализация команд
            AddProductCommand = new RelayCommand(_ => AddProduct());
            EditProductCommand = new RelayCommand(_ => EditProduct(), _ => SelectedProduct != null);
            DeleteProductCommand = new RelayCommand(_ => DeleteProduct(), _ => SelectedProduct != null);

            // Команда для поиска товара
            SearchProductCommand = new RelayCommand(_ => SearchProduct());
        }

        // Свойства для привязки
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
            }
        }

        // Команды для действий с товарами
        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand SearchProductCommand { get; }

        // Метод для добавления нового товара
        private void AddProduct()
        {
            // Создаем новый объект товара
            var newProduct = new Product();

            // Открываем окно для ввода данных нового товара
            var addProductWindow = new AddProductWindow(newProduct);

            // Обработчик, который сработает при закрытии окна
            addProductWindow.ProductAdded += (sender, e) =>
            {
                // Если товар добавлен, обновляем коллекцию товаров
                _context.Products.Add(newProduct);
                _context.SaveChanges();

                Products.Add(newProduct);  // Добавляем новый товар в коллекцию для UI
            };

            // Показываем окно
            addProductWindow.ShowDialog();
        }

        // Метод для редактирования выбранного товара
        private void EditProduct()
        {

            if (SelectedProduct == null) return;  // Если товар не выбран, ничего не делаем

            // Создаем копию выбранного товара для редактирования
            var productToEdit = new Product
            {
                ProductID = SelectedProduct.ProductID,
                Name = SelectedProduct.Name,
                CategoryID = SelectedProduct.CategoryID,
                MaterialID = SelectedProduct.MaterialID,
                StoneID = SelectedProduct.StoneID,
                Weight = SelectedProduct.Weight,
                Price = SelectedProduct.Price,
                InStock = SelectedProduct.InStock
            };

            // Открываем окно для редактирования товара
            var editProductWindow = new EditProductWindow(productToEdit);

            // Обработчик, который сработает при сохранении изменений
            editProductWindow.ProductEdited += (sender, e) =>
            {
                // Если товар изменен, обновляем данные в базе
                _context.Entry(productToEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                // Обновляем товар в коллекции
                var index = Products.IndexOf(SelectedProduct);
                Products[index] = productToEdit;  // Обновляем товар в коллекции UI
            };

            // Показываем окно
            editProductWindow.ShowDialog();
        }

        // Метод для удаления товара
        private void DeleteProduct()
        {
            if (SelectedProduct == null) return;

            _context.Products.Remove(SelectedProduct);
            _context.SaveChanges();

            // Обновляем коллекцию товаров
            Products.Remove(SelectedProduct);
            SelectedProduct = null;
        }

        // Метод для поиска товаров по имени
        private void SearchProduct()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                Products = new ObservableCollection<Product>(_context.Products.ToList());
            }
            else
            {
                var searchResults = _context.Products
                    .Where(p => p.Name.Contains(SearchTerm))
                    .ToList();

                Products = new ObservableCollection<Product>(searchResults);
            }
            OnPropertyChanged(nameof(Products));
        }
    }
}