import requests
import json

API_KEY = "b6e963cb847cfeb37d0af7eb4808b0c1"  # Replace with your OpenWeatherMap API key

def get_weather_forecast(city):
    try:
        url = f"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}"
        response = requests.get(url)
        response.raise_for_status()  # Raise an exception for 4xx or 5xx status codes
        
        data = json.loads(response.text)
        
        # Extract relevant weather information
        temperature = data['main']['temp']
        humidity = data['main']['humidity']
        description = data['weather'][0]['description']
        
        # Convert temperature from Kelvin to Celsius
        temperature_celsius = temperature - 273.15
        
        # Print the weather forecast
        print(f"Weather forecast for {city}:")
        print(f"Temperature: {temperature_celsius:.2f}°C")
        print(f"Humidity: {humidity}%")
        print(f"Description: {description}")
        
    except requests.exceptions.RequestException as e:
        print("Error occurred while making the request:", e)
    except (KeyError, IndexError) as e:
        print("Failed to parse weather data:", e)
    except json.JSONDecodeError as e:
        print("Failed to decode JSON response:", e)
    except Exception as e:
        print("An error occurred:", e)

# Prompt the user to enter a city
city = input("Enter the city name: ")

# Get the weather forecast for the given city
get_weather_forecast(city)
