using System;
using System.Collections.Generic;
using System.Linq;
using ACM.BL;

namespace ACM.DAL
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private static int _nextId = 1;
        private static readonly List<Customer> _store = new List<Customer>();

        public int Save(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            if (customer.CustomerId == 0)
            {
                customer.CustomerId = _nextId++;
                _store.Add(customer);
            }
            else
            {
                var existing = _store.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                if (existing != null)
                {
                    _store.Remove(existing);
                    _store.Add(customer);
                }
                else
                {
                    _store.Add(customer);
                }
            }
            return customer.CustomerId;
        }

        public Customer GetById(int customerId)
        {
            return _store.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(_store);
        }
    }
}