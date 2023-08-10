using Market_otomasyon.DAO;
using Market_otomasyon.Enumaration;
using Market_otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_otomasyon.controller
{
    public class Controller
    {
        Repository repository;

        public Controller()
        {
            repository = new Repository();
        }

        public LoginUser Login(string _username, string _password)
        {

            if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password))
            {
                return repository.Login(_username, _password);
            }
            else
            {
                LoginUser user = new LoginUser();
                user.status = LoginStatus.missingParameter;
                return user;
            }
        }

        public List<LoginTable> getLoginTable()
        {
            List<LoginTable> loginTables = repository.getLoginTable();

            return loginTables;
        }

        public LoginStatus getVerify(string _username, string _secQue, string _secAns)
        {
            if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_secQue) && !string.IsNullOrEmpty(_secAns))
            {
                return repository.getVerify(_username, _secQue, _secAns);
            }
            else
                return LoginStatus.missingParameter;
        }

        public LoginStatus ChangePasswrod(string _email, string _password)
        {
            if (!string.IsNullOrEmpty(_email) && !string.IsNullOrEmpty(_password))
            {
                return repository.ChangePassword(_email, _password);
            }
            else
                return LoginStatus.missingParameter;
        }

        public string checkEmail(string _username)
        {
            return repository.checkEmail(_username);

        }

        public Product getProduct(string _barcode)
        {
            if (!string.IsNullOrEmpty(_barcode))
            {
                return repository.getProduct(_barcode);
            }
            return null;
        }
        //--------- userControlPanel Form -------------
        public List<LoginUser> getUsers() //userControlPanel datagridview için
        {
            return repository.getUsers();
        }

        public RecordStatus addUser(string _user, string _pass, string _author, string _mail, string _secQue, string _answer)
        {
            if (!string.IsNullOrEmpty(_user) &&
                !string.IsNullOrEmpty(_pass) &&
                !string.IsNullOrEmpty(_author) &&
                !string.IsNullOrEmpty(_mail) &&
                !string.IsNullOrEmpty(_secQue) &&
                !string.IsNullOrEmpty(_answer))
            {

                return repository.addUser(_user, _pass, _author, _mail, _secQue, _answer);
            }
            else
                return RecordStatus.MissingParameter;
        }

        public RecordStatus deleteUser(int _id)
        {
            if (!string.IsNullOrEmpty(_id.ToString()))
                return repository.deleteUser(_id);
            else
                return RecordStatus.MissingParameter;
        }

        public RecordStatus updateUser(int _id, string _user, string _pass, string _author, string _mail, string _secQue, string _answer)
        {
            return repository.updateUser(_id, _user, _pass, _author, _mail, _secQue, _answer);
        }

        #region ProductPanel Form
        public List<Product> getProduct()
        {
            return repository.getProduct();
        }

        public RecordStatus addProduct(string _barcode, string _name, int _stock, int _price)
        {
            if (!string.IsNullOrEmpty(_barcode) &&
                !string.IsNullOrEmpty(_name) &&
                !string.IsNullOrEmpty(_stock.ToString()) &&
                !string.IsNullOrEmpty(_price.ToString()))
            {
               return repository.addProduct(_barcode,_name,_stock,_price);
            }
            else
                return RecordStatus.MissingParameter;
        }

        public RecordStatus updateProduct(int _id, string _barcode, string _name, int _stock, int _price)
        {
            if (!string.IsNullOrEmpty(_id.ToString()) &&
                !string.IsNullOrEmpty(_barcode) &&
                !string.IsNullOrEmpty(_name) &&
                !string.IsNullOrEmpty(_stock.ToString()) &&
                !string.IsNullOrEmpty(_price.ToString()))
            {
                return repository.updateProduct(_id,_barcode, _name, _stock, _price);
            }
            else
                return RecordStatus.MissingParameter;
        }

        public RecordStatus deleteProduct(int _id)
        {
            if (!string.IsNullOrEmpty(_id.ToString()))
                return repository.deleteProduct(_id);
            else
                return RecordStatus.MissingParameter;
        }

        #endregion
    }
}
