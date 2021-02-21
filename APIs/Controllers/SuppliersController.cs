using APIs.Models;
using APIs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIs.Controllers
{
    public class SuppliersController : ApiController
    {
        SupplierRepository supplierRepository = new SupplierRepository();
        // Create
        public IHttpActionResult Post(Supplier supplier)
        {
            if (supplier.Name == null || supplier.Name.Length <= 6)
            {
                return BadRequest("- Tidak boleh kosong dan Masukkan 6-50 Karakter (Huruf atau Angka)");
            }
            supplierRepository.Create(supplier);
            return Ok("Data sudah masuk!");
            // Delete
        }
        public IHttpActionResult Delete(int Id)
        {
            var delete = supplierRepository.Delete(Id);
            if (delete == 0)
            {
                return BadRequest("Data Tidak Ditemukan");
            }
            return Ok("Berhasil Delete");
        }
        public IHttpActionResult Put(Supplier supplier, int Id)
        {
            var put = supplierRepository.Update(supplier, Id);
            if (put == 0)
            {
                return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
            }
            return Ok();
        }
        public IHttpActionResult Get()
        {
            var get = supplierRepository.Get();
            if (get == null)
            {
                return Content(HttpStatusCode.BadRequest, "Terjadi Kesalahan");
            }
            return Ok(get);
        }
        public async Task<IHttpActionResult> GetById(int id)
        {
            var get = await supplierRepository.GetById(id);
            if (get != null)
            {
                if (get.Count() == 0)
                {
                    return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
                }
                return Ok(get);
            }
            return Content(HttpStatusCode.BadRequest, "Terjadi Kesalahan");
        }
    }
}
