using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessfulInsert = "Ekleme başarılı.";
        public static string FailedInsert = "Ekleme başarısız.";

        public static string SuccessfulUpdate = "Güncelleme başarılı.";
        public static string FailedUpdate = "Güncelleme başarısız.";

        public static string SuccessfulDelete = "Silme başarılı.";
        public static string FailedDelete = "Silme başarısız.";
        public static string CarImageAdded="Resim Eklendi";
        public static string CarImageDeleted="Resim Silindi";

        public static string AuthorizationDenied = "Yetkilendirme Reddedildi.";
        public static string UserRegistered="Kayıt başarılı";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string UserAlreadyExists="Bu kullanıcı sisteme zaten kayıtlı";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string PasswordError="Şifre yanlış";
        public static string UserNotFound="Kullanıcı bulunamadı";
    }
}
