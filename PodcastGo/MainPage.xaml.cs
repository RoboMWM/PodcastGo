using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PodcastGo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageFile file;
        public MainPage()
        {
            this.InitializeComponent();
            mediaPlayerElement.TransportControls.IsCompact = true;
            mediaPlayerElement.TransportControls.IsFullWindowButtonVisible = false;
            mediaPlayerElement.TransportControls.IsZoomButtonVisible = false;
        }

        private async void FilePickerButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
            openPicker.FileTypeFilter.Add(".aac");
            openPicker.FileTypeFilter.Add(".wma");
            openPicker.FileTypeFilter.Add(".ogg");
            openPicker.FileTypeFilter.Add(".flac");
            file = await openPicker.PickSingleFileAsync();

            if (file == null) //TODO: logic to stop player
            {
                return;
            }

            fileNameBlock.Text = file.DisplayName;

            mediaPlayerElement.Source = MediaSource.CreateFromStorageFile(file);
            mediaPlayerElement.MediaPlayer.AudioCategory = MediaPlayerAudioCategory.Media;
        }
    }
}
