using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using guru.Model;

namespace guru.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private GuruContext _context;

        public GuruController(GuruContext context)
        {
            this._context = context;
        }

        // GET: api/guru
        [HttpGet]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetAllGuru();
        }

        //Get : api/guru/{nip}
        [HttpGet("{nip}", Name = "Get")]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItem(String nip)
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetGuru(nip);
        }

        //Post : api/guru/ (add guru)
        [HttpPost]
        public ActionResult<GuruItem> AddGuru([FromForm] string rfid, [FromForm] string nip, [FromForm] string nama_guru, [FromForm] string alamat, [FromForm] int status_guru)
        {
            GuruItem ki = new GuruItem();
            ki.rfid = rfid;
            ki.nip = nip;
            ki.nama_guru = nama_guru;
            ki.alamat = alamat;
            ki.status = status_guru;

            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.AddGuru(ki);
        }

    }
}
