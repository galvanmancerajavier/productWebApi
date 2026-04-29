using productWebApi.Models.Products;
using productWebApi.Services.Interfaces;

namespace productWebApi.Services
{
    public class ProductService 
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        //Obtener todos los productos
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllAsync();
        }
        //Obtener un producto por su ID
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            return product;
        }

        //Crear el producto
        public async Task AddProductAsync(string nombre, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre del producto no puede estar vacío");
            }
            if (precio < 0)
            {
                throw new Exception("El precio no puede ser negativo");
            }
            if (stock < 0)
            {
                throw new Exception("El stock no puede ser negativo");
            }
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = nombre,
                Price = precio,
                Stock = stock
            };
            await _repository.AddAsync(product);
        }


        //Actualizar el producto
        public async Task UpdateProductAsync(Guid id, string nombre, decimal precio, int stock)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre del producto no puede estar vacío");
            }
            if (precio < 0)
            {
                throw new Exception("El precio no puede ser negativo");
            }
            if (stock < 0)
            {
                throw new Exception("El stock no puede ser negativo");
            }
            product.Name = nombre;
            product.Price = precio;
            product.Stock = stock;
            await _repository.UpdateAsync(product);
        }

        //Eliminar el producto
        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            await _repository.DeleteAsync(id);
        }

        //Disminuir el stock del producto
        public async Task DecreaseStockAsync(Guid id, int cantidad)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            if (cantidad < 0)
            {
                throw new Exception("La cantidad a disminuir no puede ser negativa");
            }
            if (product.Stock < cantidad)
            {
                throw new Exception("No hay suficiente stock para disminuir");
            }
            product.Stock -= cantidad;
            await _repository.UpdateAsync(product);

        }

        public async Task IncreaseStockAsync(Guid id, int cantidad)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            if (cantidad < 0)
            {
                throw new Exception("La cantidad a aumentar no puede ser negativa");
            }
            product.Stock += cantidad;
            await _repository.UpdateAsync(product);
        }
    }
}
