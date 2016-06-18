using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VKClient
{
    /// <summary>
    /// Логика взаимодействия для Chat2_MainPage.xaml
    /// </summary>
    public partial class Chat2_MainPage : UserControl
    {
        ObservableCollection<Chat2_Message> allmessages;
        public Chat2_MainPage()
        {
            InitializeComponent();

            allmessages = new ObservableCollection<Chat2_Message>();
            allmessages.Add(new Chat2_Message { TextMessage = "Hello Rita,how are you?", Time = DateTime.Now.ToString(), Status = "Sent", tofrom = true });
            allmessages.Add(new Chat2_Message { TextMessage = "Hello Raj,I am fine.Wbu?", Time = DateTime.Now.ToString(), Status = "Sent", tofrom = false });
            allmessages.Add(new Chat2_Message { TextMessage = "Everything is great at my end.Where are you?I heard it's so cold out there.Are you coming to India soon?", Time = DateTime.Now.ToString(), Status = "Sent", tofrom = true });
            allmessages.Add(new Chat2_Message { TextMessage = "I'm in Australia these days", Time = DateTime.Now.ToString(), Status = "Sent", tofrom = false });
            allmessages.Add(new Chat2_Message { TextMessage = "Great!", Time = DateTime.Now.ToString(), Status = "Sent", tofrom = true });
            allmessages.Add(new Chat2_Message { TextMessage = "I am leaving my hometown in 2-3 days", Time = DateTime.Now.ToString(), Status = "Failed", tofrom = true });

            myChat.ItemsSource = allmessages;
            System.Diagnostics.Debug.WriteLine(allmessages.Count);
            //this.myChat.DataContext = allmessages;

            //setting colors of various controls
            //Color colord = (Color)Application.Current.Resources["PhoneAccentBrush"];
            
            //System.Diagnostics.Debug.WriteLine(strHexa);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void meClick_Click(object sender, RoutedEventArgs e)
        {
            allmessages.Add(new Chat2_Message { TextMessage = "This is an extra ME bubble", Time = DateTime.Now.ToString(), Status = "Sent", tofrom = true });
        }

        private void youClick_Click(object sender, RoutedEventArgs e)
        {
            allmessages.Add(new Chat2_Message { TextMessage = "This is an extra YOU bubble", Time = DateTime.Now.ToString(), Status = "Sent", tofrom = false });
        }
    }
}
