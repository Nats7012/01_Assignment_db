using _01_Assigment.Models;
using _01_Assigment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace _01_Assigment
{
    public partial class MainWindow : Window
    {
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;

        public MainWindow(CustomerService customerService, OrderService orderService, ProductService productService)
        {
            InitializeComponent();
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
            PopulateCustomerService().ConfigureAwait(false);
        }
        private async void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var productRequest = new ProductRequest
                {
                    Name = tb_productName.Text,
                    Description = tb_description.Text,
                    Price = decimal.Parse(tb_productPrice.Text)
                };

                var result = await _productService.CreateAsync(productRequest);
                if (result is OkResult)
                    cb_products.SelectedIndex = -1;
                tb_productName.Text = "";
                tb_description.Text = "";
                tb_productPrice.Text = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task PopulateCustomerService()
        {
            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (var item in await _customerService.GetAllAsync())
                collection.Add(new KeyValuePair<string, int>(item.FullName, item.Id));
            cb_products.ItemsSource = collection;
        }

        private async void btn_Save_Order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = (KeyValuePair<int, string>)cb_customers.SelectedItem;
                var customerId = customer.Key;
                var orderRequest = new OrderRequest
                {
                    CustomerId = customerId,
                };

                var result = await _orderService.CreateOrderAsync(orderRequest);

                if (result is OkResult)
                {
                    cb_customers.SelectedItem = null!;
                    cb_products.SelectedItem = null!;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

        }
    }
}
