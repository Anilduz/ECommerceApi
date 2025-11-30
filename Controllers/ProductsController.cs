using ECommerceApi.Dtos;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // POST /products
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductCreateDto dto)
    {
        var product = await _productService.AddProductAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    // GET /products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    // PUT /products/{id}/stock
    [HttpPut("{id}/stock")]
    public async Task<IActionResult> UpdateStock(int id, [FromBody] ProductStockUpdateDto dto)
    {
        await _productService.UpdateProductStockAsync(id, dto);
        return NoContent(); // Başarılı güncelleme için 204
    }

    // Yardımcı method - sadece CreatedAtAction için gerekli
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productService.GetByIdAsync(id); // Repo'dan alabilir veya service'e ekleyebiliriz
        if (product == null) return NotFound();
        return Ok(product);
    }
}