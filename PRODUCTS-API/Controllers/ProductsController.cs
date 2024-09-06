using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRODUCTS_API.Models;
using PRODUCTS_API.Repository;
using PRODUCTS_API.Tools;

namespace PRODUCTS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IFileManager? _fileManager;
        private IRepository? _repository;
        public ProductsController(IFileManager fileManager,IRepository repository)
        {
            _fileManager = fileManager;
            _repository = repository;
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Products oProduct)
        {
            try
            {
                DateTime TimeOne = DateTime.Now; 
                DateTime TimeTwo = TimeOne;                 
                var oResul = _repository.Insert(oProduct.ProductId, oProduct.Name, oProduct.StatusName, oProduct.Stock, oProduct.Description, oProduct.Price, oProduct.Discount, oProduct.FinalPrice );
                TimeTwo = DateTime.Now;
                var oResFileManager = _fileManager.Writelog(TimeOne, TimeTwo, "Insert");
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK Result" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpGet]
        [Route("GetById/{ProductId:int}")]
        public IActionResult GetById(int ProductId)
        {
            try
            {
                DateTime TimeOne = DateTime.Now;
                DateTime TimeTwo = TimeOne;
                var list = _repository.GetById(ProductId);
                TimeTwo = DateTime.Now;
                var oResFileManager = _fileManager.Writelog(TimeOne, TimeTwo, "GetById");
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK Result", listProd = list });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Products oProduct)
        {
            try
            {
                DateTime TimeOne = DateTime.Now;
                DateTime TimeTwo = TimeOne;
                var oResul = _repository.Update(oProduct.ProductId, oProduct.Name, oProduct.StatusName, oProduct.Stock, oProduct.Description, oProduct.Price, oProduct.Discount, oProduct.FinalPrice);
                TimeTwo = DateTime.Now;
                var oResFileManager = _fileManager.Writelog(TimeOne, TimeTwo, "Update");
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK Result" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
    }
}
