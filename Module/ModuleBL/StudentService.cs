using ModuleBL.Models;
using ModuleDal;
using ModuleDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleBL
{
	public class StudentService
	{
		private readonly StudentRepository _studentRepository;
		public StudentService()
		{
			_studentRepository = new StudentRepository();
		}

		public void CreateStudent(StudentModel student)
		{
			if (!student.Payments.Any())
				throw new ArgumentException("No Payments");

			Student studentDAL = new Student() { Payments = new List<Payment>() };
			studentDAL.FirstName = student.FirstName;
			studentDAL.LastName = student.Lastname;
			studentDAL.Age = student.Age;
			var payments = student.Payments;
			foreach (var payment in payments)
			{
				studentDAL.Payments.Add(new Payment { Date = payment.Date, Value = payment.Value });
			}

			_studentRepository.Create(studentDAL);
		}


		public IEnumerable<StudentModel> GetStudentsPayLess(int sum)
		{
			var studentsEntity = _studentRepository.GetAll();

			var resultStudent = new List<StudentModel>();

			studentsEntity = studentsEntity.Where(st => st.Payments.Select(pay => pay.Value).Sum() < sum).ToList();

			foreach (var studEntity in studentsEntity)
			{
				resultStudent.Add(new StudentModel
				{
					FirstName = studEntity.FirstName,
					Lastname = studEntity.LastName,
					Age = studEntity.Age,
					Payments = studEntity.Payments.Select(pay => new PaymentModel
					{
						Value = pay.Value,
						Date = pay.Date
					})
				});
			}

			return resultStudent;
		}

		public StudentModel GetById(int id)
		{
			var studentEntity = _studentRepository.GetById(id);

			if (studentEntity == null)
				throw new ArgumentException("Student not fount");

			var resultStudent = new StudentModel
			{
				FirstName = studentEntity.FirstName,
				Lastname = studentEntity.LastName,
			};

			resultStudent.Payments = studentEntity.Payments.Select(payment => new PaymentModel
			{
				Student = resultStudent,
				Value = payment.Value,
				Date = payment.Date
			});

			return resultStudent;
		}
	}
}
