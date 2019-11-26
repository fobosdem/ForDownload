﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulePL.PostModels
{
	public class StudentPostModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int? Age { get; set; }
		public List<PaymentPostModel> Payments { get; set; }
	}
}
