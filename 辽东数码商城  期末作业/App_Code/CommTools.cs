using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
/// <summary>
/// CommTools 的摘要说明
/// </summary>
public class CommTools
{
	
    public static void alert(Page page, string msg)
    {
        string scriptString = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", " "), scriptString, true);
    }
    #region LenString 计算字符串的长度，一个汉字占两个字节
    /// <summary>
    /// 计算字符串的长度，一个汉字占两个字节
    /// </summary>
    /// <param name="myStr">需要计算长度的字符串</param>
    /// <returns>字符串的长度</returns>
    public static int LenString(string myStr)
    {
        if (myStr == null || myStr == "")
        {
            return 0;
        }
        string mytext = myStr;
        int n = 0;
        foreach (char chr in mytext)
        {
            if (((int)chr) < 0 || ((int)chr) > 126)
                n = n + 2;
            else
                n = n + 1;
        }
        return n;
    }
    #endregion

    #region LeftString 从左边截取字符串，一个汉字占两个字节
    /// <summary>
    /// 从左边截取字符串，一个汉字占两个字节
    /// </summary>
    /// <param name="myStr">字符串</param>
    /// <param name="myLen">从左边截取的长度</param>
    /// <returns>截取的字符串</returns>
    public static string LeftString(string myStr, int myLen)
    {
        if (myStr == null || myStr == "")
        {
            return "";
        }
        string mytext = myStr;
        string retext = "";
        int s, n, i;
        s = mytext.Length;
        i = 0;
        n = 0;
        if (s >= 1 && myLen >= 1)
        {
            foreach (char chr in mytext)
            {
                if (((int)chr) < 0 || ((int)chr) > 126)
                    n = n + 2;
                else
                    n = n + 1;
                i++;
                if (n == myLen)
                {
                    retext = mytext.Substring(0, i);
                    break;
                }
                else
                {
                    if (n > myLen)
                    {
                        retext = mytext.Substring(0, i - 1);
                        break;
                    }
                }
            }
            if (n >= myLen)
                return retext;
            else
                return mytext;
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region LeftTitle 截取标题,一个汉字占两个字节超长加..
    /// <summary>
    /// 截取标题,一个汉字占两个字节超长加..
    /// </summary>
    /// <param name="myStr">字符串</param>
    /// <param name="myLen">从左边截取的长度</param>
    /// <returns>截取的字符串,超长的部分加..</returns>
    public static string LeftTitle(string myStr, int myLen)
    {
        if (LenString(myStr) > myLen)
        {
            return (LeftString(myStr, myLen - 2) + "...");
        }
        else
        {
            return (myStr);
        }
    }
    #endregion

    #region Leftcontent 截取内容,一个汉字占两个字节超长加......
    /// <summary>
    /// 截取标题,一个汉字占两个字节超长加..
    /// </summary>
    /// <param name="myStr">字符串</param>
    /// <param name="myLen">从左边截取的长度</param>
    /// <returns>截取的字符串,超长的部分加..</returns>
    public static string Leftcontent(string myStr, int myLen)
    {
        if (LenString(myStr) > myLen)
        {
            return (LeftString(myStr, myLen - 2) + "......");
        }
        else
        {
            return (myStr);
        }
    }
    #endregion
}