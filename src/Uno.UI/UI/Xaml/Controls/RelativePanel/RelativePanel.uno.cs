﻿using Windows.Foundation;

#if __ANDROID__
using View = Android.Views.View;
#elif __APPLE_UIKIT__
using View = UIKit.UIView;
#else
using View = Microsoft.UI.Xaml.UIElement;
#endif

namespace Microsoft.UI.Xaml.Controls;

public partial class RelativePanel : Panel
{
	internal Size GetChildDesiredSize(View view) => GetElementDesiredSize(view);

	internal Size MeasureChild(View view, Size availableSize) => MeasureElement(view, availableSize);

	internal void ArrangeChild(View view, Rect finalRect) => ArrangeElement(view, finalRect);
}
