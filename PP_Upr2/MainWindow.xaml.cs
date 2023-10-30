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

namespace PP_Upr2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string idInput = textBoxsmt.Text;
            List<string> listId = new List<string>();
            listId = idInput.Split(' ').ToList();

            CustomerCollection customerCollection = new CustomerCollection();
            //Task task = new Task(customerCollection.FindCustomersByIDs(list));
            List<Customer> customers = await customerCollection.FindCustomersByIDs(listId);

            foreach (var customer in customers)
            {
                //listBoxSmt.ItemsSource.Cast<Customer>().ToList().Add(customer);
                listBoxSmt.Items.Add(customer.Name + "   " + customer.Id + "   " + customer.Address + "   " + customer.NumberOfOrders.ToString());
            }
        }
    }
}
