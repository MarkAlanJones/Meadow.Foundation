# Meadow.Foundation.Sensors.Atmospheric.Hih6130

**HIH6130 I2C temperature and humidity sensor**

The **Hih6130** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/)

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all of Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/)

## Usage

```
Hih6130? sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    sensor = new Hih6130(Device.CreateI2cBus());

    var consumer = Hih6130.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Observer: Temp changed by threshold; new temp: {result.New.Temperature?.Celsius:N2}C, old: {result.Old?.Temperature?.Celsius:N2}C");
        },
        filter: result =>
        {
            //c# 8 pattern match syntax. checks for !null and assigns var.
            if (result.Old?.Temperature is { } oldTemp &&
                result.Old?.Humidity is { } oldHumidity &&
                result.New.Temperature is { } newTemp &&
                result.New.Humidity is { } newHumidity)
            {
                return ((newTemp - oldTemp).Abs().Celsius > 0.5 &&
                        (newHumidity - oldHumidity).Percent > 0.05);
            }
            return false;
        }
    );
    sensor.Subscribe(consumer);

    sensor.Updated += (sender, result) =>
    {
        Resolver.Log.Info($"  Temperature: {result?.New.Temperature?.Celsius:F1}°C");
        Resolver.Log.Info($"  Relative Humidity: {result?.New.Humidity?.Percent:F1}%");
    };

    return Task.CompletedTask;
}

public override async Task Run()
{
    if(sensor == null) { return; }

    var result = await sensor.Read();
    Resolver.Log.Info("Initial Readings:");
    Resolver.Log.Info($"  Temperature: {result.Temperature?.Celsius:F1}°C");
    Resolver.Log.Info($"  Relative Humidity: {result.Humidity:F1}%");

    sensor.StartUpdating(TimeSpan.FromSeconds(1));
}

        
```

