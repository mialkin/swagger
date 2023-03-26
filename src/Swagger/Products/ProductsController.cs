using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Swagger.Products;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("List")]
    public IActionResult List()
    {
        var products = new List<Product>
        {
            new(new Guid("8036e42f-258f-4461-ac82-0664934fb8f8"), "Soap"),
            new(new Guid("6aef02a1-c60a-4bd1-9f4d-c43c3d911f9b"), "Tooth paste")
        };

        return Ok(products);
    }
}