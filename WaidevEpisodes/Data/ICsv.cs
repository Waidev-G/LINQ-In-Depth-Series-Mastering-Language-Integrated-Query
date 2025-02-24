namespace WaidevEpisodes.Data
{
    public interface ICsv
    {
        void Create();
        IEnumerable<Customer> Read();
        //void PrintCustomers(IEnumerable<Customer> customers);
    }
}