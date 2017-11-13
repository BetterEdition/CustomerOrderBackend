using CustomerSystemBLL.Services;

namespace CustomerSystemBLL
{
    public interface IBLLFacade
    {
        ICustomerService CustomerService { get; }
        IOrderService OrderService { get; }
        IOrderItemService OrderItemService { get; }
    }
}
