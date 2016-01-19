using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;

namespace NAudio_Test
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitWaves();
        }

        public void InitWaves()
        {
            sineWave.SetWaveFormat(44100, 2);
            sineWave.Frequency = (float)frequency.Value;
            sineWave.Amplitude = .9f;
            sineOut.Init(sineWave);

            //sineWave.Frequency = 440f;
            //sineWave.Amplitude = 8192;
            //sineOut.Init(sineWave);

            sawWave.SetWaveFormat(44000, 2);
            sawWave.Frequency = (float)frequency.Value;
            sawWave.Amplitude = .3f;
            sawOut.Init(sawWave);

            squareWave.SetWaveFormat(44100, 2);
            squareWave.Frequency = (float)frequency.Value;
            squareWave.Amplitude = .3f;
            squareOut.Init(squareWave);

            triangleWave.SetWaveFormat(44000, 2);
            triangleWave.Frequency = (float)frequency.Value;
            triangleWave.Amplitude = 1f;
            triangleOut.Init(triangleWave);
        }

        private WaveOut sineOut = new WaveOut();
        private WaveOut sawOut = new WaveOut();
        private WaveOut triangleOut = new WaveOut();
        private WaveOut squareOut = new WaveOut();

        WavePlayback.SineWaveProvider32 sineWave = new WavePlayback.SineWaveProvider32();
        WavePlayback.SawWaveProvider32 sawWave = new WavePlayback.SawWaveProvider32();
        WavePlayback.SquareWaveProvider32 squareWave = new WavePlayback.SquareWaveProvider32();
        WavePlayback.TriangleWaveProvider32 triangleWave = new WavePlayback.TriangleWaveProvider32();

        float freq;
        bool playing = false;
        string wave = "sine";

        private void button_Click(object sender, RoutedEventArgs e)
        {
            wave = "sine";
        }

        private void sawtooth_Click(object sender, RoutedEventArgs e)
        {
            wave = "saw";
        }

        private void square_Click(object sender, RoutedEventArgs e)
        {
            wave = "square";
        }

        private void triangle_Click(object sender, RoutedEventArgs e)
        {
            wave = "triangle";
        }

        public void PlayWave(double _frequency)
        {
            if (wave == "sine")
            {
                sineWave.Frequency = (float)_frequency;

                if (sineOut.PlaybackState == PlaybackState.Stopped)
                {
                    //sineWave.envelope.Gate(true);
                    sineOut.Play();
                }
                else
                {
                    sineOut.Resume();
                }
            }
            else if (wave == "saw")
            {
                sawWave.Frequency = (float)_frequency;

                if (sawOut.PlaybackState == PlaybackState.Stopped)
                    sawOut.Play();
                else
                    sawOut.Resume();
            }
            else if (wave == "square")
            {
                squareWave.Frequency = (float)_frequency;

                if (squareOut.PlaybackState == PlaybackState.Stopped)
                {
                    squareOut.Play();
                }
                else
                    squareOut.Resume();
            }
            else if (wave == "triangle")
            {
                triangleWave.Frequency = (float)_frequency;

                if (triangleOut.PlaybackState == PlaybackState.Stopped)
                    triangleOut.Play();
                else
                    triangleOut.Resume();
            }
            playing = true;
        }

        public void StopWave()
        {
            //sineWave.envelope.Gate(false);
            sineOut.Stop();
            sawOut.Stop();
            squareOut.Stop();
            triangleOut.Stop();
            playing = false;
        }

        public void PauseWave()
        {
            sineOut.Pause();
            sawOut.Pause();
            squareOut.Pause();
            triangleOut.Pause();
            playing = false;
        }

        public void SetFrequency(float _freq)
        {
            if (wave == "sine")
            {
                sineWave.Frequency = _freq;
            }
            else if (wave == "square")
            {
                squareWave.Frequency = _freq;
            }
            else if (wave == "triangle")
            {
                triangleWave.Frequency = _freq;
            }
            else if (wave == "saw")
            {
                sawWave.Frequency = _freq;
            }
        }

        private void volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sineOut.Volume = (float)volume.Value;
            sawOut.Volume = (float)volume.Value;
            squareOut.Volume = (float)volume.Value;
            triangleOut.Volume = (float)volume.Value;
        }

        private void frequency_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            freq = (float)frequency.Value;
            if (wave != "")
            {
                if (wave == "sine")
                {
                    sineWave.Frequency = freq;
                }
                else if (wave == "square")
                {
                    squareWave.Frequency = freq;
                }
                else if (wave == "triangle")
                {
                    triangleWave.Frequency = freq;
                }
                else if (wave == "saw")
                {
                    sawWave.Frequency = freq;
                }
            }
        }

        private void Stop(object sender, MouseEventArgs e)
        {
            StopWave();
        }

        private void a2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(110.000);
        }

        private void b2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(123.471);
        }

        private void c3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(130.813);
        }

        private void d3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(146.832);
        }

        private void e3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(164.814);
        }

        private void f3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(174.614);
        }

        private void g3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(195.998);
        }

        private void a3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(220.000);
        }

        private void b3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(246.942);
        }

        private void c4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(261.626);
        }

        private void c4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(261.626f);
            }
        }

        private void b3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(246.942f);
            }
        }

        private void a3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(220.000f);
            }
        }

        private void g3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(195.998f);
            }
        }

        private void f3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(174.614f);
            }
        }

        private void e3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(164.814f);
            }
        }

        private void d3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(146.832f);
            }
        }

        private void c3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(130.813f);
            }
        }

        private void b2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(123.471f);
            }
        }

        private void a2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(110.000f);
            }
        }

        private void d4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(293.665);
        }

        private void d4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(293.665f);
            }
        }

        private void e4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(329.628);
        }

        private void e4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(329.628f);
            }
        }

        private void f4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(349.228);
        }

        private void f4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(349.228f);
            }
        }

        private void g4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(391.995);
        }

        private void g4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(391.995f);
            }
        }

        private void a4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(440.000);
        }

        private void a4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(440.000f);
            }
        }

        private void b4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(493.883);
        }

        private void b4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(493.883f);
            }
        }

        private void c5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(523.251);
        }

        private void c5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(523.251f);
            }
        }

        private void d5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(587.330);
        }

        private void d5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(587.330f);
            }
        }

        private void e5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(659.255);
        }

        private void e5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(659.255f);
            }
        }

        private void f5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(698.456);
        }

        private void f5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(698.456f);
            }
        }

        private void g5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(783.991);
        }

        private void g5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(783.991f);
            }
        }

        private void a5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayWave(880.000);
        }

        private void a5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                SetFrequency(880.000f);
            }
        }

        private void freq_test_Click(object sender, RoutedEventArgs e)
        {
            if (!playing)
            {
                PlayWave(frequency.Value);
                squareWave.envelope.Gate(true);
                freq_test.Content = "Stop";
            }
            else
            {
                StopWave();
                squareWave.envelope.Gate(false);
                freq_test.Content = "Play";
            }
        }
    }

}

namespace WavePlayback
{

    public abstract class WaveProvider32 : IWaveProvider
    {
        private WaveFormat waveFormat;

        public WaveProvider32()
            : this(44100, 1)
        {

        }

        public WaveProvider32(int sampleRate, int channels)
        {
            SetWaveFormat(sampleRate, channels);
        }

        public void SetWaveFormat(int sampleRate, int channels)
        {
            this.waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            WaveBuffer waveBuffer = new WaveBuffer(buffer);
            int samplesRequired = count / 4;
            int samplesRead = Read(waveBuffer.FloatBuffer, offset / 4, samplesRequired);
            return samplesRead * 4;
        }

        public abstract int Read(float[] buffer, int offset, int sampleCount);

        public WaveFormat WaveFormat
        {
            get { return waveFormat; }
        }
    }

    class SineWaveOscillator : WaveProvider16
    {
        double phaseAngle;
        public EnvelopeGenerator envelope = new EnvelopeGenerator();

        public SineWaveOscillator(int sampleRate) :
          base(sampleRate, 1)
        {
            envelope.AttackRate = 300;
            envelope.DecayRate = 0;
            envelope.SustainLevel = 1f;
            envelope.ReleaseRate = 300;
        }

        public double Frequency { set; get; }
        public short Amplitude { set; get; }
        public double Pitch { set; get; }

        public override int Read(short[] buffer, int offset, int sampleCount)
        {
            for (int index = 0; index < sampleCount; index++)
            {
                float envelopeAmplitude = envelope.Process();

                buffer[offset + index] = (short)(Amplitude * envelopeAmplitude * Math.Sin(phaseAngle));
                phaseAngle += 2 * Math.PI * Frequency / WaveFormat.SampleRate;

                if (phaseAngle > 2 * Math.PI)
                    phaseAngle -= 2 * Math.PI;
            }
            return sampleCount;
        }
    }

    public class SineWaveProvider32 : WaveProvider32
    {
        double phaseAngle;

        public SineWaveProvider32()
        {
            Frequency = 1000;
            Amplitude = .1f;           
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (float)(Amplitude * Math.Sin(phaseAngle));
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    phaseAngle += 2 * Math.PI * Frequency / sampleRate;
                if (phaseAngle > 2 * Math.PI)
                    phaseAngle -= 2 * Math.PI;
            }
            return sampleCount;
        }
    }

    public class SquareWaveProvider32 : WaveProvider32
    {
        double phaseAngle;
        public EnvelopeGenerator envelope = new EnvelopeGenerator();

        public SquareWaveProvider32()
        {
            Frequency = 1000;
            Amplitude = 0.25f;
            envelope.AttackRate = 44100;
            envelope.DecayRate = 44100;
            envelope.SustainLevel = 0.6f;
            envelope.ReleaseRate = 44100;
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (float)(Amplitude * Math.Sign(Math.Sin(phaseAngle)));
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    phaseAngle += 2 * Math.PI * Frequency / sampleRate;
                if (phaseAngle > 2 * Math.PI)
                    phaseAngle -= 2 * Math.PI;
            }
            return sampleCount;
        }
    }

    public class SawWaveProvider32 : WaveProvider32
    {
        double phaseAngle;

        public SawWaveProvider32()
        {
            Frequency = 1000;
            Amplitude = 0.25f;
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (float)(Amplitude * ((phaseAngle % 1.0) * 2 - 1));
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    phaseAngle += (Frequency / sampleRate);
                //if (phaseAngle > 2 * Math.PI)
                //    phaseAngle -= 2 * Math.PI;
            }
            return sampleCount;
        }
    }

    public class TriangleWaveProvider32 : WaveProvider32
    {
        double phaseAngle;

        public TriangleWaveProvider32()
        {
            Frequency = 1000;
            Amplitude = 1f;
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        //public override int Read(float[] buffer, int offset, int sampleCount)
        //{
        //    int sampleRate = WaveFormat.SampleRate;
        //    for (int n = 0; n < sampleCount; n++)
        //    {
        //        buffer[n + offset] = (float)((1 - Math.Abs((((sample * Frequency) / sampleRate) % 1.0) - 0.5) * 4) * Amplitude);
        //        if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
        //            sample++;
        //        if (sample >= sampleRate) sample = 0;
        //    }
        //    return sampleCount;
        //}
        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (float)(Amplitude * (1 - Math.Abs((phaseAngle % 1.0) - 0.5) * 4));
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    phaseAngle += (Frequency / sampleRate);
                //if (phaseAngle > 2 * Math.PI)
                //    phaseAngle -= 2 * Math.PI;
            }
            return sampleCount;
        }
    }
}
