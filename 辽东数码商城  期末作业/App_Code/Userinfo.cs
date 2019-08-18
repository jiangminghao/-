using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Text;

using System.Web.Security;
/// <summary>
/// Userinfo 的摘要说明
/// </summary>
public class Userinfo
{
	//判断是否是管理员
   
    public bool checklogin(string username,string password)
    {
        string sqlstr = "select * from userinfo where power=2 and username=@usename and password=@password ";
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@username",username),
                                       new OleDbParameter("@password",password)
                                    };
        OleDbDataReader dr = OleDbHelper.executeReader(sqlstr, CommandType.Text, param);
        if (dr.HasRows)
            return true;
        else
            return false;
    }
    public bool checkname(string username)
    {
        string sqlstr = "select * from userinfo where  username=@usename ";
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@username",username)
                                      
                                    };
        OleDbDataReader dr = OleDbHelper.executeReader(sqlstr, CommandType.Text, param);
        if (dr.HasRows)
            return true;
        else
            return false;
    }
    public DataTable getUser()
    {
        String  sqlstr = "select  * from userinfo order by power desc ";
       
        return OleDbHelper.executeDataAdapter(sqlstr, CommandType.Text, null);
    }
   
   
    public int delelteUser(int userid)
    {
        String sqlstr = "delete from userinfo where [userid]=@userid";
      
        OleDbParameter[] param = { new OleDbParameter("@userid", userid) };
        return OleDbHelper.executeNonQuery(sqlstr, CommandType.Text, param);
    }
    public int updateUser(string  username, string password, string email, string question, string answer)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update userinfo set [password]=@password,email=@email,question=@question,");
        sb.Append("answer=@answer where [username]=@username");
        OleDbParameter[] param = 
                                    {
                                        
                                        new OleDbParameter("@password",password),
                                        new OleDbParameter("@email",email),
                                        new OleDbParameter("@question",question),
                                        new OleDbParameter("@answer",answer),
                                        new OleDbParameter("@username",username)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }
    public int createUser(string username)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into userinfo ([username],[password],[power]) values ");
        sb.Append(" (@username,@password,@power)");
        OleDbParameter[] pars = 
                                    {
                                       new OleDbParameter("@username",username),
                                       new OleDbParameter("@password","123456"),
                                       new OleDbParameter("@power",2)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, pars);
    }


    public int createUser(string username, string password, int power, string email, string question, string answer)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into userinfo ([username],[password],[power],email,question,answer) values ");
        sb.Append(" (@username,@password,@power,@email,@question,@answer)");
        OleDbParameter[] pars = 
                                    {
                                       new OleDbParameter("@username",username),
                                       new OleDbParameter("@password",password),
                                       new OleDbParameter("@power",power),
                                       new OleDbParameter("@email",email),
                                       new OleDbParameter("@question",question),
                                       new OleDbParameter("@answer",answer)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, pars);
    }

    /// <summary>
    /// 获得一个用户资料
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    public DataTable getUser(int userid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select [userid],[username],[password],[power],email,question,answer ");
        sb.Append("from userinfo where [userid]=@userid");
        OleDbParameter[] param = { new OleDbParameter("@userid", userid) };
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 获得一个用户资料
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    public DataTable getUser(string username)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select [userid],[password],[username],[power],email,question,answer ");
        sb.Append("from userinfo where [username]=@username");
        OleDbParameter[] param = { new OleDbParameter("@username", username) };
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 删除一个用户
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <returns></returns>
    

    /// <summary>
    /// 修改用户资料
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="password">用户密码</param>
    /// <param name="email">电子邮件</param>
    /// <param name="question">密码问题</param>
    /// <param name="answer">问题答案</param>
    /// <returns></returns>
    public int updateUser(int userid, string password, string email, string question, string answer)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update userinfo set [password]=@password,email=@email,question=@question,");
        sb.Append("answer=@answer where [userid]=@userid");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@userid",userid),
                                        new OleDbParameter("@password",password),
                                        new OleDbParameter("@email",email),
                                        new OleDbParameter("@question",question),
                                        new OleDbParameter("@answer",answer)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }
    public int updateUserinfo(int userid, string email, string question, string answer)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update userinfo set email=@email,question=@question,");
        sb.Append("answer=@answer where [userid]=@userid");
        OleDbParameter[] param = {
                                        new OleDbParameter("@email",email),
                                        new OleDbParameter("@question",question),
                                        new OleDbParameter("@answer",answer),
                                        new OleDbParameter("@userid",userid)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="newpassword">新密码</param>
    /// <returns></returns>
    public int updateUserPassword(int userid, string newpassword)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update userinfo set [password]=@newpassword where [userid]=@userid");
        OleDbParameter[] param = 
                                   {  new OleDbParameter("@newpassword",newpassword),
                                      new OleDbParameter("@userid", userid) 
                                     
                                   };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 找回用户密码
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="question">密码问题</param>
    /// <param name="answer">问题答案</param>
    /// <returns></returns>
    public string researchPassword(string username, string question, string answer)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select [password] from userinfo where [username]=@username ");
        sb.Append("and question=@question and answer=@answer");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@username",username),
                                       new OleDbParameter("@question",question),
                                       new OleDbParameter("@answer",answer)
                                    };
        DataTable table = OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, param);
        if (table.Rows.Count > 0)
        {
            return table.Rows[0]["password"].ToString();
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 验证用户登陆
    /// </summary>
    /// <param name="username">用户名称</param>
    /// <param name="password">用户密码</param>
    /// <returns></returns>
    public bool validUser(string username, string password, int power)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select [username] from userinfo where [username]=@username ");
        sb.Append("and [password]=@password and [power]=@power");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@username",username),
                                       new OleDbParameter("@password",password),
                                       new OleDbParameter("@power",power)
                                    };
        DataTable table = OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, param);
        if (table.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 用户名是否已经存在
    /// </summary>
    /// <param name="username">用户名称</param>
    /// <returns></returns>
    public bool IsExtie(string username)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select [username] from userinfo where [username]=@username ");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@username",username),
                                    };
        DataTable table = OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, param);
        if (table.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetCookie(string username)
    {
        DataTable table = getUser(username);
        if (table.Rows.Count > 0)
        {
            int userID = int.Parse(table.Rows[0]["userid"].ToString());
            int power = int.Parse(table.Rows[0]["power"].ToString());
            string userData = username.Replace(@"\", @"\\") + "#" + power.ToString();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userID.ToString(), DateTime.Now, DateTime.Now.AddMinutes(60), false, userData, FormsAuthentication.FormsCookiePath);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie newCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(newCookie);
            cart ocart = new cart();
            string oldcartid = ocart.GetShoppingCartId();
            
            ocart.migratecart(oldcartid, userID.ToString());
        }
    }
    public bool IsLogin()
    {
        // FormsAuthentication.SignOut();
        return HttpContext.Current.User.Identity.IsAuthenticated;
    }

    /// <summary>
    /// 退出登录
    /// </summary>
    public void Logout()
    {
        FormsAuthentication.SignOut();
    }

    /// <summary>
    /// 获取登录的用户ID
    /// </summary>
    /// <returns></returns>
    public int getUserID()
    {
        if (IsLogin())
        {
            return Convert.ToInt32(HttpContext.Current.User.Identity.Name);
        }
        else
        {
            return -1;
        }
    }


    /// <summary>
    /// 获得用户名
    /// </summary>
    /// <returns></returns>
    public string getUserName()
    {
        if (IsLogin())
        {
            string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            string[] UserData = strUserData.Split(new string[] { @"#" }, StringSplitOptions.RemoveEmptyEntries);
            if (UserData.Length > 0)
            {
                return UserData[0].Replace(@"\\", @"\");
            }
            else
                return "";
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 返回用户的角色
    /// </summary>
    /// <returns></returns>
    public int getUserRole()
    {
        if (IsLogin())
        {
            string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            string[] UserData = strUserData.Split(new string[] { @"#" }, StringSplitOptions.RemoveEmptyEntries);
            if (UserData.Length > 0)
            {
                return Int32.Parse(UserData[1]);
            }
            else
                return -1;
        }
        else
        {
            return -1;
        }
    }

}
