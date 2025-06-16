namespace Swagger.Products;

/// <summary>
/// Product model description
/// </summary>
/// <param name="Id">ID</param>
/// <param name="Name">Name</param>
public record Product(Guid Id, string Name);