namespace Flight_client_server.Models
{
    public class BatchDataResult<T>
        where T : class
    {
        public IEnumerable<T> Data { get; set; }

        public int Total { get; set; }
    }
}
