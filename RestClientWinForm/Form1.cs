using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Rest;

namespace RestClientWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestTblaFill();
        }

        async void TestTblaFill()
        {
            //Dynamically create Table from class.
            //Not fullfil our requirements. Table structure should be created at design time
            //to use in Controls. Create maunally now.
            //var aaaa = CreateDataTable<TblaRec>();
            //dataSet1.Tables.Add(aaaa);


            var dt = dataSet1.Tables[0];
            //if (dt.Rows[0].RowState == DataRowState.
            dt.BeginLoadData();
            StringBuilder sb = new StringBuilder();
            int nor = 0, ml = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.TblaFill(new QryStr { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(token))
                {
                    var rec = response.ResponseStream.Current;
                    
                    row = dt.NewRow();

                    ObjectToRow(dt, row, rec);
                    /*
                    row["RowPk"] = rec.RowPk;
                    row["FldStr"] = rec.FldStr;
                    row["FldInt"] = rec.FldInt;
                    row["FldDbl"] = rec.FldDbl;
                    row["FldDate"] = new DateTime(rec.FldDate);
*/
                    dt.Rows.Add(row);
                    
                    sb.AppendLine(rec.RowPk.ToString());
                    nor++;
                    ml += rec.CalculateSize();
                    //MessageBox.Show(rec.Message);
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            sw.Stop();
            //MessageBox.Show(sb.ToString());
            MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestTblaUpdate();
        }

        void TestTblaUpdate()
        {
            var dt = dataSet1.Tables[0];
            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            var request = new TblaRec();

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);
                if (rs == "A" || rs == "M")
                {
                    request.RowState = rs;

                    RowToObject(dt, dt.Rows[i], request);

                    var reply = client.TblaUpdate(request);

                    ObjectToRow(dt, dt.Rows[i], reply);
                    //dt.Rows[i]["RowPk"] = reply.RowPk;

                    if (string.IsNullOrEmpty(reply.RowErr))
                        dt.Rows[i].AcceptChanges();
                    else
                        dt.Rows[i].RowError = reply.RowErr;
                }
            }
            channel.ShutdownAsync().Wait();
        }

        // Get table column value from obj
        public static void RowToObject(DataTable tbl, DataRow row, object obj)
        {
            string colName = "";
            object colVal = null;

            for (int c = 0; c < tbl.Columns.Count; c++)
            {
                colName = tbl.Columns[c].ColumnName;
                colVal = row[c];

                if (colVal != DBNull.Value)
                {
                    if (tbl.Columns[c].DataType.Name == "DateTime")
                        colVal = Convert.ToDateTime(colVal).Ticks;
                    else if (tbl.Columns[c].DataType.Name == "Decimal")
                        colVal = Convert.ToDouble(colVal);

                    obj.GetType().GetProperty(colName).SetValue(obj, colVal);
                }
            }
        }
        
        // Set obj from table column value
        public static void ObjectToRow(DataTable tbl, DataRow row, object obj)
        {
            string colName = "";
            object objVal = null;

            for (int c = 0; c < tbl.Columns.Count; c++)
            {
                colName = tbl.Columns[c].ColumnName;
                objVal = obj.GetType().GetProperty(colName).GetValue(obj);

                if (objVal != null)
                {
                    if (tbl.Columns[c].DataType.Name == "DateTime")
                        row[c] = Convert.ToDateTime(new DateTime((long)objVal));
                    else if (tbl.Columns[c].DataType.Name == "Decimal")
                        row[c] = Convert.ToDecimal(objVal);
                    else
                        row[c] = objVal;
                }
            }
        }

        public static DataTable CreateDataTable<T>()
        {
            var dt = new DataTable();

            var propList = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (MemberInfo info in propList)
            {
                if (info is PropertyInfo)
                    dt.Columns.Add(new DataColumn(info.Name, (info as PropertyInfo).PropertyType));
                else if (info is FieldInfo)
                    dt.Columns.Add(new DataColumn(info.Name, (info as FieldInfo).FieldType));
            }

            return dt;
        }

        public static void CopyProperties(object objSource, object objDestination)
        {
            //get the list of all properties in the destination object
            var destProps = objDestination.GetType().GetProperties();

            //get the list of all properties in the source object
            foreach (var sourceProp in objSource.GetType().GetProperties())
            {
                foreach (var destProperty in destProps)
                {
                    //if we find match between source & destination properties name, set
                    //the value to the destination property
                    if (destProperty.Name == sourceProp.Name &&
                            destProperty.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                    {
                        destProperty.SetValue(destProps, sourceProp.GetValue(
                            sourceProp, new object[] { }), new object[] { });
                        break;
                    }
                }
            }
        }
    }
}
