// <auto-generated>
#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.DragDrop
{
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__
	[global::Uno.NotImplemented]
#endif
	public partial interface IDropOperationTarget
	{
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__
		global::Windows.Foundation.IAsyncOperation<global::Windows.ApplicationModel.DataTransfer.DataPackageOperation> DropAsync(global::Microsoft.UI.Input.DragDrop.DragInfo dragInfo);
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__
		global::Windows.Foundation.IAsyncOperation<global::Windows.ApplicationModel.DataTransfer.DataPackageOperation> EnterAsync(global::Microsoft.UI.Input.DragDrop.DragInfo dragInfo, global::Microsoft.UI.Input.DragDrop.DragUIOverride dragUIOverride);
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__
		global::Windows.Foundation.IAsyncAction LeaveAsync(global::Microsoft.UI.Input.DragDrop.DragInfo dragInfo);
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__
		global::Windows.Foundation.IAsyncOperation<global::Windows.ApplicationModel.DataTransfer.DataPackageOperation> OverAsync(global::Microsoft.UI.Input.DragDrop.DragInfo dragInfo, global::Microsoft.UI.Input.DragDrop.DragUIOverride dragUIOverride);
#endif
	}
}
