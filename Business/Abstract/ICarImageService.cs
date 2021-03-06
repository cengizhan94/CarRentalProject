    using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImageByCarId(int carId);
        IDataResult<CarImage> GetByImageId(int imageId);
    }
}
