# Delivery Order Service

Веб-приложение для создания и просмотра заказов на доставку

- создание заказа;
- автоматическая генерация номера заказа;
- просмотр списка заказов;
- просмотр деталей заказа;
- удаление заказа.

## Технологии

- ASP.NET Core 9
- Entity Framework Core
- SQLite
- ASP.NET Core MVC
- Swagger

## Запуск проекта

Требования:
- .NET 9 SDK

1. Клонировать проект:
```bash
git clone https://github.com/n0wad/TestWebApp.git
```
2. Перейти в папку проекта:
```bash
cd TestWebApp
```
3. Применить миграции:
```bash
dotnet ef database update
```
4. Запустить:
```bash
dotnet run
```

### После запуска
- Веб интерфейс: https://localhost:7039/OrdersMvc
- Swagger: https://localhost:7039/swagger
