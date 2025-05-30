//******************************************************************
//**                                                              **
//**         STUDENT NAME : MUHAMMET BURAK ÖZYURT                 **
//**         STUDENT NUMBER: B231202062                           **
//**                                                              **
//******************************************************************

using System;
using System.Windows.Forms;

namespace b231202062
{
    static class Program
    {
        [STAThread]    //windows form için gerekli
        static void Main()
        {
            Application.EnableVisualStyles();    //windows form uygulamalarını yönetmek için gerekli
            Application.SetCompatibleTextRenderingDefault(false);  //uygulamanın metin görüntülemesini kontrol eder
            Application.Run(new Form1());     //formu çalıştırır
        }
    }
}