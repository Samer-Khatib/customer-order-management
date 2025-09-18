using CustomerOrderManagement.Services;
using CustomerOrderManagement.UI;

class Program
{
    static void Main ()
    {
    var service = new OrderService();
    var menu = new Menu(service);
    menu.ShowMenu();
    }
}
