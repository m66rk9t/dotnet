using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    class ToModel
    {
        public static PerInfo_Model DataRowToModel(DataRow dr)
        {
            PerInfo_Model pm = null;

            if (dr != null)
            {
                pm = new PerInfo_Model();
                pm.StdNum = dr["StdNum"].ToString();
                pm.Name = dr["Name"].ToString();
                pm.Sex = dr["Sex"].ToString();
                pm.Nation = dr["Nation"].ToString();
                pm.E_Mail = dr["E_Mail"].ToString();
                pm.PhoneNumber = dr["PhoneNumber"].ToString();
            }

            return pm;
        }
    }
}