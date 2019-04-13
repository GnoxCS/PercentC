using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace PercentC
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", Icon = "@mipmap/percentico1", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //Widgets;
            var involvedview = FindViewById<TextView>(Resource.Id.involvedView);
            var successedview = FindViewById<TextView>(Resource.Id.successedView);
            var btnCalc = FindViewById<Button>(Resource.Id.btnCalc);
            btnCalc.Click += Calculate_Click;

        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                var successedtext = FindViewById<EditText>(Resource.Id.successedText);
                var involvedtext = FindViewById<EditText>(Resource.Id.involvedText);
                double involved = double.Parse(involvedtext.Text);
                double successed = double.Parse(successedtext.Text);

                double sum = successed * 100 / involved;
                Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("النتيجة");
                alertDialog.SetMessage($"نسبة النجاح هي : {sum:F3}%");
                alertDialog.SetNeutralButton("موافق", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
            }
            catch
            {
                Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("خطأ");
                alertDialog.SetMessage("القيم المُدخلة غير صحيحة");
                alertDialog.SetNeutralButton("موافق", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

