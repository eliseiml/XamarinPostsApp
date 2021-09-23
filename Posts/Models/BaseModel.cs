
using System.ComponentModel;

namespace Posts.Models
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
