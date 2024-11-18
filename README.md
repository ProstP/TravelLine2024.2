# TravelLine2024.2
Второй этап практики, начало - октябрь 2024
***
## Настройка БД
* Переходим в src/Backend
* Пишем в консоль команду: dotnet ef database update --startup-project WebApi/WebApi.csproj --project Infrastructure/Infrastructure.csproj -- --environment <название конфигурационного фалйа>
***
## Разворачивание Backend
* В папке src/Backend/WebApi содержиться общий appsettings.json, необходимо создать свой appsettings.<название>.json, в нём будут указаны:
    * Секретный ключ для JWT токена
    * Строка для соединения с БД
    * Адрес на которой будет разворачиваться ваш Frontend
* Добавить созданную кофнигурацию в launchSettings.json
* Необходимо выбрать WebApi в качестве запускаемого проекта, выбрать ваш созданную кофнигурацию
***
## Разворачивание Frontend
* Переходим в папку src/Frontend
* Устанавливаем все необходимые зависимости с помощью команды npm install
* В файле src/core/api.config.ts есть константа с адресом сервера, меняем на свой адрес, по которому разворачивается Backend
* Находясь в папке src/Frontend запускаем проект npm run dev
* В консоли появится локальный адрес, по которому развернулся Frontend 