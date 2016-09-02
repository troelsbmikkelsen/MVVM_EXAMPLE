using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_EXAMPLE {
    public static class DatabaseAccess {

        //private static string connectionString = @"Data Source = CV-PC-T-04\SQLEXPRESS; Initial Catalog = Test; Integrated Security = True";
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Test.mdf;Integrated Security=True;Connect Timeout=30";

        private static DataTable Select(string query, params SqlParameter[] parameters) {
            DataTable dt = new DataTable();
            using (SqlConnection myConnection = new SqlConnection(connectionString)) {
                myConnection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection)) {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parameters) {
                        adapter.SelectCommand.Parameters.Add(param);
                    }
                    adapter.Fill(dt);
                }

            }

            return dt;
        }



        public static Member GetMemberById(int id) {
            DataTable dt = Select("GetMemberById", new SqlParameter("id", id));

            Member m = new Member {
                Fornavn = (string)dt.Rows[0]["Fornavn"],
                Efternavn = (string)dt.Rows[0]["Efternavn"],
            };

            return m;
        }

        public static Member GetMemberNr(int nr) {
            DataTable dt = Select("GetMemberNr", new SqlParameter("nr", nr));

            Member m = new Member {
                Fornavn = (string)dt.Rows[0]["Fornavn"],
                Efternavn = (string)dt.Rows[0]["Efternavn"],
            };

            return m;
        }
    }
}
