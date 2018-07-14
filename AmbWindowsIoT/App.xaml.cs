using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AmbWindowsIoTSDK;
using AmbWindowsIoTSDK.Model.Event;
using Newtonsoft.Json.Linq;

namespace AmbWindowsIoT
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            var sdk = new AmbrosusSdk(new AmbrosusSettings
            {
                ApiEndpoint = "https://gateway-test.ambrosus.com",
                Address = "0x1B59bF08472C601c638eF710b3af625a3238C1c0",
                Secret = "0xcdde30d1c7e4e047a192098bc3aaff24e1519595a22161726df0fe22ab5f1467"



            });
            var nodeinfo = sdk.GetNodeInfo();
            //var data2 = sdk.GetAssetById("0x0fa1c2b80d6ecdfbad74b0b178c9a654e19f9caf1e02b6e1309f63f11aa408e6");
            //var data = sdk.CreateAsset();
            //var events = sdk.GetEvents(new EventOptions
            //{
            //    AssetId = "0x9d906df5f69a7a9fa416dd0742994d93d65bc70b2073e2fe43fd3f833802632f",
            //    PerPage = 1
            //});

            //var createdEvent = sdk.CreateEvent("0x9d906df5f69a7a9fa416dd0742994d93d65bc70b2073e2fe43fd3f833802632f",
            //    new List<Datum>
            //    {
            //        new Datum
            //        {
            //            Type = EventType.Temperature.Value,
            //            AdditionalData = new Dictionary<string, JToken>
            //            {
            //                {"temperature", "15 C"},
            //                {"greetings", "yo" }
            //            }
            //        },
            //        new Datum
            //        {
            //            Type = EventType.AssetLocation.Value,
            //            AdditionalData = new Dictionary<string, JToken>
            //            {
            //                {"location", "dsadsa"},
            //                {"ant", "vv" }
            //            }
            //        }
            //    });
            //var event1 = sdk.GetEventById("0xd00331d81e6e4285950eb7b9c6549e99c569be2da26f9815b3b367bb09eb90ca");

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
