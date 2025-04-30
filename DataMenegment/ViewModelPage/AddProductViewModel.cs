using ClickerApp.ViewModels.Base;
using StoreDB.ContextDB;
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
    public class AddProductViewModel : ViewModelBase
    {
        private readonly SQLServerDBContext _context = new SQLServerDBContext();

        public AddProductViewModel()
        {
            Categories = new ObservableCollection<Category>(_context.Categories.ToList());
            Materials = new ObservableCollection<Material>(_context.Materials.ToList());
            Stones = new ObservableCollection<Stone>(_context.Stones.ToList());

            AddProductCommand = new RelayCommand(_ => AddProduct(), _ => CanAddProduct());
        }

        // Свойства для привязки
        public string Name { get; set; }
        public Category SelectedCategory { get; set; }
        public Material SelectedMaterial { get; set; }
        public Stone SelectedStone { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        // Коллекции для ComboBox
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Material> Materials { get; set; }
        public ObservableCollection<Stone> Stones { get; set; }

        public ICommand AddProductCommand { get; }

        public string StatusMessage { get; set; }

        private bool CanAddProduct()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   SelectedCategory != null &&
                   SelectedMaterial != null &&
                   Weight > 0 &&
                   Price > 0 &&
                   InStock >= 0;
        }

        private void AddProduct()
        {
            var product = new Product
            {
                Name = Name,
                CategoryID = SelectedCategory.CategoryID,
                MaterialID = SelectedMaterial.MaterialID,
                StoneID = SelectedStone?.StoneID,
                Weight = Weight,
                Price = Price,
                InStock = InStock
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            StatusMessage = "Товар успешно добавлен!";
            OnPropertyChanged(nameof(StatusMessage));
        }
    }
}
