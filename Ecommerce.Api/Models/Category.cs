namespace Ecommerce.Api.Models;

public class Category
{
    public int id {get; set;}
    public string Name {get; set;} = string.Empty;

    public string Slug {get; set;} = string.Empty;

    public List<Product> products {get;set;} = new();
}