using ModuleBL;
using ModuleBL.Models;
using ModulePL.ViewModels;
using System.Linq;
using ModulePL.PostModels;
using System.Collections.Generic;

namespace ModulePL
{
	public class StudentsController
	{

		public List<StudentViewModel> StudentPayLes(int sum)
		{
			var result = new List<StudentViewModel>();
			var service = new StudentService();
			var studentsBl = service.GetStudentsPayLess(sum);

			foreach(var studentBl in studentsBl)
			{
				result.Add(
					new StudentViewModel
					{
						Age = studentBl.Age.GetValueOrDefault(),
						FullName = $"{studentBl.FirstName} {studentBl.Lastname}",
						Payments = studentBl.Payments.Select(payment => new PaymentViewModel
						{
							Date = payment.Date,
							Value = payment.Value
						})
					});
			}
			return result;
		}

		public void Create(StudentPostModel student)
		{
			var studentModel = new StudentModel()
			{
				FirstName = student.FirstName,
				Lastname = student.LastName,
				Age = student.Age,
				Payments = student.Payments.Select(p => new PaymentModel
				{
					Date = p.Date,
					Value = p.Value
				})
			};
			var service = new StudentService();
			service.CreateStudent(studentModel);

		}
		public StudentViewModel GetById(int id)
		{
			var service = new StudentService();

			var student = service.GetById(id);

			return new StudentViewModel
			{
				Age = student.Age.GetValueOrDefault(),
				FullName = $"{student.FirstName} {student.Lastname}",
				Payments = student.Payments.Select(payment => new PaymentViewModel
				{
					Date = payment.Date,
					Value = payment.Value
				})
			};
		}
	}
}
