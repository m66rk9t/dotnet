using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerInfo.UI
{
    public partial class Form_PerInfo : Form
    {
        public Form_PerInfo()
        {
            InitializeComponent();
        }

        private void Form_PerInfo_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“_2018ETDataSet.T_PerInfo”中。您可以根据需要移动或删除它。
            this.t_PerInfoTableAdapter.Fill(this._2018ETDataSet.T_PerInfo);

        }
    }
}
