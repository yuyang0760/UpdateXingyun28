// Pceggs.domain.PK10
using System.Collections.Generic;
using System;
internal class PK10
{
    /// <summary>
    /// ÓÃ¶ººÅ·Ö¸ôµÄ×Ö·û´®
    /// </summary>
    public string Opencode
    {
        get
        {
            List<string> l = new List<string>();
            foreach (int item in ListOpencode)
            {
                l.Add(item.ToString());
            }
            return string.Join(",", l);
        }
    }
    public List<int> ListOpencode
    {
        get;
        set;
    }

    public DateTime Opentime
    {
        get;
        set;
    }

    public int Expect
    {
        get;
        set;
    }
}
