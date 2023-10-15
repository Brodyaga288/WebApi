using Microsoft.AspNetCore.Mvc;
using Project_Test_01.Models;

namespace Project_Test_01.Controllers
{
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        List<Users> users = new List<Users>()
        {
            new Users{Id = 1, Name = "Тимур", Age = 24},
            new Users{Id = 2, Name = "Макс", Age = 17},
        };

        [HttpGet]
        public IEnumerable<Users> Get() => users;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = users.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        private int NextUsersId => users.Count() == 0 ? 1 : users.Max(u => u.Id) + 1;

        [HttpPost]
        public IActionResult Post(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            user.Id= NextUsersId;
            users.Add(user);
            return Ok(user); 
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
