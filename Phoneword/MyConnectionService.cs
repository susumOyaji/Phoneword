using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telecom;
using Android.Util;
using Android.Views;
using Android.Widget;
using Uri = Android.Net.Uri;

namespace Phoneword
{
    class MyConnectionService :ConnectionService
    {
        //private const string TAG = MyConnectionService.class.getName();

        //public override int OnStartCommand(Intent intent, int flags, int startId)
        //{
            //Log.d(TAG, "On Start");
        //    return base.OnStartCommand(intent, flags, startId);
        //}





        public override Connection OnCreateOutgoingConnection(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
        {
            Connection connection = base.OnCreateOutgoingConnection(connectionManagerPhoneAccount, request);
            //Log.d(TAG, connection.getDisconnectCause().getReason());
            return connection;
        }

        public override void OnCreateOutgoingConnectionFailed(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
        {
            if (request != null)
            {
               // Log.d(TAG, request.ToString());
            }
            base.OnCreateOutgoingConnectionFailed(connectionManagerPhoneAccount, request);
        }


        /*
        public override Connection OnCreateIncomingConnection(PhoneAccountHandle, ConnectionRequest)
        {

        }

        public override Connection OnCreateIncomingConnectionFailed(PhoneAccountHandle, ConnectionRequest)
        {

        }
        */
    }

    /*
    public static void registerNewPhoneAccount(Context context, String accountName)
    {
        PhoneAccountHandle accountHandle = createPhoneAccountHandle(context, accountName);

        PhoneAccount phone = PhoneAccount.builder(accountHandle, context.getResources().getString(R.string.app_name))
                .setIcon(Icon.createWithResource(context, R.mipmap.ic_launcher_round))
                .setCapabilities(PhoneAccount.CAPABILITY_CALL_PROVIDER)
                .addSupportedUriScheme(PhoneAccount.SCHEME_SIP)
                .setAddress(Uri.Parse("sip:" + accountName))
                .build();

        TelecomManager telecomManager = (TelecomManager)context.getSystemService(Context.TELECOM_SERVICE);

        telecomManager.registerPhoneAccount(phone);

        // Let the user enable our phone account
        // TODO Show toast so the user knows what is happening
        context.startActivity(new Intent(TelecomManager.ACTION_CHANGE_PHONE_ACCOUNTS));
    }
    */











}