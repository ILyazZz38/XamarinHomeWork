using WEBclass;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using Hangfire.Annotations;

namespace HW.ViewModels
{
    public class PictureViewModel : INotifyPropertyChanged
    {
        public ICommand loading => new Command(async value => { await LoadData(); });

        private ObservableCollection<Picture> _picture;

        public ObservableCollection<Picture> picture
        {
            get => _picture;
            set
            {
                _picture = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData()
        {
            var client = new HttpClient(GetInsecureHandler());
            var response = await client.GetAsync("http://10.0.2.2:5000/api/Picture/List").ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Picture>>(json);
            picture = list;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}