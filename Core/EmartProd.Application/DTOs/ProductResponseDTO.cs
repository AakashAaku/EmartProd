namespace EmartProd.Application.DTOs
{
    public class ProductResponseDTO
    {
        public string Name { get; set; }
        public string Description {get;set;}
        public decimal Price {get;set;}
        public string ImageUrl {get;set;}
        public string ProductTypes {get;set;}
        public int ProductTypeId {get;set;}
        public string ProductBrands {get;set;}
        public int ProductBrandId {get;set;}
    }
}