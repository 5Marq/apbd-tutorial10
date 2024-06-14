using tutorial6.Models;

namespace tutorial6.Repos;

public class ProductWarehouseRepository : IProductWarehouseRepository
{
    private readonly IConfiguration _configuration;

    public ProductWarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public int CreateProductWarehouse(ProductWarehouse prouctWarehouse)
    {
        return 0;
    }
}

