using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarAddedInvalid = "Araba eklenemedi";
        public static string CarListed = "Araba Listelendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string GetCarByBrandId = "Araba modeline gore getirildi";
        public static string GetCarColor = "Araba renkleri getirildi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string CustomerByIdListed = "Müşteri İd ile Listelendi";
        public static string CustomerNot = "Müşteri Yok";
        public static string RentalAdded = "Araba kiralandi";
        public static string RentalDeleted = "Araba teslim edildi";
        public static string RentalInvalid = "Araba Kiralanamadı";
        public static string RentalNot = "Araba yok";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserGetAll = "Kullanıcılar Listelendi";
        public static string UserGetByIdAll = "Kullanıcılar Id ile Listelendi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string ProductNameAlreadyExists = "Araba ismi zaten mevcut";
    }
}
