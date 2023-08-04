﻿using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Sensors.Distance;
using Meadow.Units;
using System;
using System.Threading.Tasks;

namespace Me007ys_Sample
{
    // Change F7FeatherV2 to F7FeatherV1 for V1.x boards
    public class MeadowApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        Me007ys me007ys;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize...");

            me007ys = new Me007ys(Device, Device.PlatformOS.GetSerialPortName("COM4"));

            var consumer = Me007ys.CreateObserver(
                handler: result =>
                {
                    Resolver.Log.Info($"Observer: Distance changed by threshold; new distance: {result.New.Centimeters:N2}cm, old: {result.Old?.Centimeters:N2}cm");
                },
                filter: result =>
                {
                    if (result.Old is { } old)
                    {
                        return Math.Abs((result.New - old).Centimeters) > 0.5;
                    }
                    return false;
                }
            );
            me007ys.Subscribe(consumer);

            me007ys.DistanceUpdated += Me007y_DistanceUpdated;

            return Task.CompletedTask;
        }

        public override async Task Run()
        {
            var distance = await me007ys.Read();
            Resolver.Log.Info($"Distance is: {distance.Centimeters}cm");

            me007ys.StartUpdating(TimeSpan.FromSeconds(1));
        }

        private void Me007y_DistanceUpdated(object sender, IChangeResult<Length> e)
        {
            Resolver.Log.Info($"Length: {e.New.Centimeters}cm");
        }

        //<!=SNOP=>
    }
}