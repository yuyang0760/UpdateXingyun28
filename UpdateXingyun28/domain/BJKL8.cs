// Pceggs.domain.BJKL8
using System;
using System.Collections.Generic;

internal class BJKL8
{
    /// <summary>
    /// �ö��ŷָ����ַ���
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
