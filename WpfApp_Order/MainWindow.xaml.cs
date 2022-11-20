using Microsoft.EntityFrameworkCore;
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
using WpfApp_Order.Contexts;
using WpfApp_Order.Models;
using WpfApp_Order.Models.Entities;

namespace WpfApp_Order
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataContext _context;
        private List<ProductEntity> productList = new List<ProductEntity>();
        public MainWindow(DataContext context)
        {
            InitializeComponent();
            _context = context;
            PopulateCustomers().ConfigureAwait(false);
            PopulateProducts().ConfigureAwait(false);
        }


        private async Task PopulateCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
        }

        private async Task PopulateProducts()
        {
            var products = await _context.Products.ToListAsync();
        }

        private async void btn_AddProductToList_Click(object sender, RoutedEventArgs e)
        {
            var id = cb_products.SelectedValue;
            var product = await _context.Products.FindAsync(id);
            productList.Add(product);
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            var customer = (KeyValuePair<int, string>)cb_customers.SelectedItem;
            var customerId = customer.Key;
            var customerName = customer.Value;

            var orderRequest = new OrderRequest
            {
                CustomerId = customerId,
                Products = productList
            };
            _context.Add(orderRequest);
            await _context.SaveChangesAsync();
        }
    }
}
