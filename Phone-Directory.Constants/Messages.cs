using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Constants
{
    public static class Messages
    {
        public static string UsernameExists = "Bu kullanıcı adı sistemde mevcut.";
        public static string SuccessRegistered = "Kullanıcı başarıyla üye oldu.";
        public static string SuccessUpdatedUser = "Kullanıcı başarıyla güncellendi.";
        public static string ErrorOccurred = "Hata oluştu:";
        public static string NotRecordFound = "Kayıt bulunamadı.";
        public static string NotUserFound = "Kullanıcı bulunamadı.";
        public static string NotUserIdFound = "UserId bulunamadı.";
        public static string NotUserIDFound = "Kullanıcı Id bulunamadı.";
        public static string NotUpdatedInfo = "Güncellenmiş bir bilgi yok.";
        public static string LoginFailed = "Giriş başarısız oldu.";
        public static string PasswordNotMatch = "Şifreler eşleşmedi.";
        public static string RegisterFailed = "Kayıt başarısız oldu.";
        public static string UpdateFailed = "Güncelleme sırasında bir hata oluştu.";
        public static string SuccessLogin = "Başarıyla giriş yapıldı.";
        public static string InvalidUsernameOrPassword = "Kullanıcı adı veya şifre geçersiz.";
        public static string UserSpecificRecords = "Kullanıcıya özel kayıtlar getirildi.";
        public static string RecordBrought = "Kayıt getirildi.";
        public static string UserBrought = "Kullanıcı getirildi.";
        public static string RecordAddedDirectory = "Rehbere kayıt eklendi.";
        public static string RecordUpdatedDirectory = "Rehberdeki kayıt güncellendi.";
        public static string RecordDeletedDirectory = "Rehberdeki kayıt silindi.";
    }
}
