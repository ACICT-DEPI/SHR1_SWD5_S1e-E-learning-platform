using LearningPlatform.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.BLL.ViewModels
{
	public class ShoppingCart
	{
		public Course Course { get; set; }
		public int Count { get; set; }
	}
}
