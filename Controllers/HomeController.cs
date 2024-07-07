using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.eventstodo.ToListAsync());
        }

        public IActionResult AddNewEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewEvent(Event futureEvent)
        {
            _context.eventstodo.Add(futureEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (id != null)
            {
                Event? eventToDel = await _context.eventstodo.FirstOrDefaultAsync(e => e.Id == id);
                if (eventToDel != null)
                {
                    _context.eventstodo.Remove(eventToDel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            if (id != null)
            {
                Event? eventDone = await _context.eventstodo.FirstOrDefaultAsync(e =>e.Id == id);
                if(eventDone != null)
                {
                    eventDone.IsFinished = !eventDone.IsFinished;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
