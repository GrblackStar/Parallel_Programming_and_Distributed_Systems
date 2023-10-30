using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PP_Upr2
{
    public class CustomerCollection
    {
        public List<Customer> list;

        public CustomerCollection()
        {
            list = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                Customer customer = new Customer();
                customer.Name = "Name" + i.ToString();
                customer.Address = "Address" + i.ToString();
                customer.NumberOfOrders = i + 10;
                customer.Id = "CustomerId->" + i.ToString();
                list.Add(customer);
            }

        }

        public async Task<Customer> FindCustomerById(string id)
        {
            await Task.Delay(200);
            foreach (Customer customer in list)
            {
                //await Task.Delay(200);
                if (customer.Id == id) return customer;
            }

            return null;
        }

        public async Task<List<Customer>> FindCustomersByIDs(List<string> ids)
        {
            List<Customer> customerlist = new List<Customer>();
            List<Task<Customer>> tasks = new List<Task<Customer>>();
            foreach (string id in ids)
            {
                Task task = FindCustomerById(id);
                tasks.Add((Task<Customer>)task);
            }

            await Task.WhenAll(tasks);

            foreach (Task<Customer> task in tasks)
            {
                if (task.Result != null) customerlist.Add(task.Result);
            }

            return customerlist;
        }



    }
}
