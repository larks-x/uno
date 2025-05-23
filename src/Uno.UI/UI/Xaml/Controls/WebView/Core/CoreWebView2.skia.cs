﻿#nullable enable

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Uno.Foundation.Extensibility;
using Uno.UI.Xaml.Controls;

namespace Microsoft.Web.WebView2.Core;

public partial class CoreWebView2
{
	internal INativeWebView? GetNativeWebViewFromTemplate()
	{
		if (VisualTreeHelper.GetChild((DependencyObject)_owner, 0) is not ContentPresenter { Name: "WebViewTemplateRoot" } contentPresenter)
		{
			return null;
		}

		if (ApiExtensibility.CreateInstance<INativeWebViewProvider>(this, out var nativeWebViewProvider))
		{
			return nativeWebViewProvider.CreateNativeWebView(contentPresenter);
		}

		return null;
	}
}
