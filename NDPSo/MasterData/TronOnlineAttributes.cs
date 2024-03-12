using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    internal class TronOnlineAttributes
    {
        private bool _IsRunning;
        private bool _WeiEnd;
        private bool _MarkAsSendSetpoint;
        private bool _MarkAsSendSetpointSuccess;
        private bool _HeThongAuto;
        private bool _XaNoiTronAuto;
        private bool _NapLieuAuto;
        private bool _HopperDischarging;
        private bool _HopperDischargingChanged;
        private bool _MixerRunning;
        private bool _MixerRunningChanged;
        private bool _MixerDischarging;
        private bool _MixerDischargingChanged;
        private bool _Mixer50Discharging;
        private bool _Mixer50DischargingChanged;

        internal event TronOnlineAttributes.WeiEventHandler WeiRunningStatusChanged;

        internal bool IsRunning
        {
            get => this._IsRunning;
            set
            {
                if (this._IsRunning != value && this.WeiRunningStatusChanged != null)
                    this.WeiRunningStatusChanged(value);
                this._IsRunning = value;
            }
        }

        internal bool WeiEnd
        {
            get => this._WeiEnd;
            set => this._WeiEnd = value;
        }

        internal bool MarkAsSendSetpoint
        {
            get => this._MarkAsSendSetpoint;
            set => this._MarkAsSendSetpoint = value;
        }

        internal bool MarkAsSendSetpointSuccess
        {
            get => this._MarkAsSendSetpointSuccess;
            set => this._MarkAsSendSetpointSuccess = value;
        }

        private bool HeThongAuto
        {
            get => this._HeThongAuto;
            set => this._HeThongAuto = value;
        }

        private bool XaNoiTronAuto
        {
            get => this._XaNoiTronAuto;
            set => this._XaNoiTronAuto = value;
        }

        private bool NapLieuAuto
        {
            get => this._NapLieuAuto;
            set => this._NapLieuAuto = value;
        }

        internal bool HopperDischarging
        {
            get => this._HopperDischarging;
            set
            {
                if (this._HopperDischarging != value)
                    this._HopperDischargingChanged = true;
                this._HopperDischarging = value;
            }
        }

        private bool HopperDischargingChanged
        {
            get
            {
                bool dischargingChanged = this._HopperDischargingChanged;
                this._HopperDischargingChanged = false;
                return dischargingChanged;
            }
        }

        internal bool MixerRunning
        {
            get => this._MixerRunning;
            set
            {
                if (this._MixerRunning != value)
                    this._MixerRunningChanged = true;
                this._MixerRunning = value;
            }
        }

        internal bool MixerRunningChanged
        {
            get
            {
                bool mixerRunningChanged = this._MixerRunningChanged;
                this._MixerRunningChanged = false;
                return mixerRunningChanged;
            }
        }

        internal bool MixerDischarging
        {
            get => this._MixerDischarging;
            set
            {
                if (this._MixerDischarging != value)
                    this._MixerDischargingChanged = true;
                this._MixerDischarging = value;
            }
        }

        internal bool MixerDischargingChanged
        {
            get
            {
                bool dischargingChanged = this._MixerDischargingChanged;
                this._MixerDischargingChanged = false;
                return dischargingChanged;
            }
        }

        internal bool Mixer50Discharging
        {
            get => this._Mixer50Discharging;
            set
            {
                if (this._Mixer50Discharging != value)
                    this._Mixer50DischargingChanged = true;
                this._Mixer50Discharging = value;
            }
        }

        internal bool Mixer50DischargingChanged
        {
            get
            {
                bool dischargingChanged = this._Mixer50DischargingChanged;
                this._Mixer50DischargingChanged = false;
                return dischargingChanged;
            }
        }

        internal bool CheckConditionForRunning() => this._MarkAsSendSetpoint && this._MarkAsSendSetpointSuccess;

        internal void ResetConditionForRunning()
        {
            this._MarkAsSendSetpoint = false;
            this._MarkAsSendSetpointSuccess = true;
        }

        internal void ResetAttributes()
        {
            this._IsRunning = false;
            this._MarkAsSendSetpoint = false;
            this._MarkAsSendSetpointSuccess = true;
        }

        internal delegate void WeiEventHandler(bool isRunning);
    }
}
