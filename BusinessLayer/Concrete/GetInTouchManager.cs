using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class GetInTouchManager : IGetInTouchService
	{
		private readonly IGetinTouchDal _getinTouchDal;

		public GetInTouchManager(IGetinTouchDal getinTouchDal)
		{
			_getinTouchDal = getinTouchDal;
		}

		public void Add(GetInTouch t)
		{
			_getinTouchDal.Insert(t);
		}

		public void Delete(GetInTouch t)
		{
			_getinTouchDal.Delete(t);
		}

		public List<GetInTouch> GetAll()
		{
			return _getinTouchDal.GetAll();
		}

		public GetInTouch GetById(int id)
		{
			return _getinTouchDal.GetById(id);
		}

		public void Update(GetInTouch t)
		{
			_getinTouchDal.Update(t);
		}
	}
}
