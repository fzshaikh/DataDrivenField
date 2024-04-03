using DataDrivenField.EF;
using DataDrivenField.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DataDrivenField.Controllers
{
    public class DataEntryController : Controller
    {
        private readonly DataEntryContext _context;
        public DataEntryController()
        {
            _context = new DataEntryContext();
        }
        // GET: DataEntry
        public ActionResult Index()
        {
            return View(_context.DataEntries.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DataEntry dataentries)
        {
            _context.DataEntries.Add(dataentries);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dataentriesObject = _context.DataEntries.Find(id);
            return View(dataentriesObject);
        }

        [HttpPost]

        public ActionResult Edit(DataEntry dataentries)
        {
            _context.Entry(dataentries).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var dataentriesObject = _context.DataEntries.Find(id);
            return View(dataentriesObject);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var dataentriesObject = _context.DataEntries.Find(id);
            _context.DataEntries.Remove(dataentriesObject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var dataentriesObject = _context.DataEntries.Find(id);
            return View(dataentriesObject);
        }




        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SelectRole(string userName)
        {
            ViewBag.UserRoles = from ur in _context.UserRoles
                                join u in _context.Users on ur.UserId equals u.Id
                                join r in _context.Roles on ur.RoleId equals r.Id
                                where u.Username == userName
                                select r.Name;
            return View();
        }

        [HttpPost]
        public ActionResult SelectRolePost(string Roles)
        {
            string roleName = Roles;
            Session["Role"] = roleName;

            return RedirectToAction("Entry");
        }

        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPost(User model)
        {
            bool success = checkLoginFromDb(model);

            if (success)
            {
                return RedirectToAction("SelectRole", new { userName = model.Username });
            }


            return View();
        }

        private bool checkLoginFromDb(User model)
        {
            return _context
                 .Users
                 .Any(x => x.Username == model.Username
                 && x.Password == model.Password);

        }

        private string GetRoleByUsername(string userName)
        {
            var roleName = (from ur in _context.UserRoles
                            join u in _context.Users on ur.UserId equals u.Id
                            join r in _context.Roles on ur.RoleId equals r.Id
                            where u.Username == userName
                            select r.Name).FirstOrDefault();

            return roleName;

        }
    }
}