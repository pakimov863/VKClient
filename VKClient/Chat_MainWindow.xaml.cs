﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VKClient
{
    /// <summary>
    /// Логика взаимодействия для Chat_MainWindow.xaml
    /// </summary>
    public partial class Chat_MainWindow : UserControl
    {
        public Chat_MessageCollection messages = new Chat_MessageCollection();
        private Storyboard scrollViewerStoryboard;
        private DoubleAnimation scrollViewerScrollToEndAnim;

        private MessageSide curside;

        #region VerticalOffset DP

        /// <summary>
        /// VerticalOffset, a private DP used to animate the scrollviewer
        /// </summary>
        private DependencyProperty VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset",
          typeof(double), typeof(Chat_MainWindow), new PropertyMetadata(0.0, OnVerticalOffsetChanged));

        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Chat_MainWindow app = d as Chat_MainWindow;
            app.OnVerticalOffsetChanged(e);
        }

        private void OnVerticalOffsetChanged(DependencyPropertyChangedEventArgs e)
        {
            ConversationScrollViewer.ScrollToVerticalOffset((double)e.NewValue);
        }

        #endregion

        public Chat_MainWindow()
        {
            InitializeComponent();

            /*// FOLLOWING CODEBLOCK IS ONLY FOR DEMONSTRATION PURPOSES
            messages.Add(new Chat_Message()
            {
                Side = MessageSide.You,
                Text = "Hello sir. How may I help you?"
            });

            curside = MessageSide.You;
            // END OF DEMO BLOCK*/

            this.DataContext = messages;

            scrollViewerScrollToEndAnim = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new SineEase()
            };
            Storyboard.SetTarget(scrollViewerScrollToEndAnim, this);
            Storyboard.SetTargetProperty(scrollViewerScrollToEndAnim, new PropertyPath(VerticalOffsetProperty));

            scrollViewerStoryboard = new Storyboard();
            scrollViewerStoryboard.Children.Add(scrollViewerScrollToEndAnim);
            this.Resources.Add("foo", scrollViewerStoryboard);

            TextInput.Focus();
        }

        private void TextInput_GotFocus(object sender, RoutedEventArgs e)
        {
            ScrollConversationToEnd();
        }

        public void ScrollConversationToEnd()
        {
            scrollViewerScrollToEndAnim.From = ConversationScrollViewer.VerticalOffset;
            scrollViewerScrollToEndAnim.To = ConversationContentContainer.ActualHeight;
            scrollViewerStoryboard.Begin();
        }

        private void TextInput_LostFocus(object sender, RoutedEventArgs e)
        {
            ScrollConversationToEnd();
        }

        public void addTextMe(string text)
        {
            messages.Add(new Chat_Message()
            {
                Side = MessageSide.Me,
                Text = text,
                PrevSide = curside
            });

            curside = MessageSide.Me;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();

            /*// FOLLOWING CODEBLOCK IS ONLY FOR DEMONSTRATION PURPOSES
            // DELETE FOR NORMAL USE!

            addTextYou(text);

            addTextYou(text);

            messages.Add(new Chat_Message()
            {
                Side = MessageSide.Me,
                Text = text,
                PrevSide = curside
            });

            curside = MessageSide.Me;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();

            messages.Add(new Chat_Message()
            {
                Side = MessageSide.Me,
                Text = text,
                PrevSide = curside
            });

            curside = MessageSide.Me;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();

            // END OF DEMO BLOCK*/
        }

        public void addTextMe(string text, DateTime time)
        {
            messages.Add(new Chat_Message()
            {
                Side = MessageSide.Me,
                Text = text,
                PrevSide = curside,
                Timestamp = time
            });

            curside = MessageSide.Me;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();
        }

        public void addTextYou(string text)
        {
            messages.Add(new Chat_Message()
            {
                Side = MessageSide.You,
                Text = text,
                PrevSide = curside
            });

            curside = MessageSide.You;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();
        }

        public void addTextYou(string text, DateTime time)
        {
            messages.Add(new Chat_Message()
            {
                Side = MessageSide.You,
                Text = text,
                PrevSide = curside,
                Timestamp = time
            });

            curside = MessageSide.You;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();
        }
    }
}