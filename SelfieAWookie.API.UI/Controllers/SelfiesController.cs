using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookies.Core.Domain;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System.IO;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        // IWebHostEnvironment pour accéder au dosssier d'execution de notre machine ou se trouve l'app sur notre pc
        #region Fields
        private readonly ISelfieRepository _repository ;
        private readonly IWebHostEnvironment _webHostEnvironment ;
        #endregion

        #region Constructor
        public SelfiesController(ISelfieRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this._repository = repository;
            this._webHostEnvironment = webHostEnvironment;
        }

        #endregion


        //#region Constructor
        //public SelfiesController(SelfiesContext context)
        //{
        //    this._context = context;
        //}

        //#endregion
        //#region public methods
        //[HttpGet]
        //public IEnumerable<Selfie> TestAMoi()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}
        //#endregion
        #region public methods
        [HttpGet]
        public IActionResult GetAll([FromQuery]int wookieId = 0)
        {

            var param = this.Request.Query["wookieId"];
            var selfieList  = _repository.GetAll(wookieId);

            var model = selfieList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();
         
             return this.Ok(model);
        }

        ////[Route("photos")]
        ////[HttpPost]
        ////public async Task<IActionResult> AddPicture()
        ////{
        ////    using var stream = new StreamReader(this.Request.Body);
        ////    var content =  await stream.ReadToEndAsync();
        ////    return this.Ok();
        ////}

        [Route("photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            // combiner le dossier là ou est l'api avec là ou on veut mettre notre image
            string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, @"images\selfies");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = Path.Combine(filePath, picture.FileName);


            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            // copier notre stream picture dans un autre stream sur notre disque dure
            await picture.CopyToAsync(stream);

           
            var itemFile = this._repository.AddOnePicture(filePath);
            

            try
            { 
                this._repository.IUnitOfWork.SaveChanges(); 
            } 
            catch (Exception ex)
            {
                throw;
            }
   

            return this.Ok(itemFile);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddPicture(IFormFile picture)
        //{
        //    if (picture != null && picture.Length > 0)
        //    {
        //        string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, @"images\selfies");

        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }

        //        filePath = Path.Combine(filePath, picture.FileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await picture.CopyToAsync(stream);
        //        }

        //        return this.Ok();
        //    }
        //    else
        //    {
        //        return BadRequest("Aucun fichier sélectionné.");
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddPicture(IFormFile picture)
        //{
        //    string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, @"images\selfies");

        //    if(!Directory.Exists(filePath))
        //    {
        //        Directory.CreateDirectory(filePath);
        //    }
        //    filePath = Path.Combine(filePath, picture.FileName);


        //    using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
        //    await picture.CopyToAsync(picture.OpenReadStream());


        //    return this.Ok();
        //}

        [HttpPost]
        public IActionResult AddOne(SelfieDto dto)
        {

            IActionResult result = this.BadRequest();

            Selfie addSelfie = this._repository.AddOne(new Selfie()
            {
                ImagePath = dto.ImagePath,
                Title = dto.Title
            });

            this._repository.IUnitOfWork.SaveChanges();

            if (addSelfie != null)
            {
                dto.Id = addSelfie.Id;
                result = this.Ok(dto);
            }

            return result;
        }
        #endregion      
    }
}
