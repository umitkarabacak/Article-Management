# Genel Bilgilendirme
<br/>Gerekli olan bütün konfigürasyon bilgileri appsettings.json dosyasý üzerinde tutulmaktadýr.
<br/>Proje çalýþtýrýlmadan MSSQL Server üzerinde DatabaseGeneratorScript.sql dosyasý çalýþtýrýlmalý ve appsettings.json dosyasý veri tabaný server bilgilerine göre yeniden düzenlenmelidir.
<br/>Proje kullanýlmasý istendiðinden dolayý Cache için Redis Server kullanýlmýþtýr. Proje kullanýlmadan önce Redis'in de çalýþýyor olmasý gerekmektedir.
<br/>Projede olmasý gerektiði için Authentication yanlýzca /west üzerinde kullanýlmýþtýr. (Article ile ilgili olan testlerin rahat yapýlabilmesi için)
<br/>Authentication için gerekli olan token key /token üzerinden alýnmalýdýr.
<br/>Projenin yönetim kolaylýðý için Swagger kullanýlmýþtýr.
<br/><br/>
# Projede kullanýdýðýnýz tasarým desenleri hangileridir? Bu desenleri neden kullandýnýz?
<br/>Repository Pattern ve Unit 
<br/>Ýlk sebebim proje içerisinde kullanýlmasý istenildiði için (:
<br/>Veri yönetiminde tekrarlayan CRUD iþlemlerini bir daha yazmamak ve olasý problemlerin önüne geçmek için kullanýlmýþtýr.
<br/><br/>
# Kullandýðýnýz teknoloji ve kütüphaneler hakkýnda daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?
<br/>Redis
<br/>Cache'i yönetmek için kullanýlmýþtýr.
<br/>Daha önce yaptýðým projeler üzerinde çok sýk deðiþmeyen ve yoðun istek alan istekleri cache'lemek için kullandým.
<br/>NLog
<br/>Proje üzerinde kullanýcýlar tarafýndan yapýlan iþlemleri, hatalarý kayýt altýna almak için kullanýlmýþtýr.
<br/>Ýhtiyaç olabilecek projelerde kullandým.
<br/>EF Core
<br/>Veri tabaný yönetimi için kullanýlmýþtýr.
<br/>Bütün projelerimde kullanýyorum.
<br/>Newtonsoft.JSON
<br/>Veri transferinde verinin serileþtirme/de-serileþtirme iþlemlerinde kullanýlmýþtýr.
<br/>Bütün projelerimde kullanýyorum.
<br/>Swagger
<br/>API projelerinde daha esnek ve kullanýþlý bir yönetim için kullanýlmýþtýr.
<br/>Bütün Web API projelerimde kullanýyorum.
<br/>Docker
<br/>Projenin Docker ile kullanabilmesi için kullanýlmýþtýr.
<br/><br/>
# Daha geniþ vaktiniz olsaydý projeye neler eklemek isterdiniz?
<br/>Unit Test eklemek daha saðlýklý olabilirdi.