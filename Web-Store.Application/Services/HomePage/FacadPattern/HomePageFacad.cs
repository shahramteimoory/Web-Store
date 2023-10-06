using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.HomePage.Commands.AddNewSlider;
using Web_Store.Application.Services.HomePage.Commands.DeleteSlider;
using Web_Store.Application.Services.HomePage.Queries.GetAllSlider;
using Web_Store.Application.Services.Products.Commands.AddNewProduct;

namespace Web_Store.Application.Services.HomePage.FacadPattern
{
    public class HomePageFacad : IHomePageFacad
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDataBaseContext _context;
        public HomePageFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context= context;
            _environment= environment;
        }
        private AddNewSliderService _AddNewSliderService;
        public AddNewSliderService AddNewSliderService
        {
            get
            {
                return _AddNewSliderService = _AddNewSliderService ?? new AddNewSliderService(_context, _environment);
            }
        }
        private IGetAllSliderService _getAllSliderService;
        public IGetAllSliderService getAllSliderService
        {
            get
            {
                return _getAllSliderService = _getAllSliderService ?? new GetAllSliderService(_context);
            }
        }
        private IDeleteSliderService _deleteSliderService;
        public IDeleteSliderService deleteSliderService
        {
            get
            {
                return _deleteSliderService = _deleteSliderService ?? new DeleteSliderService(_context);
            }
        }
    }
}
