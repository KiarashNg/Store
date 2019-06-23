using Store.Models;
using Store.Services.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Store.Services.Controllers
{
    public class ProductController : ApiController
    {
        private readonly StoreDbContext db = new StoreDbContext();

        //1. Getting All Products
        [HttpGet]
        public IHttpActionResult AllProducts()
        {
            var products = db.Products.AsNoTracking().Select(x => new Product
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Category = x.Category,
                CompanyId = x.CompanyId,
                Company = x.Company,
                ModelName = x.ModelName,
                Description = x.Description
            }).ToList();

            return Ok(products);
        }

        //2. Getting One Product with it's Id
        [ResponseType(typeof(Product))]
        [HttpGet]
        public IHttpActionResult ProductWithId([FromUri] int id)
        {
            var product = db.Products.Where(x => x.Id == id).Select(x => new Product
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Category = x.Category,
                CompanyId = x.CompanyId,
                Company = x.Company,
                ModelName = x.ModelName,
                Description = x.Description
            }).SingleOrDefault();

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //3. Creating and Saving a Product
        [ResponseType(typeof(Product))]
        [HttpPost]
        public IHttpActionResult CreateProduct([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return Ok("The Product was Created Successfully!");
        }

        //4. Getting All Countries
        [HttpGet]
        public IHttpActionResult AllCountries()
        {
            var country = db.Countries.AsNoTracking().Select(x => new Country
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(country);
        }

        //5. Getting All Categories
        [HttpGet]
        public IHttpActionResult AllCategories()
        {
            var category = db.Categories.AsNoTracking().Select(x => new Category
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(category);
        }

        //6. Getting All Companies
        [HttpGet]
        public IHttpActionResult AllCompanies()
        {
            var company = db.Companies.AsNoTracking().Select(x => new Company
            {
                Id = x.Id,
                PersianName = x.PersianName,
                EnglishName = x.EnglishName,
                CountryId = x.CountryId,
                Country = x.Country
            }).ToList();

            return Ok(company);
        }
    }
}
