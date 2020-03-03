using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
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
            return Task.FromResult<bool> (true);
        }

        private string _consoleViewText;
        public string ConsoleViewText { get => _consoleViewText ?? ""; set => SetProperty(ref _consoleViewText, value); }

        public Action MyAction = () => Debug.WriteLine("MyAction");
        public Action Callingaction => () => DelayFor5SecondsDotResult();

        private void CalledByAction([CallerMemberName] string CallerName = "" )
        {
            Debug.WriteLine($"Method {nameof(CalledByAction)} called by {CallerName}");
        }



        private void WriteLine(string newLine)
        {
            ConsoleViewText = newLine + "\n" + ConsoleViewText;
        }

    }
}
