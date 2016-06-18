using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VKClient
{
    public class Chat2_ChatBubbleSelector : DataTemplateSelector
    {
        public DataTemplate toBubble { get; set; }
        public DataTemplate fromBubble { get; set; }

        protected DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var message = item as Chat2_Message;
            if (message.tofrom == true)
            {
                return toBubble;
            }
            else
            {
                return fromBubble;
            }
        }
    }
}