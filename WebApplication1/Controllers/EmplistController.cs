using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmplistController:Controller
    {

        private readonly Iinterface _interfaece;
        public EmplistController(Iinterface interfaece)
        {
            this._interfaece = interfaece;
        }
        [HttpGet]
        [Route("getall")]
        public IEnumerable<Emplistclass> getall()
        {
            return _interfaece.getall().ToList();
        }
        [HttpPost]
        [Route("Savedata")]
        public Emplistclass Postdata(Emplistclass emplistclass)
        {
          var result=_interfaece.Postdata(emplistclass);
            return result;
        }
        [HttpPut]
        [Route("UpdateEmployees/{id}")]
        public Emplistclass Updatedata(Emplistclass emplistclass,int id)
        {
            var resl=_interfaece.Updatedata(emplistclass,id);
            return resl;
        }
        [HttpDelete]

        public Emplistclass deletdata(Emplistclass emplistclass5,int id)
        {
            var reslt1=_interfaece.deletdata(emplistclass5,id);
            return reslt1;
        }
    }
}
