namespace StockApi.Request
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Color { get; set; }

        public int Size { get; set; }
    }
}
