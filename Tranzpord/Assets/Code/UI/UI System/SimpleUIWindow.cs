public abstract class SimpleWindow<T> : UIWindow<T> where T : SimpleWindow<T>
{
    public void Show()
    {
        Open();
    }

    public void Hide()
    {
        Close();
    }
}