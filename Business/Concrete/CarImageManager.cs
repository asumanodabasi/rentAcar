using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _ımageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal ımageDal, IFileHelper fileHelper)
        {
            _ımageDal = ımageDal;
            _fileHelper = fileHelper;
        }


        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result !=null)  //businessrules da islem basarili ise null doncek o yuzden nulla esit degilse hata verir.
            {
                return new ErrorResult();
            }
            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _ımageDal.Add(carImage);
            return new SuccessResult("Resim  yüklendi...");
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _ımageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_ımageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if(result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetByDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_ımageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<CarImage> GetByCarImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_ımageDal.Get(i => i.Id == imageId));
        }

        public IResult UpDate(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesPath, PathConstants.ImagesPath);
            _ımageDal.UpDate(carImage);
            return new SuccessResult();
        }
                  //   BUSİNESS RULES   //
        private IDataResult<List<CarImage>> GetByDefaultImage(int carId)
        {
            List<CarImage> ımages = new List<CarImage>();
            ımages.Add(new CarImage { CarId = carId, ImagePath = "Default.jpg",Date=DateTime.Now });
            return new SuccessDataResult<List<CarImage>>(ımages);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _ımageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var result = _ımageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
