using tutorial6.Models;
using tutorial6.Repos;

namespace tutorial6.Services;

public class ProductWarehouseService : IProductWarehouseService
{
    private readonly IProductWarehouseRepository _productWarehouseRepository;

    public int CreateProductWarehouse(ProductWarehouse _productWarehouse)
    {
        return _productWarehouseRepository.CreateProductWarehouse(_productWarehouse);
    }
}