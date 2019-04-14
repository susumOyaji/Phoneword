using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Core;
using Android.Net;//.Uri;
using Android.Content;
using Android.Telephony;

using Java.Util;

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

                // If permission to call is granted
                if (CheckSelfPermission(CALL_PHONE) == PERMISSION_GRANTED)
                {

                    var intent = new Intent(Intent.ActionCall);
                    // Create the Uri from phoneNumberInput
                    intent.SetData(Uri.Parse("tel:" + translatedNumber));
                    // Start call to the number in input
                    StartActivity(intent);
                }
                else
                {
                    // Request permission to call
                    ActivityCompat.requestPermissions(this, new String[] { CALL_PHONE }, REQUEST_PERMISSION);
                }

                var intent1 = new Intent(Intent.ActionCall);
                intent1.SetData(Uri.Parse("tel:" + translatedNumber));
                StartActivity(intent1);



            };
        }
    }
}