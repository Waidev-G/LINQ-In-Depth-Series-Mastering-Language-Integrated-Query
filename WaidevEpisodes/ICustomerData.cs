
namespace WaidevEpisodes
{
    public interface ICustomerData
    {
        List<Customer> getCusttomer();
        void Print(IEnumerable<Customer> filteredList);
    }
}