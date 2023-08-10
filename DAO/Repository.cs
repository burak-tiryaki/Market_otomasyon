using Market_otomasyon.Enumaration;
using Market_otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZXing;

namespace Market_otomasyon.DAO
{
    public class Repository
    {
        SqlConnection conn; 
        SqlCommand cmd;
        SqlDataReader dr;
        int returnValue;

        List<LoginTable> loginTableList = new List<LoginTable>();

        public Repository()
        {
            conn = new SqlConnection("Data Source=DESKTOP-06B3154\\SQLEXPRESS;Initial Catalog=Market;User ID=sa;password=1");
        }

        public LoginUser Login(string _username, string _password)
        {
            conn.Open();

            cmd = new SqlCommand("SELECT * FROM LoginTbl WHERE username=@user AND password=@pass",conn);
            cmd.Parameters.AddWithValue("@user", _username);
            cmd.Parameters.AddWithValue("@pass", _password);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                LoginUser user = new LoginUser();

                user.id = int.Parse(dr["id"].ToString());
                user.username = dr["username"].ToString();
                user.password = dr["password"].ToString();
                user.authority = dr["authority"].ToString();
                user.email = dr["email"].ToString();
                user.securityQue = dr["securityQuestion"].ToString();
                user.securityAns = dr["securityAnswer"].ToString();
                user.status = LoginStatus.Success;

                return user;
            }
            else
            {
                LoginUser user = new LoginUser();
                user.status = LoginStatus.Failed;

                return user;
            }

            /*
            cmd = new SqlCommand("sp_login", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", _username);
            cmd.Parameters.AddWithValue("@passwd", _password);

            returnValue = (int)cmd.ExecuteScalar(); //sql tek satır ve sutun değer döndürüyorsa kullan.

            conn.Close();

            if (returnValue == 1)
                return LoginStatus.Success;
            else
                return LoginStatus.Failed;
            */
        }

        public List<LoginTable> getLoginTable()
        {
            loginTableList = new List<LoginTable>();
            
            conn.Open();

            cmd = new SqlCommand("sp_getSecurityQue", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                LoginTable lgnT = new LoginTable();

                lgnT.id = int.Parse(dr["id"].ToString());
                lgnT.username = dr["username"].ToString();
                lgnT.password = dr["password"].ToString();
                lgnT.authority = dr["authority"].ToString();
                lgnT.email = dr["email"].ToString();
                lgnT.securityQue = dr["securityQuestion"].ToString();
                lgnT.securityAns = dr["securityAnswer"].ToString();

                loginTableList.Add(lgnT);
            }

            conn.Close();

            return loginTableList;
        }

        public LoginStatus getVerify(string _username, string _secQue, string _secAns)
        {

            conn.Open();

            cmd = new SqlCommand("SELECT COUNT(*) FROM LoginTbl WHERE username=@user AND securityQuestion=@secQue AND securityAnswer=@secAns",conn);
            cmd.Parameters.AddWithValue("@user", _username);
            cmd.Parameters.AddWithValue("@secQue", _secQue);
            cmd.Parameters.AddWithValue("@secAns", _secAns);

            returnValue = (int)cmd.ExecuteScalar();

            conn.Close();

            if (returnValue == 1)
                return LoginStatus.Success;
            else
                return LoginStatus.Failed;
        }

        public LoginStatus ChangePassword(string _email,string _password)
        {
            conn.Open();

            cmd = new SqlCommand("sp_passwordUpdate", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", _email);
            cmd.Parameters.AddWithValue("@password", _password);

            returnValue = cmd.ExecuteNonQuery();

            conn.Close();

            if (returnValue == 1)
                return LoginStatus.Success;
            else
                return LoginStatus.Failed;
        }

        public string checkEmail(string _username)
        {
            conn.Open();
            cmd = new SqlCommand("SELECT email FROM LoginTbl WHERE username=@user",conn);
            cmd.Parameters.AddWithValue("@user", _username);

            string emailAdress = (string)cmd.ExecuteScalar();

            conn.Close();

            return emailAdress;
        }

        public Product getProduct(string _barcode)
        {
            conn.Open();

            cmd = new SqlCommand($"SELECT *  FROM Product WHERE barcode = '{_barcode}'", conn);

            dr = cmd.ExecuteReader();

            Product pro = new Product();
            while (dr.Read())
            {
                pro.id          = int.Parse(dr["id"].ToString());
                pro.barcode     = dr["barcode"].ToString();
                pro.createdDate = DateTime.Parse(dr["createdDate"].ToString());
                pro.updateTime  = DateTime.Parse(dr["updateDate"].ToString());
                //updateTime' sonradan yorumdan çıkarttım. Hata olursa terar al. Önceden NULL olduğu için hata veriyordu.
                pro.name        = dr["name"].ToString();
                pro.stock       = int.Parse(dr["stock"].ToString());
                pro.price       = int.Parse(dr["price"].ToString());
                pro.revenue     = int.Parse(dr["revenue"].ToString());
            }

            conn.Close();

            return pro;
        }

        //--------- userControlPanel Form -------------
        public List<LoginUser> getUsers()
        {
            
            List<LoginUser> loginList = new List<LoginUser>();

            conn.Open();

            cmd = new SqlCommand("SELECT * FROM LoginTbl", conn);

            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                LoginUser user = new LoginUser();

                user.id          = int.Parse(dr["id"].ToString());
                user.username    = dr["username"].ToString();
                user.password    = dr["password"].ToString();
                user.authority   = dr["authority"].ToString();
                user.email       = dr["email"].ToString();
                user.securityQue = dr["securityQuestion"].ToString();
                user.securityAns = dr["securityAnswer"].ToString();

                loginList.Add(user);
            }

            conn.Close();

            return loginList;
        }

        public RecordStatus addUser(string _user, string _pass, string _author,string _mail, string _secQue, string _answer)
        {
            conn.Open();

            cmd = new SqlCommand($"INSERT INTO LoginTbl(username,password,authority,email,securityQuestion,securityAnswer) VALUES('{_user}','{_pass}','{_author}','{_mail}','{_secQue}','{_answer}')", conn);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result >= 1)
                return RecordStatus.Success;
            else
                return RecordStatus.Failed;
        }

        public RecordStatus deleteUser(int _id)
        {
            conn.Open();

            cmd = new SqlCommand($"DELETE FROM LoginTbl WHERE id={_id}", conn);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return RecordStatus.Success;
            else
                return RecordStatus.Failed;

        }

        public RecordStatus updateUser(int _id,string _user, string _pass, string _author, string _mail, string _secQue, string _answer)
        {
            conn.Open();

            cmd = new SqlCommand(
                "UPDATE LoginTbl " +
                $"SET username = '{_user}', password = '{_pass}', authority = '{_author}', email = '{_mail}', securityQuestion = '{_secQue}', securityAnswer = '{_answer}'" +
                $"WHERE id = {_id}", conn);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result >= 1)
                return RecordStatus.Success;
            else
                return RecordStatus.Failed;
            
        }

        #region ProductPanel From

        public List<Product> getProduct()
        {
            List<Product> proList = new List<Product>();

            conn.Open();

            cmd = new SqlCommand($"SELECT *  FROM Product", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Product pro = new Product();

                pro.id          = int.Parse(dr["id"].ToString());
                pro.barcode     = dr["barcode"].ToString();
                pro.createdDate = DateTime.Parse(dr["createdDate"].ToString());
                pro.updateTime  = DateTime.Parse(dr["updateDate"].ToString());
                pro.name        = dr["name"].ToString();
                pro.stock       = int.Parse(dr["stock"].ToString());
                pro.price       = int.Parse(dr["price"].ToString());
                pro.revenue     = int.Parse(dr["revenue"].ToString());

                proList.Add(pro);
            }

            conn.Close();

            return proList;
        }

        public RecordStatus addProduct(string _barcode, string _name, int _stock, int _price)
        {
            conn.Open();

            cmd = new SqlCommand("INSERT INTO Product(barcode,name,stock,price)" +
                $"VALUES('{_barcode}','{_name}',{_stock},{_price})", conn);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return RecordStatus.Success;
            else
                return RecordStatus.Failed;

        }

        public RecordStatus updateProduct(int _id,string _barcode, string _name, int _stock, int _price)
        {
            conn.Open();

            cmd = new SqlCommand(
                "UPDATE Product " +
                $"SET barcode ='{_barcode}',name ='{_name}', stock ={_stock},price ={_price}" +
                $"WHERE id= {_id}", conn);

            returnValue = cmd.ExecuteNonQuery();

            conn.Close();

            if (returnValue >= 1)
                return RecordStatus.Success;
            else
                return RecordStatus.Failed;

        }

        public RecordStatus deleteProduct(int _id)
        {
            conn.Open();

            cmd = new SqlCommand($"DELETE FROM Product WHERE id={_id}", conn);

            returnValue = cmd.ExecuteNonQuery();

            conn.Close();

            if (returnValue == 1)
                return RecordStatus.Success;
            else
                return RecordStatus.Failed;

        }
        #endregion
    }
}
