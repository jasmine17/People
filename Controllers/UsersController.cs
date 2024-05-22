using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using People.data;
using People.Models;

namespace People.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserContext _context;
    public UsersController(UserContext context)
        {
    _context = context;
        }

        // GET: Users/Index
        public async Task< IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        //Get Users/Details/id
        public async Task<IActionResult > Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m=>m.ID== id);
            if(user==null)
                {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create() {
            return View();
        }

        //Post : Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Password,PhoneNumber,IsActive")]
        Users user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                _context.Add(user);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        //Get : Users/Edit/id
        public async Task<IActionResult> Edit(int? id) 
        {
            if(id==null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if(user==null)
            {
                return NotFound();
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

        //post : Users/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Password,PhoneNumber,IsActive")] Users user)
        {
            if(id!=user.ID)
            { return NotFound(); }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
