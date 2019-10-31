using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace _8_ControlsPersonalitzats_Shapes.View
{
    public sealed partial class Velocimetre : UserControl
    {
        public Velocimetre()
        {
            this.InitializeComponent();
        }

        #region Propietats



        public double Velocitat
        {
            get { return (double)GetValue(VelocitatProperty); }
            set { SetValue(VelocitatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Velocitat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VelocitatProperty =
            DependencyProperty.Register("Velocitat", typeof(double), typeof(Velocimetre),
                new PropertyMetadata(0, VelocitatChangedCallback));

        private static void VelocitatChangedCallback(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            Velocimetre v = (Velocimetre)d;

            if (v.Velocitat > v.Max)
            {
                v.Velocitat = v.Max;
            } else if(v.Velocitat<0)
            {
                v.Velocitat = 0;
            }
            if (v.Max > 0)
            {
                double angle = v.getAnglePerVelocitat(v.Velocitat);
                ((RotateTransform)v.cnvAgulla.RenderTransform).Angle = angle;
            }



        }

        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(double), typeof(Velocimetre), 
                new PropertyMetadata(100.0, MaxChangedCallback));

        private static void MaxChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            Velocimetre v = (Velocimetre)d;
            int numeroTicks = 10;
            double deltaVelocitat = v.Max / (double)numeroTicks;
            double vel = 0;
            for (int i = 0; i <= numeroTicks; i++, vel+=deltaVelocitat)
            {
                v.cnvPrincipal.Children.Add(v.crearTick((int)vel));
            }

        }



        #endregion

        private double getAnglePerVelocitat(double velocitat)
        {
            return  320 * velocitat / Max;
        }


        private StackPanel crearTick(int velocitat)
        {
            /*
        <StackPanel Canvas.Left="45" Width="10">
            <StackPanel.RenderTransform>
                <RotateTransform Angle="45" CenterX="5" CenterY="50" ></RotateTransform>
            </StackPanel.RenderTransform>
            <Rectangle Width="3" Height="10" Fill="Black"></Rectangle>
            <TextBlock  FontSize="6" Height="10" VerticalAlignment="Center" TextAlignment="Center" >56
                <TextBlock.RenderTransform>
                    <RotateTransform Angle="-45" CenterX="5" CenterY="5"></RotateTransform>
                </TextBlock.RenderTransform>
            </TextBlock>
        </StackPanel>             
             */

            double angle = getAnglePerVelocitat(velocitat);

            StackPanel stp = new StackPanel();
            stp.Width = 10;
            Canvas.SetLeft(stp, 45);
            RotateTransform rt = new RotateTransform();
            rt.Angle = angle;
            rt.CenterX = 5;
            rt.CenterY = 50;
            stp.RenderTransform = rt;

            Rectangle r = new Rectangle();
            r.Width  = 3;
            r.Height = 10;
            r.Fill = new SolidColorBrush(Colors.Black);

            TextBlock tb = new TextBlock();
            tb.FontSize=6;
            tb.Height = 10;
            tb.Text = velocitat + "";
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.TextAlignment = TextAlignment.Center;

            RotateTransform rtt = new RotateTransform();
            rtt.Angle = -angle;
            rtt.CenterX = 5;
            rtt.CenterY = 5;
            tb.RenderTransform = rtt;


            stp.Children.Add(r);
            stp.Children.Add(tb);


            return stp;
        }



    }
}
