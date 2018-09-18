using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LazyOrm
{
	public static class Program
	{
		public static void Main( String[] args )
		{
			const String connectionString = @"Server=server.in.dai.me;Database=myDataBase;Trusted_Connection=True;";

			List<Tuple<Table,Column>> allColumns = new List<Tuple<Table,Column>>();

			using( SqlConnection c = new SqlConnection( connectionString ) )
			{
				c.Open();

				using( SqlCommand cmd = c.CreateCommand() )
				{
					cmd.CommandText = @"
SELECT
	TABLE_SCHEMA,
	TABLE_NAME,
	ORDINAL_POSITION,
	COLUMN_NAME,
	DATA_TYPE,
	CASE IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END AS IS_NULLABLE,
	COLUMNPROPERTY( OBJECT_ID( TABLE_SCHEMA + '.' + TABLE_NAME ), COLUMN_NAME, 'IsIdentity' ) AS IS_IDENTITY
FROM
	INFORMATION_SCHEMA.COLUMNS
ORDER BY
	TABLE_SCHEMA,
	TABLE_NAME,
	ORDINAL_POSITION";

					using( SqlDataReader rdr = cmd.ExecuteReader() )
					{
						while( rdr.Read() )
						{
							Table table = new Table()
							{
								Schema = rdr.GetString(0),
								Name = rdr.GetString(1)
							};

							Column col = new Column()
							{
								Ordinal = rdr.GetInt32(2),
								Name = rdr.GetString(3),
								Type = rdr.GetString(4),
								IsNullabe = rdr.GetInt32(5) == 1,
								IsIdentity = rdr.GetInt32(6) == 1
							};

							allColumns.Add( Tuple.Create(table,col) );
						}
					}
				}
			}

			List<Table> allTables = allColumns
				.GroupBy( tuple => new { tuple.Item1.Schema, tuple.Item1.Name } )
				.Select( grp =>
					new Table()
					{
						Schema = grp.Key.Schema,
						Name   = grp.Key.Name,
						Columns = grp
							.Select( t => t.Item2 )
							.OrderBy( c => c.Ordinal )
							.ToList()
					} )
				.ToList();

			////////////////////////

		}



		class Table
		{
			public String Schema;
			public String Name;

			public List<Column> Columns;
		}

		class Column
		{
			public Int32 Ordinal;
			public String Name;
			public String Type;
			public Boolean IsNullabe;
			public Boolean IsIdentity;
		}
	}
}
