using System.ComponentModel;

public class Notifier : INotifyPropertyChanged
{
    // 인터페이스로 구현
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
