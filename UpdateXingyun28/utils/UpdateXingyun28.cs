using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateXingyun28
{
    class UpdateXingyun28
    {
 
        /// <summary>
        /// 查找数据库 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> search(string type)
        {
            //listBox1.Items.Clear();
            string str = "pceggs.db";
            string connectionString = "Data Source=" + str + ";Pooling=true;FailIfMissing=false";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);
            sQLiteConnection.Open();
            SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();
            sQLiteCommand.CommandText = string.Format("SELECT distinct(date(shiJian)) FROM " + type);
            sQLiteCommand.CommandType = CommandType.Text;
                List<string> result = new List<string>();
            using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
            {
                while (sQLiteDataReader.Read())
                {
                    result.Add(sQLiteDataReader.GetString(0));
                }
            }
            sQLiteCommand.Dispose();
            sQLiteConnection.Close();
            return result;
        }
    }
}
