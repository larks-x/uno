﻿#nullable enable

#if !__WASM__ && !__APPLE_UIKIT__ && !__ANDROID__ && !__SKIA__

using System;

namespace Windows.ApplicationModel.DataTransfer
{
	public partial class DataTransferManager
	{
		private DataTransferManager()
		{
		}

		public static bool IsSupported() => false;

		public static DataTransferManager GetForCurrentView() => throw new NotSupportedException("DataTransferManager is not yet supported on this platform.");
	}
}
#endif
