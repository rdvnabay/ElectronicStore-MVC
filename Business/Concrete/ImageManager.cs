using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        #region Dependency Injection
        private IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        #endregion
        public IResult Add(Image image)
        {
            _imageDal.Add(image);
            return new SuccessResult();
        }
    }
}
