using BlazorBootstrap;

namespace AI.Client.GateWay.Services
{
    public class ToastService
    {
        public event Action<string, ToastType>? OnShow;
        public event Action? OnHide;

        public void ShowToast(string message, ToastType type)
        {
            OnShow?.Invoke(message, type);
        }

        public void HideToast()
        {
            OnHide?.Invoke();
        }
    }

    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }
}
