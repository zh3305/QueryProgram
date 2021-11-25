using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryProgram
{
    public partial class UserControl1 : UserControl
    {
        private readonly string _execlDataPath;
        DataTable MainData;
        public UserControl1(string execlDataPath)
        {
            _execlDataPath = execlDataPath;
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
           _=  LoadAsync();
        }

        public async Task LoadAsync()
        {
            MainData = await ExcelHelper.ExcelToDataTable(_execlDataPath);
            metroGrid1.DataSource = MainData;
            // metroGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public void search(string searchtext)
        {
          // var data=  MainData
          //   .Rows
          //   .Cast<DataRow>()
          //   .Where(r => r.ItemArray.Any(
          //       c => c.ToString().IndexOf(searchtext, StringComparison.OrdinalIgnoreCase) > 0
          //   )).CopyToDataTable();

       var data =  MainData.AsEnumerable().Where
              (row =>  row.ItemArray.Select(p => p.ToString()).Any<string>(s => s.Contains(searchtext))).ToArray();
       if (data.Any())
       {
           metroGrid1.DataSource = data.CopyToDataTable();
       }
       else
       {
           metroGrid1.DataSource = MainData.Clone();
       }

          // 
          //     .Rows
          //     .Cast<DataRow>()
          //     .Where(r => r.ItemArray.Any(
          //         c => c.ToString().IndexOf(searchtext, StringComparison.OrdinalIgnoreCase) > 0
          //     )).ToArray();
        }
    }
}
