// MyBlog.Data.SQLiteHelper
using System;
using System.Data;
using System.Data.SQLite;

public class SQLiteHelper : IDisposable
{
    private SQLiteConnection _SQLiteConn = null;

    private SQLiteTransaction _SQLiteTrans = null;

    private bool _IsRunTrans = false;

    private string _SQLiteConnString = null;

    private bool _disposed = false;

    private bool _autocommit = false;

    public string ConnectionString => _SQLiteConnString;

    public bool AutoCommit
    {
        get
        {
            return _autocommit;
        }
        set
        {
            _autocommit = value;
        }
    }

    public SQLiteHelper()
    {
    }

    public SQLiteHelper(string connectionstring)
    {
        _SQLiteConnString = connectionstring;
        _SQLiteConn = new SQLiteConnection(_SQLiteConnString);
        _SQLiteConn.Commit += _SQLiteConn_Commit;
        _SQLiteConn.RollBack += _SQLiteConn_RollBack;
    }

    ~SQLiteHelper()
    {
        Dispose(false);
    }

    private void Open()
    {
        if (_SQLiteConn.State == ConnectionState.Closed)
        {
            _SQLiteConn.Open();
        }
    }

    private void Close()
    {
        if (_SQLiteConn.State != 0)
        {
            if (_IsRunTrans && _autocommit)
            {
                Commit();
            }
            _SQLiteConn.Close();
        }
    }

    public void BeginTransaction()
    {
        _SQLiteConn.BeginTransaction();
        _IsRunTrans = true;
    }

    public void BeginTransaction(IsolationLevel isoLevel)
    {
        _SQLiteConn.BeginTransaction(isoLevel);
        _IsRunTrans = true;
    }

    public void Commit()
    {
        if (_IsRunTrans)
        {
            _SQLiteTrans.Commit();
            _IsRunTrans = false;
        }
    }

    public void Rollback()
    {
        if (_IsRunTrans)
        {
            _SQLiteTrans.Rollback();
            _IsRunTrans = false;
        }
    }

    public void Execute(string[] command)
    {
        Open();
        BeginTransaction();
        try
        {
            using (SQLiteCommand sQLiteCommand = new SQLiteCommand())
            {
                for (int i = 0; i < command.Length; i++)
                {
                    sQLiteCommand.CommandText = command[i];
                    sQLiteCommand.ExecuteNonQuery();
                }
            }
            Commit();
        }
        catch (Exception)
        {
            Rollback();
            throw;
        }
        Close();
    }

    public int Execute(string command)
    {
        int result = -1;
        Open();
        using (SQLiteCommand sQLiteCommand = new SQLiteCommand(command))
        {
            result = sQLiteCommand.ExecuteNonQuery();
        }
        Close();
        return result;
    }

    public int Execute(string command, SQLiteParameter[] parameter)
    {
        int result = -1;
        Open();
        using (SQLiteCommand sQLiteCommand = new SQLiteCommand(command))
        {
            sQLiteCommand.Parameters.AddRange(parameter);
            result = sQLiteCommand.ExecuteNonQuery();
        }
        Close();
        return result;
    }

    public object ExecuteScalar(string command)
    {
        object result = null;
        Open();
        using (SQLiteCommand sQLiteCommand = new SQLiteCommand(command))
        {
            result = sQLiteCommand.ExecuteScalar();
        }
        Close();
        return result;
    }

    public object ExecuteScalar(string command, SQLiteParameter[] parmeter)
    {
        object result = null;
        Open();
        using (SQLiteCommand sQLiteCommand = new SQLiteCommand(command))
        {
            sQLiteCommand.Parameters.AddRange(parmeter);
            result = sQLiteCommand.ExecuteScalar();
        }
        Close();
        return result;
    }

    public DataSet GetDs(string command)
    {
        return GetDs(command, string.Empty);
    }

    public DataSet GetDs(string command, string tablename)
    {
        DataSet dataSet = new DataSet();
        Open();
        using (SQLiteCommand cmd = new SQLiteCommand(command, _SQLiteConn))
        {
            using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd))
            {
                if (string.Empty.Equals(tablename))
                {
                    sQLiteDataAdapter.Fill(dataSet);
                }
                else
                {
                    sQLiteDataAdapter.Fill(dataSet, tablename);
                }
            }
        }
        Close();
        return dataSet;
    }

    public DataSet GetDs(string command, out SQLiteCommand SqlItecmd)
    {
        return GetDs(command, string.Empty, out SqlItecmd);
    }

    public DataSet GetDs(string command, string tablename, out SQLiteCommand SqlItecmd)
    {
        DataSet dataSet = new DataSet();
        Open();
        SQLiteCommand sQLiteCommand = new SQLiteCommand(command, _SQLiteConn);
        using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(sQLiteCommand))
        {
            sQLiteDataAdapter.Fill(dataSet);
        }
        SqlItecmd = sQLiteCommand;
        Close();
        return dataSet;
    }

    public int Update(DataSet ds, ref SQLiteCommand SqlItecmd)
    {
        return Update(ds, string.Empty, ref SqlItecmd);
    }

    public int Update(DataSet ds, string tablename, ref SQLiteCommand SqlItecmd)
    {
        int result = -1;
        Open();
        using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(SqlItecmd))
        {
            using (new SQLiteCommandBuilder(sQLiteDataAdapter))
            {
                result = ((!string.Empty.Equals(tablename)) ? sQLiteDataAdapter.Update(ds, tablename) : sQLiteDataAdapter.Update(ds));
            }
        }
        Close();
        return result;
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }
        if (!disposing)
        {
            goto IL_0016;
        }
        goto IL_0016;
    IL_0016:
        _disposed = true;
    }

    private void _SQLiteConn_RollBack(object sender, EventArgs e)
    {
        _IsRunTrans = false;
    }

    private void _SQLiteConn_Commit(object sender, CommitEventArgs e)
    {
        _IsRunTrans = false;
    }
}
