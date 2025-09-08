using CsvHelper.Configuration.Attributes;

namespace ShopForHome.Api.Models.Dto
{
    public class ProductCsvDto
    {
        [Name("Name")]
        public string? Name { get; set; }


        [Name("Price")]
        public decimal Price { get; set; }

        [Name("Category")]
        public string? Category { get; set; }

        [Name("Stock")]
        public int Stock { get; set; }
    }
}
