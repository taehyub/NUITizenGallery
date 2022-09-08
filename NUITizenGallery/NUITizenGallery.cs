using System;
using System.Linq;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Reflection;

namespace NUITizenGallery
{
    class Program : NUIApplication
    {
        private Window window;
        private Navigator navigator;
        private Page currentExample = null;
        private ContentPage page;
        private Page firstPage = null;
        private Page firstPage2 = null;

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace")
                {
                    currentExample = navigator.Peek();

                    if (firstPage == currentExample)
                        Exit();   
                    else
                        currentExample = navigator.Pop();
                }
            }
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            SetMainPage();
        }
        private void Initialize()
        {
            window = GetDefaultWindow();
            window.Title = "NUITizenGallery";
            window.KeyEvent += OnKeyEvent;

            navigator = window.GetDefaultNavigator();
        }

        private void SetMainPage()
        {
            firstPage = new HelloWorldPage();
            currentExample = firstPage;
            firstPage2 = new HelloWorldPage();
            currentExample = firstPage2;
            navigator.Push(firstPage);
            navigator.Push(firstPage2);
        }

        private void ExitSample()
        {
            currentExample = navigator.Pop();
            FullGC();
        }

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
