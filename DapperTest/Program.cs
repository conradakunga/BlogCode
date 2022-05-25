using Dapper;
using Microsoft.Data.SqlClient;

var cn = new SqlConnection("data source=;trusted_connection=true;database=test;encrypt=false");

//Query the dynamic object
var result = cn.Query("Select '12 nov 2000' DateOfBirth, 'James Bond' Name, 'Finance' DegreeProgram");

// Query and map to Person
var person = cn.Query<Person>("Select '12 nov 2000' DateOfBirth, 'James Bond' Name, 'Finance' DegreeProgram");

// Query and map to Student
var student = cn.Query<Student>("Select '12 nov 2000' DateOfBirth, 'James Bond' Name, 'Finance' DegreeProgram");

Console.WriteLine("Completed");
