using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Products;
using Microsoft.AspNetCore.Hosting;

namespace Web_Store.Application.Services.Products.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddNewProductService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }


        public ResultDto Execute(RequestAddNewProductDto request)
        {
            //age kar kard validation haram bayad biyaram bebinam chetoor bayad estefade konam
            try
            {
                var category = _context.categories.Find(request.CategoryId);
                Product product = new Product()
                {
                    Name = request.Name,
                    Brand = request.Brand,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    Description = request.Description,
                    Category = category,
                    Display= request.Display,
                };
                _context.products.Add(product);

                List<ProductImages> productImages = new List<ProductImages>();
                foreach (var image in request.Images)
                {
                    var UploadedResult=UploadFile(image);
                    productImages.Add(new ProductImages
                    {
                        Product=product,
                        Src= UploadedResult.FileNameAddress
                    });
                }
                _context.productImages.AddRange(productImages);

                List<ProductFeatures> features = new List<ProductFeatures>();
                foreach (var item in request.Features)
                {
                    features.Add(new ProductFeatures
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = product,
                    });
                }
                _context.ProductFeatures.AddRange(features);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به لیست محصولات اضافه شد"
                };
            }
            catch 
            {
                return new ResultDto { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };
                
            }
  

        }



        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

}
