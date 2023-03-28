using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Swagger.Products;

[ApiController]
[Route("[controller]")]
[SwaggerTag("Products controller description")]
public class ProductsController : ControllerBase
{
    /// <summary>
    /// List endpoint description
    /// </summary>
    /// <returns>List endpoint return value description</returns>
    [HttpGet("list")]
    [SwaggerOperation("List products")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult List()
    {
        var products = new List<Product>
        {
            new(new Guid("8036e42f-258f-4461-ac82-0664934fb8f8"), "Soap"),
            new(new Guid("6aef02a1-c60a-4bd1-9f4d-c43c3d911f9b"), "Tooth paste")
        };

        return Ok(products);
    }

    /// <summary>
    /// Create endpoint description
    /// </summary>
    /// <param name="dto">DTO description</param>
    /// <returns>Create endpoint return value description</returns>
    [HttpPost("create")]
    [SwaggerOperation("Create product")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create(ProductDto dto)
    {
        return Ok(dto);
    }
    
    /// <summary>
    /// Update endpoint description
    /// </summary>
    /// <param name="description" example="Shower gel">Product description</param>
    /// <param name="price" example="19.99">Price per unit</param>
    /// <returns>Update endpoint return value description</returns>
    [HttpPost("update")]
    [SwaggerOperation("Update product")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update(string description, decimal price)
    {
        return Ok();
    }
}