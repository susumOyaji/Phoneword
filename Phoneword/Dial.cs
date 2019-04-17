using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Telecom;
using Android.Views;
using Android.Widget;
using static Java.Text.Normalizer;
using Uri = Android.Net.Uri;





namespace Phoneword
{
    class Dial
    {
        public bool Dials(string phoneNumber)
            {
                var context = Form.Context;

                if (context == null)
                {
                    return false;
                }

                var intent = new Intent(Intent.ActionCall);
                intent.SetData(Uri.Parse("tel:" + phoneNumber));

                if (IsIntentAvailable(context, intent))
                {
                    context.StartActivity(intent);
                    return true;
                }

                return false;
            }


    }
}