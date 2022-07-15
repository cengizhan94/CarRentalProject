using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedMessage = "Ekleme işlemi Başarılı. ";
        public static string MaintenanceTime="Sistem Bakımda.";
        public static string DeletedMessage = "Silme işlemi başarılı. ";
        public static string UpdatedMessage = "Güncelleme işlemi başarılı. ";
        public static string InvalidMessage = "işlem geçersiz. ";
        public static string SuccessMessage = "işlem Başarılı.";
        public static string TextInvalidMessage = "Eksik veya hatalı tuşladınız.";
        public static string NotAvailableMessage = "Birim müsait değil.";
        public static string AvailableMessage = "Birim müsaittir.";
        public static string PasswordInvalidMessage = "Geçerli bir parola giriniz.";
        public static string CarImageLimitError = "Bir araç için en fazla 5 resim yüklenebilir.";
        public static string SuccessFileUpload = "Dosya Başarıyla Yüklendi.";
        public static string AuthorizationDenied = "Yapmak istediğiniz işlem için yetkiniz yok.";
        public static string UserRegistered     = "Kullanıcı kaydedildi.";
        public static string UserNotFound       ="Kullanıcı bulunamadı";
        public static string PasswordError      ="Şifre hatası.";
        public static string UserAlreadyExists  ="Kullanıcı zaten mevcut.";
        public static string SuccessfulLogin    ="Başarılı giriş.";
        public static string AccessTokenCreated ="Kullanıcı tokeni oluşturuldu";
        public static string SendingVerifyMail  ="Doğrulama gaili girilen email adresinize gönderildi.";
        public static string VerifyYourEmailAdress = "Lütfen email adresinizi doğrulayın.";
    }
}
