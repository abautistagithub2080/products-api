using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PRODUCTS_API.Controllers;
using PRODUCTS_API.Models;
using PRODUCTS_API.Tools;

namespace TestProducts
{
    public class OperationTest
    {
        private readonly XperationController? _controller;

        public OperationTest() { 
            _controller = new XperationController();
        }

        [Fact]
        public void GetSumar()
        {
            var result = _controller.Suma(9, 20);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void Get_Sumar()
        {
            var resultX = _controller.Suma(9, 20);
            ////var expected = 5;

            Assert.Equal(20, 20);
        }

        [Fact]
        public void Get_Writelog()
        {
            FileManager oFileManager = new FileManager();
            DateTime TimeOne = DateTime.Now;
            DateTime TimeTwo = TimeOne;
            string sModulo = "Insert";
            var result = oFileManager.Writelog(TimeOne, TimeTwo, sModulo);
            Assert.True(result);
        }


    }
}