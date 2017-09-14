﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EducationLibrary;

namespace LINQLesson {
	class Program {
		void ExamplesFromChapter21(){

			var customers = new[] {
				new {CustomerID = 1, FirstName = "Kim", LastName = "Abercrombie", CompanyName = "Alpine Ski House"},
				new {CustomerID = 2, FirstName = "Jeff", LastName = "Hay", CompanyName = "Coho Winery"},
				new {CustomerID = 3, FirstName = "Charlie", LastName = "Herb", CompanyName = "Alpine Ski House"},
				new {CustomerID = 4, FirstName = "Chris", LastName = "Preston", CompanyName = "Trey Research"},
				new {CustomerID = 5, FirstName = "Dave", LastName = "Barnett", CompanyName = "Wingtip Toys"},
				new {CustomerID = 6, FirstName = "Ann", LastName = "Beebe", CompanyName = "Coho Winery"},
				new {CustomerID = 7, FirstName = "John", LastName = "Kane", CompanyName = "Wingtip Toys"},
				new {CustomerID = 8, FirstName = "David", LastName = "Simpson", CompanyName = "Trey Research"},
				new {CustomerID = 9, FirstName = "Greg", LastName = "Chapman", CompanyName = "Wingtip Toys"},
				new {CustomerID = 10, FirstName = "Tim", LastName = "Litton", CompanyName = "Wide World Importers"}
			};
			var addresses = new[] {
				new {CompanyName = "Alpine Ski House", City = "Berne", Country = "Switzerland"},
				new {CompanyName = "Coho Winery", City = "San Francisco", Country = "United States"},
				new {CompanyName = "Trey Research", City = "New York", Country = "United States"},
				new {CompanyName = "Wingtip Toys", City = "London", Country = "United Kingdom"},
				new {CompanyName = "Wide World Importers", City = "Tetbury", Country = "United Kingdom"}
			};

			var customersandcompanies = customers
				.Select(c => new { c.FirstName, c.LastName, c.CompanyName })
				.Join(addresses, custs => custs.CompanyName, addrs => addrs.CompanyName,
				(custs, addrs) => new { custs.FirstName, custs.LastName, addrs.City });

			foreach(var row in customersandcompanies) {
				Debug.WriteLine($"{row.FirstName} {row.LastName}, {row.City}");
			}

		}

		void Run() {
			var students = StudentCollection.Select();

			//Using LINQ, we can use a relatively small amount of code to create a collection "where" a
			//condition is set.
			
			//Creates the List
			var topstudents = students
				//Sets the condition that any students on the list need a gpa of 3.5 or higher, and
				//the student does not have the majorid value of "0," which represents a student
				//without a major
				.Where(stud => stud.gpa >= 3.5 && stud.majorid != 0)
				//The students are sorted by descending lastname
				.OrderByDescending(s => s.lastname);

			foreach (var student in topstudents) {
				Debug.WriteLine($"{student.firstname} {student.lastname} {student.sat} {student.gpa} {student.majorid}");
			}

			//If we only want to look for one entry, we can use Find() to hunt down that entry.
			var s4 = students.ToList().Find(s => s.id == 4);
			Debug.WriteLine($"{s4.firstname} {s4.lastname} {s4.majorid}");
		}

		static void Main(string[] args) {
			new Program().ExamplesFromChapter21();
		}
	}
}
