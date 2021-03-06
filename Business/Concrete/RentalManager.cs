using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            IResult result = BusinessRules.Run(CheckIfForRent(entity.CarId));
            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.SuccessfulInsert);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfulDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p=>p.Id==id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.SuccessfulUpdate);
        }


        public IResult CheckIfForRent(int id)
        {
            var result = _rentalDal.GetAll(p => p.CarId == id);
            if (result.Any())
            {
                if (result.Last().ReturnDate!=null)
                {
                    return new SuccessResult();
                }
                else
                {
                    return new ErrorResult("Bu araba kiralanmış");
                }
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
