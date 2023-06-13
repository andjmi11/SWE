namespace Elfind.Data
{
    public class MainLayoutState
    {
        string currentPic;
        public string CurrentPic
        {
            get => currentPic;
            set
            {
                if (currentPic == value) return;
                currentPic = value;
                CurrentPicChanged?.Invoke(this, value);
            }
        }
        public event EventHandler<string> CurrentPicChanged;
    }
}
