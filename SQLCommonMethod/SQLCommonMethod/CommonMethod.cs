using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLCommonMethod
{
    public static class CommonMethod
    {
        //连接字符串属性
        public static string connStr { get; set; }

        //ExecuteNonQuery方法，适用于增加、删除、更新数据的方法
        public static int ExecuteNonQuery(string cmdText,params SqlParameter[] sqlParameters)
        {
            //声明存储返回值的变量
            int result = default;

            //创建SqlConnection对象
            using(SqlConnection sqlConn=new SqlConnection(connStr))
            {
                //打开数据库
                sqlConn.Open();

                //创建SqlCommand对象
                using(SqlCommand sqlCmd=new SqlCommand(cmdText,sqlConn))
                {
                    //向SqlParameter的末尾添加一个SqlParameterCollection值数组
                    sqlCmd.Parameters.AddRange(sqlParameters);
                    //执行ExecuteNonQuery方法
                    result = sqlCmd.ExecuteNonQuery();
                    //从SqlParameter中移除所有SqlParameterCollection对象
                    sqlCmd.Parameters.Clear();
                }
            }

            //返回值
            return result;
        }

        //ExecuteScalar方法，适用于查询某条数据的某一列
        public static object ExecuteScalar(string cmdText, params SqlParameter[] sqlParameters)
        {
            //声明存储返回值的变量
            object result = null;

            //创建SqlConnection对象
            using(SqlConnection sqlConn=new SqlConnection(connStr))
            {
                //打开数据库
                sqlConn.Open();

                //创建SqlCommand对象
                using(SqlCommand sqlCmd=new SqlCommand(cmdText,sqlConn))
                {
                    //向SqlParameter的末尾添加一个SqlParameterCollection值数组
                    sqlCmd.Parameters.AddRange(sqlParameters);
                    //执行ExecuteScalar方法
                    result = sqlCmd.ExecuteScalar();
                    //从SqlParameter中移除所有SqlParameterCollection对象
                    sqlCmd.Parameters.Clear();
                }
            }

            //返回值
            return result;
        }
        
        //GetDataSet方法，适用于查询并输出数据的方法
        public static DataSet GetDataSet(string cmdText, params SqlParameter[] sqlParameters)
        {
            //声明存储返回值的变量
            DataSet ds = new DataSet();

            //创建SqlDataAdapter对象
            using(SqlDataAdapter sda=new SqlDataAdapter(cmdText,connStr))
            {
                //向SqlParameter的末尾添加一个SqlParameterCollection值数组
                sda.SelectCommand.Parameters.AddRange(sqlParameters);
                //将查询结果添加到DataSet对象中
                sda.Fill(ds);
                //从SqlParameter中移除所有SqlParameterCollection对象
                sda.SelectCommand.Parameters.Clear();
            }

            //返回值
            return ds;
        }
 
        //ExecuteReader方法，适用于查询并输出数据的方法
        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] sqlParameters)
        {
            //创建SqlConnection对象
            SqlConnection sqlCon = null;

            //创建SqlDataReader对象
            SqlDataReader sdr = null;           

            try
            {
                //实例化SqlConnection对象
                sqlCon = new SqlConnection(connStr);
                //打开数据库
                sqlCon.Open();
                //创建SqlCommand对象
                SqlCommand sqlCmd = new SqlCommand(cmdText, sqlCon);
                //向SqlParameter的末尾添加一个SqlParameterCollection值数组
                sqlCmd.Parameters.AddRange(sqlParameters);
                //执行ExecuteReader方法
                sdr = sqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); ;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //关闭数据库连接
                sqlCon.Close();
                //释放资源
                sqlCon.Dispose();
            }

            //返回值
            return sdr;
        }
    }
}