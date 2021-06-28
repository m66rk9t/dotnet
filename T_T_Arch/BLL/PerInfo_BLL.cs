using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class PerInfo_BLL
    {

        //创建PerInfo_DAL对象
        private PerInfo_DAL pd = new PerInfo_DAL();

        //添加数据
        public int AddInfo(string stdNum, string name, string sex, string nation, string e_mail, string pn)
        {
            return pd.AddInfo(stdNum, name, sex, nation, e_mail, pn);
        }

        //删除数据
        public int DeleteInfoByNum(string stdNum)
        {
            return pd.DeleteInfoByNum(stdNum);
        }

        //更新数据
        public int UpdatePN(string phoneNumber, string name)
        {
            return pd.UpdatePN(phoneNumber, name);
        }

        //查询数据
        public PerInfo_Model GetInfoByNum(string stdNum)
        {
            return pd.GetInfoByNum(stdNum);
        }

    }
}
