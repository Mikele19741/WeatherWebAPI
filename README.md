# Weather Web API
# BACKEND 
I used http://api.openweathermap.org/data/2.5/weather? api service for get current weather and another interesting values. For deployment please register
on http://api.openweathermap.org/ this api and get API Key. After that change parameter "weatherAPICode" in appsettings.json file on you api key
# Request Sample
http://yourhost/api/weather?Lat=24.6877300&Lng=46.7218500
# Request result
{
    "currentDateTime": "2021-08-10T14:30:58Z",
    "minTemp": 42.23000000000002,
    "maxTemp": 42.23000000000002,
    "temp": 42.23000000000002,
    "pressure": 751.5616280535005,
    "wind": {
        "speed": "4.6",
        "deg": "44"
    },
    "main": {
        "temp": "315.23",
        "pressure": "1002",
        "humidity": "7",
        "temp_min": "315.23",
        "temp_max": "315.23",
        "sea_level": "1002",
        "grnd_level": "938"
    },
    "atm": "clear sky",
    "cloud": " 10 ",
    "sunrise": "02:25:20(UTC Time)",
    "sunset": "15:31:45(UTC Time)",
    "timeZone": "Riyadh"
}
