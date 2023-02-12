﻿using Artisanale.Web.Models;
using Artisanale.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Artisanale.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
    
        public  async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list= new();

            var response = await _productService.GetAllProductAsync<ResponseDto>();
            if (response != null)
            {
                list=JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));

            }


            return View(list);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {

            var response = await _productService.CreateProductAsync<ResponseDto>(model);
            if (response != null )

            {
                return RedirectToAction(nameof(ProductIndex));
            }


            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int ProductId)
        {

           
            var response = await _productService.GetProductByIdAsync<ResponseDto>(ProductId);
            if (response != null && response.IsSuccess)

            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                return View(model);
            }



            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {


            var response = await _productService.UpdateProductAsync<ResponseDto>(model);
            if (response != null && response.IsSuccess)

            {

                return RedirectToAction(nameof(ProductIndex));
            }



            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int ProductId)
        {


            var response = await _productService.GetProductByIdAsync<ResponseDto>(ProductId);
            if (response != null && response.IsSuccess)

            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                return View(model);
            }



            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto model)
        {


            var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId);
            if (response.IsSuccess)

            {

                return RedirectToAction(nameof(ProductIndex));
            }



            return View(model);
        }

    }
}
