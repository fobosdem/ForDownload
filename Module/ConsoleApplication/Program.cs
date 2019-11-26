using ModulePL;
using ModulePL.ViewModels;
using ModulePL.PostModels;
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var ctrl = new StudentsController();

			var student = ctrl.GetById(1);
			//Console.WriteLine(student.FullName);


			//var payments = new List<PaymentPostModel>();

			////payments.Add(new PaymentPostModel { Date = DateTime.Now, Value = 15500 });
			////payments.Add(new PaymentPostModel { Date = DateTime.Now, Value = 2000 });
			////payments.Add(new PaymentPostModel { Date = DateTime.Now, Value = 2200 });
			////payments.Add(new PaymentPostModel { Date = DateTime.Now, Value = 23330 });

			//var addFirstStudent = new StudentPostModel()
			//{
			//	FirstName = "petya",
			//	LastName = "1111",
			//	Age = 25,
			//	Payments = payments
			//};

			ctrl.Create(addFirstStudent);


			var test = ctrl.StudentPayLes(100000);

			Console.ReadKey();
		}
	}
}
