# Genel Bilgilendirme
<br/>Gerekli olan b�t�n konfig�rasyon bilgileri appsettings.json dosyas� �zerinde tutulmaktad�r.
<br/>Proje �al��t�r�lmadan MSSQL Server �zerinde DatabaseGeneratorScript.sql dosyas� �al��t�r�lmal� ve appsettings.json dosyas� veri taban� server bilgilerine g�re yeniden d�zenlenmelidir.
<br/>Proje kullan�lmas� istendi�inden dolay� Cache i�in Redis Server kullan�lm��t�r. Proje kullan�lmadan �nce Redis'in de �al���yor olmas� gerekmektedir.
<br/>Projede olmas� gerekti�i i�in Authentication yanl�zca /west �zerinde kullan�lm��t�r. (Article ile ilgili olan testlerin rahat yap�labilmesi i�in)
<br/>Authentication i�in gerekli olan token key /token �zerinden al�nmal�d�r.
<br/>Projenin y�netim kolayl��� i�in Swagger kullan�lm��t�r.
<br/><br/>
# Projede kullan�d���n�z tasar�m desenleri hangileridir? Bu desenleri neden kulland�n�z?
<br/>Repository Pattern ve Unit 
<br/>�lk sebebim proje i�erisinde kullan�lmas� istenildi�i i�in (:
<br/>Veri y�netiminde tekrarlayan CRUD i�lemlerini bir daha yazmamak ve olas� problemlerin �n�ne ge�mek i�in kullan�lm��t�r.
<br/><br/>
# Kulland���n�z teknoloji ve k�t�phaneler hakk�nda daha �nce tecr�beniz oldu mu? Tek tek yazabilir misiniz?
<br/>Redis
<br/>Cache'i y�netmek i�in kullan�lm��t�r.
<br/>Daha �nce yapt���m projeler �zerinde �ok s�k de�i�meyen ve yo�un istek alan istekleri cache'lemek i�in kulland�m.
<br/>NLog
<br/>Proje �zerinde kullan�c�lar taraf�ndan yap�lan i�lemleri, hatalar� kay�t alt�na almak i�in kullan�lm��t�r.
<br/>�htiya� olabilecek projelerde kulland�m.
<br/>EF Core
<br/>Veri taban� y�netimi i�in kullan�lm��t�r.
<br/>B�t�n projelerimde kullan�yorum.
<br/>Newtonsoft.JSON
<br/>Veri transferinde verinin serile�tirme/de-serile�tirme i�lemlerinde kullan�lm��t�r.
<br/>B�t�n projelerimde kullan�yorum.
<br/>Swagger
<br/>API projelerinde daha esnek ve kullan��l� bir y�netim i�in kullan�lm��t�r.
<br/>B�t�n Web API projelerimde kullan�yorum.
<br/>Docker
<br/>Projenin Docker ile kullanabilmesi i�in kullan�lm��t�r.
<br/><br/>
# Daha geni� vaktiniz olsayd� projeye neler eklemek isterdiniz?
<br/>Unit Test eklemek daha sa�l�kl� olabilirdi.