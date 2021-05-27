using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";


        public static string PostAdded = "Makale eklendi";
        public static string PostDeleted = "Makale eklendi";
        public static string PostUpdated = "Makale güncellendi";

        public static string CommentAdded = "Yorum eklendi";
        public static string CommentDeleted = "Yorum eklendi";
        public static string CommentUpdated = "Yorum eklendi";

        public static string CategoryAdded = "Yorum eklendi";
        public static string CategoryDeleted = "Yorum eklendi";
        public static string CategoryUpdated= "Yorum eklendi";

        public static string ExistUser = "Kullanıcı mevcut";
        public static string InvalidMail = "Geçersiz mail";
        public static string InvalidPassword = "Hatalı şifre";
        public static string SuccessLogin = "Giriş başarılı";
        internal static string TokenCreated = "Token oluşturuldu";

        public static string AuthorizationDenied = "Bu işlemi yapabilmek için yetkiniz yok";

    }
}
