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
	public class AdminManager : IAdminService
	{
		private readonly IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}
		public void Add(Login t)
		{
			_adminDal.Insert(t);
		}
		public void Delete(Login t)
		{
			_adminDal.Delete(t);
		}
		public void Update(Login t)
		{
			_adminDal.Update(t);
		}

		public List<Login> GetAll()
		{
			return _adminDal.GetAll();
		}

		public Login GetById(int id)
		{
			return _adminDal.GetById(id);
		}
	}
}
