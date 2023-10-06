using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Services.HomePage.Commands.AddNewSlider;
using Web_Store.Application.Services.HomePage.Commands.DeleteSlider;
using Web_Store.Application.Services.HomePage.Queries.GetAllSlider;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface IHomePageFacad
    {
        AddNewSliderService AddNewSliderService { get; }
        IGetAllSliderService getAllSliderService {  get; }
        IDeleteSliderService  deleteSliderService { get; }
    }
}
