using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using SQLCommonMethod;
using System.Data;

namespace DAL
{
    //数据访问层
    public class PerInfo_DAL
    {

        //CRUD操作

        //添加数据的方法
        public int AddInfo(string stdNum, string name, string sex, string nation, string e_mail, string pn)
        {
            //拼接SQL语句
            string cmdText = @"INSERT INTO T_PerInfo VALUES(@StdNum,@Name,@Sex,@Nation,@E_Mail,@PhoneNumber)";

            //创建SqlParameter对象，获取参数
            SqlParameter[] sp = new SqlParameter[6];
            sp[0] = new SqlParameter("@StdNum", SqlDbType.Char, 12);
            sp[0].Value = stdNum;
            sp[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 6);
            sp[1].Value = name;
            sp[2] = new SqlParameter("@Sex", SqlDbType.NChar, 2);
            sp[2].Value = sex;
            sp[3] = new SqlParameter("@Nation", SqlDbType.NVarChar, 10);
            sp[3].Value = nation;
            sp[4] = new SqlParameter("@E_Mail", SqlDbType.NVarChar, 100);
            sp[4].Value = e_mail;
            sp[5] = new SqlParameter("@PhoneNumber", SqlDbType.Char, 11);
            sp[5].Value = pn;

            //返回影响行数
            return CommonMethod.ExecuteNonQuery(cmdText, sp);
        }

        //删除数据的方法
        public int DeleteInfoByNum(string stdNum)
        {
            //拼接SQL语句
            string cmdText = "DELETE FROM T_PerInfo WHERE StdNum=@Stdnum";

            //创建SqlParameter对象
            SqlParameter sp = new SqlParameter("@Stdnum", SqlDbType.Char, 12);
            sp.Value = stdNum;

            //返回影响行数
            return CommonMethod.ExecuteNonQuery(cmdText, sp);

        }

        //更新数据的方法
        public int UpdatePN(string phoneNumber, string name)
        {
            //拼接SQL语句
            string cmdText = @"UPDATE T_PerInfo SET PhoneNumber=@NewPN WHERE Name=@Name";

            //SqlParameter对象，获取参数“姓名”
            SqlParameter spName = new SqlParameter("@Name", SqlDbType.NVarChar, 6);
            spName.Value = name;

            //SqlParameter对象，获取参数“新电话号码”
            SqlParameter spPN = new SqlParameter("@NewPN", SqlDbType.Char, 11);
            spPN.Value = phoneNumber;

            //返回影响行数
            return CommonMethod.ExecuteNonQuery(cmdText, spPN, spName);

        }

        //查询数据的方法
        public PerInfo_Model GetInfoByNum(string stdNum)
        {
            string cmdText = @"SELECT * FROM T_PerInfo WHERE StdNum=@StdNum";
            SqlParameter sp = new SqlParameter("@StdNum", SqlDbType.Char, 12);
            sp.Value = stdNum;
            DataSet ds = CommonMethod.GetDataSet(cmdText, sp);
            if (ds.Tables.Count > 0)
            {
                return ToModel.DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

    }
}