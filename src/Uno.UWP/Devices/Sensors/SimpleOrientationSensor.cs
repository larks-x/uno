#nullable enable

using System;
using Windows.UI.Core;
using Windows.Foundation;
using Uno.Helpers;

namespace Windows.Devices.Sensors
{
	public partial class SimpleOrientationSensor
	{
		private readonly StartStopTypedEventWrapper<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs> _orientationChangedWrapper;

		#region Static
		private readonly static Lazy<SimpleOrientationSensor?> _instance = new Lazy<SimpleOrientationSensor?>(() => TryCreateInstance());

		/// <summary>
		/// Gets the default simple orientation sensor.
		/// </summary>
		/// <returns>
		/// The default simple orientation sensor or null if no simple orientation sensors are found.
		/// </returns>
		public static SimpleOrientationSensor? GetDefault() => _instance.Value;

		private static partial SimpleOrientationSensor? TryCreateInstance();
		#endregion

		partial void StartListeningOrientationChanged();

		partial void StopListeningOrientationChanged();

#pragma warning disable CS0649 // Field 'SimpleOrientationSensor._currentOrientation' is never assigned to, and will always have its default value - Assigned only in Android and iOS.
		private SimpleOrientation _currentOrientation;
#pragma warning restore CS0649 // Field 'SimpleOrientationSensor._currentOrientation' is never assigned to, and will always have its default value

		/// <summary>
		/// Represents a simple orientation sensor.
		/// </summary>
		private SimpleOrientationSensor()
		{
			_orientationChangedWrapper = new StartStopTypedEventWrapper<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs>(
				() => StartListeningOrientationChanged(),
				() => StopListeningOrientationChanged());

			Initialize();
		}

		partial void Initialize();

		/// <summary>
		/// Gets the device identifier.
		/// </summary>
		[Uno.NotImplemented]
		public string DeviceId { get; } = string.Empty;

		/// <summary>
		/// Gets or sets the transformation that needs to be applied to sensor data. Transformations to be applied are tied to the display orientation with which to align the sensor data.
		/// </summary>
		/// <remarks>
		/// This is not currently implemented, and acts as if <see cref="ReadingTransform" /> was set to <see cref="Graphics.Display.DisplayOrientations.Portrait" />.
		/// </remarks>
		[Uno.NotImplemented]
		public Graphics.Display.DisplayOrientations ReadingTransform { get; set; } = Graphics.Display.DisplayOrientations.Portrait;

		/// <summary>
		/// Gets the default simple orientation sensor.
		/// </summary>
		/// <returns></returns>
		public SimpleOrientation GetCurrentOrientation() => _currentOrientation;

		/// <summary>
		/// Occurs each time the simple orientation sensor reports a new sensor reading.
		/// </summary>
#pragma warning disable CS0067 // The event 'SimpleOrientationSensor.OrientationChanged' is never used - Used only in Android and iOS.
		public event TypedEventHandler<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs> OrientationChanged
		{
			add => _orientationChangedWrapper.AddHandler(value);
			remove => _orientationChangedWrapper.RemoveHandler(value);
		}
#pragma warning restore CS0067 // The event 'SimpleOrientationSensor.OrientationChanged' is never used

#if __ANDROID__ || __IOS__
		private void SetCurrentOrientation(SimpleOrientation orientation)
		{
			if (_currentOrientation != orientation)
			{
				_currentOrientation = orientation;

				var args = new SimpleOrientationSensorOrientationChangedEventArgs()
				{
					Orientation = orientation,
					Timestamp = DateTimeOffset.Now,
				};
				_orientationChangedWrapper.Invoke(this, args);
			}
		}

		private static SimpleOrientation ToSimpleOrientation(double gravityX, double gravityY, double gravityZ, double threshold, SimpleOrientation previous)
		{
			// Ensures orientation only changes when within close range to new orientation.
			if (Math.Abs(gravityX) > Math.Abs(gravityY) + threshold && Math.Abs(gravityX) > Math.Abs(gravityZ) + threshold)
			{
				if (gravityX > 0)
				{
					return SimpleOrientation.Rotated270DegreesCounterclockwise;
				}

				return SimpleOrientation.Rotated90DegreesCounterclockwise;
			}
			else if (Math.Abs(gravityY) > Math.Abs(gravityX) + threshold && Math.Abs(gravityY) > Math.Abs(gravityZ) + threshold)
			{
				if (gravityY > 0)
				{
					return SimpleOrientation.Rotated180DegreesCounterclockwise;
				}

				return SimpleOrientation.NotRotated;
			}
			else if (Math.Abs(gravityZ) > Math.Abs(gravityY) + threshold && Math.Abs(gravityZ) > Math.Abs(gravityX) + threshold)
			{
				if (gravityZ > 0)
				{
					return SimpleOrientation.Facedown;
				}

				return SimpleOrientation.Faceup;
			}

			return previous;
		}
#endif
	}
}
