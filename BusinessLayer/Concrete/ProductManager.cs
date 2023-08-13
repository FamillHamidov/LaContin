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
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void Add(Product t)
		{
			_productDal.Insert(t);
		}

		public void Delete(Product t)
		{
			_productDal.Delete(t);
		}

		public List<Product> GetAll()
		{
			return _productDal.GetAll();
		}

		public Product GetById(int id)
		{
			return _productDal.GetById(id);
		}

		public void Update(Product t)
		{
			_productDal.Update(t);
		}
	}
}
