using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using project_clz;


namespace project_clz
{
    internal class SqlHelper
    {
        public SqlConnection cn;
        public SqlDataAdapter da;
        public SqlCommand cm;
        public DataSet ds = new DataSet();
        public SqlDataReader myreader;
        public DataTable dt = new DataTable();
        public SqlHelper()
        {

            try
            {
                cn = new SqlConnection (ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);

                cn.Open();
            }
            catch

            {


            }
        }
        public int Dmlstmt(string s)
        {
            try
            {
                cm = new SqlCommand(s, cn);
                cm.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Fill(string s)
        {
            try
            {
                cm = new SqlCommand(s, cn);
                myreader = cm.ExecuteReader();
                return 1;
            }
            catch
            {
                return 0;
            }
        }



        public DataSet Fetch(string s)
        {
            da = new SqlDataAdapter(s, cn);

            ds.Clear();
            ds.Reset();
            da.Fill(ds);
            return ds;
        }
        public DataTable DatagridFetch(string s)
        {
            da = new SqlDataAdapter(s, cn);

            ds.Clear();
            ds.Reset();
            da.Fill(ds);

            dt = ds.Tables[0];
            return dt;
        }

    }
}