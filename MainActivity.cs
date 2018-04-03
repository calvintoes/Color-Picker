using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace ColorPicker
{
    [Activity(Label = "ColorPicker", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText redEditText, greenEditText, blueEditText;
        SeekBar redBar, greenBar, blueBar;
        TextView hexTextView;
        //Button colorButt;
        Android.Views.View colorView;
        int red, blue, green = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            redEditText = FindViewById<EditText>(Resource.Id.redText);
            blueEditText = FindViewById<EditText>(Resource.Id.blueText);
            greenEditText = FindViewById<EditText>(Resource.Id.greenText);

            redBar = FindViewById<SeekBar>(Resource.Id.redseekBar);
            greenBar = FindViewById<SeekBar>(Resource.Id.greenseekBar);
            blueBar = FindViewById<SeekBar>(Resource.Id.blueseekBar);

            hexTextView = FindViewById<TextView>(Resource.Id.hexText);

            //colorButt = FindViewById<Button>(Resource.Id.colorButton);

            colorView = FindViewById<Android.Views.View>(Resource.Id.colorView);
            colorView.SetBackgroundColor(new Color(0, 0, 0));

            redEditText.TextChanged += RedEditText_TextChanged;
            blueEditText.TextChanged += BlueEditText_TextChanged;
            greenEditText.TextChanged += GreenEditText_TextChanged;

           
            redBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                
                if (e.FromUser)
                {
                    red = e.Progress;
                    redEditText.Text = red.ToString();
                    updateColor();
                }
            };

            blueBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                
                if (e.FromUser)
                {
                    blue = e.Progress;
                    blueEditText.Text = blue.ToString();
                    updateColor();
                    
                }
            };

            greenBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                
                if (e.FromUser)
                {
                    green = e.Progress;
                    greenEditText.Text = green.ToString();
                    updateColor();
                }
            };
            

            //colorButt.Click += ColorButt_Click;

          

           
            

        }
        /*
        // Button that registers the RGB values and displays it to the 'colorView'
        // Button also takes RGB values and converts them to Hex code
        private void ColorButt_Click(object sender, System.EventArgs e)
        {
            int red, blue, green;
            if(int.TryParse(redEditText.Text, out red) &&
                int.TryParse(greenEditText.Text, out green) &&
                    int.TryParse(blueEditText.Text, out blue))
            {

                if (red < 0)
                    red = 0;
                else if (red > 255)
                    red = 255;

                if (blue < 0)
                    blue = 0;
                else if (blue > 255)
                    blue = 255;

                if (green < 0)
                    green = 0;
                else if (green > 255)
                    green = 255;

                redEditText.Text = red.ToString();
                greenEditText.Text = green.ToString();
                blueEditText.Text = blue.ToString();

                hexTextView.Text = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
                colorView.SetBackgroundColor(new Color(red, green, blue));
            }

        }
        */

        private void updateColor()
        {
            colorView.SetBackgroundColor(new Color(red, green, blue));
            hexTextView.Text = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);

        }
        
         
        //Make the _Textchanged actions return a single hexcode because it returns individual values rightnow
        private void GreenEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            
            if (int.TryParse(greenEditText.Text, out green))
            {

                if (green < 0)
                    green = 0;
                else if (green > 255)
                    green = 255;

                updateColor();
            }
        }

        private void BlueEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
           
            if (int.TryParse(blueEditText.Text, out blue))
            {

                if (blue < 0)
                    blue = 0;
                else if (blue > 255)
                    blue = 255;

                updateColor();
            }
        }

        private void RedEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            
            if (int.TryParse(redEditText.Text, out red))
            {

                if (red < 0)
                    red = 0;
                else if (red > 255)
                    red = 255;


                updateColor();



            }
        }
        
    }
}

