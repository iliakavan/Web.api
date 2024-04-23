using Webapi.Common;
using Webapi.Persistance.Repositories;
using Webapi.services.Dots;

namespace Webapi.services;

public interface IProductService
{
    Task<ResultDto> Add(ProductDto product);
    Task<ResultDto> Update(ProductDto product);
    Task<ResultDto> Delete(ProductDto product);
    ResultDto<Product> Get(int id);
    ResultsDto<Product> GetAll();

}
// Dto Return
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IWareHouseRepository _wareHouseRepository;

    public ProductService(IProductRepository productRepository, IWareHouseRepository wareHouseRepository)
    {
        _productRepository = productRepository;
        _wareHouseRepository = wareHouseRepository;
    }

    public async Task<ResultDto> Add(ProductDto productDto)
    {
        if (productDto == null)
        {
            return new ResultDto{Message = "This Product not valid.", IsSuccessfull = false};
        }
        
        var warehouse = await _wareHouseRepository.Get(productDto.WarehouseId);
        if (warehouse == null)
        {
            return new ResultDto{Message = "This warehouse not Found.", IsSuccessfull = false}; 
        }
        
        var product = new Product() 
        {
            Name = productDto.Name,
            Code = productDto.Code,
            Count = productDto.Inventory,
            Warehouse = warehouse,
            WarehouseId = productDto.WarehouseId,
        };
        _productRepository.Add(product);
        
        return new ResultDto{Message = "This product added.", IsSuccessfull = true};
    }

    public Task<ResultDto> Delete(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public ResultDto<Product> Get(int id)
    {
        throw new NotImplementedException();
    }

    public ResultsDto<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto> Update(ProductDto product)
    {
        throw new NotImplementedException();
    }
}