﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductDetailService
    {
        IDataResult<ProductDetail> Add(ProductDetail productDetail);
    }
}
