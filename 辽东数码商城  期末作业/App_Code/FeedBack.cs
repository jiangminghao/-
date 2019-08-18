using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// FeedBack 的摘要说明
/// </summary>
public class FeedBack
{
    //添加留言
    public Boolean addfeedback(string fb_title, string username,string fb_content)
    {
        string sqlstr = "insert into feedback(fb_title,username,fb_content,fb_date) values(@fb_title,@username,@fb_content,@fb_date)";
        List<OleDbParameter> para = new List<OleDbParameter>();
        para.Add(commDBHelper.CreateParameters("@fb_title", OleDbType.Char, fb_title));
        para.Add(commDBHelper.CreateParameters("@username", OleDbType.Char, username));
        para.Add(commDBHelper.CreateParameters("@fb_content", OleDbType.Char, fb_content));      
        para.Add(commDBHelper.CreateParameters("@fb_date", OleDbType.Date, DateTime.Now));         
        return commDBHelper.ExecuteNonQuery(sqlstr, CommandType.Text, para);
    }
    //后台显示所有留言
    public  DataTable getfeedbacklist()
    {
        string sqlstr = "select * from feedback order by fb_date desc";
        return commDBHelper.ExecuteReader(sqlstr, CommandType.Text, null);
    }
    //前台显示允许查看的留言
    public  DataTable getisviewfeedlist()
    {
        string sqlstr = "select * from feedback   where isview=true   order by fb_date desc";
        return commDBHelper.ExecuteReader(sqlstr, CommandType.Text, null);
    }
    //删除留言
    public  bool deletefeed(string fb_id)
    {
        string sqlstr = "delete from feedback where fb_id=" + fb_id;
        return commDBHelper.ExecuteNonQuery(sqlstr, CommandType.Text, null);
    }
    //查询一条留言是否允许查看
    public  Boolean getisview(string fb_id)
    {
        string sqlstr = "select isview  from feedback  where fb_id=" + fb_id;
        object result =  commDBHelper.ExecuteScalar(sqlstr, CommandType.Text, null);
        return Convert.ToBoolean(result);
    }
    //修改留言查看状态
    public bool changeview(int fb_id, Boolean isview)
    {
        string sqlstr = "update feedback set isview=@isview where  fb_id=@fb_id";
        List<OleDbParameter> para = new List<OleDbParameter>();
        para.Add(commDBHelper.CreateParameters("@isview", OleDbType.Boolean, isview));
        para.Add(commDBHelper.CreateParameters("@fb_id", OleDbType.Integer, fb_id));
        return commDBHelper.ExecuteNonQuery(sqlstr, CommandType.Text, para);     
    }
}