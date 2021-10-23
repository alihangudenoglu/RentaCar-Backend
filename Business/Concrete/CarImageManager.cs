using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageRestriction(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }


        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageAdded);

        }


        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            
            var rt = ChechIfImageOfCar(id);
            if (BusinessRules.Run(rt) != null)
            {
                return new ErrorDataResult<List<CarImage>>(rt.Message);
            }
            return new SuccessDataResult<List<CarImage>>(rt.Data);


        }



        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        private IResult CheckImageRestriction(int id)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == id).Count;
            if (carImageCount > 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> ChechIfImageOfCar(int id)
        {
            string path = @"\Images\default.png";
            var result = _carImageDal.GetAll(p => p.CarId == id);
            if (!result.Any())
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = id, ImagePath = path, ImageDate = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }

            return new SuccessDataResult<List<CarImage>>(result);
        }
    }
}
