// Pceggs._2存入数据库.UpdataDb

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

internal class UpdataDb
{
    // 定义委托，异步调用  
 

    public void SaveWithBJKL8(string filePath, DateTime startDateTime, System.ComponentModel.BackgroundWorker worker )
    {
        string connectionString = "Data Source=" + filePath + ";Pooling=true;FailIfMissing=false";
        SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);
        sQLiteConnection.Open();
        SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();
        sQLiteCommand.CommandText = string.Format("SELECT max(shiJian) FROM BJKL8");
        sQLiteCommand.CommandType = CommandType.Text;
        DateTime dt;
        using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
        {
            sQLiteDataReader.Read();
            dt = ((!(((DbDataReader)sQLiteDataReader)[0].ToString() == "")) ? DateTime.Parse(((DbDataReader)sQLiteDataReader)[0].ToString()) : startDateTime);
        }
        sQLiteCommand.CommandText = string.Format("DELETE FROM  BJKL8  where shiJian>='{0}'", dt.ToString("yyyy-MM-dd"));
        sQLiteCommand.CommandType = CommandType.Text;
        sQLiteCommand.ExecuteNonQuery();
        Converts converts = new Converts();
        GetInitialData getInitialData = new GetInitialData();
        DbTransaction dbTransaction = sQLiteConnection.BeginTransaction();
        while (true)
        {
            string a = dt.ToString("yyyy-MM-dd");
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddDays(1.0);
            if (a != dateTime.ToString("yyyy-MM-dd"))
            {
                //dbf.Text = "正在更新:" + dt.ToString("yyyy-MM-dd");
                worker.ReportProgress(1, "正在更新:" + dt.ToString("yyyy-MM-dd"));//报告工作进度
                Console.WriteLine("正在更新:" + dt.ToString("yyyy-MM-dd"));
                // 如果查询的时间是今天,并且小于9:20,就不查询
                if(dt.ToString("yyyy-MM-dd")==DateTime.Now.ToString("yyyy-MM-dd") && 
                    DateTime.Compare(DateTime.Now,
                    DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")+" 09:15:00"))<0)
                {
                    dt = dt.AddDays(1.0); continue;
                }
                //List<BJKL8> bJKL = getInitialData.getBJKL8(dt);getBJKL8_by168kai
                List<BJKL8> bJKL = getInitialData.getBJKL8_by168kai(dt);
                if (bJKL == null) { dt = dt.AddDays(1.0); continue; };
                for (int i = 0; i < bJKL.Count; i++)
                {
                    int[] numList = bJKL[i].ListOpencode.ToArray();
                    SQLiteCommand sQLiteCommand2 = sQLiteCommand;
                    object[] array = new object[8];
                    array[0] = bJKL[i].Opentime.ToString("yyyy-MM-dd HH:mm:ss");
                    array[1] = bJKL[i].Opencode;
                    array[2] = bJKL[i].Expect;
                    array[3] = converts.toPC28(numList);
                    array[4] = converts.toBJ28(numList);
                    array[5] = converts.toBJ16(numList);
                    array[6] = converts.toBJ36ZN(numList);
                    array[7] = converts.toBJ36(numList);
                    sQLiteCommand2.CommandText = string.Format("INSERT INTO BJKL8(shiJian,neiRong,qiHao,PC28,BJ28,BJ16,BJ36ZN,BJ36) VALUES ('{0}', '{1}',{2}, {3},{4}, {5},'{6}',{7})", array);
                    sQLiteCommand.ExecuteNonQuery();
                }
                dt = dt.AddDays(1.0);
                continue;
            }
            break;
        }
        dbTransaction.Commit();
        sQLiteCommand.Dispose();
        sQLiteConnection.Close();
        sQLiteConnection.Dispose();
    }

    //public void SaveWithJNDKL8(DatabaseForm dbf, string filePath, DateTime startDateTime)
    //{
    //    string connectionString = "Data Source=" + filePath + ";Pooling=true;FailIfMissing=false";
    //    SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);
    //    sQLiteConnection.Open();
    //    SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();
    //    sQLiteCommand.CommandText = string.Format("SELECT max(shiJian) FROM JNDKL8");
    //    sQLiteCommand.CommandType = CommandType.Text;
    //    DateTime dt;
    //    using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
    //    {
    //        sQLiteDataReader.Read();
    //        dt = ((!(((DbDataReader)sQLiteDataReader)[0].ToString() == "")) ? DateTime.Parse(((DbDataReader)sQLiteDataReader)[0].ToString()) : startDateTime);
    //    }
    //    sQLiteCommand.CommandText = string.Format("DELETE FROM  JNDKL8  where shiJian>='{0}'", dt.ToString("yyyy-MM-dd"));
    //    sQLiteCommand.CommandType = CommandType.Text;
    //    sQLiteCommand.ExecuteNonQuery();
    //    Converts converts = new Converts();
    //    GetInitialData getInitialData = new GetInitialData();
    //    DbTransaction dbTransaction = sQLiteConnection.BeginTransaction();
    //    while (true)
    //    {
    //        string a = dt.ToString("yyyy-MM-dd");
    //        DateTime dateTime = DateTime.Now;
    //        dateTime = dateTime.AddDays(1.0);
    //        if (a != dateTime.ToString("yyyy-MM-dd"))
    //        {
    //            dbf.Text = "正在更新:" + dt.ToString("yyyy-MM-dd");
    //            List<JNDKL8list> jNDKL = getInitialData.getJNDKL8(dt);
    //            for (int i = 0; i < jNDKL.Count; i++)
    //            {
    //                int[] numList = jNDKL[i].getNumList();
    //                SQLiteCommand sQLiteCommand2 = sQLiteCommand;
    //                object[] array = new object[6];
    //                object[] array2 = array;
    //                dateTime = jNDKL[i].getTime(dt.ToString("yyyy/MM/dd"));
    //                array2[0] = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
    //                array[1] = jNDKL[i].cTermResult;
    //                array[2] = jNDKL[i].getQiHao();
    //                array[3] = converts.toJND28(numList);
    //                array[4] = converts.toJND16(numList);
    //                array[5] = converts.toJND11(numList);
    //                sQLiteCommand2.CommandText = string.Format("INSERT INTO JNDKL8(shiJian,neiRong,qiHao,JND28,JND16,JND11) VALUES ('{0}', '{1}',{2}, {3},{4}, {5})", array);
    //                sQLiteCommand.ExecuteNonQuery();
    //            }
    //            dt = dt.AddDays(1.0);
    //            continue;
    //        }
    //        break;
    //    }
    //    dbTransaction.Commit();
    //    sQLiteCommand.Dispose();
    //    dbf.Text = "更新数据库";
    //    sQLiteConnection.Close();
    //    sQLiteConnection.Dispose();
    //}

    public void SaveWithPK10( string filePath, DateTime startDateTime, System.ComponentModel.BackgroundWorker worker)
    {
        string connectionString = "Data Source=" + filePath + ";Pooling=true;FailIfMissing=false";
        SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);
        sQLiteConnection.Open();
        SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();
        sQLiteCommand.CommandText = string.Format("SELECT max(shiJian) FROM PK10");
        sQLiteCommand.CommandType = CommandType.Text;
        DateTime dt;
        using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
        {
            sQLiteDataReader.Read();
            dt = ((!(((DbDataReader)sQLiteDataReader)[0].ToString() == "")) ? DateTime.Parse(((DbDataReader)sQLiteDataReader)[0].ToString()) : startDateTime);
        }
        sQLiteCommand.CommandText = string.Format("DELETE FROM  PK10  where shiJian>='{0}'", dt.ToString("yyyy-MM-dd"));
        sQLiteCommand.CommandType = CommandType.Text;
        sQLiteCommand.ExecuteNonQuery();
        Converts converts = new Converts();
        GetInitialData getInitialData = new GetInitialData();
        DbTransaction dbTransaction = sQLiteConnection.BeginTransaction();
        while (true)
        {
            string a = dt.ToString("yyyy-MM-dd");
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddDays(1.0);
            if (a != dateTime.ToString("yyyy-MM-dd"))
            {
                //dbf.Text = "正在更新:" + dt.ToString("yyyy-MM-dd");
                worker.ReportProgress(1, "正在更新:" + dt.ToString("yyyy-MM-dd"));//报告工作进度
                Console.WriteLine("正在更新:" + dt.ToString("yyyy-MM-dd"));
                // 如果查询的时间是今天,并且小于9:20,就不查询
                if (dt.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                    DateTime.Compare(DateTime.Now,
                    DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 09:15:00")) < 0)
                {
                    dt = dt.AddDays(1.0); continue;
                }

                //List<PK10> pK = getInitialData.getPK10(dt);getPK10_by168kai
                List<PK10> pK = getInitialData.getPK10_by168kai(dt);
                for (int i = 0; i < pK.Count; i++)
                {
                    int[] numList = pK[i].ListOpencode.ToArray();  
                    SQLiteCommand sQLiteCommand2 = sQLiteCommand;
                    object[] array = new object[6];
                    array[0] = pK[i].Opentime.ToString("yyyy-MM-dd HH:mm:ss");
                    array[1] = pK[i].Opencode;
                    array[2] = pK[i].Expect;
                    array[3] = converts.toPK10GJ(numList);
                    array[4] = converts.toPK10QH(numList, pK[i].Expect);
                    array[5] = converts.toPK22GJ(numList);
                    sQLiteCommand2.CommandText = string.Format("INSERT INTO PK10(shiJian,neiRong,qiHao,PK10GJ,PK10QH,PK22GJ) VALUES ('{0}', '{1}',{2}, {3},{4}, {5})", array);
                    sQLiteCommand.ExecuteNonQuery();
                }
                dt = dt.AddDays(1.0);
                continue;
            }
            break;
        }
        dbTransaction.Commit();
        sQLiteCommand.Dispose();
        sQLiteConnection.Close();
        sQLiteConnection.Dispose();
    }
}
