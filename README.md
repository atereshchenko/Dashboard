# Dashboard
### мини-модуль хранения ссылок быстрого доступа
Стек:
* C# ASP.NET Core 5 + EF
* IIS
* Postresql
* Bootstrap 5.1
* Jquery
* доп. js-модули визуализации данных

### Запуск приложения
#### Fluent API: OnModelCreating:

При первом запуске приложения выполнится автоматическое создание таблиц в БД.
Наименование БД должно быть определено в статическом поле **Connecton** класса **Startup**:
    
    {
        public static string Connecton = "Host=localhost;Port=5432;Database=dashboard;Username=postgres;Password=A1aaaaaa";
    }

1. По умолчанию создастся администратор системы:
   1. имя: *Администратор*
   2. роль: *admin*
   3. логин/email: *admin@dashboard.com*
   4. пароль: *A1aaaaaa* (En).
2. Пройдя в браузере по адресу _[url]/[/admin]_ попадаем на страницу авторизации, где введя выше указанные данные окажемся на странице администрирования данного модуля

