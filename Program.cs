using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid
{
    class Program
    {
        static int LineCount = 3;
        static void Main(string[] args)
        {
            List<string> XList = GetLines(3);
            int Count = LineCount * LineCount;
            string StrPsw = "";
            int PswCount = 0;
            for (int a = 1; a <= Count; a++)
            {
                for (int b = 1; b <= Count; b++)
                {
                    if (b == a)
                        continue;
                    for (int c = 1; c <= Count; c++)
                    {
                        if (c == a || c == b)
                            continue;
                        for (int d = 1; d <= Count; d++)
                        {
                            if (d == a || d == b || d == c)
                                continue;
                            StrPsw = a.ToString("X")+b.ToString("X")+c.ToString("X")+d.ToString("X");
                            if (!Check(StrPsw, XList))
                               PswCount++;
                            for (int e = 1; e <= Count; e++)
                            {
                                if (e == a || e == b || e == c || e == d)
                                    continue;
                                StrPsw = a.ToString("X") + b.ToString("X") + c.ToString("X") + d.ToString("X") + e.ToString("X");
                                if (!Check(StrPsw, XList))
                                    PswCount++;
                                for (int f = 1; f <= Count; f++)
                                {
                                    if (f == a || f == b || f == c || f == d || f == e)
                                        continue;
                                    StrPsw = a.ToString("X") + b.ToString("X") + c.ToString("X") + d.ToString("X") + e.ToString("X") + f.ToString("X");
                                    if (!Check(StrPsw, XList))
                                        PswCount++;
                                    for (int g = 1; g <= Count; g++)
                                    {
                                        if (g == a || g == b || g == c || g == d || g == e || g == f)
                                            continue;
                                        StrPsw = a.ToString("X") + b.ToString("X") + c.ToString("X") + d.ToString("X") + e.ToString("X") + f.ToString("X") + g.ToString("X");
                                        if (!Check(StrPsw, XList))
                                            PswCount++;
                                        for (int h = 1; h <= Count; h++)
                                        {
                                            if (h == a || h == b || h == c || h == d || h == e || h == f || h == g)
                                                continue;
                                            StrPsw = a.ToString("X") + b.ToString("X") + c.ToString("X") + d.ToString("X") + e.ToString("X") + f.ToString("X") + g.ToString("X") + h.ToString("X");
                                            if (!Check(StrPsw, XList))
                                                PswCount++;
                                            for (int i = 1; i <= Count; i++)
                                            {
                                                if (i == a || i == b || i == c || i == d || i == e || i == f || i == g || i == h)
                                                    continue;
                                                StrPsw = a.ToString("X") + b.ToString("X") + c.ToString("X") + d.ToString("X") + e.ToString("X") + f.ToString("X") + g.ToString("X") + h.ToString("X") + i.ToString("X");
                                                if (!Check(StrPsw, XList))
                                                    PswCount++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(PswCount);
        }

        static bool Check(string psw,List<string> XList)
        {
            foreach (string str in XList)
                if (X(psw,str[0],str[1],str[2]))
                    return true;
            return false;
        }

        static List<string> GetLines(int m)
        {
            List<string> XItemList = new List<string>();
            string XItem = "";
            //横
            for (int i = 1; i < m*m; i += m)
            {
                XItem = "";
                for (int j = 0; j < m; j++)
                    XItem += (i+j).ToString("X");
                XItemList.Add(XItem);
            }
            //竖
            for (int i = 1; i <= m; i++)
            {
                XItem = "";
                for (int j = i; j <= m * m; j += m)
                    XItem += j.ToString("X"); ;
                XItemList.Add(XItem);
            }
            //对角
            XItem = "";
            for (int i = 0; i < m; i++)
            {
                XItem += (i * m + i + 1).ToString("X"); ;
            }
            XItemList.Add(XItem);
            XItem = "";
            for (int i = 1; i <= m; i++)
            {
                XItem += (i * m - i + 1).ToString("X"); ;
            }
            XItemList.Add(XItem);
            return XItemList;
        }
        
        //a和c是不能连续的两个数，b是a和c中间的数
        static bool X(string s, char a, char b, char c)
        {            
            int ib = s.IndexOf(b);

            int ia = s.IndexOf(a);
            if (ia < 0)
                return false;           
            int ic = s.IndexOf(c);
            if (ic < 0)
                return false;
            if (ia + 1 == ic)
                if (ib < 0 || (ib > ic))
                    return true;
            if(ia -1 == ic)
                if (ib < 0 || (ib > ia))
                    return true;
            return false;
        }
    }
}
