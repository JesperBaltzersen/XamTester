using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestFormsAsyncAwait.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsyncPage : ContentPage
    {
        public AsyncPage()
        {
            InitializeComponent();
        }
    }
}