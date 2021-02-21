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
    public class ItemsController : ApiController
    {
        ItemRepository itemRepository = new ItemRepository();
        // Create
        public IHttpActionResult Post(Item item)
        {
            if (item.ItemName == null)
            {
                return BadRequest("Nama Tidak boleh kosong");
            }
            itemRepository.Create(item);
            return Ok("Data sudah masuk!");
            // Delete
        }
        public IHttpActionResult Delete(int Id)
        {
            var delete = itemRepository.Delete(Id);
            if (delete == 0)
            {
                return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
            }
            return Ok("Berhasil Delete");
        }
        public IHttpActionResult Put(Item item, int Id)
        {
            var put = itemRepository.Update(item, Id);
            if (put == 0)
            {
                return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
            }
            return Ok();
        }
        public IHttpActionResult Get()
        {
            var get = itemRepository.Get();
            if (get == null)
            {
                return Content(HttpStatusCode.BadRequest, "Terjadi Kesalahan");
            }
            return Ok(get);
        }
        public async Task<IHttpActionResult> GetById(int Id)
        {
            var get = await itemRepository.GetById(Id);
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