__https://zhukovsd.github.io/java-backend-learning-course/Projects/WeatherViewer/ - тз было адаптировано для .NET__
# Weather App - проект погоды 

Функционал приложения предоставляет из себя ASP.net MVC приложение, которое предоставляет доступ к прогнозу погоды.
Поиск локаций происходит локально/при запросе к API weather с сайта openweathermap. Если пользователь укажет город, которого нет в локальном списке, система запросит локацию через удаленный сервер.э

---
В проекте предусмотрена локальная база данных LocalServer name  = (LocalDB)\MSSQLLocalDb MSSQL подключенная по Enity Framework со следующими таблицами

## LOCATIONS
ID | NAME | USER_ID | LATITUDE | LONGITUDE |
--- | --- | --- | --- |--- |
INT | STR | INT | DOUBLE | DOUBLE |

## SESSIONS
ID | USER_ID | EXPIRES | 
--- | --- | --- |
INT | INT | DATETIME |

## USERS
ID | LOGIN | PASSWORD (temp) | 
--- | --- | --- |
INT | STR | STR |

Система включает в себя функционал авторизации и регистрации, авторизированные пользователи имеют возозможность сохранять к себе до 5 локаций, удалять и добавлять новые.

**Стек:**
1) C# ASP.net MVC
2) JS


TODO: 
1) MIddleware JWT Token
