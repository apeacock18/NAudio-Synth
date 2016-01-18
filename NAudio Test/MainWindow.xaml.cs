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

namespace NAudio_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private WaveOut waveOut = new WaveOut();
        private WaveOut waveOutBuffer = new WaveOut();
        WavePlayback.SineWaveOscillator sineWave = new WavePlayback.SineWaveOscillator(44100);
        float freq = 300;
        string wave = "";

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StartStopSineWave();
        }

        private void sawtooth_Click(object sender, RoutedEventArgs e)
        {
            StartStopSawWave();
        }

        private void square_Click(object sender, RoutedEventArgs e)
        {
            StartStopSquareWave();
        }

        private void triangle_Click(object sender, RoutedEventArgs e)
        {
            StartStopTriangleWave();
        }

        private void StartStopSineWave()
        {
            if (wave == "sine")
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                wave = "";
            }
            else
            {
                var sineWave = new WavePlayback.SineWaveProvider32();
                sineWave.SetWaveFormat(44000, 2); // 16kHz mono
                sineWave.Frequency = (float)frequency.Value;
                sineWave.Amplitude = 1f;
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                }
                waveOut = new WaveOut();
                waveOut.Init(sineWave);
                waveOut.Play();
                wave = "sine";
            }
        }

        private void StartStopSawWave()
        {
            if (wave == "saw")
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                wave = "";
            }
            else
            {
                var sawWave = new WavePlayback.SawWaveProvider32();
                sawWave.SetWaveFormat(44000, 2); // 16kHz mono
                sawWave.Frequency = (float)frequency.Value;
                sawWave.Amplitude = 1f;
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                }
                waveOut = new WaveOut();
                waveOut.Init(sawWave);
                waveOut.Play();
                wave = "saw";
            }
        }

        private void StartStopSquareWave()
        {
            if (wave == "square")
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                wave = "";
            }
            else
            {
                var squareWave = new WavePlayback.SquareWaveProvider32();
                squareWave.SetWaveFormat(44000, 2); // 16kHz mono
                squareWave.Frequency = (float)frequency.Value;
                squareWave.Amplitude = 1f;
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                }
                waveOut = new WaveOut();
                waveOut.Init(squareWave);
                waveOut.Play();
                wave = "square";
            }
        }
        private void StartStopTriangleWave()
        {
            if (wave == "triangle")
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                wave = "";
            }
            else
            {
                var triangleWave = new WavePlayback.TriangleWaveProvider32();
                triangleWave.SetWaveFormat(44000, 2); // 16kHz mono
                triangleWave.Frequency = (float)frequency.Value;
                triangleWave.Amplitude = 1f;
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                }
                waveOut = new WaveOut();
                waveOut.Init(triangleWave);
                waveOut.Play();
                wave = "triangle";
            }
        }

        private void volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (waveOut != null)
                waveOut.Volume = (float)volume.Value;
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
                    var squareWave = new WavePlayback.SquareWaveProvider32();
                    squareWave.SetWaveFormat(44000, 2); // 16kHz mono
                    squareWave.Frequency = freq;
                    squareWave.Amplitude = 1f;
                    waveOutBuffer.Dispose();
                    waveOutBuffer = new WaveOut();
                    waveOutBuffer.Init(squareWave);
                    waveOutBuffer.Play();
                    waveOut.Stop();
                    waveOut = waveOutBuffer;
                }
                else if (wave == "triangle")
                {
                    var triangleWave = new WavePlayback.TriangleWaveProvider32();
                    triangleWave.SetWaveFormat(44000, 2); // 16kHz mono
                    triangleWave.Frequency = freq;
                    triangleWave.Amplitude = 1f;
                    waveOutBuffer.Dispose();
                    waveOutBuffer = new WaveOut();
                    waveOutBuffer.Init(triangleWave);
                    waveOutBuffer.Play();
                    waveOut.Stop();
                    waveOut = waveOutBuffer;
                }
                else if (wave == "saw")
                {
                    //var sawWave = new WavePlayback.SawWaveProvider32();
                    //sawWave.SetWaveFormat(44000, 2); // 16kHz mono
                    //sawWave.Frequency = freq;
                    //sawWave.Amplitude = 1f;
                    //waveOut.Stop();
                    //waveOut.Dispose();
                    //waveOut = new WaveOut();
                    //waveOut.Init(sawWave);
                    //waveOut.Play();

                    var sawWave = new WavePlayback.SawWaveProvider32();
                    sawWave.SetWaveFormat(44000, 2); // 16kHz mono
                    sawWave.Frequency = freq;
                    sawWave.Amplitude = 1f;
                    waveOutBuffer.Dispose();
                    waveOutBuffer = new WaveOut();
                    waveOutBuffer.Init(sawWave);
                    waveOutBuffer.Play();
                    waveOut.Stop();
                    waveOut = waveOutBuffer;
                }
            }
        }

        private void a3_Click(object sender, RoutedEventArgs e)
        {

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

        public SineWaveOscillator(int sampleRate) :
          base(sampleRate, 1)
        {
        }

        public double Frequency { set; get; }
        public short Amplitude { set; get; }
        public double Pitch { set; get; }

        public override int Read(short[] buffer, int offset, int sampleCount)
        {
            for (int index = 0; index < sampleCount; index++)
            {
                buffer[offset + index] = (short)(Amplitude * Math.Sin(phaseAngle));
                phaseAngle += 2 * Math.PI * Frequency / WaveFormat.SampleRate;

                if (phaseAngle > 2 * Math.PI)
                    phaseAngle -= 2 * Math.PI;
            }
            return sampleCount;
        }
        public void Play()
        {

        }
    }

    public class SineWaveProvider32 : WaveProvider32
    {
        int sample;

        public SineWaveProvider32()
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
                buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }
    }

    public class SquareWaveProvider32 : WaveProvider32
    {
        int sample = 1;

        public SquareWaveProvider32()
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
                buffer[n + offset] = (float)(Amplitude * Math.Sign(Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate)));
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    sample++;
                if (sample >= sampleRate) sample = 1;
            }
            return sampleCount;
        }
    }

    public class SawWaveProvider32 : WaveProvider32
    {
        int sample = 1;

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
                buffer[n + offset] = (float)(Amplitude * ((((sample * Frequency) / sampleRate) % 1.0) * 2 - 1));
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    sample++;
                if (sample >= sampleRate) sample = 1;
            }
            return sampleCount;
        }
    }

    public class TriangleWaveProvider32 : WaveProvider32
    {
        int sample = 1;

        public TriangleWaveProvider32()
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
                buffer[n + offset] = (float)((1 - Math.Abs((((sample * Frequency) / sampleRate) % 1.0) - 0.5) * 4) * Amplitude);
                if (this.WaveFormat.Channels == 1 || (n + offset) % 2 == 0)
                    sample++;
                if (sample >= sampleRate) sample = 1;
            }
            return sampleCount;
        }
    }
}
