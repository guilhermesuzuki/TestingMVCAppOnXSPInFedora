using System;
using System.Collections.Generic;
using System.Configuration;
using website.Models;
using System.Data.SqlClient;

namespace website.DAL
{
	public class PersonDAL
	{
		readonly string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

		public PersonDAL ()
		{
		}

		public List<Person> Get() {
			var l = new List<Person> ();

			using (var sqlConn = new SqlConnection (connectionString)) {
				sqlConn.Open ();
				using (var sqlCmd = new SqlCommand ("SELECT FirstName, MiddleName, LastName FROM Person.Person", sqlConn)) {
					var reader = sqlCmd.ExecuteReader ();
					while (reader.Read ()) {
						var p = new Person ();

						var firstName = reader.GetOrdinal ("FirstName");
						var middleName = reader.GetOrdinal ("MiddleName");
						var lastName = reader.GetOrdinal ("LastName");

						p.FirstName = reader.IsDBNull(firstName) == false ? reader.GetString (firstName): string.Empty;
						p.MiddleName = reader.IsDBNull(middleName) == false ? reader.GetString (middleName) : string.Empty;
						p.LastName = reader.IsDBNull(lastName) == false ? reader.GetString (lastName) : string.Empty;

						l.Add (p);
					}
				}
			}

			return l;
		}
	}
}

