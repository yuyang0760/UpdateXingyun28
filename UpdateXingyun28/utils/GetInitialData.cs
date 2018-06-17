// Pceggs._1获取原始数据.GetInitialData
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

internal class GetInitialData
{
    private string getWebresource(string url)
    {
        try
        {
            WebClient webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            Stream stream = webClient.OpenRead(url);
            if (stream == null)
            {
                return "";
            }
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            string text = streamReader.ReadToEnd();
            if (text == null || text == "")
            {
                return "";
            }
            stream.Close();
            webClient.Dispose();
            return text;
        }
        catch (Exception)
        {
            return "";
        }
    }

    public List<BJKL8> getBJKL8(DateTime dt)
    {
        string url = "http://kaijiang.500.com/static/info/kaijiang/xml/kl8/" + dt.ToString("yyyyMMdd") + ".xml";
        string webresource = getWebresource(url);
        if (webresource == "")
        {
            return null;
        }
        // 解析 webresource
        XmlControl xmlControl = new XmlControl();
        xmlControl.LoadXmlString(webresource);
        XmlNodeList xmlNodeList = xmlControl.SelectNodes("row");
        List<BJKL8> bJKL8List = new List<BJKL8>();
        foreach (XmlNode item in xmlNodeList)
        {
            BJKL8 bJKL8 = new BJKL8();
            bJKL8.Expect = int.Parse(item.SelectSingleNode("@expect").Value);
            bJKL8.Opentime = Convert.ToDateTime(item.SelectSingleNode("@opentime").Value);
            string[] sArr = item.SelectSingleNode("@opencode").Value.Split(',');
            List<int> list = new List<int>();
            foreach (string item1 in sArr)
            {
                list.Add(int.Parse(item1));
            }
            bJKL8.ListOpencode = list;
            bJKL8List.Add(bJKL8);
        }
        bJKL8List.Reverse();
        return bJKL8List;
      
    }
    // 从 https://168kai.com/ 获取
    public List<BJKL8> getBJKL8_by168kai(DateTime dt)
    {
        // https://api.api68.com/LuckTwenty/getBaseLuckTwentyList.do?&lotCode=10014&date=2018-05-08
        string url = "http://api.api68.com/LuckTwenty/getBaseLuckTwentyList.do?&lotCode=10014&date=" + dt.ToString("yyyy-MM-dd");
        string webresource = getWebresource(url);
        if (webresource == "")
        {
            return null;
        }
        // 解析json  webresource
        JObject jo = (JObject)JsonConvert.DeserializeObject(webresource);
        //Console.WriteLine(jo["errorCode"]);
        //Console.WriteLine(jo["message"]);
        //Console.WriteLine(jo["result"]["businessCode"]);
        //Console.WriteLine(jo["result"]["data"]);
        //Console.WriteLine(jo["result"]["data"][0]["preDrawCode"]);

        if(jo["errorCode"].ToString() != "0" || jo["result"]["businessCode"].ToString()!="0")
        {
            return null;
        }
        List<BJKL8> bJKL8List = new List<BJKL8>();
        foreach (JObject item in jo["result"]["data"])
        {
            BJKL8 bJKL8 = new BJKL8();
            bJKL8.Expect = int.Parse(item["preDrawIssue"].ToString());
            bJKL8.Opentime = Convert.ToDateTime(item["preDrawTime"].ToString());
            string[] sArr = item["preDrawCode"].ToString().Split(',');
            if (sArr.Length < 2) { continue; }
            List<int> list = new List<int>();
            foreach (string item1 in sArr)
            {
                list.Add(int.Parse(item1));
            }
            bJKL8.ListOpencode = list;
            bJKL8List.Add(bJKL8);
        }
        bJKL8List.Reverse();
        return bJKL8List;

    }


    // 从 https://168kai.com/ 获取
    public List<PK10> getPK10_by168kai(DateTime dt)
    {
        // https://api.api68.com/pks/getPksHistoryList.do?lotCode=10001&date=2018-05-01
        string url = "https://api.api68.com/pks/getPksHistoryList.do?lotCode=10001&date=" + dt.ToString("yyyy-MM-dd");
        string webresource = getWebresource(url);
        if (webresource == "")
        {
            return null;
        }
        // 解析json  webresource
        JObject jo = (JObject)JsonConvert.DeserializeObject(webresource);
        //Console.WriteLine(jo["errorCode"]);
        //Console.WriteLine(jo["message"]);
        //Console.WriteLine(jo["result"]["businessCode"]);
        //Console.WriteLine(jo["result"]["data"]);
        //Console.WriteLine(jo["result"]["data"][0]["preDrawCode"]);

        if (jo["errorCode"].ToString() != "0" || jo["result"]["businessCode"].ToString() != "0")
        {
            return null;
        }
        List<PK10> Pk10List = new List<PK10>();
        foreach (JObject item in jo["result"]["data"])
        {
            PK10 pK10 = new PK10();
            pK10.Expect = int.Parse(item["preDrawIssue"].ToString());
            pK10.Opentime = Convert.ToDateTime(item["preDrawTime"].ToString());
            string[] sArr = item["preDrawCode"].ToString().Split(',');
            if (sArr.Length < 2) { continue; }
            List<int> list = new List<int>();
            foreach (string item1 in sArr)
            {
                list.Add(int.Parse(item1));
            }
            pK10.ListOpencode = list;
            Pk10List.Add(pK10);
        }
        Pk10List.Reverse();
        return Pk10List;

    }

    //public JNDKL8 getJNDKL8(DateTime dt)
    //{
    //    string url = "http://www.168kai.com/History/HisList?id=10041&date=" + dt.ToString("yyyy-MM-dd") + "&_=0.6148420795228382";
    //    string webresource = getWebresource(url);
    //    if (webresource == "")
    //    {
    //        return null;
    //    }
    //    JNDKL8 jNDKL = JsonConvert.DeserializeObject<JNDKL8>(webresource);
    //    //jNDKL.list.Reverse();
    //    return null;
    //}

    public List<PK10> getPK10(DateTime dt)
    {
        // http://kaijiang.500.com/static/info/kaijiang/xml/bjpkshi/20180508.xml?_A=BYLAPNGF1525816892243
        string url = "http://kaijiang.500.com/static/info/kaijiang/xml/bjpkshi/" + dt.ToString("yyyyMMdd") + ".xml";
        string webresource = getWebresource(url);
        if (webresource == "")
        {
            return null;
        }
        // 解析 webresource
        XmlControl xmlControl = new XmlControl();
        xmlControl.LoadXmlString(webresource);
        XmlNodeList xmlNodeList = xmlControl.SelectNodes("row");
        List<PK10> pK10List = new List<PK10>();
        foreach (XmlNode item in xmlNodeList)
        {
            PK10 pK10 = new PK10();
            pK10.Expect = int.Parse(item.SelectSingleNode("@expect").Value);
            pK10.Opentime = Convert.ToDateTime(item.SelectSingleNode("@opentime").Value);
            string[] sArr = item.SelectSingleNode("@opencode").Value.Split(',');
            List<int> list = new List<int>();
            foreach (string item1 in sArr)
            {
                list.Add(int.Parse(item1));
            }
            pK10.ListOpencode = list;
            pK10List.Add(pK10);
        }
        pK10List.Reverse();
        return pK10List;

    }
}
