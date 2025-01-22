namespace OrdenesDeinversion.Models.Error
{
    public class Error 
    {
        public int statusCode { get; set; }
        public string? Message { get; set; }
        public string? Detail { get; set; }
    }
}
