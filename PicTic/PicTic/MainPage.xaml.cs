using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;

namespace PicTic
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            FileResult result = await MediaPicker.CapturePhotoAsync(); // Armazena a foto

            if (result != null)
            {
                Stream stream = await result.OpenReadAsync(); // Lê o último arquivo gravado
                imgFoto.Source = ImageSource.FromStream(() => stream); // Mostra a foto
            }
        }

        private async void btnPegar_Clicked(object sender, EventArgs e)
        {
            FileResult result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions // Abre uma caixa de diálogo para selecionar uma foto
            {
                Title = "Escolha uma foto..."
            });

            if (result != null)
            {
                Stream stream = await result.OpenReadAsync();
                imgFoto.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}
