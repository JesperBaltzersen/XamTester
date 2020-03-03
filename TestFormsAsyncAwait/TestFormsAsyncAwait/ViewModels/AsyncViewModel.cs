using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TestFormsAsyncAwait.ViewModels
{
    public class AsyncViewModel : DataStoreViewModel
    {
        public ICommand DontBlockAwaitInsteadOfResultCommand => new Command(DelayFor5Seconds);
        private async void DelayFor5Seconds()
        {
            WriteLine("With Await: Wait 5 seconds");
            await Task.Delay(5000);//.ConfigureAwait(false);
            WriteLine("With Await: Waited 5 seconds");
        }

        public ICommand BlockWithResultCommand => new Command(DelayFor5SecondsDotResult);
        private async void DelayFor5SecondsDotResult()
        {
            WriteLine(".Result: Wait 5 seconds");
            _ = Run5Sec().Result;
            WriteLine(".Result: Waited 5 seconds");
        }

        private Task<bool> Run5Sec()
        {
            Thread.Sleep(5000);
            return Task.FromResult<bool>(true);
        }

        private string _consoleViewText;
        public string ConsoleViewText { get => _consoleViewText ?? ""; set => SetProperty(ref _consoleViewText, value); }

        //public Action MyAction = () => Debug.WriteLine("MyAction");
        //public Action Callingaction => () => DelayFor5SecondsDotResult();

        //private void CalledByAction([CallerMemberName] string CallerName = "")
        //{
        //    Debug.WriteLine($"Method {nameof(CalledByAction)} called by {CallerName}");
        //}

        public Color _color;
        public Color BtnColor { set => SetProperty(ref _color, value); get => _color; }
        public ICommand UpdateInBackgroundCommand => new Command(UpdateInBackgroundAsync);
        private async void UpdateInBackgroundAsync()
        {
            WriteLine("Updating from background with ConfigureAwait(false)");
            await Task.Delay(1000).ConfigureAwait(false);
            try
            {
                if (BtnColor == Color.Green)
                {
                    WriteLine($"Is on MainThread {MainThread.IsMainThread}");
                    BtnColor = Color.Blue;
                    Task.Run(() => ComputeShit());
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        WriteLine($"Is on MainThread {MainThread.IsMainThread}");
                        BtnColor = Color.Green;
                    });
                }
                WriteLine("Updated from background with ConfigureAwait(false)");
            }
            catch (Exception)
            {
                WriteLine("Updating from background thread causes exception");
            }
        }
        private void ComputeShit()
        {
            long j = 0;
            for (int i = 0; i < 99999999; i++)
            {
                j = j + i / 3 + i;
                if ((i % 99000) == 0)
                {
                    WriteLine($"i:{i} OnMainThread: {MainThread.IsMainThread.ToString()}");
                }
            }
            WriteLine("Task.Run: " + MainThread.IsMainThread.ToString());
        }

        private void WriteLine(string newLine)
        {
            ConsoleViewText = newLine + "\n" + ConsoleViewText;
        }

    }
}
