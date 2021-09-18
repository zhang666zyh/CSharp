using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Test
{
    class Program
    {
        public struct User
        {
            public string Name;
            public string Card;
            public string Account;
            public float Ye;
            public string PassWord;
        }

        static User[] users = new User[10];
        static int usernum = 0;
        static int position = -1;
        static bool flag = true;
        static string account;
        static string password;


        static void Main(String[] args)
        {
            int main_choice = 0, master_choice = 0;
            bool boolean_login;
            while (flag)
            {
                Console.Clear();
                main_menu();
                Console.WriteLine("请输入你想要办理的业务编号:");
                main_choice = int.Parse(Console.ReadLine());
                if (main_choice == 0)
                {
                    Environment.Exit(0);
                }
                else if (main_choice == 1)
                {
                    create_account(usernum);
                    Console.WriteLine("恭喜您,开户成功!!!");
                    Console.WriteLine("恭喜您获得三天免费会员体验!!!");
                    usernum++;
                    Console.ReadKey();
                }
                else if (main_choice == 2)
                {
                    boolean_login = login();
                    if (boolean_login){
                        Console.WriteLine("登录成功!!!");
                        flag = true;
                        while (flag) {
                            master_menu();
                            Console.WriteLine("请输入你想要办理的业务编号:");
                            master_choice = int.Parse(Console.ReadLine());
                            if(master_choice == 0)
                            {
                                break;
                            }else if(master_choice == 1){
                                save_money();
                            }else if(master_choice == 2){
                                get_money();
                            }else if(master_choice == 3){
                                user_sort();
                            }
                        }
                    }
                    else{
                        Console.WriteLine("登录失败!!!");
                        flag = true;
                    }
                }
                else{

                }

            }

        }

        static void main_menu(){
            Console.WriteLine("*************************");
            Console.WriteLine("*\t0-退出系统\t*");
            Console.WriteLine("*\t1-首次开户\t*");
            Console.WriteLine("*\t2-登录功能\t*");
            Console.WriteLine("*************************");
        }

        static void master_menu(){
            Console.WriteLine("*************************");
            Console.WriteLine("*\t0-退出登录\t*");
            Console.WriteLine("*\t1-存款\t\t*");
            Console.WriteLine("*\t2-取款\t\t*");
            Console.WriteLine("*\t3-用户预览表\t*");
            Console.WriteLine("*************************");
        }

        static void create_account(int usernum)
        {
            Console.WriteLine("开始开户!");
            Console.WriteLine("您是本行的第{0}个用户!!!", usernum + 1);
            Console.WriteLine("请输入您的姓名:");
            users[usernum].Name = Console.ReadLine();
            Console.WriteLine("请输入您的身份证号:");
            users[usernum].Card = Console.ReadLine();
            Console.WriteLine("请输入您的卡号:");
            users[usernum].Account = Console.ReadLine();
            Console.WriteLine("请输入您的密码:");
            users[usernum].PassWord = Console.ReadLine();
            Console.WriteLine("请输入您的余额:");
            users[usernum].Ye = float.Parse(Console.ReadLine());
        }

        static void save_money(){
            int i = 0;
            bool judge = false;
            Console.WriteLine("请输入卡号:");
            account = Console.ReadLine();
            Console.WriteLine("请输入你存入的金额:");
            float save_moneyAccount = float.Parse(Console.ReadLine());
            for (i = 0; i < users.Length; i++)
            {
                if (account.Equals(users[i].Account))
                {
                    users[i].Ye += save_moneyAccount;
                    judge = true;
                    break;
                }
            }
            if (judge)
            {
                Console.WriteLine("存款成功,您账户的存款为{0}", users[i].Ye);
            }
            else
            {
                Console.WriteLine("存款失败,请重新操作!!!");
            }
        }


        static void get_money(){
            int i = 0;
            bool judge = login();
            if (judge){
                Console.WriteLine("请输入你想要取走的金额:");
                float get_money = float.Parse(Console.ReadLine());
                for(i = 0;i < users.Length; i++){
                    if(account.Equals(users[i].Account)){
                        if(get_money <= users[i].Ye){
                            users[i].Ye -= get_money;
                            Console.WriteLine("取款成功,您账户的存款为{0}", users[i].Ye);
                        }else{
                            Console.WriteLine("取款失败,余额不足!!!");
                            Console.WriteLine("取款成功,您账户的存款为{0}", users[i].Ye);
                        }
                    }
                }
            }else{
                Console.Write("登录失败,请重新登录!!!");
            }
        }

        static bool login()
        {
            int i;  
            int boolean_judge = 0;
            Console.WriteLine("请输入卡号:");
            account = Console.ReadLine();

            for (i = 0; i < users.Length; i++)
            {
                if (account.Equals(users[i].Account))
                {
                    position = i;
                    break;
                }
            }

            if (position == -1)
            {
                Console.WriteLine("用户不存在,请重新登录!!!");
                Console.ReadKey();
                return false;
            }
            Console.WriteLine("请输入密码:");
            password = Console.ReadLine();
            if (password.Equals(users[position].PassWord))
            {
                flag = true;
            }
            else{
                flag = false;
            }
            return flag;
        }

        static void user_sort(){
            User user = new User();
            user.Ye = 0;
            int i, j;
            for(i = 0;i < users.Length - 1; i++)
            {
                for(j = 0;j < users.Length - 1 - i; j++)
                {
                    if(users[j].Ye < users[j + 1].Ye)
                    {
                        user.Ye = users[j].Ye;
                        users[j].Ye = users[j + 1].Ye;
                        users[j + 1].Ye = user.Ye;
                    }
                }
            }
            for(i = 0;i < users.Length; i++)
            {
                if(users == null)
                {
                    break;
                }
                Console.WriteLine("{0}-{0}",users[i].Ye, users[i].Name);
            }
        }
    }
}