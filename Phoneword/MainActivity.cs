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
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }   
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                }

               

                var intent = new Intent(Intent.ActionCall);
                intent.SetData(Uri.Parse("tel:" + translatedNumber));
                StartActivity(intent);

                //ShowInCallScreen(true);

            };
        }
    }
}