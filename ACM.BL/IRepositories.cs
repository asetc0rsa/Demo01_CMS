using System.Collections.Generic;

namespace ACM.BL
{
    public interface ICustomerRepository
    {
        int Save(Customer customer);
        Customer GetById(int customerId);
        List<Customer> GetAll();
    }

    public interface IProductRepository
    {
        int Save(Product product);
        Product GetById(int productId);
        List<Product> GetAll();
    }

    public interface IOrderRepository
    {
        int Save(Order order);
        Order GetById(int orderId);
        List<Order> GetAll();
    }

    public interface IOrderItemRepository
    {
        int Save(OrderItem orderItem);
        OrderItem GetById(int orderItemId);
        List<OrderItem> GetAll();
    }
}