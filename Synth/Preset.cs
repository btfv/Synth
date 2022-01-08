using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synth
{
    public class Preset
    {
        public string Title;

        public bool Osc1Enable;

        public bool Osc2Enable;

        public bool FilterEnable;

        public bool DistortEnable;

        public bool TremoloEnable;

        public bool DelayEnable;

        public float Osc1Volume;

        public float Osc2Volume;

        public Synth.Module.SignalType Osc1Waveform;

        public Synth.Module.SignalType Osc2Waveform;

        public Synth.Filter.FilterType FilterType;

        public int Osc1Octave;

        public int Osc2Octave;
        public float Attack;

        public float Decay;

        public float Sustain;

        public float Release;

        public int Cutoff;

        public float Bandwidth;

        public float DistortAmount;

        public float DistortMix;

        public int TremoloFrequency;

        public float TremoloAmplitude;

        public double Delay;
        public float Feedback;
        public float Mix;
        public float Wet;
        public float Dry;

        public Preset(Controller c)
        {
            this.Osc1Enable = c.Osc1Enable;
            this.Osc2Enable = c.Osc2Enable;
            this.FilterEnable = c.FilterEnable;
            this.DistortEnable = c.DistortEnable;
            this.TremoloEnable = c.TremoloEnable;
            this.DelayEnable = c.DelayEnable;
            this.Osc1Volume = c.Osc1Volume;
            this.Osc2Volume = c.Osc2Volume;
            this.Osc1Waveform = c.Osc1Waveform;
            this.Osc2Waveform = c.Osc2Waveform;
            this.FilterType = c.FilterType;
            this.Osc1Octave = c.Osc1Octave;
            this.Osc2Octave = c.Osc2Octave;
            this.Attack = c.Attack;
            this.Decay = c.Decay;
            this.Sustain = c.Sustain;
            this.Release = c.Release;
            this.Cutoff = c.Cutoff;
            this.Bandwidth = c.Bandwidth;
            this.DistortAmount = c.DistortAmount;
            this.DistortMix = c.DistortMix;
            this.TremoloFrequency = c.TremoloFrequency;
            this.TremoloAmplitude = c.TremoloAmplitude;
            this.Delay = c.Delay;
            this.Feedback = c.Feedback;
            this.Delay = c.Delay;
            this.Mix = c.Mix;
            this.Wet = c.Wet;
            this.Dry = c.Dry;
        }

        public Preset() { }
    }
}
