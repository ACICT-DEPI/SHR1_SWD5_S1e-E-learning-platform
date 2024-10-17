using LearningPlatform.BLL.ViewModels;
using LearningPlatform.DAL.Repository.Abstraction;
using LearningPlatform.DAL.Repository.Impelementation;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.mvc.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

		public HomeController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var categories = _unitOfWork.Category.GetAll();
			var courses = _unitOfWork.Course.GetAll();
			var viewModel = new CourseViewModel
			{
				Categories = categories,
				Courses = courses
			};
			return View(viewModel);
		}
		public IActionResult Details(int id)
		{
			ShoppingCart obj = new ShoppingCart()
			{
				Course = _unitOfWork.Course.GetFirstorDefault(x => x.Id == id, Includeword: "Category"),
				Count = 1
			};
			return View(obj);
		}
		public IActionResult Category(int categoryId)
		{
			var courses = _unitOfWork.Course.GetAll(x => x.CategoryId == categoryId).Select(item => new
			{
				item.Id,
				item.CourseName,
				item.CourseDescription,
				item.Image,
				item.CourseTime,
				item.TotalLecture,
				item.Price,
				ImageUrl = Url.Content("/" + item.Image) // Ensure correct image URL
			});
			return Json(courses);
		}
		public IActionResult GetAllCourses()
		{
			var allcourses= _unitOfWork.Course.GetAll().Select(item => new
			{
				item.Id,
				item.CourseName,
				item.CourseDescription,
				item.Image,
				item.CourseTime,
				item.TotalLecture,
				item.Price,
				ImageUrl = Url.Content("/" + item.Image)
			});
			return Json(allcourses);
		}

	}
}
