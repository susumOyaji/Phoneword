using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Net;//.Uri;
using Android.Content;
using Android.Telephony;

using Java.Util;
using Uri = Android.Net.Uri;
using Android.Telecom;
using Android.Views;
using Android.Views.InputMethods;

namespace Phoneword
{
    [Activity(Label = "Phone Word", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our UI controls from the loaded layout
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);

            // Add code to translate number
            string translatedNumber = string.Empty;

            translateButton.Click += (sender, e) =>
            {
                // Translate user’s alphanumeric phone number to numeric
                translatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);


                MyConnectionService myConnectionService = new MyConnectionService();

                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                }


                // myConnectionService.PerformDial("1234567890");


                //var intent = new Intent(Intent.ActionCall);
                //intent.SetData(Uri.Parse("tel:" + translatedNumber));
                //StartActivity(intent);

                //ShowInCallScreen(true);

            };

            protected override void OnStart()
            {
                base.OnStart();
                OfferReplacingDefaultDialer();

                translatedNumber.SstOnEditorActionListener += (send,e) => {
                    PerformDial1(translatedNumber);
                    return true;
                };

            }

            EditText editText = FindViewById<EditText>(Resource.Id.search);
            editText.EditorAction += HandleEditorAction;  

            // Add this method to your class
            private void HandleEditorAction(object sender, TextView.EditorActionEventArgs e)
            {
                e.Handled = false;
                if (e.ActionId == ImeAction.Send)
                {
                    SendMessage();
                    e.Handled = true;
                }
        }



        public void PerformDial1(string translatedNumber)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + translatedNumber));
            StartActivity(intent);
        }

        /*
        public override void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults)
        {
            ArrayList<Integer> grantRes = new ArrayList<>();
            // Add every result to the array
            for (Integer grantResult: grantResults) grantRes.add(grantResult);

            if (requestCode == REQUEST_PERMISSION && grantRes.contains(PERMISSION_GRANTED))
            {
                makeCall();
            }
        }
        */
        private void OfferReplacingDefaultDialer()
        {
           // TelecomManager systemService = this.GetSystemService(TelecomManager.class);
           //     if (systemService != null && !systemService.getDefaultDialerPackage().equals(this.getPackageName())) {
           // startActivity((new Intent(ACTION_CHANGE_DEFAULT_DIALER)).putExtra(EXTRA_CHANGE_DEFAULT_DIALER_PACKAGE_NAME, this.getPackageName()));
            }
    }
}



    






