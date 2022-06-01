using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IActionResult_HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public AnimalController()
        {
            Animals.Add(new Animal() { Age = 22, Name = "Lion" });
            Animals.Add(new Animal() { Age = 22, Name = "Cat" });
            Animals.Add(new Animal() { Age = 22, Name = "Dog" });
            Animals.Add(new Animal() { Age = 22, Name = "Chimpanze" });
            Animals.Add(new Animal() { Age = 22, Name = "Eagle" });
        }


        [HttpGet("{name}")]
        public IActionResult GetByName([FromRoute] string name)
        {
            if (name.ToLower() == "giraffe")
            {
                return RedirectToPage("api/animal/smile");
            }

            foreach (var item in Animals)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                   
                    return Ok(item);
                }
               

            }
            return NotFound();
        }

        [Route("smile")]
        public ActionResult GetSmile()
        {
            return Accepted("Hello :)");
        }
    }
}
