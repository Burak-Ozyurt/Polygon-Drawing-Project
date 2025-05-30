//******************************************************************
//**                                                              **
//**         STUDENT NAME : MUHAMMET BURAK ÖZYURT                 **
//**         STUDENT NUMBER: B231202062                           **
//**                                                              **
//******************************************************************

namespace b231202062
{
    partial class Form1     //sınıfı birden fazla parçaya ayırır
    {
        private void InitializeComponent()         //formun görselini ayarlar
        {
            this.SuspendLayout();           //form düzenin işlemlerini durdurur
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);    //otomatik ölçeklendirme yapar
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;    //fonta göre ölçeklendirme yapar
            this.ClientSize = new System.Drawing.Size(791, 600);
            this.Name = "Form1";                  //formun adı
            this.Text = "Proje";                  //form açıldığında yazacak isim
            this.Load += new System.EventHandler(this.Form1_Load);    //form yüüklendiğinde çalışcak metot
            this.ResumeLayout(false);         //form düzenlemelerini tekrar aktif eder

        }
        
    }
}