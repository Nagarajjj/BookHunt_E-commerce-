using DataComponentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComponentLib
{
    public interface IUserModule
    {
        CustomerTable ValidateUser(string email, string password);

        void RegisterUser(CustomerTable customer);

        void UpdateUserDetails(string address, string telephone, int cstId);

        List<OrderTable> GetAllOrders(int cstId);
    }

    public interface IOrderModule
    {
        void CreateNewOrder(OrderTable record);

        //void UpdateOrderDetail(int noOfItems, double totalAmount, int orderId);
        void UpdateOrderDetail(int orderId);
    }

    public class UserComponent : IUserModule
    {
        public List<OrderTable> GetAllOrders(int cstId)
        {
            throw new NotImplementedException();
        }
        private bool isCustomerNotAvailable(string emailAddress)
        {
            //get the customer with matching email address
            var contxt = new BookHuntEntities();
            var cst = contxt.CustomerTables.FirstOrDefault((c) => c.CustomerEmailId == emailAddress);
            //if not found return true, else return false. 
            return cst == null;
        }
        public void RegisterUser(CustomerTable customer)
        {
            var context = new BookHuntEntities();
            if (isCustomerNotAvailable(customer.CustomerEmailId))
                context.CustomerTables.Add(customer);
            else
                throw new CustomerAlreadyExistsException("This Email Address is already available");
            context.SaveChanges();
        }

        public void UpdateUserDetails(string address, string telephone, int cstId)
        {
            var context = new BookHuntEntities();
            var cst = context.CustomerTables.FirstOrDefault((c) => c.CustomerId == cstId);
            if (cst == null)
                throw new Exception("Customer does not exist");
            cst.CustomerEmailId = address;
            cst.CustomerPhNo = telephone;
            context.SaveChanges();
        }

        public CustomerTable ValidateUser(string email, string password)
        {
            var context = new BookHuntEntities();
            var rec = context.CustomerTables.Where((c) => c.CustomerEmailId == email && c.CustomerPassword == password).SingleOrDefault();
            return rec;
        }
    }

    public class OrderComponent : IOrderModule
    {
        public void CreateNewOrder(OrderTable record)
        {
            var context = new BookHuntEntities();
            context.OrderTables.Add(record);
            context.SaveChanges();
        }

        public void UpdateOrderDetail(int orderId)
        {
            var context = new BookHuntEntities();
            var order = context.OrderTables.FirstOrDefault((c) => c.OrderId == orderId);
            if (order == null)
                throw new Exception("Order does not exist");
            order.NoOfItems = (short)order.OrderDetails.ToList().Count;
            order.OrderAmount = order.OrderDetails.Sum((e) => e.BookTable.BookPrice * 1);
            context.SaveChanges();
        }
    }

    public class CartComponent
    {
        public CustomerTable Customer { get; set; }

        private List<BookTable> CartItems = new List<BookTable>();

        public void AddToCart(BookTable item) => CartItems.Add(item);

        private int getCurrentOrderId()
        {
            var context = new BookHuntEntities();
            short orderId = context.OrderTables.Max((o) => o.OrderId);
            return orderId;
        }

        private void addToBillDetail(List<OrderDetail> items)
        {
            var context = new BookHuntEntities();
            context.OrderDetails.AddRange(items);
            context.SaveChanges();
        }
        public void GenerateBill()
        {
            var context = new BookHuntEntities();

            OrderComponent com = new OrderComponent();
            //Create the order
            OrderTable order = new OrderTable();
            if (Customer == null)
            {
                throw new Exception("Login First before U order the products");
            }
            order.CustomerId = Customer.CustomerId;
            order.OrderDate = DateTime.Now;
            com.CreateNewOrder(order);
            //Get the OrderId of this order:
            var currentOrderId = getCurrentOrderId();
            List<OrderDetail> billingDetails = new List<OrderDetail>();
            foreach (var item in CartItems)
            {
                var billDetail = new OrderDetail
                {
                    OrderId = (short)currentOrderId,
                    BookId = item.BookId
                };
                billingDetails.Add(billDetail);
            }
            addToBillDetail(billingDetails);
            com.UpdateOrderDetail(currentOrderId);
        }
    }
    public class CustomerAlreadyExistsException : Exception
    {
        public CustomerAlreadyExistsException()
        {
        }

        public CustomerAlreadyExistsException(string message) : base(message)
        {
        }

        public CustomerAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
