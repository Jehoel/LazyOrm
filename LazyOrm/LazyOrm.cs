using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyNamespace
{
	public sealed class MyDatabase : IDisposable
	{
		private readonly SqlConnection c;

		private MyDatabase(SqlConnection c)
		{
			this.c = c;
		}

		public void Dispose()
		{
			this.c.Dispose();
		}

		public static async Task<MyDatabase> CreateAsync(String connectionString)
		{
			SqlConnection con = new SqlConnection( connectionString );
			await con.OpenAsync().ConfigureAwait(false);
			return new MyDatabase( con );
		}

		
		public Task InsertCategoriesAsync( String CategoryName, String Description, Byte[] Picture )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Categories (
	[CategoryName], [Description], [Picture]
) VALUES (
	@CategoryName , @Description , @Picture 
)
";				
				
				cmd.Parameters.Add( "@CategoryName", SqlDbType.NVarChar ).Value = CategoryName;
				cmd.Parameters.Add( "@Description", SqlDbType.NText ).Value = ( Description == null ) ? DBNull.Value : (Object)Description;
				cmd.Parameters.Add( "@Picture", SqlDbType.Image ).Value = ( Picture == null ) ? DBNull.Value : (Object)Picture;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertCustomerCustomerDemoAsync( String CustomerID, String CustomerTypeID )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.CustomerCustomerDemo (
	[CustomerID], [CustomerTypeID]
) VALUES (
	@CustomerID , @CustomerTypeID 
)
";				
				
				cmd.Parameters.Add( "@CustomerID", SqlDbType.NChar ).Value = CustomerID;
				cmd.Parameters.Add( "@CustomerTypeID", SqlDbType.NChar ).Value = CustomerTypeID;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertCustomerDemographicsAsync( String CustomerTypeID, String CustomerDesc )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.CustomerDemographics (
	[CustomerTypeID], [CustomerDesc]
) VALUES (
	@CustomerTypeID , @CustomerDesc 
)
";				
				
				cmd.Parameters.Add( "@CustomerTypeID", SqlDbType.NChar ).Value = CustomerTypeID;
				cmd.Parameters.Add( "@CustomerDesc", SqlDbType.NText ).Value = ( CustomerDesc == null ) ? DBNull.Value : (Object)CustomerDesc;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertCustomersAsync( String CustomerID, String CompanyName, String ContactName, String ContactTitle, String Address, String City, String Region, String PostalCode, String Country, String Phone, String Fax )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Customers (
	[CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]
) VALUES (
	@CustomerID , @CompanyName , @ContactName , @ContactTitle , @Address , @City , @Region , @PostalCode , @Country , @Phone , @Fax 
)
";				
				
				cmd.Parameters.Add( "@CustomerID", SqlDbType.NChar ).Value = CustomerID;
				cmd.Parameters.Add( "@CompanyName", SqlDbType.NVarChar ).Value = CompanyName;
				cmd.Parameters.Add( "@ContactName", SqlDbType.NVarChar ).Value = ( ContactName == null ) ? DBNull.Value : (Object)ContactName;
				cmd.Parameters.Add( "@ContactTitle", SqlDbType.NVarChar ).Value = ( ContactTitle == null ) ? DBNull.Value : (Object)ContactTitle;
				cmd.Parameters.Add( "@Address", SqlDbType.NVarChar ).Value = ( Address == null ) ? DBNull.Value : (Object)Address;
				cmd.Parameters.Add( "@City", SqlDbType.NVarChar ).Value = ( City == null ) ? DBNull.Value : (Object)City;
				cmd.Parameters.Add( "@Region", SqlDbType.NVarChar ).Value = ( Region == null ) ? DBNull.Value : (Object)Region;
				cmd.Parameters.Add( "@PostalCode", SqlDbType.NVarChar ).Value = ( PostalCode == null ) ? DBNull.Value : (Object)PostalCode;
				cmd.Parameters.Add( "@Country", SqlDbType.NVarChar ).Value = ( Country == null ) ? DBNull.Value : (Object)Country;
				cmd.Parameters.Add( "@Phone", SqlDbType.NVarChar ).Value = ( Phone == null ) ? DBNull.Value : (Object)Phone;
				cmd.Parameters.Add( "@Fax", SqlDbType.NVarChar ).Value = ( Fax == null ) ? DBNull.Value : (Object)Fax;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertEmployeesAsync( String LastName, String FirstName, String Title, String TitleOfCourtesy, DateTime? BirthDate, DateTime? HireDate, String Address, String City, String Region, String PostalCode, String Country, String HomePhone, String Extension, Byte[] Photo, String Notes, Int32? ReportsTo, String PhotoPath )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Employees (
	[LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Photo], [Notes], [ReportsTo], [PhotoPath]
) VALUES (
	@LastName , @FirstName , @Title , @TitleOfCourtesy , @BirthDate , @HireDate , @Address , @City , @Region , @PostalCode , @Country , @HomePhone , @Extension , @Photo , @Notes , @ReportsTo , @PhotoPath 
)
";				
				
				cmd.Parameters.Add( "@LastName", SqlDbType.NVarChar ).Value = LastName;
				cmd.Parameters.Add( "@FirstName", SqlDbType.NVarChar ).Value = FirstName;
				cmd.Parameters.Add( "@Title", SqlDbType.NVarChar ).Value = ( Title == null ) ? DBNull.Value : (Object)Title;
				cmd.Parameters.Add( "@TitleOfCourtesy", SqlDbType.NVarChar ).Value = ( TitleOfCourtesy == null ) ? DBNull.Value : (Object)TitleOfCourtesy;
				cmd.Parameters.Add( "@BirthDate", SqlDbType.DateTime ).Value = ( BirthDate == null ) ? DBNull.Value : (Object)BirthDate.Value;
				cmd.Parameters.Add( "@HireDate", SqlDbType.DateTime ).Value = ( HireDate == null ) ? DBNull.Value : (Object)HireDate.Value;
				cmd.Parameters.Add( "@Address", SqlDbType.NVarChar ).Value = ( Address == null ) ? DBNull.Value : (Object)Address;
				cmd.Parameters.Add( "@City", SqlDbType.NVarChar ).Value = ( City == null ) ? DBNull.Value : (Object)City;
				cmd.Parameters.Add( "@Region", SqlDbType.NVarChar ).Value = ( Region == null ) ? DBNull.Value : (Object)Region;
				cmd.Parameters.Add( "@PostalCode", SqlDbType.NVarChar ).Value = ( PostalCode == null ) ? DBNull.Value : (Object)PostalCode;
				cmd.Parameters.Add( "@Country", SqlDbType.NVarChar ).Value = ( Country == null ) ? DBNull.Value : (Object)Country;
				cmd.Parameters.Add( "@HomePhone", SqlDbType.NVarChar ).Value = ( HomePhone == null ) ? DBNull.Value : (Object)HomePhone;
				cmd.Parameters.Add( "@Extension", SqlDbType.NVarChar ).Value = ( Extension == null ) ? DBNull.Value : (Object)Extension;
				cmd.Parameters.Add( "@Photo", SqlDbType.Image ).Value = ( Photo == null ) ? DBNull.Value : (Object)Photo;
				cmd.Parameters.Add( "@Notes", SqlDbType.NText ).Value = ( Notes == null ) ? DBNull.Value : (Object)Notes;
				cmd.Parameters.Add( "@ReportsTo", SqlDbType.Int ).Value = ( ReportsTo == null ) ? DBNull.Value : (Object)ReportsTo.Value;
				cmd.Parameters.Add( "@PhotoPath", SqlDbType.NVarChar ).Value = ( PhotoPath == null ) ? DBNull.Value : (Object)PhotoPath;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertEmployeeTerritoriesAsync( Int32 EmployeeID, String TerritoryID )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.EmployeeTerritories (
	[EmployeeID], [TerritoryID]
) VALUES (
	@EmployeeID , @TerritoryID 
)
";				
				
				cmd.Parameters.Add( "@EmployeeID", SqlDbType.Int ).Value = EmployeeID;
				cmd.Parameters.Add( "@TerritoryID", SqlDbType.NVarChar ).Value = TerritoryID;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertOrderDetailsAsync( Int32 OrderID, Int32 ProductID, Decimal UnitPrice, Int16 Quantity, Double Discount )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Order Details (
	[OrderID], [ProductID], [UnitPrice], [Quantity], [Discount]
) VALUES (
	@OrderID , @ProductID , @UnitPrice , @Quantity , @Discount 
)
";				
				
				cmd.Parameters.Add( "@OrderID", SqlDbType.Int ).Value = OrderID;
				cmd.Parameters.Add( "@ProductID", SqlDbType.Int ).Value = ProductID;
				cmd.Parameters.Add( "@UnitPrice", SqlDbType.Money ).Value = UnitPrice;
				cmd.Parameters.Add( "@Quantity", SqlDbType.SmallInt ).Value = Quantity;
				cmd.Parameters.Add( "@Discount", SqlDbType.Real ).Value = Discount;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertOrdersAsync( String CustomerID, Int32? EmployeeID, DateTime? OrderDate, DateTime? RequiredDate, DateTime? ShippedDate, Int32? ShipVia, Decimal? Freight, String ShipName, String ShipAddress, String ShipCity, String ShipRegion, String ShipPostalCode, String ShipCountry )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Orders (
	[CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry]
) VALUES (
	@CustomerID , @EmployeeID , @OrderDate , @RequiredDate , @ShippedDate , @ShipVia , @Freight , @ShipName , @ShipAddress , @ShipCity , @ShipRegion , @ShipPostalCode , @ShipCountry 
)
";				
				
				cmd.Parameters.Add( "@CustomerID", SqlDbType.NChar ).Value = ( CustomerID == null ) ? DBNull.Value : (Object)CustomerID;
				cmd.Parameters.Add( "@EmployeeID", SqlDbType.Int ).Value = ( EmployeeID == null ) ? DBNull.Value : (Object)EmployeeID.Value;
				cmd.Parameters.Add( "@OrderDate", SqlDbType.DateTime ).Value = ( OrderDate == null ) ? DBNull.Value : (Object)OrderDate.Value;
				cmd.Parameters.Add( "@RequiredDate", SqlDbType.DateTime ).Value = ( RequiredDate == null ) ? DBNull.Value : (Object)RequiredDate.Value;
				cmd.Parameters.Add( "@ShippedDate", SqlDbType.DateTime ).Value = ( ShippedDate == null ) ? DBNull.Value : (Object)ShippedDate.Value;
				cmd.Parameters.Add( "@ShipVia", SqlDbType.Int ).Value = ( ShipVia == null ) ? DBNull.Value : (Object)ShipVia.Value;
				cmd.Parameters.Add( "@Freight", SqlDbType.Money ).Value = ( Freight == null ) ? DBNull.Value : (Object)Freight.Value;
				cmd.Parameters.Add( "@ShipName", SqlDbType.NVarChar ).Value = ( ShipName == null ) ? DBNull.Value : (Object)ShipName;
				cmd.Parameters.Add( "@ShipAddress", SqlDbType.NVarChar ).Value = ( ShipAddress == null ) ? DBNull.Value : (Object)ShipAddress;
				cmd.Parameters.Add( "@ShipCity", SqlDbType.NVarChar ).Value = ( ShipCity == null ) ? DBNull.Value : (Object)ShipCity;
				cmd.Parameters.Add( "@ShipRegion", SqlDbType.NVarChar ).Value = ( ShipRegion == null ) ? DBNull.Value : (Object)ShipRegion;
				cmd.Parameters.Add( "@ShipPostalCode", SqlDbType.NVarChar ).Value = ( ShipPostalCode == null ) ? DBNull.Value : (Object)ShipPostalCode;
				cmd.Parameters.Add( "@ShipCountry", SqlDbType.NVarChar ).Value = ( ShipCountry == null ) ? DBNull.Value : (Object)ShipCountry;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertProductsAsync( String ProductName, Int32? SupplierID, Int32? CategoryID, String QuantityPerUnit, Decimal? UnitPrice, Int16? UnitsInStock, Int16? UnitsOnOrder, Int16? ReorderLevel, Boolean Discontinued )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Products (
	[ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]
) VALUES (
	@ProductName , @SupplierID , @CategoryID , @QuantityPerUnit , @UnitPrice , @UnitsInStock , @UnitsOnOrder , @ReorderLevel , @Discontinued 
)
";				
				
				cmd.Parameters.Add( "@ProductName", SqlDbType.NVarChar ).Value = ProductName;
				cmd.Parameters.Add( "@SupplierID", SqlDbType.Int ).Value = ( SupplierID == null ) ? DBNull.Value : (Object)SupplierID.Value;
				cmd.Parameters.Add( "@CategoryID", SqlDbType.Int ).Value = ( CategoryID == null ) ? DBNull.Value : (Object)CategoryID.Value;
				cmd.Parameters.Add( "@QuantityPerUnit", SqlDbType.NVarChar ).Value = ( QuantityPerUnit == null ) ? DBNull.Value : (Object)QuantityPerUnit;
				cmd.Parameters.Add( "@UnitPrice", SqlDbType.Money ).Value = ( UnitPrice == null ) ? DBNull.Value : (Object)UnitPrice.Value;
				cmd.Parameters.Add( "@UnitsInStock", SqlDbType.SmallInt ).Value = ( UnitsInStock == null ) ? DBNull.Value : (Object)UnitsInStock.Value;
				cmd.Parameters.Add( "@UnitsOnOrder", SqlDbType.SmallInt ).Value = ( UnitsOnOrder == null ) ? DBNull.Value : (Object)UnitsOnOrder.Value;
				cmd.Parameters.Add( "@ReorderLevel", SqlDbType.SmallInt ).Value = ( ReorderLevel == null ) ? DBNull.Value : (Object)ReorderLevel.Value;
				cmd.Parameters.Add( "@Discontinued", SqlDbType.Bit ).Value = Discontinued;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertRegionAsync( Int32 RegionID, String RegionDescription )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Region (
	[RegionID], [RegionDescription]
) VALUES (
	@RegionID , @RegionDescription 
)
";				
				
				cmd.Parameters.Add( "@RegionID", SqlDbType.Int ).Value = RegionID;
				cmd.Parameters.Add( "@RegionDescription", SqlDbType.NChar ).Value = RegionDescription;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertShippersAsync( String CompanyName, String Phone )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Shippers (
	[CompanyName], [Phone]
) VALUES (
	@CompanyName , @Phone 
)
";				
				
				cmd.Parameters.Add( "@CompanyName", SqlDbType.NVarChar ).Value = CompanyName;
				cmd.Parameters.Add( "@Phone", SqlDbType.NVarChar ).Value = ( Phone == null ) ? DBNull.Value : (Object)Phone;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertSuppliersAsync( String CompanyName, String ContactName, String ContactTitle, String Address, String City, String Region, String PostalCode, String Country, String Phone, String Fax, String HomePage )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Suppliers (
	[CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage]
) VALUES (
	@CompanyName , @ContactName , @ContactTitle , @Address , @City , @Region , @PostalCode , @Country , @Phone , @Fax , @HomePage 
)
";				
				
				cmd.Parameters.Add( "@CompanyName", SqlDbType.NVarChar ).Value = CompanyName;
				cmd.Parameters.Add( "@ContactName", SqlDbType.NVarChar ).Value = ( ContactName == null ) ? DBNull.Value : (Object)ContactName;
				cmd.Parameters.Add( "@ContactTitle", SqlDbType.NVarChar ).Value = ( ContactTitle == null ) ? DBNull.Value : (Object)ContactTitle;
				cmd.Parameters.Add( "@Address", SqlDbType.NVarChar ).Value = ( Address == null ) ? DBNull.Value : (Object)Address;
				cmd.Parameters.Add( "@City", SqlDbType.NVarChar ).Value = ( City == null ) ? DBNull.Value : (Object)City;
				cmd.Parameters.Add( "@Region", SqlDbType.NVarChar ).Value = ( Region == null ) ? DBNull.Value : (Object)Region;
				cmd.Parameters.Add( "@PostalCode", SqlDbType.NVarChar ).Value = ( PostalCode == null ) ? DBNull.Value : (Object)PostalCode;
				cmd.Parameters.Add( "@Country", SqlDbType.NVarChar ).Value = ( Country == null ) ? DBNull.Value : (Object)Country;
				cmd.Parameters.Add( "@Phone", SqlDbType.NVarChar ).Value = ( Phone == null ) ? DBNull.Value : (Object)Phone;
				cmd.Parameters.Add( "@Fax", SqlDbType.NVarChar ).Value = ( Fax == null ) ? DBNull.Value : (Object)Fax;
				cmd.Parameters.Add( "@HomePage", SqlDbType.NText ).Value = ( HomePage == null ) ? DBNull.Value : (Object)HomePage;

				return cmd.ExecuteNonQueryAsync();
			}
		}

		
		public Task InsertTerritoriesAsync( String TerritoryID, String TerritoryDescription, Int32 RegionID )
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
INSERT INTO dbo.Territories (
	[TerritoryID], [TerritoryDescription], [RegionID]
) VALUES (
	@TerritoryID , @TerritoryDescription , @RegionID 
)
";				
				
				cmd.Parameters.Add( "@TerritoryID", SqlDbType.NVarChar ).Value = TerritoryID;
				cmd.Parameters.Add( "@TerritoryDescription", SqlDbType.NChar ).Value = TerritoryDescription;
				cmd.Parameters.Add( "@RegionID", SqlDbType.Int ).Value = RegionID;

				return cmd.ExecuteNonQueryAsync();
			}
		}


		public async Task<TestResult> ExecuteTestQueryAsync()
		{
			using( SqlCommand cmd = this.c.CreateCommand() )
			{
				cmd.CommandText =
@"
SELECT
	*
FROM
	Products

SELECT
	*
FROM
	Orders

";
				
				using( SqlDataReader rdr = await cmd.ExecuteReaderAsync().ConfigureAwait(false) )
				{
					TestResult allResults = new TestResult();

					allResults.Result0 = new List<TestResult.Result0Row>();

					while( await rdr.ReadAsync().ConfigureAwait(false) )
					{
						TestResult.Result0Row row = new TestResult.Result0Row()
						{
							ProductID = rdr.GetInt32( 0 ),
							ProductName = rdr.GetString( 1 ),
							SupplierID = rdr.IsDBNull( 2 ) ? (Int32?)null : rdr.GetInt32( 2 ),
							CategoryID = rdr.IsDBNull( 3 ) ? (Int32?)null : rdr.GetInt32( 3 ),
							QuantityPerUnit = rdr.IsDBNull( 4 ) ? (String)null : rdr.GetString( 4 ),
							UnitPrice = rdr.IsDBNull( 5 ) ? (Decimal?)null : rdr.GetDecimal( 5 ),
							UnitsInStock = rdr.IsDBNull( 6 ) ? (Int16?)null : rdr.GetInt16( 6 ),
							UnitsOnOrder = rdr.IsDBNull( 7 ) ? (Int16?)null : rdr.GetInt16( 7 ),
							ReorderLevel = rdr.IsDBNull( 8 ) ? (Int16?)null : rdr.GetInt16( 8 ),
							Discontinued = rdr.GetBoolean( 9 ),
						};
						allResults.Result0.Add( row );
					}

					await rdr.NextResultAsync().ConfigureAwait(false);

					allResults.Result1 = new List<TestResult.Result1Row>();

					while( await rdr.ReadAsync().ConfigureAwait(false) )
					{
						TestResult.Result1Row row = new TestResult.Result1Row()
						{
							OrderID = rdr.GetInt32( 0 ),
							CustomerID = rdr.IsDBNull( 1 ) ? (String)null : rdr.GetString( 1 ),
							EmployeeID = rdr.IsDBNull( 2 ) ? (Int32?)null : rdr.GetInt32( 2 ),
							OrderDate = rdr.IsDBNull( 3 ) ? (DateTime?)null : rdr.GetDateTime( 3 ),
							RequiredDate = rdr.IsDBNull( 4 ) ? (DateTime?)null : rdr.GetDateTime( 4 ),
							ShippedDate = rdr.IsDBNull( 5 ) ? (DateTime?)null : rdr.GetDateTime( 5 ),
							ShipVia = rdr.IsDBNull( 6 ) ? (Int32?)null : rdr.GetInt32( 6 ),
							Freight = rdr.IsDBNull( 7 ) ? (Decimal?)null : rdr.GetDecimal( 7 ),
							ShipName = rdr.IsDBNull( 8 ) ? (String)null : rdr.GetString( 8 ),
							ShipAddress = rdr.IsDBNull( 9 ) ? (String)null : rdr.GetString( 9 ),
							ShipCity = rdr.IsDBNull( 10 ) ? (String)null : rdr.GetString( 10 ),
							ShipRegion = rdr.IsDBNull( 11 ) ? (String)null : rdr.GetString( 11 ),
							ShipPostalCode = rdr.IsDBNull( 12 ) ? (String)null : rdr.GetString( 12 ),
							ShipCountry = rdr.IsDBNull( 13 ) ? (String)null : rdr.GetString( 13 ),
						};
						allResults.Result1.Add( row );
					}

					await rdr.NextResultAsync().ConfigureAwait(false);

					return allResults;
				}
			}
		}

	}

	public class TestResult
	{
			
		public class Result0Row
		{
			public Int32 ProductID { get; set; }
			public String ProductName { get; set; }
			public Int32? SupplierID { get; set; }
			public Int32? CategoryID { get; set; }
			public String QuantityPerUnit { get; set; }
			public Decimal? UnitPrice { get; set; }
			public Int16? UnitsInStock { get; set; }
			public Int16? UnitsOnOrder { get; set; }
			public Int16? ReorderLevel { get; set; }
			public Boolean Discontinued { get; set; }
		}

		public List<Result0Row> Result0 { get; set; }

			
		public class Result1Row
		{
			public Int32 OrderID { get; set; }
			public String CustomerID { get; set; }
			public Int32? EmployeeID { get; set; }
			public DateTime? OrderDate { get; set; }
			public DateTime? RequiredDate { get; set; }
			public DateTime? ShippedDate { get; set; }
			public Int32? ShipVia { get; set; }
			public Decimal? Freight { get; set; }
			public String ShipName { get; set; }
			public String ShipAddress { get; set; }
			public String ShipCity { get; set; }
			public String ShipRegion { get; set; }
			public String ShipPostalCode { get; set; }
			public String ShipCountry { get; set; }
		}

		public List<Result1Row> Result1 { get; set; }

	}
}
